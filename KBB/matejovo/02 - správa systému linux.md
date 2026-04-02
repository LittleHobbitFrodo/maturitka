# Správa systému Linux

1. [Uživatelé a oprávnění](#uživatelé-a-oprávnění)
    2. [Vyhledání nastavených oprávnění](#vyhledání-nastavených-oprávnění)
2. [Změna oprávnění](#změna-oprávnění)
3. [Speciální oprávnění](#speciální-oprávnění)
4. [Vytvořrní uživatele](#vytvořrní-uživatele)
5. [Změna hesla](#změna-hesla)
6. [Editace uživatele](#editace-uživatele)
7. [Zamknutí účtu](#zamknutí-účtu)
8. [Odebrání uživatele](#odebrání-uživatele)
9. [Změna vlastníka souboru](#změna-vlastníka-souboru)
10. [Informace o uživatelích](#informace-o-uživatelích)
    1. [`/etc/passwd`](#etcpasswd)
    2. [`/etc/shadow`](#etcshadow)
    3. [`/etc/goups`](#etcgoups)
    4. [Aktuálně příhlášený uživatel](#aktuálně-příhlášený-uživatel)
    5. [Identifikátory a skupiny](#identifikátory-a-skupiny)
11. [Skupiny](#skupiny)
    1. [Práce se skupinamy](#práce-se-skupinamy)
12. [Package managery](#package-managery)
    1. [Repozitáře](#repozitáře)
    2. [Další operace](#další-operace)
13. [Sestavení ze zdrojáku](#sestavení-ze-zdrojáku)
    1. [Kompilace](#kompilace)
    2. [Build systémy](#build-systémy)
    3. [Workflow](#workflow)
    4. [Kdy využít kompilaci ze zdroje](#kdy-využít-kompilaci-ze-zdroje)
    5. [Základní kroky](#základní-kroky)
14. [`$PATH`](#path)
    1. [Typické adresáře](#typické-adresáře)

---


## Uživatelé a oprávnění

### Vyhledání nastavených oprávnění

- **Zobrazení** - `ls -l` - `ls -la`

> `-rw-r--r--. 1 sam sam  358 17. led 22.32 Cargo.toml`

| `-rw-r--r--.` | `1` | `sam` | `sam` | `358` | `17. led 22.32` | `Cargo.toml`|
|-------------|-----|-------|-------|-------|-----------------|-------------|
| Oprávnění | Počet p. odkazů | Vlastník | Skupina | Velikost (b) | Čas poslední změny | Název |

---

#### Oprávnění

| d | rwx | rwx | rwx |
|---|-----|-----|-----|
|**d**ir| owner | group | other|

---

|`r`|`w`|`x`
|---|---|---|
|**r**ead|**w**rite|e**x**ecute|

---

**Číselný zápis**
- jednotlivé 3 bity = `0..8`
- `7` = `0b111` => `rwx`
- `6` = `0b110` => `rw-`  
...

---

## Změna oprávnění
`chmod [OPTION]... [FILE/DIR]...`
- `chmod 755 ./file.txt` - změní práva na `755`
- `chmod +r ./file.txt` - přidá r pro všechny
- `chmod -R +r ./dir/` - rekurzivně


`chmod [u|g|o|a][+|-|=][r|w|x] soubor`
- `chmod u+x soubor` - přidá x pro vlastníka
- `u` = **u**ser - `chmod u[+|-][r|w|x] ...`
- `g` = **g**roup - `chmod g[+|-][r|w|x] ...`
- `o` = **o**ther - `chmod o[+|-][r|w|x] ...`
- `a` = **a**ll - `chmod a[+|-][r|w|x] ...`
- `+` = **přidat** právo - `chmod [u|g|o|a]+[r|w|x] ...`
- `-` = **odebrat** právo - `chmod [u|g|o|a]-[r|w|x] ...`
- `=` = **nastavit přesně** - `chmod [u|g|o|a]=[r|w|x] ...`

---

## Speciální oprávnění
**SUID** - **S**et **U**ser **ID**
- Spustí s právy vlastníka
  - `sudo`, `passwd`
  - `chmod u+s [file|dir]`
  - `chmod 4755 [file|dir]`

  - -rw`s`r-xr-x

**SGID** - **S**et **G**roup **ID**
- Spustí s právy skupiny
  - `chmod g+s [file|dir]`
  - `chmod 2755 [file|dir]`

  - drwxr-sr-x

**Sticky Bit**
- Zabrání mazání jinými uživateli, i když mají w oprávnění
  - `chmod +t [file|dir]`
  - `chmod 1777 [file|dir]`

---

## Vytvořrní uživatele
`sudo useradd skullhacker69`
- Defaults:
  - Home: `/home/skullhacker69`
  - Shell: `/bin/sh` nebo `/bin/bash`
  - Group: `skullhacker69`
  
- Swiches
  - `-d`: Změna domovského adresáře (`-d /some/path`)
  - `-m`: Vytvořit domovský addr. (`-m skupphacker68`)
  - `-s`: Defaultní shell (`-s /usr/bin/fish`)
  - `-g`: Groupa (`-g group420`)
  - `-G`: Groupy (`-G group420 group69`)
  - `-c`: Koment (`-c "negr"`)

### Změna hesla
`sudo passwd skullhacker69`

---

## Editace uživatele
`sudo usermod ...`
- Switches:
  - `-l`: Mění uživatelské jméno (`sudo usermod skullhacker69 skullhacker420`)
    - Změna jména uživatele `skullhacker69` na `skullhacker420`
  - `-d`: Nový domovský adresář (`sudo usermod -d /home/skullhacker69 skullhacker420`)
  - `-m`: Vytvořit nebo přesunout domovský adresář (`sudo usermod -d /home/skullhacker69 -m skullhacker420`)
  - `-s`: Změna shellu (`sudo usermod -s /usr/bin/fish skullhacker69`)
  - `-aG`: Přidat do skupin (`sudo usermod sudo,developers skullhacker69`)
    - `-a` = append
  
### Zamknutí účtu
- Deaktivuje login, soubory zůstávají
- `sudo usermod -L skullhacker69`
- Odemknutí: `sudo usermod -U skullhacker69`

---

## Odebrání uživatele
`sudo userdel skullhacker69`
- `-r` Pro smazání domovského uživatele

---

## Změna vlastníka souboru
`sudo chown skullhacker69 soubor`
- Změna vlastníka i skupiny: `sudo chown skullhacker69:group soubor`

---

## Informace o uživatelích
### `/etc/passwd`
základní info o uživatelích, odkaz na hesla

> `sam:x:1000:1000:Samwise Gamgee:/home/sam:/usr/bin/zsh`

| sam | x | 1000 | 1000 | Samwise Gamgee | `/home/sam` | `/usr/bin/zsh` |
|-----|---|------|------|----------------|-------------|----------------|
| Jméno | heslo je v `/etc/shadow` | `uid` | `gid` | popis | home | shell |

---

### `/etc/shadow`
- Obsahuje zašifrovaná hesla
- Přístup má pouze root


### `/etc/goups`
- Obsahuje info o skupinách

### Aktuálně příhlášený uživatel
- `whoami`
- `echo $USER`

### Identifikátory a skupiny
- `id`
- Skupiny konkrétního uživatele: `groups skullhacker69`

---

## Skupiny

- **Primární** skupina: Každý uživatel jenom jednu
- **Sekundární** skupina: Každý může mít více

### Práce se skupinamy
- **Vytvořit**: `grupadd groupa1`
- **Přidat uživatele** do skupiny: `usermod -aG groupa1 skullhacker69`
- **Odebrat** uživatele: `gpasswd -d skullhacker groupa1`
- **Nastavit** konkrétní skupiny: `usermod -G grooupa1 groupa2 skullhacker69`
- **Zobrazení členů** skupiny: `getent group groupa1`
- **Zobrazení skup. příslušnosti**: `groups uživatel`
- **Group DB**: `/etc/group`

---

## Package managery
- Instaluje programy jedním příkazem
- Umisťuje soubory na správná místa v systému
- Eviduje, co je v systému nainstalováno

- **Řešení závislostí**: zjistí, co chybí
- **Rozdíly mezi distribucemi**: `apt`, `dnf`, `pacman`, `zypper`
- **Instalace**: `apt/dnf/zypper install ..`, `pacmand -S`
  - Root access
- **Smazání**: `apt/dnf/zypper remove ..`, `pacman -R ..`
- **Aktualizace DB**: `apt/dnf update`, `dnf check-update`, `pacman -Sy`, `zypper refresh`
- **Update stažených**: `apt/dnf updgrade`, `pacman -Syu`, `zypper update`
### Repozitáře
- Server/y obsahujici balicky softwaru

| Typ | Správce | Výhody | Nevýhody | Příklady |
|--------|------------|-----------|----------|-----|
| Oficiální | Dev team distribuce | Stabilita, bezpečnost | Starší verze | `main`|
| Komuniní | Komunita | Širší nabídka, novější verze | méně testování | Ubuntu `universe`, `AUR`, `rpm fusion` |
| 3rd party | Externí firmy, projekty | Specifický software | Bezp. riziko | Docker, Nvidia |

### Další operace
- **Vyhledávání**: `apt search ..`, `dnf search ..`, `pacman -Ss ..`
- **Zobrazení informací**: `apt show ..`, `dnf info ..`, `pacman -Si ..`
- **Správa cache**: `apt clean/autoclean/autoremove`

---

## Sestavení ze zdrojáku
- **Zdrojový kód**: Napsaný v prog. jazyce (čitelný)
- **Binárka**: Zkompilovaný zdrojový kód (spustitelný, nečitelný)

### Kompilace
1. **Preprocessor**: Zpracovává preprocesorové direktivy `#...`
    - `#include <header.h>` vloží header nebo source
    - `#define macro ...` vytvoří nové makro
    - `#if/ifdef/ifndef/...` podmíněná kompilace
2. **Kompilátor**: Překládá zdroj. kód do objektových souborů (`.o`)
3. **Linker**: Zpracovává obj. soubory do výstupního programu
    - Přidává knihovny (statické, dynamické)
    - Řeší odkazy na funkce, proměnné

### Build systémy
> Automatizace sestavování  

**Proč**: Ruční sestavování je neudržitelné (u větších projrktů)
- Efektivita: Zzkompilují se jenom změněné části  
**Příklady**:
- `make`: Klasika na linuxu (bohužel)
- `cmake`: Překládá konfiguraci do jiných build systémů
- `meson`: Moderní
- `autotools`(?): Starší, ale furt se používá
- Většina nových jazyků má vlastní build systémy: (C#, Zig, Rust, atd.)

### Workflow
```bash
git clone projekt # nebo tar -xvf projekt.tar.gz
cd projekt
./configure # nebo cmake .
make .  # sestaveni
make test # testovani
sudo make install # instalace sestaveneho programu
```

### Kdy využít kompilaci ze zdroje
- Balíček není dostupný v repozitáři
- Potřeba nejnovější verze softwaru
- Specifické optimalizace nebo konfigurace
- Vývoj a úpravy softwaru
- Důvěra k vlastnímu sestavení

### Základní kroky
- Instalace build nástrojů
- Stažení zdrojového kódu
- Instalace vývojářských závislostí
- Konfigurace sestavení
- Kompilace
- Instalace do systému


## `$PATH`
- Proměnná prostředí obsahující cesty k adresářům se spustitelnými soubory
- Shell prohledává tyto adresáře při spuštění příkazu
- `echo $PATH`: Zobrazení aktuální hodnoty PATH
- **Přidání adresáře**: `export PATH="$PATH:/novy/adresar"`
  - Trvalá změna: `echo $(export PATH="$PATH:/novy/adresar") > ~/.bashrc`
    - Projeví se po: `source ~/.bashrc`
- **Pořadí**: prohledává se zleva

### Typické adresáře
- Systémové: `/bin`, `/usr/bin`
- Lokaálně nainstalovaný SW: `/usr/local/bin`, `/usr/local/sbin`
- Sysadmin nástroje: `/sbin`, `/usr/sbin`
- Uživatelské: `~/bin`, `~/.local/bin`







