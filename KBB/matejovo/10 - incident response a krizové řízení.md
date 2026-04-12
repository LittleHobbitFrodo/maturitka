# 10 - Incident Response a krizové řízení

1. [10 - Incident Response a krizové řízení](#10---incident-response-a-krizové-řízení)
2. [Úvod do Incident Response](#úvod-do-incident-response)
   1. [Co je bezpečnostní incident](#co-je-bezpečnostní-incident)
   2. [Proč je IR důležité](#proč-je-ir-důležité)
3. [Fáze Incident Response](#fáze-incident-response)
   1. [1. Příprava - Preparation](#1-příprava---preparation)
      1. [Incident Response plán](#incident-response-plán)
      2. [IR tým - CSIRT/CERT](#ir-tým---csirtcert)
   2. [2. Detekce a analýza (Detection & Analysis)](#2-detekce-a-analýza-detection--analysis)
      1. [Zdroje detekce](#zdroje-detekce)
      2. [Klasifikace incidentů](#klasifikace-incidentů)
      3. [Analýza incidentu](#analýza-incidentu)
   3. [3. Omezení (Containment)](#3-omezení-containment)
      1. [Krátkodobé omezení - Okamžitá reakce](#krátkodobé-omezení---okamžitá-reakce)
      2. [Dlouhodobé omezení - Stabilizace situace](#dlouhodobé-omezení---stabilizace-situace)
   4. [4. Odstranění (Eradication)](#4-odstranění-eradication)
      1. [Identifikace příčiny](#identifikace-příčiny)
      2. [Odstranění hrozby](#odstranění-hrozby)
   5. [5. Obnova (Recovery)](#5-obnova-recovery)
      1. [Obnovení systémů](#obnovení-systémů)
      2. [Návrat do produkce](#návrat-do-produkce)
   6. [6. Poučení (Lessons Learned)](#6-poučení-lessons-learned)
      1. [Post-incident review](#post-incident-review)
      2. [Dokumentace](#dokumentace)
4. [Krizová komunikace](#krizová-komunikace)
   1. [Interní komunikace](#interní-komunikace)
   2. [Externí komunikace](#externí-komunikace)
   3. [Zásady krizové komunikace](#zásady-krizové-komunikace)
5. [CSIRT / CERT](#csirt--cert)
   1. [Typy týmů](#typy-týmů)
   2. [Národní a sektorové týmy](#národní-a-sektorové-týmy)
6. [Playbooks a Runbooks](#playbooks-a-runbooks)
   1. [Incident Response Playbook](#incident-response-playbook)
   2. [Příklady playbooků](#příklady-playbooků)
7. [Metriky a KPIs](#metriky-a-kpis)
8. [Právní aspekty](#právní-aspekty)
   1. [Povinnosti hlášení](#povinnosti-hlášení)
   2. [Zachování důkazů](#zachování-důkazů)

# Úvod do Incident Response
## Co je bezpečnostní incident

**Incident**: Událost **narušující bezpečnost** systému
- Narušující např:
  - [Důvěrnost](./07%20-%20síťové%20útoky%20a%20bezpečnost.md#c---confidentiality-důvěrnost): Někdo získá data, která neměl vidět
  - [Integritu](./07%20-%20síťové%20útoky%20a%20bezpečnost.md#i---integrity): Data jsou změněna nebo poškozena
  - [Dostupnost](./07%20-%20síťové%20útoky%20a%20bezpečnost.md#a---availability-dostupnost): Systém nebo služba nefunguje
- Každý incident je event (ne naopak)
- Příklady: **Malware**, **Únik dat**, **DDoS**, **Neoprávněný přístup**

**Event**: Běžná událost (např. přihlášení uživatele)

## Proč je IR důležité

**Minimalizace škod** – Čím rychlejší reakce, tím menší dopad  
**Rychlá obnova provozu** – Firma funguje dál  
**Splnění zákonů a regulací**: např. GDPR
**Ochrana reputace** –Ffirma neztratí důvěru zákazníků

---

# Fáze Incident Response

## 1. Příprava - Preparation
Nejdůležitější fáze – bez ní se incident řeší chaoticky

### Incident Response plán

**Popisuje jak reagovat na incidenty**

Obsahuje
- **Postupy** (krok za krokem)
- **Role** a odpovědnosti
- **Kontakty** (kdo se volá při problému)
- **Eskalační matice** (kdy se problém „posouvá výš“)

### IR tým - CSIRT/CERT

**2 specializované týmy**:
- **CSIRT**: **C**omputer **S**ecurity **I**ncident **R**esponse **T**eam  
- **CERT**: **C**omputer **E**mergency **R**esponse **T**eam

**Řeší**:
- Analýzu incidentu
- Koordinaci reakce
- Komunikaci (interní i externí)

**Typy týmů**
- Interní (ve firmě)
- Externí (outsourcovaný tým)

Důležité je pravidelné školení a cvičení (simulace útoků)

## 2. Detekce a analýza (Detection & Analysis)

**Odhalit incident** a pochopit, co se vlastně stalo

### Zdroje detekce

**SIEM systémy a logy**
- SIEM (**S**ecurity **I**nformation and **E**vent **M**anagement)
  - Sbírá a vyhodnocuje logy

**IDS / IPS alerty**
- **IDS**: **I**ntruison **D**etection **S**ystems
  - Identifikuje potenciální hrozby a zranitelnosti
- **IPS**: **I**ntrusion **P**revention **S**ystem
  - Dynamická řešení sbírající a analyzující podezřelý traffic

**Uživatelská hlášení**
- Např. „nejde mi počítač“, „přišel divný e-mail“

**Threat intelligence**
- Informace o aktuálních hrozbách
  - Nové viry
  - IP adresy útočníků

### Klasifikace incidentů

**Závažnost (Severity)**:
- Kritická – Velký dopad (např. výpadek firmy)
- Vysoká
- Střední
- Nízká

**Typy incidentů**
- Malware
- Phishing
- DoS / DDoS
- Insider threat (útok zevnitř firmy)

**Prioritizace**: Co řešit hned a co může počkat

### Analýza incidentu

Co, kdy, kde, jak?

**Rozsah kompromitace**: Jak moc je systém napadený  
**Zasažené systémy**: Které počítače / servery jsou problém  
**Časová osa (timeline)**: Kdy útok začal a jak se šířil


## 3. Omezení (Containment)

Zastavit šíření útoku a zabránit větším škodám

### Krátkodobé omezení - Okamžitá reakce
**Izolace systémů**: Odpojení napadeného PC/serveru od sítě  
**Blokování komunikace**: Např. zablokování škodlivé IP adresy  
**Zachování důkazů**: Logy, paměť, soubory (důležité pro analýzu)

### Dlouhodobé omezení - Stabilizace situace
**Dočasná řešení**: Např. náhradní server, omezený provoz  
**Monitoring**: Sledování, jestli se útok nešíří dál


## 4. Odstranění (Eradication)
Úplně odstranit příčinu incidentu

### Identifikace příčiny
**Root Cause Analysis**: Hledání hlavní příčiny problému
- Např. nezáplatovaný systém, slabé heslo

**Nalezení všech napadených systémů**: Aby se na nic nezapomnělo (jinak se útok vrátí)

### Odstranění hrozby
**Odstranění malware**: Antivir, forenzní nástroje, ruční zásah  
**Uzavření zranitelností**: Aktualizace systému, oprava chyb  
**Reset účtů**: Změna hesel, zneplatnění kompromitovaných přístupů

## 5. Obnova (Recovery)
Vrátit systémy zpět do normálního provozu

### Obnovení systémů
**Obnova ze záloh**: Nejčistší řešení  
**Reinstalace systémů**: Pokud je systém silně napadený  
**Ověření integrity**: Kontrola, že je vše v pořádku a bezpečné

### Návrat do produkce
**Postupné spouštění služeb**: Ne všechno najednou (aby se problém nevrátil)  
**Zvýšený monitoring**: Sledování podezřelé aktivity  
**Validace funkčnosti**: Testování, že vše funguje správně

## 6. Poučení (Lessons Learned)

### Post-incident review
1. Co se stalo a proč
2. Co fungovalo dobře
3. Co selhalo
4. Co zlepšit do budoucna

### Dokumentace
**Incident report**: Detailní popis incidentu  
**Aktualizace postupů**: Zlepšení IR plánu  
**Sdílení poznatků**: Tým i organizace se poučí

---

# Krizová komunikace
**Jak správně komunikovat během incidentu**, aby nevznikla panika a škody nebyly ještě větší

## Interní komunikace

**Informování managementu**: Vedení musí vědět, co se děje a jak vážné to je  
**Koordinace týmů**: IT, bezpečnost, právníci, PR musí spolupracovat  
**Eskalační postupy**: Kdy a komu se problém „posouvá výš“

## Externí komunikace
**Zákazníci / klienti**: Informovat o problému (např. únik dat)  
**Média a PR**: Kontrola informací, aby nevznikly fámy  
**Regulátoři a úřady**: Povinné hlášení incidentů
- NÚKIB - **N**árodní **Ú**řad pro **K**ibernetickou a **I**nformační **B**ezpečnost
- ÚOOÚ - **Ú**řad pro **O**chranu **O**sobních **Ú**dajů

## Zásady krizové komunikace
**Včasnost a transparentnost**: Nečekat, ale zároveň nešířit neověřené info  
**Konzistentní messaging**: Všichni říkají to samé (žádné zmatky)  
**Určený mluvčí**: Komunikuje jen jedna osoba (např. PR manažer)

---

# CSIRT / CERT

## Typy týmů

**CERT**: **C**omputer **E**mergency **R**esponse **T**eam
- (Historicky) první oficiální týmy pro řešení incidentů

**CSIRT**: Computer Security Incident Response Team
- Modernější označení (prakticky stejné jako CERT)

**SOC**: **S**ecurity **O**perations **C**enter
- Nepřetržité sledování provozu a událostí
- Detekce hrozeb
- První reakce na incidenty

## Národní a sektorové týmy
**Národní tým**: Spadá pod NÚKIB  
**Sektorové CSIRTy**: Např. pro banky, energetiku, zdravotnictví  
**Mezinárodní spolupráce**: Sdílení informací mezi státy (např. nové hrozby)


---

# Playbooks a Runbooks
Rychle a správně reagovat na incidenty bez zmatku

**Playbook** = scénář pro konkrétní typ incidentu
- Co dělat => Např. izolovat server

**Runbook** = Detailní návod „jak přesně to udělat“
- Jak to udělat technicky => Např. konkrétní kroky a postup izolace


## Incident Response Playbook

Předpřipravené postupy  
Checklist kroků (co udělat krok za krokem)  
Kontakty (kdo se zapojuje)  
Nástroje (co použít)

## Příklady playbooků
Ransomware response - [Rapid7](https://www.rapid7.com/globalassets/_pdfs/whitepaperguide/rapid7-insightidr-ransomware-playbook.pdf)  
Phishing incident - [Hubspot](https://cdn2.hubspot.net/hubfs/2766624/starkedge-theme-2019/Pdf%20Files/Phishing%20Playbook.pdf)  
Data breach (únik dat) - [CyberAlberta](https://cyberalberta.ca/system/files/data-breach-playbook.pdf)  
DDoS attack - [HaltDOS](https://www.haltdos.com/wp-content/uploads/2025/05/DDoS-Playbook.pdf)

---

# Metriky a KPIs

Hodnocení, jak dobře funguje bezpečnost a IR tým


**MTTD** (**M**ean **T**ime to **D**etect): Jak rychle odhalíme incident  
**MTTR** (**M**ean **T**ime to **R**espond/**R**ecover): Jak rychle reagujeme nebo obnovíme provoz  
**Počet incidentů podle typu**: Přehled hrozeb (např. kolik phishingů)  
**False Positive Rate**: Kolik planých poplachů systém hlásí

---

# Právní aspekty

**Incidenty** nejsou jen technický problém, ale **i právní povinnost**

## Povinnosti hlášení

[**Zákon o kybernetické bezpečnosti**](https://www.zakonyprolidi.cz/cs/2025-264): Povinnost hlásit incidenty (např. vůči NÚKIB)  
**GDPR**: únik osobních údajů musí být nahlášen do 72 hodin (např. vůči ÚOOÚ)  
**Sektorové regulace**: Např. banky, energetika mají vlastní pravidla

## Zachování důkazů
Důležité pro vyšetřování (i soud)

**Chain of custody**: přesný záznam:
- Kdo měl důkaz
- Kdy s ním pracoval
- Jak byl uchován

**Spolupráce s policií**: Orgány činné v trestním řízení