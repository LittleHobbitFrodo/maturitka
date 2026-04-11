# 09 Bash skriptování

# Obsah

1. [09 Bash skriptování](#09-bash-skriptování)

   1. [Shell a Bash](#shell-a-bash)
      1. [Co je shell a k čemu slouží](#co-je-shell-a-k-čemu-slouží)
      2. [Co je Bash?](#co-je-bash)
      3. [Různé shelly – rozdíly](#různé-shelly--rozdíly)
      4. [Práce se shelly](#práce-se-shelly)
      5. [Tvorba a spouštění skriptů](#tvorba-a-spouštění-skriptů)
      6. [Spuštění skriptu](#spuštění-skriptu)

   2. [Proměnné](#proměnné)
      1. [Práce s proměnnými](#práce-s-proměnnými)
      2. [Environment proměnné](#environment-proměnné)

   3. [Uživatelský vstup](#uživatelský-vstup)
      1. [Argumenty skriptu](#argumenty-skriptu)
      2. [Interaktivní vstup read](#interaktivní-vstup-read)

   4. [Podmínky](#podmínky)
      1. [if](#if)
         1. [Číselné operátory](#číselné-operátory)
         2. [Textové operátory](#textové-operátory)
         3. [Souborové operátory](#souborové-operátory)

   5. [Cykly](#cykly)
      1. [while](#while)
      2. [for](#for)

   6. [Funkce](#funkce)
      1. [Deklarace](#deklarace)
      2. [Volání funkce](#volání-funkce)
      3. [Parametry funkce](#parametry-funkce)

   7. [Návratové hodnoty](#návratové-hodnoty)

   8. [Logické operátory a řetězení](#logické-operátory-a-řetězení)
      1. [&& - AND](#--and)
      2. [|| - OR](#--or)
      3. [; - Středník](#--středník)

   9. [Další dovednosti](#další-dovednosti)
      1. [Práce se soubory](#práce-se-soubory)
         1. [> - Přepsání obsahu](#---přepsání-obsahu)
         2. [>> - Přidání na konec](#---přidání-na-konec)
         3. [Čtení souboru](#čtení-souboru)

   10. [Aritmetika](#aritmetika)
       1. [$(( ))](#--)
       2. [let - Při deklaraci](#let---při-deklaraci)

   11. [$() - Command substitution](#--command-substitution)


# Shell a Bash
## Co je shell a k čemu slouží
**Shell**: Program, který umožňuje komunikaci s operačním systémem
- Přijímá příkazy od uživatele
- Předává je jádru (kernelu)
- Vypisuje výstup

## Co je Bash?

**Bash** (**B**ourne **A**gain **S**hell) je konkrétní shell
- Nejpoužívanější na Linuxu
- Rozšíření staršího shellu `sh`

**podporuje**
- Skriptování
- Proměnné
- Podmínky
- Cykly

## Různé shelly – rozdíly

**Bash**
- Standard na většině systémů
- Stabilní, široce podporovaný

**Zsh**
- Bash compatible
    - Modernější
- Lepší:
  - Autocomplete
  - Pluginy
- Často používaný dnes (např. macOS default)

**Fish** - **F**riendly **I**nteractive **SH**ell
- Velmi uživatelsky přívětivý
- Barevný, intuitivní
- Méně kompatibilní se skripty
  - Vlastní skriptování


**Dash**
- Velmi rychlý a jednoduchý
- Používá se pro systémové skripty
- Méně funkcí

## Práce se shelly

**Dostupné shelly**: V `/etc/shells`
- `cat /etc/shells`

**Aktuální shell**: V `$SHELL` proměnné
- `echo $SHELL`

**Změna shellu**: `chsh -s <cesta k shellu>`

## Tvorba a spouštění skriptů

**Shebang**: `#!/bin/bash`
- Ukazuje na interpretter (shell)
- "Tento skript spouští bash"

**Nastavení oprávnění pro spuštění**: `chmod +x script.sh`


## Spuštění skriptu:

Spuštění pomocí `./skript.sh`  
Spuštění pomocí `bash skript.sh`

---

# Proměnné

## Práce s proměnnými
**Deklarace**: `jmeno="Jan"`
- Syntax: `<nazev>=<hodnota>`
  - Invalidní: `jmeno = "Jan"`


**Čtení proměnných** (`$`): `echo $jmeno`
- Probíhá textová substituce
  - `echo $jmeno` => `echo "Jan"`

**Použití ve stringu**: `echo "Ahoj, jmenuji se $jmeno"`
- Textová substituce: ... => `echo "Ahoj, jmenuji se Jan"`


**Konvence pojmenování**: Často VELKÁ PÍSMENA
- Hlavně u systémových
- Pravidla:
  - Bez mezer
  - Nezačínat číslem

## Environment proměnné

Nastavené systémem

```bash
echo $HOME   # domovský adresář => /home/student
echo $USER   # uživatel => student
echo $PWD    # aktuální složka
echo $PATH   # cesty k programům (oddělené : )
echo $SHELL  # aktuální shell
```

**Návratový kód**: `$?`
- Obsahuje návratový kód posledního programu
  - `0` pro úspěch

---

# Uživatelský vstup

## Argumenty skriptu

`./skript.sh Ahoj 123`
- ```bash
  echo $0   # ./skript.sh (název skriptu)
  echo $1   # Ahoj
  echo $2   # 123
  echo $@   # "Ahoj" "123" (všechny argumenty (oddělené))
  echo $*   # "Ahoj 123" (všechny argumenty dohromady)
  ```

## Interaktivní vstup (`read`)

```bash
read jmeno  # Vytvoří proměnnou $jmeno
echo $jmeno
```

# Podmínky
## `if`

```bash
if [ podmínka ]; then
    příkazy
else
    příkazy
fi
```
- Více podmínek pomocí `elif`

### Číselné operátory

```bash
if [ $a -gt $b ]; then
    echo "a je větší"
fi
```

| operátor | význam |
| -------- | ------ |
| `-eq` | == |
| `-ne` | != |
| `-gt` | > |
| `-lt` | < |
| `-ge` | ≥ |
| `-le` | ≤ |

### Textové operátory

```bash
if [ "$jmeno" == "Jan" ]; then
    echo "Ahoj Jane"
fi
```
- Vždy raději do uvozovek

| operátor | význam |
| -------- | ------ |
| `==` | rovno |
| `!=` | nerovno |
| `-z` | prázdný string |
| `-n` | neprázdný |


### Souborové operátory

```bash
if [ -f "test.txt" ]; then
    echo "Soubor existuje"
fi
```


| operátor | význam |
| -------- | ------ |
| `-e` | existuje |
| `-f` | je soubor |
| `-d` | je adresář |
| `-r` | lze číst |
| `-w` | lze zapisovat |
| `-x` | lze spustit |


---

# Cykly
## `while`

Opakuje se dokud platí podmínka

```bash
while [ podmínka ]; do
    příkazy
done
```

## `for`

```bash
for jmeno in Jan Petr Pavel; do
    echo $jmeno
done
```

```bash
for soubor in *.txt; do
    echo $soubor
done
```
- Projde všechny `.txt` soubory

---

## Funkce

### Deklarace
```bash
pozdrav() {
    echo "Ahoj"
}
```

### Volání funkce

Jako klasický příkaz: `pozdrav`

### Parametry funkce

Jako u příkazu:
```bash
pozdrav() {
    echo "Ahoj $1"
}

pozdrav Jan
```

---

# Návratové hodnoty

`0` = úspěch  
`!= 0` = chyba

**Nastavení návratového kódu**: `exit 1`
- Nastaví exitkód na `1`

**Zjištění návratového kódu**: `echo $?`

---

# Logické operátory a řetězení

## `&&` - AND
Další příkaz se spustí **jen při úspěchu**

```bash
mkdir test && cd test
```

## `||` - OR
Spustí se **při chybě**

```bash
cd neexistuje || echo "Chyba"
```

## `;` - Středník
Spustí další příkaz **bez ohledu** na exitkód

```bash
echo -n "Ahoj"; echo "světe"
```

---

# Další dovednosti
**Komentáře**: `# Toto je komentář`

## Práce se soubory

### `>` - Přepsání obsahu
```bash
echo "Ahoj" > soubor.txt
```

### `>>` - Přidání na konec

```bash
echo "Další řádek" >> soubor.txt
```

### Čtení souboru

```bash
cat soubor.txt
# nebo
while read radek; do
    echo $radek
done < soubor.txt
```

## Aritmetika
### `$(( ))`
```bash
a=5
b=3
echo $((a + b))
```

### `let` - Při deklaraci
```bash
let a=5+3
echo $a
```

## `$()` - Command substitution
Výstup příkazu do proměnné

```bash
datum=$(date)
echo $datum
```
