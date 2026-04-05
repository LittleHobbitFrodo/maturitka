# 07 - Síťové útoky a bezpečnost

1. [07 - Síťové útoky a bezpečnost](#07---síťové-útoky-a-bezpečnost)

2. [CIA Triad](#cia-triad)
   1. [C - Confidentiality (Důvěrnost)](#c---confidentiality-důvěrnost)
      1. [Příklady](#příklady)
      2. [Hrozby](#hrozby)
   2. [I - Integrity](#i---integrity)
      1. [Příklady](#příklady-1)
      2. [Hrozby](#hrozby-1)
   3. [A - Availability (Dostupnost)](#a---availability-dostupnost)
      1. [Příklady](#příklady-2)
      2. [Hrozby](#hrozby-2)
3. [Typy útočníků](#typy-útočníků)
   1. [Insider](#insider)
      1. [Výhody](#výhody)
      2. [Rizika](#rizika)
   2. [Outsider](#outsider)
      1. [Charakteristika](#charakteristika)
      2. [Rizika](#rizika-1)
4. [Motivace útočníků](#motivace-útočníků)
   1. [Finanční zisk](#finanční-zisk)
   2. [Špionáž](#špionáž)
   3. [Sabotáž](#sabotáž)
   4. [Ideologie (hacktivismus)](#ideologie-hacktivismus)
   5. [Zvědavost / výzva](#zvědavost--výzva)
   6. [Osobní důvody](#osobní-důvody)
5. [Kill Chain (Cyber Attack Lifecycle)](#kill-chain-cyber-attack-lifecycle)
   1. [1) Reconnaissance (Průzkum)](#1-reconnaissance-průzkum)
   2. [2) Weaponization (Zbrojení)](#2-weaponization-zbrojení)
   3. [3) Delivery (Doručení)](#3-delivery-doručení)
   4. [4) Exploitation (Zneužití)](#4-exploitation-zneužití)
   5. [5) Installation](#5-installation)
   6. [6) Command and Control (C2)](#6-command-and-control-c2)
   7. [7) Actions and Objectives (Akce k dosažení cíle)](#7-actions-and-objectives-akce-k-dosažení-cíle)
6. [Útoky narušující Důvěrnost (Confidentiality)](#útoky-narušující-důvěrnost-confidentiality)
   1. [Man in the middle (MITM)](#man-in-the-middle-mitm)
      1. [ARP spoofing](#arp-spoofing)
         1. [Jak to funguje](#jak-to-funguje)
         2. [Výsledek](#výsledek)
      2. [DNS Spoofing (DNS Cache Poisoning)](#dns-spoofing-dns-cache-poisoning)
         1. [Jak to funguje](#jak-to-funguje-1)
         2. [Výsledek](#výsledek-1)
         3. [Obrana](#obrana)
      3. [Evil twin](#evil-twin)
      4. [SSL Stripping](#ssl-stripping)
         1. [Jak to funguje](#jak-to-funguje-2)
         2. [Výsledek](#výsledek-2)
   2. [Sniffing](#sniffing)
      1. [Co může vidět](#co-může-vidět)
      2. [Promiskuitní režim](#promiskuitní-režim-síťové-karty)
      3. [Zachytávání citlivých údajů](#zachytávání-citlivých-údajů)
   3. [Session hijacking](#session-hijacking)
      1. [Odcizení session ID](#odcizení-session-id)
         1. [Jak se krade](#jak-se-krade)
      2. [Cookie Stealing](#cookie-stealing)
         1. [Rizikové situace](#rizikové-situace)
      3. [Sidejacking (Session Sidejacking)](#sidejacking-session-sidejacking)
7. [Útoky narušující Integritu](#útoky-narušující-integritu)
   1. [Spoofing útoky](#spoofing-útoky)
      1. [IP spoofing - maskování útočníka](#ip-spoofing---maskování-útočníka)
         1. [Využití](#využití)
         2. [Omezení](#omezení)
      2. [DNS Spoofing - fake web](#dns-spoofing---fake-web)
      3. [ARP spoofing](#arp-spoofing-1)
      4. [Email Spoofing](#email-spoofing)
   2. [DHCP rogue server](#dhcp-rogue-server)
      1. [Co může podvrhnout](#co-může-podvrhnout)
      2. [Obrana](#obrana-1)
   3. [NTP Spoofing](#ntp-spoofing)
      1. [Dopady](#dopady)
      2. [Time shifting útoky](#time-shifting-útoky)
      3. [Obrana](#obrana-2)
   4. [Replay Attack](#replay-attack)
      1. [Zneužití](#zneužití)
      2. [Obrana](#obrana-3)

8. [Útoky narušující dostupnost (Availability)](#útoky-narušující-dostupnost-availability)
   1. [Denial of Service (DoS)](#denial-of-service-dos)
      1. [SYN flood](#syn-flood)
      2. [UDP port](#udp-port)
      3. [ICMP Flood](#icmp-flood)
      4. [Slowloris](#slowloris)
      5. [HTTP Flood](#http-flood)
      6. [Distributed Denial of Service (DDoS)](#distributed-denial-of-service-ddos)
         1. [Často cílí na](#často-cílí-na)
   2. [Distributed denial of service (DDoS)](#distributed-denial-of-service-ddos-1)
      1. [Botnet](#botnet)
         1. [Výsledek](#výsledek-3)
      2. [Amplification útoky (zesilovací)](#amplification-útoky-zesilovací)
         1. [DNS Amplification](#dns-amplification)
         2. [NTP amplification](#ntp-amplification)
   3. [Resource Exhaustion](#resource-exhaustion)
      1. [DHCP Starvation – vyčerpání DHCP poolu](#dhcp-starvation--vyčerpání-dhcp-poolu)
      2. [ARP Table Flooding](#arp-table-flooding)
         1. [Výsledek](#výsledek-4)
      3. [CAM Table Overflow](#cam-table-overflow)
         1. [Výsledek](#výsledek-5)
         2. [Dopad](#dopad)
9. [Útoky na bezdrátové sítě](#útoky-na-bezdrátové-sítě)
   1. [Wi-Fi zabezpečení](#wi-fi-zabezpečení)
      1. [WEP (Wired Equivalent Privacy)](#wep-wired-equivalent-privacy)
         1. [Typické útoky](#typické-útoky)
      2. [WPA (Wi-Fi Protected Access)](#wpa-wi-fi-protected-access)
         1. [Útoky](#útoky)
      3. [WPA2](#wpa2)
      4. [WPA3](#wpa3)
         1. [Výhody](#výhody-1)
   2. [Útoky na Wi-fi](#útoky-na-wi-fi)
      1. [Deauthentication attack](#deauthentication-attack)
         1. [Princip](#princip)
      2. [Evil Twin](#evil-twin-1)
      3. [WPS attack (zneužití WPS PIN)](#wps-attack-zneužití-wps-pin)
         1. [Výsledek](#výsledek-6)
      4. [Handshake capture + brute-force](#handshake-capture--brute-force)
      5. [KRACK (Key Reinstallation Attack)](#krack-key-reinstallation-attack)
   3. [Nástroje](#nástroje)
      1. [`aircrack-ng`](#aircrack-ng)
         1. [Umožňuje](#umožňuje)
         2. [Deauth attack](#deauth-attack)
      2. [`wifite`](#wifite)
10. [Password útoky](#password-útoky)
    1. [Brute Force](#brute-force)
       1. [Slovníkový útok (dictionary attack)](#slovníkový-útok-dictionary-attack)
       2. [Kombinatorický útok](#kombinatorický-útok)
       3. [Hybrid útok](#hybrid-útok)
    2. [Rainbow tables 🌈](#rainbow-tables-)
       1. [Ochrana – Salt](#ochrana--salt)
    3. [Credential Stuffing](#credential-stuffing)
11. [Reconnaissance a scanning](#reconnaissance-a-scanning)
    1. [Pasivní reconnaissance](#pasivní-reconnaissance)
       1. [OSINT](#osint)
          1. [Vřejné zdroje](#vřejné-zdroje)
          2. [Co lze zjistit](#co-lze-zjistit)
       2. [DNS enumeration](#dns-enumeration)
       3. [WHOIS lookup](#whois-lookup)
          1. [Co zjistíš](#co-zjistíš)
    2. [Aktivní reconnaissance](#aktivní-reconnaissance)
       1. [Port scanning - nmap](#port-scanning---nmap)
       2. [Service enumeration](#service-enumeration)
       3. [Vulnerability scanning](#vulnerability-scanning)
          1. [Co hledat](#co-hledat)
12. [Ochrana a detekce](#ochrana-a-detekce)
    1. [Šifrování](#šifrování)
       1. [TLS/SSL](#tlsssl)
       2. [VPN](#vpn)
    2. [Silná autentizace (MFA)](#silná-autentizace-mfa)
       1. [Segmentace sítě (VLAN)](#segmentace-sítě-vlan)
       2. [Port security](#port-security)
       3. [802.1X autentizace](#8021x-autentizace)
    3. [Detekce](#detekce)
       1. [IDS/IPS systémy](#idsips-systémy)
       2. [SIEM](#siem-security-information-and-event-management)
       3. [Honeypot](#honeypot)
       4. [Monitoring anomálií](#monitoring-anomálií)
    4. [Reakce (Response)](#reakce-response)
       1. [Incident Response Plan](#incident-response-plan)
          1. [Obsah](#obsah)
       2. [Izolace kompromitovaných systémů](#izolace-kompromitovaných-systémů)
       3. [Forenzní analýza](#forenzní-analýza)

---

# CIA Triad

Základní bezpečnostní model
- Je jeden z nejdůležitějších konceptů v oblasti Information Security

Popisuje 3 klíčové principy: **CIA**

## **C** - **C**onfidentiality (Důvěrnost)

Zajišťuje, že **přístup k informacím** mají pouze oprávněné osoby
- **Kdo může co vidět**

#### **Příklady**
- Hesla, šifrování dat
- Přístupová práva

#### **Hrozby**
- Únik dat
- Odposlech komunikace

Jenom příslušný uživatel by měl vidět svůj zůstatek na účtu

## **I** - **I**ntegrity

Zajišťuje, že **data jsou správná**, úplná a nebyla neoprávněně změněna
- **Jestli jsou data správná**

#### **Příklady**
- Hashování pro kontrolu souborů
- Asymetrické podpisy

#### **Hrozby**
- Neoprávněná úprava dat
- Malware měnící obsah souborů

Při převodu peněz musí částka dorazit přesně tak, jak byla odeslána

## **A** - **A**vailability (Dostupnost)

Zajišťuje, že systémy a data jsou **dostupné, když je uživatel potřebuje**
- **Jestli jsou data dostupná**

#### **Příklady**
- Zálohování dat

#### **Hrozby**
- Výpadky serverů
- DDoS útoky

Banka musí být dostupná když má projít platba

---

# Typy útočníků

## Insider

**Má** legitimní **přístup** do systému (zaměstnanec, admin, ...)

#### **Výhody**
- Přístupová práva předem
- Zná systém zevnitř

#### **Rizika**
- Zneužití oprávnění
- Krádež nebo únik dat
- Sabotáž

## Outsider

**Není součástí** organizace - snaží se proniknout zvenčí

#### **Charakteristika**
- Nemá přímý přístup
- Využívá zranitelnosti

#### **Rizika**
- Hackerské útoky
- Malware, phishing


## Motivace útočníků

### Finanční zisk
Krádež peněz nebo dat
- **Ransom**(ware), ...

### Špionáž
Průmyslová nebo státní špionáž

Krádež know-how, technologií

### Sabotáž
Poškození systému nebo reputace organizace

Vyřazení služeb (DDoS)


### Ideologie (hacktivismus)
Politické nebo sociální cíle
- Vládní nebo korporátní weby

### Zvědavost / výzva
„Jen si to zkusit“
- Často script kiddies

### Osobní důvody
Pomsta (bývalý zaměstnanec)
- Nespokojenost

---

# Kill Chain (Cyber Attack Lifecycle)

**Čím dříve útok zastavíš, tím menší škody vzniknou**
- Reconnaissance -> prevence
- Delivery / Exploitation -> detekce
- C2 / Actions -> reakce a mitigace

## 1) Reconnaissance (Průzkum)
Útočník sbírá **informace o cíli**
- Veřejné údaje (web, sociální sítě)
- Skenování portů, zjišťování technologií

**Cíl**: Najít slabá místa

## 2) Weaponization (Zbrojení)
Útočník připravuje útok
- Vytvoření škodlivého souboru/dokumentu
- Příprava exploit kitu

**Obrana**: Antiviry, detekce známých vzorků

## 3) Delivery (Doručení)
Např.:
- Phishingový email
  - Škodlivý odkaz nebo příloha
- Malicious USB

**Obrana**: Emailové filtry, školení útočníků

## 4) Exploitation (Zneužití)
Využití zranitelností k získání přístupu
- Zneužití chyby v softwaru
- Spuštění škodlivého kódu

**Obrana**: aktualizace, patch management

## 5) Installation
Instalace malwaru do systému
- backdoor, trojský kůň

**Obarana**
- EDR (**E**ndpoint **D**etection and **R**esponse)
- [XDR](https://www.crowdstrike.com/en-us/cybersecurity-101/endpoint-security/extended-detection-and-response-xdr/) (e**X**tended **D**etection and **R**esponse)
- Kontrola [integrity](#i---integrity)


## 6) Command and Control (**C2**)
Útočník navazuje komunikaci s napadeným systémem
- Vzdálené ovládání zařízení
- Přijímání instrukcí ze serveru

**Obrana**: monitoring síťového provozu, blokace C2 serverů

## 7) Actions and Objectives (Akce k dosažení cíle)
Finální fáze – útočník plní svůj cíl
- Krádež dat
- Šifrování dat (ransomware)
= Sabotáž systému

**Obrana**: segmentace sítě, detekce anomálií

---




# Útoky narušující Důvěrnost (Confidentiality)

## Man in the middle (MITM)

Útočník **zachytává nebo mění komunikaci** aniž by si toho obě strany všimly
- **Cíl**: získat nebo změnit hesla, cookies, osobní data, nebo jiná citlivá data

### ARP spoofing

**Tool**: `arpspoof`

**Obrana**: statické ARP záznamy, detekce ARP anomálií

#### **Jak to funguje**
**Manipulace ARP tabulky** v lokální síti

1. Útočník **pošle falešné ARP odpovědi**
2. Přesvědčí zařízení, že **jeho MAC adresa patří např. routeru**
3. **Provoz pak teče přes útočníka**

#### **Výsledek**
- Odposlech komunikace v LAN
- Možnost modifikace dat

### [DNS](./03%20-%20počítačové%20sítě.md#dns-domain-name-service) Spoofing (DNS Cache Poisoning)

#### **Jak to funguje**
Podvržení **falešných DNS odpovědí**

1. Útočník „otráví“ DNS cache
    - DNS server se zeptá root serveru, útočník odpoví dřív než root server
2. Uživatel je přesměrován na falešný web

#### **Výsledek**
- Krádež přihlašovacích údajů (phishing)
- Přesměrování na malware

#### **Obrana**
- DNSSEC (**D**omain **N**ame **S**ystem **S**ecurity **E**xtensions)
  - Přidá kryptografické ověření
- Zabezpečené DNS
  - DoH (**D**NS **o**ver **H**TTPS)
  - DoT (**D**NS **o**ver **T**LS)


### Evil twin

Útočník vytvoří **falešný Wi-Fi Access Point** se stejným názvem (SSID) jako legitimní síť

**Scénář**
1. Útočník vytvoří novou síť: `Hotel-X-free-wifi`
2. Oběť se připojí
3. Útočník vidí sšechen provoz
    - Může provádět další MITM útoky

### SSL Stripping

Downgraduje HTTP**S** na HTTP

#### **Jak to funguje**
1. Oběť chce jít na HTTPS (např. `https://example.com`)
2. Útočník zachytí požadavek
3. Přesměruje komunikaci na HTTP verzi
4. S obětí komunikuje nešifrovaně
    - Se serverem komunikuje šifrovaně

#### **Výsledek**
- Útočník vidí citlivá data (hesla, cookies)
- Oběť si nemusí všimnout (pokud ignoruje `http://`)


## Sniffing

**Pasivní odposlech** komunikace
- Útočník pouze naslouchá síťovému provozu
  - **Ne**zasahuje do komunikace => je skoro nezjistitelný
- Ve stejné síťi LAN
- V nezabezpečených sítích


#### **Co může vidět**
- HTTP komunikaci (nešifrovaná data)
- E-maily (pokud nejsou šifrované)
- Přihlašovací údaje

### [Promiskuitní režim](./05%20-%20analýza%20síťového%20provozu.md#promiskuitní-režim-síťové-karty)

### Zachytávání citlivých údajů
Hlavní cíl sniffingu

**Typicky**: Uživatelská jména a hesla, session cookies, API klíče

**Nejzranitelnější**: Starší protokoly bez TLS
- HTTP, email, ftp

## Session hijacking

Odcizení/krádež identity

**Obrana**
- Používat **HTTPS všude**
- Nastavit cookies:
  - `secure` (jen přes HTTPS)
  - `HttpOnly` (nepřístupné JS)
- Častá regenerace session ID
  - Krátká session ID expirace
- VPN na veřejných síťích

### Odcizení session ID

Útočník převezme aktivní session uživatele
- Ukradení **session ID** = krádež identity

1. Po přihlášení **server přiřadí** uživateli **session ID** (např. v cookie)
    - Tento identifikátor říká: „tento uživatel je ověřený“
2. Útočník ho ukradne => převezme jednorázový session/login uživatele
    - Může se vydávat za uživatele

#### **Jak se krade**
- Sniffing (nešifrovaný HTTP)
- MITM útoky
- XSS (Cross-Site Scripting) - krádež cookie ze skriptu

### Cookie Stealing
Session ID je nejčastěji uložené v cookies

Útočník zachytí cookie (sniffing nebo malware)
- Server ho pak považuje za legitimního uživatele

#### **Rizikové situace**
- Nezabezpečené Wi-Fi
- Weby bez HTTPS
- Špatně nastavené cookies (chybí `HttpOnly`, `Secure`)

### Sidejacking (Session Sidejacking)
1. Uživatel se přihlásí přes HTTPS
    - Další komunikace běží přes HTTP (nebo částečně nešifrovaně)
2. Útočník zachytí session cookie



---

# Útoky narušující Integritu

## Spoofing útoky

Spoofing = **Podvržení identity**

### IP spoofing - maskování útočníka
Útočník falšuje zdrojovou IP adresu v paketech
- Paket vypadá, že přišel z důvěryhodného zdroje

#### **Využití**
- Obcházení IP-based autentizace
- DDoS útoky (skrytí identity)

#### **Omezení**
- Útočník často nevidí odpovědi

### DNS Spoofing - fake web

Útočník podvrhne DNS odpověď → špatná IP adresa
- Uživatel jde na falešný server => Phishing/malware

**Souvislost**: [DNS cache poisoning](#dns-spoofing)

### [ARP spoofing](#arp-spoofing)

### Email Spoofing
Útočník **falšuje adresu odesílatele e-mailu**

**Výsledek**: e-mail vypadá jako od důvěryhodné osoby/firmy
- Používáno pro phishing, šíření malwaru, BEC (**B**ussiness **E**mail **C**ompromise) útoky

## [DHCP](./03%20-%20počítačové%20sítě.md#dhcp-dynamic-host-configuration-protocol) rogue server

Útočník **spustí falešný DHCP** server v síti
- Reaguje **rychleji než legitimní** DHCP => klienti **přijmou jeho konfiguraci**

#### **Co může podvrhnout**
- Výchozí bránu (gateway = útočník) => [MITM](#man-in-the-middle-mitm)
- DNS server => škodlivé DNS
- IP adresy (chaos v síti)


#### **Obrana**
DHCP snooping (na switchi) - posílat DHCP zprávy mají pouze vybraná zařízení

## [NTP](https://en.wikipedia.org/wiki/Network_Time_Protocol) (**N**etwork **T**ime **P**rotocol) Spoofing

Útočník **podvrhne odpovědi z NTP serveru**
- Manipulace s časem

#### **Dopady**
- Neplatné certifikáty (HTTPS může selhat)
- Selhání autentizace (tokeny, Kerberos)
- Zmatené logy => forenzní analýza je těžší

#### **Time shifting útoky**
- Zneužití časových závislostí (**expirace session**)
- Obcházení bezpečnostních mechanismů


#### **Obrana**
- Autentizovaný NTP server
- Více NTP serverů

## Replay Attack
Útočník **zachytí komunikaci a znovu ji přehraje**

1. Zachytí autentizační paket / request
2. Později ho znovu odešle
3. Systém ho považuje za platný

#### **Zneužití**
- Opakované přihlášení bez znalosti hesla
- Opakování platební transakce

#### **Obrana**
- **Nonce** - Jednorázové hodnoty
- Timestamps
- Kryptografické podpisy


---

# Útoky narušující dostupnost (Availability)

## Denial of Service (DoS)
Vyčerpat zdroje serveru nebo sítě
- Z jednoho zdroje (narozdíl od DDoS)

### SYN flood
Zneužívá TCP handshake (3-way handshake)
- Pošle pouze TCP SYN, server odpoví ACK
  - Útočník nepošle ACK, spojení zůstane otevřené

**Výsledek**: Server drží velké množství polovičních spojení => legit klienti se nepřipojí

### UDP port
Útočník posílá obrovské množství UDP paketů na různé porty

**Výsledek**: Server musí kontrolovat porty a často odpovídat ICMP
- Zahlcení CPU nebo síťové linky

### ICMP Flood
Masivní množství ICMP Echo Request (ping)

**Výsledek**
- Zahlcení sítě nebo zařízení
- Systém tráví čas odpovídáním

### Slowloris
„Pomalý“ aplikační útok na HTTP server.

1. Útočník otevře mnoho HTTP spojení
2. Posílá data velmi pomalu
3. Nikdy request nedokončí

**Výsledek**
- Server drží spojení otevřená
- Vyčerpání počtu dostupných spojení

### HTTP Flood
Velké množství HTTP požadavků (`GET`/`POST`)

**Výsledek**: Zatížení web serveru, databáze, backendu

### Distributed Denial of Service (DDoS)

Útočník posílá velké množství legitimně vypadajících HTTP požadavků
- `GET /index.html` tisíckrát za vteřinu

#### **Často cílí na**
- Databáze
- Dynamické stránky (náročné na výkon)



## Distributed denial of service (DDoS)
DoS z mnoha zařízení najednou
- Obtížně se blokuje - více nebezpečný než DoS

### Botnet
Síť infikovaných zařízení - počítače, IoT, kamery
- Řízené útočníkem (C2 servery)

#### **Výsledek**
- Masivní škálování útoku
- Obtížná identifikace zdroje

### Amplification útoky (zesilovací)

Útočník zneužívá servery třetích stran pro zesílení útoku

1. Útočník pošle malý požadavek
2. Podvrhne (spoofuje) IP adresu oběti
3. Server odpoví velkou odpovědí na oběť

#### **DNS Amplification**
- Využívá otevřené DNS servery
- Malý dotaz => velká odpověď (seznam záznamů, ...)

#### **NTP amplification**
[CludFlare článek](https://www.cloudflare.com/learning/ddos/ntp-amplification-ddos-attack/)

Využívá otevřené NTP servery (např. `monlist` command)
- [NTP monlist](https://security.stackexchange.com/questions/151446/what-was-is-the-purpose-of-the-monlist-command-in-ntp)

**Nebezpečné při velkém počtu serverů**

## Resource Exhaustion
Cílem není jen síť zahltit, ale vyčerpat konkrétní interní zdroje
- Paměť, tabulky, IP adresy, MAC adresy


### [DHCP](./03%20-%20počítačové%20sítě.md#dhcp-dynamic-host-configuration-protocol) Starvation – vyčerpání DHCP poolu

Útočník posílá velké množství `DHCP Discover` zpráv
- Používá falešné MAC adresy

DHCP server přiděluje IP adresy => Pool se rychle vyčerpá
- Legitimní klienti nedostanou IP adresu

### ARP Table Flooding

Útočník posílá velké množství ARP odpovědí
- Mapuje IP na falešné MAC adresy

#### **Výsledek**
- Přepisování legitimních záznamů
  - Zpomalení komunikace
  - MITM útoky
  - Nedostupnost zařízení

### CAM Table Overflow
CAM tabulka = mapování MAC na port na switchi

1. Útočník posílá rámce s náhodnými MAC adresami
2. Switch ukládá MAC adresy do CAM tabulky
3. Tabulka se zaplní

#### **Výsledek**
Switch přepne do režimu broadcast
- Hub-like behavior

#### **Dopad**
- Zahlcení sítě
- Odposlech provozu (sniffing)
- Zhoršení výkonu

---

# Útoky na bezdrátové sítě

## Wi-Fi zabezpečení

### WEP (**W**ired **E**quivalent **P**rivacy)
RC4 šifrování
- Dnes zcela zastaralé a nebezpečné
  - Polomitelné do několika minut

#### **Typické útoky**
- Zachytávání paketů (sniffing)
- Statistická analýza - útočník získá heslo velmi rychle

### WPA (**W**i-Fi **P**rotected **A**ccess)

Přechodná náhrada za WEP
- Používá [TKIP](https://en.wikipedia.org/wiki/Temporal_Key_Integrity_Protocol) (**T**emporal **K**ey **I**ntegrity **P**rotocol)

**Výhody**: Dynamická změna klíčů
  - lepší integrita dat

**Slabiny**: stále používá RC4 (jen upravený)

#### **Útoky**
- Slovníkové útoky na heslo
- Útoky na TKIP (např. injekce paketů)

### WPA2
Dlouho používaný standard bezpečnosti Wi-Fi
- Používá [AES](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard) + [CCMP](https://en.wikipedia.org/wiki/CCMP_(cryptography))
- AES = **A**dvanced **E**ncryption **S**tandard
- CCMP = (**C**ounter Mode **C**ipher Block Chaining **M**essage Authentication Code **P**rotocol)

**Výhody**: Silné šifrování
- Bezpečné při správném nastavení

**Slabiny**: Slabá hesla -> slovníkové útoky
- Zranitelnost handshake

[KRACK](#krack-key-reinstallation-attack) (**K**ey **R**einstallation **A**ttacks) útok
- Zneužívá 4-way handshake

### WPA3

Používá SAE (**S**imultaneous **A**uthentication of **E**quals)

#### **Výhody**
- Ochrana proti slovníkovým útokům
- Forward secrecy
- Lepší ochrana i při slabším hesle

**Slabiny**: zatím méně rozšířené, implementační chyby
- (např. Dragonblood útoky)

## Útoky na Wi-fi
### Deauthentication attack
**Cíl**: odpojit zařízení od Wi-Fi

#### **Princip**
1. Útočník posílá falešné deauthentication rámce
    - Nejsou u starších standardů dostatečně chráněné
2. Klient věří, že ho odpojil legitimní access point
3. Zařízení se odpojí
    - Znovu se připojuje, lze odchytit handshake

### [Evil Twin](#evil-twin)

### WPS attack (zneužití WPS PIN)
- WPS = **W**i-Fi **P**rotected **S**etup

WPS používá 8místný PIN
- PIN se ověřuje ve dvou částech -> menší počet kombinací
- Umožňuje brute-force útok


#### **Výsledek**
- Útočník zjistí správný PIN -> získá WPA/WPA2 heslo

### Handshake capture + brute-force
Útočník zachytí se 4-way handshake
- Často se kombinuje s deauth útokem
- Crackování probíhá offline:
  - Slovníkový útok
  - Brute-force

### KRACK (Key Reinstallation Attack)

**Princip**: útok na proces handshake
- Znovupoužití šifrovacího klíče (key reinstallation)

**Dopad**: dešifrování komunikace
- Manipulace s daty

## Nástroje

### `aircrack-ng`
Komplexní sada nástrojů pro Wi-Fi audit
- [Wiki](https://www.aircrack-ng.org/doku.php?id=Main)

#### **Umožňuje**
- Zachytávání paketů
- Analýzu sítí
- Cracking WEP/WPA/WPA2
- Práci v monitor mode

#### Deauth attack
`aireplay-ng -0 1 -a 00:14:6C:7E:40:80 -c 00:0F:B5:34:30:30 ath0`
- `-0`: Deauthorizační útok
- `-N` (`-1`): Počet deautorizačních paketů
- `-a`: Adresa access pointu
- `-c`: Adresa klienta (deautorizuje všechny klenty, pokud není uvedeno)
- `ath0`: Interface


### `wifite`
Automatizovaný nástroj nad `aircrack-ng`
- Jednoduché použití

Umožňuje automatické:
- Deauth útoky
- Zachycení handshake
- Cracking hesel

---
# Password útoky

## Brute Force:

### Slovníkový útok (dictionary attack)
Útočník používá seznam běžných hesel

**Výhoda**: Rychost
**Nevýhoda**: Nefunguje na složitá hesla

### Kombinatorický útok
Zkouší všechny možné kombinace znaků
- `a`, `b`, `c` ... => `aa`, `ab`, `ac`, ...

**Výhoda**: Najde jakékoliv heslo

**Nevýhoda**: Extrémně pomalý (exponenciální růst)

### Hybrid útok

Kombinace slovníku + modifikací
- `password` -> `Password123!`

Velmi efektivní v praxi
- Lidé často používají „upravená“ hesla

## Rainbow tables 🌈
Útočník má předpočítané hashe běžných hesel
- Místo výpočtu jen hledá shodu
- Funguje jen bez dodatečné ochrany

### Ochrana – Salt
Ke každému heslu se přidá náhodná hodnota (salt)
- Výsledný hash je unikátní

**Výsledek**: Rainbow tables jsou prakticky nepoužitelné

## Credential Stuffing
**Cíl**: Zneužít uniklá přihlašovací data

1. Útočník má databázi:
    - email + heslo (z úniků)
2. Zkouší je na jiných službách
    - Uživatelé často používají stejné heslo všude

# Reconnaissance a scanning
**Cíl**: získat co nejvíce informací o systému, síti nebo organizaci

## Pasivní reconnaissance
Bez přímého kontaktu s cílem

### [OSINT](https://osintframework.com/)
Sběr veřejně dostupných informací

#### **Vřejné zdroje**
- Webové stránky firmy
- Sociální sítě
- Veřejné databáze
- GitHub repozitáře

#### **Co lze zjistit**
- Zaměstnance
- Technologie
- Emaily
- Strukturu firmy

### DNS enumeration

Zjišťování DNS záznamů

**Výsledek**: mapování infrastruktury

### WHOIS lookup
Dotaz na databázi domén

#### **Co zjistíš**
- Vlastník domény
- Kontaktní údaje
- DNS servery

**Užitečné pro**: Identifikaci organizace

## Aktivní reconnaissance

Přímý kontakt s cílem -> lze detekovat

### [Port scanning](./04%20-%20průzkum%20a%20diagnostika%20sítě.md) - `nmap`

### [Service enumeration](./04%20-%20průzkum%20a%20diagnostika%20sítě.md#service-scan)

### Vulnerability scanning
Hledání zranitelností

Automatizované skenery
- Nessus, OpenVAS
- [Nmap skripty](./04%20-%20průzkum%20a%20diagnostika%20sítě.md#nmap-script-engine)

#### **Co hledat**
- Známé chyby (CVE)
- Špatné konfigurace
- Zastaralý software


---

# Ochrana a detekce
**Cíl**: Zabránit útoku ještě předtím, než nastane

## Šifrování

Ochrana dat před odposlechem

### TLS/SSL
Transport Layer Security / SSL:
- Šifrování komunikace (např. HTTPS)

### VPN
Bezpečný tunel přes internet

## Silná autentizace (MFA)
Vícefaktorové ověření
- Heslo + SMS / aplikace / biometrie

**Výsledek**: I při úniku hesla je účet chráněný

### Segmentace sítě (VLAN)

Rozdělení sítě na menší části

**Výhody**: Omezení šíření útoku
- Lepší kontrola provozu

### Port security

Omezení počtu MAC adres na portu switchi
- Ochrana proti [CAM overflow](#cam-table-overflow), neautorizovaným zařízením

### 802.1X autentizace
Síťová autentizace zařízení před přístupem
- Zařízení musí být ověřeno (certifikát)

**Výsledek**: Pouze autorizovaní uživatelé v síti




## Detekce
**Cíl**: Včas odhalit útok nebo podezřelé chování

### IDS/IPS systémy
**IDS** (**I**ntrusion **D**etection **S**ystem)
- Detekuje útoky

**IPS** (**I**ntrusion **P**revention **S**ystem)
- Detekuje a blokuje útoky

**Sledují**
- Známé signatury
- Podezřelé chování

### SIEM (**S**ecurity **I**nformation and **E**vent **M**anagement)

Sběr a analýza logů z:
- Serverů
- Firewallů
- Aplikací

**Výsledek**: Korelace událostí
- Odhalení komplexních útoků

### Honeypot

„Návnada“ pro útočníky

**Cíl**: Přilákat útočníka
- Možnost sledovat jeho chování

**Výhoda**: odhalení nových útoků

### Monitoring anomálií

Sledování odchylek od normálního chování
- Náhlý nárůst provozu, neobvyklé přihlášení




## Reakce (Response)
### Incident Response Plan
Předem definovaný postup

#### **Obsah**
- Identifikace incidentu
- Eskalace
- Řešení
- Komunikace

### Izolace kompromitovaných systémů
Odpojení napadených zařízení ze sítě
- Zabrání šíření útoku, dalším škodám

### Forenzní analýza
**Cíl**: zjistit:
- Jak útok proběhl
- Co bylo zasaženo
- Jak tomu zabránit příště
