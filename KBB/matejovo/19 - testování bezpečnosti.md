# 19 - Testování bezpečnosti


1. [19 - Testování bezpečnosti](#19---testování-bezpečnosti)
2. [Úvod do testování bezpečnosti](#úvod-do-testování-bezpečnosti)
   1. [Proč testovat bezpečnost](#proč-testovat-bezpečnost)
   2. [Kdy testovat](#kdy-testovat)
3. [Typy bezpečnostního testování](#typy-bezpečnostního-testování)
   1. [Podle přístupu k informacím](#podle-přístupu-k-informacím)
   2. [Podle metody](#podle-metody)
      1. [SAST - Static Application Security Testing](#sast---static-application-security-testing)
      2. [DAST - Dynamic Application Security Testing](#dast---dynamic-application-security-testing)
      3. [IAST - Interactive Application Security Testing](#iast---interactive-application-security-testing)
      4. [Penetration Testing](#penetration-testing)
      5. [Code Review](#code-review)
4. [Metodiky testování](#metodiky-testování)
   1. [OWASP Testing Guide](#owasp-testing-guide)
   2. [PTES - Penetration Testing Execution Standard](#ptes---penetration-testing-execution-standard)
   3. [OSSTMM - Open Source Security Testing Methodology Manual](#osstmm---open-source-security-testing-methodology-manual)
5. [Nástroje pro testování](#nástroje-pro-testování)
   1. [Proxy nástroje](#proxy-nástroje)
      1. [Burp Suite](#burp-suite)
         1. [Hlavní moduly](#hlavní-moduly)
      2. [OWASP ZAP - Zed Attack Proxy](#owasp-zap---zed-attack-proxy)
         1. [Funkce](#funkce)
6. [Skenery zranitelností](#skenery-zranitelností)
   1. [Nikto](#nikto)
   2. [Nessus a OpenVAS](#nessus-a-openvas)
   3. [SQLMap](#sqlmap)
7. [Fuzzing nástroje](#fuzzing-nástroje)
   1. [ffuf](#ffuf)
   2. [wfuzz](#wfuzz)
   3. [gobuster/dirb](#gobusterdirb)
   4. [Burp suite Intruder](#burp-suite-intruder)
8. [Fuzzing](#fuzzing)
   1. [Typy fuzzingu](#typy-fuzzingu)
   2. [Co fuzzovat](#co-fuzzovat)
   3. [Wordlisty](#wordlisty)
9. [Praktické postupy testování bezpečnosti](#praktické-postupy-testování-bezpečnosti)
   1. [Reconnaissance (průzkum)](#reconnaissance-průzkum)
   2. [Testování autentizace](#testování-autentizace)
   3. [Testování autorizace](#testování-autorizace)
   4. [Testování vstupů](#testování-vstupů)
10. [Reporting](#reporting)
    1. [Obsah reportu](#obsah-reportu)
    2. [Klasifikace závažnosti](#klasifikace-závažnosti)
11. [DevSecOps](#devsecops)
    1. [Integrace bezpečnosti do CI/CD](#integrace-bezpečnosti-do-cicd)
    2. [Shift-left přístup](#shift-left-přístup)



# Úvod do testování bezpečnosti

**Soubor metod a postupů**, které **slouží k odhalení slabin** (zranitelností) v informačních **systémech, aplikacích nebo sítích**


## Proč testovat bezpečnost
**Identifikace zranitelností před útočníky**: Chyby je lepší odhalit interně než až při reálném útoku  
**Ověření účinnosti bezpečnostních opatření**: Kontrola, zda firewally, autentizace nebo šifrování fungují správně  
**Compliance a regulatorní požadavky**: Organizace musí splňovat [normy](./16%20-%20legislativa,%20etika%20a%20normy.md#legislativa-upravující-kybernetickou-bezpečnost)  
**Snížení rizika bezpečnostních incidentů**: Méně chyb = menší pravděpodobnost útoku a škod

## Kdy testovat
**Během vývoje** (shift-left): Testování už při psaní kódu  
**Před nasazením do produkce**: Kontrola před spuštěním pro uživatele  
**Pravidelně v produkčním prostředí**: Systémy se mění, vznikají nové hrozby  
**Po významných změnách**: Např. nová funkce, aktualizace nebo integrace

---

# Typy bezpečnostního testování
## Podle přístupu k informacím
**Black Box** Testing: Tester nemá žádné informace o systému
- Simuluje reálného útočníka
- Časově náročnější, nemusí odhalit všechny zranitelnosti

**White Box** Testing: Tester má plný přístup ke kódu a dokumentaci
- Důkladnější pokrytí
- Efektivnější pro nalezení všech zranitelností

**Grey Box** Testing: Částečné informace o systému
- Kombinace obou přístupů
- Nejčastější v praxi

## Podle metody
### SAST - **S**tatic **A**pplication **S**ecurity **T**esting
**Analýza zdrojového kódu bez spuštění**
- Nalezení zranitelností v kódu
- Lze automatizovat a integrovat do CI/CD pipeline
- Nástroje: SonarQube, Checkmarx, Semgrep

**Výhoda**: Odhalení chyb už v rané fázi vývoje  
**Nevýhoda**: Neodhalí chyby vznikající za běhu aplikace

### DAST - **D**ynamic **A**pplication **S**ecurity **T**esting
**Testování běžící aplikace**
- Simulace útoků zvenčí
- Nalezení runtime zranitelností
- Nástroje: OWASP ZAP, Burp Suite, Nikto

**Nevýhoda**: Nevidí do zdrojového kódu

### IAST - **I**nteractive **A**pplication **S**ecurity **T**esting
**Kombinace SAST a DAST**
- V aplikaci běží agent, který sleduje chování v reálném čase
- Poskytuje přesnější výsledky a méně falešných poplachů

### Penetration Testing
**Simulované útoky odborníky**
- Manuální testování + automatizované nástroje
- Cílem je napodobit reálného útočníka
- Komplexní report s doporučeními

### Code Review
**Manuální kontrola kódu**
- Identifikace logických chyb
- Sdílení znalostí v týmu

---

# Metodiky testování
## [OWASP Testing Guide](https://owasp.org/www-project-web-security-testing-guide/stable/)
**Standardizovaný framework pro testování**
- Pokrývá všechny aspekty webové bezpečnosti
- Detailní checklisty pro testery

## PTES - **P**enetration **T**esting **E**xecution **S**tandard

**Metodika zaměřená na penetrační testování krok za krokem**

Definuje jasný proces
1. **Pre-engagement**: Dohoda o rozsahu testu
    - Co se bude testovat, pravidla, povolení
2. **Intelligence Gathering**: Sběr informací o cíli
    - Domény, IP adresy, technologie
3. **Threat Modeling**
    - Analýza možných hrozeb a scénářů útoků
4. **Vulnerability Analysis**
    - Hledání zranitelností v systému
5. **Exploitation**: Pokus o jejich zneužití (ověření reálného dopadu)
6. **Post-Exploitation**: Zjištění, co může útočník dělat po průniku
    - Např. získání dat
7. **Reporting**: Vytvoření reportu s nálezy a doporučeními

**Výhoda**: Jasná struktura a reálný pohled na útok

## OSSTMM - **O**pen **S**ource **S**ecurity **T**esting **M**ethodology **M**anual

**Otevřená metodologie pro testování bezpečnosti**
- Hodnocení na základě metrik
- Nejen pro weby, ale i sítě, fyzickou bezpečnost nebo procesy

---

# Nástroje pro testování
## Proxy nástroje
### Burp Suite

**Profesionální nástroj pro testování webových aplikací**

Funguje jako intercepting proxy – zachytává komunikaci mezi klientem a serverem

#### **Hlavní moduly**
**Proxy**: Zachytávání a úprava HTTP požadavků  
**Scanner**: Automatické hledání zranitelností  
**Intruder**: Automatizované útoky (např. brute-force)  
**Repeater**: Opakované odesílání požadavků s úpravami  
**Decoder**: Kódování/dekódování dat


### OWASP [ZAP](https://www.zaproxy.org/) - **Z**ed **A**ttack **P**roxy
Open-source alternativa k Burp Suite
- Vhodná pro začátečníky i pokročilé

#### **Funkce**

**Automatický scanner** zranitelností  
**Pasivní skenování** (bez zásahu)  
**Aktivní skenování** (simulace útoků)  
**API pro automatizaci** (např. v CI/CD)

---

# Skenery zranitelností
## [Nikto](https://hackviser.com/tactics/tools/nikto)

[sullo/nikto - github](https://github.com/sullo/nikto)

**Jednoduchý skener webových serverů**

**Zaměřuje se na**
- Zastaralý software
- Známé zranitelnosti
- Špatnou konfiguraci

## Nessus a [OpenVAS](https://openvas.org/)

Komplexní nástroje pro **skenování zranitelností**

**Testují**
- Síťovou infrastrukturu
- Operační systémy
- Aplikace
- Poskytují detailní reporty a hodnocení rizik

## SQLMap

Specializovaný nástroj na **[SQL injection](./18%20-%20principy%20bezpečného%20vývoje.md#sql-injection)**

**Umožňuje**
- Automatickou detekci zranitelností
- Určení typu databáze
- Extrakci dat z databáze

**Používané techniky**
- **blind** (boolean-based): Dotazy, které vrací pravda/nepravda
- **Time-based**: Využívá časové zpoždění (např. funkce `SLEEP()`)
  - Zpožděná odpověď znamená, že podmínka byla pravdivá
- **UNION-based**: Příkaz `UNION` - Umožňuje přímo zobrazit data z databáze v odpovědi aplikace

---

# Fuzzing nástroje

## [`ffuf`](https://github.com/ffuf/ffuf)
**Velmi rychlý web fuzzer**

**Používá se hlavně pro**
- Hledání skrytých souborů a adresářů
- Fuzzing URL parametrů

**Výhoda**: Vysoký výkon a jednoduché použití

## [`wfuzz`](https://github.com/xmendez/wfuzz)
**Flexibilní nástroj pro fuzzing webových aplikací**

**Umožňuje testovat**
- Parametry
- Cookies
- HTTP hlavičky

## [`gobuster`](https://github.com/OJ/gobuster)/[`dirb`](https://www.kali.org/tools/dirb/)
Nástroje pro **brute-force vyhledávání adresářů a souborů**
- Fungují na principu wordlistů
- Často se používají při mapování struktury webu

## Burp suite **Intruder**

&&Integrovaný fuzzer v nástroji Burp Suite**

**Typy útoků**
- **Sniper**: Testování jednoho parametru
- **Battering ram**: Stejný payload pro více míst
- **Pitchfork**: Paralelní kombinace payloadů
- **Cluster bomb**: Všechny kombinace payloadů

---

# Fuzzing
**Automatizované testování aplikace pomocí neočekávaných vstupů**
- Cílem je odhalit chyby (např. pády aplikace) a/nebo najít zranitelnosti
- Generuje se velké množství různých vstupních dat

## Typy fuzzingu

**Mutation-based**: Modifikace validních vztupů
- Např. změna znaků v URL nebo formuláři

**Generation-based**: Generování vstupů podle specifikace
- Vstupy se generují podle definované struktury (např. protokol, formát)

**Coverage-guided**: Optimalizace podle pokrytí kódu
- Sleduje, jaký kód byl vykonán, a optimalizuje testy pro lepší pokrytí

## Co fuzzovat
**URL parametry**: Např.`?id=1` v URL  
**POST data**: Např. formuláře  
**HTTP hlavičky**  
**Cookies**  
**Soubory a adresáře**  
**API endpointy**


## Wordlisty

**[SecLists](https://github.com/danielmiessler/SecLists)**: Velká kolekce wordlistů pro různé typy útoků  
**Vlastní wordlisty**: Přizpůsobené konkrétní aplikaci  
**Kombinace wordlistů**: Zvyšuje šanci na nalezení skrytých cest nebo parametrů

---

# Praktické postupy testování bezpečnosti
## Reconnaissance (průzkum)
**Získat co nejvíce informací o cíli ještě před samotným útokem**

Dobrý průzkum výrazně zvyšuje úspěšnost testování

**Provádí se**
- **OSINT**: Sběr a analýza veřejných informací
  - [OSINT framework](https://osintframework.com/)
- **Enumerace subdomén**: Např. `example.com` -> `api.example.com`
- **Identifikace technologií**: Např. [Wrappalyzer](https://www.wappalyzer.com/)
- **Hledání skrytých souborů a endpointů**: Např. `/admin`, ...


## Testování autentizace
**Zaměřuje se na proces přihlašování a správu účtů**

**Typické testy**
- **Brute-force**: Zkoušení velkého množství hesel
- **Default credentials**: Testování výchozích přihlašovacích údajů
- **Password policy bypass**: Slabá pravidla hesel
- **Session management**: Kontrola session tokenů (např. platnost, odhlášení)

## Testování autorizace
**Ověřuje, zda má uživatel přístup jen k tomu, co má mít**

**Typy zranitelností**
- **IDOR**: Přístup k cizím datům změnou ID
  - [IDOR](https://portswigger.net/web-security/access-control/idor#top) = (**I**nsecure **D**irect **O**bject **R**eference)
- **Privilege escalation**: Získání vyšších oprávnění
- **Horizontal access control**: Přístup k datům jiného uživatele
- **Vertical access control**: Přístup k funkcím admina

## Testování vstupů

**Kontrola, jak aplikace zpracovává data od uživatele**

**Nejčastější zranitelnosti**
- **[SQL Injection](./18%20-%20principy%20bezpečného%20vývoje.md#sql-injection)**: Manipulace s databází
- **[XSS](./18%20-%20principy%20bezpečného%20vývoje.md#xss---cross-site-scripting)**: Vkládání škodlivého JavaScriptu
- **[Command Injection](./18%20-%20principy%20bezpečného%20vývoje.md#commandline-injection)**: Spouštění systémových příkazů
- **[Path Traversal](https://owasp.org/www-community/attacks/Path_Traversal)**: Přístup k souborům mimo povolené cesty
- **[File Upload vulnerabilities](https://hackviser.com/tactics/pentesting/web/file-upload)**: Nahrání škodlivých souborů

---

# Reporting

## Obsah reportu
**Executive summary**: Shrnutí pro management  
**Metodologie**: Jak bylo testování provedeno (např. OWASP standardy)  
**Nalezené zranitelnosti**: Detailní popis chyb  
**Severity rating**: Hodnocení závažnosti podle [CVSS](https://www.first.org/cvss/v4.0/specification-document)  
**Proof of Concept** (PoC): Ukázka zneužití  
**Doporučení pro nápravu**: Jak chyby opravit  

## Klasifikace závažnosti

**Critical**: Okamžité riziko, možný úplný kompromis systému  
**High**: Vysoké riziko, únik citlivých dat  
**Medium**: Omezený dopad  
**Low**: Malý dopad  
**Informational**: Doporučení, best practices

---

# DevSecOps
## Integrace bezpečnosti do CI/CD
**Bezpečnost je součástí vývojového procesu**
- **[SAST](#sast---static-application-security-testing)** při každém commitu
- **[DAST](#dast---dynamic-application-security-testing)** ve staging prostředí
- **Dependency scanning**: Detekce zranitelných knihoven
- **Container scanning**: Např. [Docker](./11%20-%20virtualizace%20a%20kontejnerizace.md#docker) image


## Shift-left přístup
**Bezpečnost se řeší už od začátku vývoje**
- Školení vývojářů - secure coding
- Threat modeling při návrhu aplikace
- Prevence chyb místo jejich pozdějšího opravování
























