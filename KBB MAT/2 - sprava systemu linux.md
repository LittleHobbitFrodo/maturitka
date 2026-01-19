# Správa systému Linux
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

`/etc/shadow`
- Obsahuje zašifrovaná hesla
- Přístup má pouze root


`/etc/goups`
- Obsahuje info o skupinách

Aktuálně příhlášený uživatel
- `whoami`
- `echo $USER`

Identifikátory a skupiny
- `id`
- Skupiny konkrétního uživatele: `groups skullhacker69`

---

## Skupiny

- **Primární** skupina: Každý uživatel jenom jednu
- **Sekundární** skupina: Každý může mít více

### Práce
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
- **Command pro instalaci**: `apt/dnf/zypper install ..`, `pacmand -S`
  - Root access




