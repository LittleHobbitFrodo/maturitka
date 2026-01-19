
# Zaklady prace v terminalovem prostredi

## Základní znalost
- **Spuštění** commandu: napsat command a Enter
	- Na pozadí: `<command> &`
		
- **Přerušení**/pozastavení: `ctrl + Z` (SIGSTP)
	- `jobs`: vypíše všechny pozastavené tasky
	- `fg %X`: spustí task X na popředí
	- `bg %X`: spustí task X na pozadí
		
- **Ukončení**: `ctrl + C` (SIGINT)

- Zkratky
	- `↑/↓`: historie příkazů
	- `!!`: poslední command znovu

---

## Terminologie
- **Terminál** - rozhrani pro textovy vystup (obecne)
  - Prenasi 
	- **Emulátor** - emuluje chovani starych terminalu
	- `gnome-terminal`, `konsole`, `xterm`, ...

- **Shell** - program cte prikazy od uzivatele, interpretuje je
	- `bash`, `zsh`, `fish`, ...

- **Bash** - **B**ourne **A**gain **SH**ell
	- Nejčastější defaultní shell v linuxu
	- shell, skriptovací jazyk, interpret příkazů
- **TTY** - **T**ele**TY**pewriter
	- dnes: zarizeni pro textovou komunikaci
		
---

## Práce s programy
- **Parametry**: S cím má program pracovat
- **Přepínače**: Jak se má program choavt - začínají pomlčkou
	- Krátké: `-l`, nebo `-abcd ...`
	- Dlouhé: `--switch`
	- S hodnotou: `--switch value` nebo někdy `--switch=value`
- **Nápovědy**: `<program> --help` nebo `man <program>`

### Manpages
`man <program>`
**Struktura**
1. **NAME** - `ls - list directory contents`
2. **SYNOPSIS** - `ls [OPTION]... [FILE]...`
	- `[]`: Volitelné
	- `...`: Může se opakovat
3. **DESCRIPTION**: Popis chování programu
4. **OPTIONS**: Popis jednotlivých přepínačů
5. **EXAMPLES**: Příklady použití
6. **EXIT STATUS**: návratné kódy
7. **SEE ALSO**: Reference

---

## Čísla manuálu
- **1**: Uživatelské příkazy
- **2**: Syscally
- **3**: Funkce knihoven
- **5**: Konfigurační soubory
- **8**: Admin nástroje

---

## STDIO a STDERR
- **3 streamy**:

| Číslo | Název                     | Zkratka  | Význam            |
| ----- | ------------------------- | -------- | ----------------- |
| 0     | Standardní vstup          | `stdin`  | odkud program čte |
| 1     | Standardní výstup         | `stdout` | běžný výstup      |
| 2     | Standardní chybový výstup | `stderr` | chybová hlášení   |

Běžně:
- `stdin`: klávesnice
- `stdout`: terminál
- `stderr`: terminál

### Směrování
- **Do souboru**: `echo "řádek" > soubor.txt`
  - **Append**: `echo "druhej rádek" >> soubor.txt`
- **Soubor jako stdin**: `cat soubor.txt | wc -l` nebo `wc -l < soubor.txt`
- **Přesměrování sterr**: `ls neexistuje 2> error.txt`
  - I stdout: `ls neexistuje >/dev/null 2>&1`
- **Umlčení**: Přesměrovat do `/dev/null`
- **Propojení**: `cmd1 | cmd2 | cmd3`

---

## Logické operátory
- Provedení příkazů v závislosti na exit kódu
1. **`&&`** - Při úspěchu
    - `cmd1 && cmd2` - `cmd2` jenom když `cmd1` uspěje
2. **`||`&& - Při neúspěchu
    - `cmd1 || cmd2` - `cmd2` jenom když `cmd1` selže
3. **`;`** - exitkód se ignoruje - oddělení příkazů

- Exitkódy
  - **`0`** => úspěch
  - **`_`** => neúspěch

---

## Práce se soubory/adresari
- **Vytvorit**: `touch soubor.txt` - `mkdir directory`
- **Smazat**: `rm soubor.txt` - `rmdir directory`
  - `rm -r` - rekurzivně
- **Vypisování**: `ls` - `ls -a` vypíše i skryté
- **Kopírování**: `cp` - `cp -R` (rekurzivně)
- **Přesouvání/přejmenování**: `mv file.txt dir/file.txt`/`mv old.txt new.txt`

### Cesty
- Absolutní: `/home/user/file.txt`
- Realtivní: `./file.txt`

### Zkratky
- **Home** => `~` (vlnovka)
- **Přechozí** (kde jsi byl před posledním `cd`) => `-` (pomlčka)
- **Úrověň výš** (`/home` => `/`) => `..`
- **Aktuální adresář** => `.`

---

## Prohlížení obsahu souborů
- **Celý soubor**: `cat`
- **Stránkování**: `less`/`more`
- **Začátek**: `head` (`head -n 5` => 5 řádků)
- **Konec**: `tail` ...
  - **V reálném čase**: `tail -f`

---

## Editace souborů
### `vim`
- `vim ./soubor.txt`
- **Módy**
  - **Normal** (default) - `esc`
  - **I**nsert (`i`)
    - `I` => editace + skok na začátek řádku
    - `o` => editace na novém řádku
  - **Command** mode - `:`
    - `:w` uložit
    - `:q` ukončit

---

## Vyhledávání
- `find` souborů podle:
  - **Názvu** - `find <path> -name <name>`
  - **Typu** - `find <path> -type f/d`
  - **Velikosti** - `find <path> -size +100M` - > 100MB
    - `-size -1K` - < 1KB
  - **Času**:
    - `find <path> -mtime -1` - **změněné** za poslední den
    - `find <path> -atime 7` **přístup** za poslední týden
    - `find <path> -ctime -3` **změna práv** za poslední 3 dny

- `grep` - v souborech:
  - `grep "text" soubor.txt` - najde `"text"` v souboru.txt
  - `grep -r "text" <path>` - rekurzivně ve složce (obsah souborů)
  - `-i` bez ohledu na velikosti písmen
  - `-n` čísla řádků
  - `-v` řádky, které neobsahují

- Indexovaná databáze
  - `locate soubor.txt`
  - `sudo updatedb`

### Wildcards
- `*` - Výběr libovolného počtu znaků
  - `*.txt` - Všechny soubory končící `.txt`
  - `a*` - Všechny soubory začínající `a`
- `?` - Jeden znak
- `[]` - Množina znaků
  - `[a-z]` - Všechny písmena od `a` do `z`
  - `[123]` - Písmena `1`, `2`, `3`
- `{}` - Kombinace
  - `echo soubor{1,2,3}.txt` => `soubor1.txt soubor2.txt soubor3.txt`
  - **Rozsah** - `echo soubor{1..4}` => `soubor1 soubor2 soubor3 soubor4`

