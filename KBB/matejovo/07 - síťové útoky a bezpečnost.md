# 07 - Síťové útoky a bezpečnost

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

# Útorky narušující Důvěrnost

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


# **TODO**



