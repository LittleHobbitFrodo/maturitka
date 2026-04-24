# 20 - Forenzní analýza

1. [20 - Forenzní analýza](#20---forenzní-analýza)
2. [Úvod do digitální forenzní analýzy](#úvod-do-digitální-forenzní-analýzy)
   1. [Digitální forenzní analýza](#digitální-forenzní-analýza)
   2. [Cíle forenzní analýzy](#cíle-forenzní-analýzy)
   3. [Typy](#typy)
3. [Sběr a uchování důkazů](#sběr-a-uchování-důkazů)
   1. [Metody sběru důkazů](#metody-sběru-důkazů)
      1. [Bitová kopie vs. logická kopie](#bitová-kopie-vs-logická-kopie)
   2. [Zachování integrity důkazů](#zachování-integrity-důkazů)
4. [Analýza logů](#analýza-logů)
   1. [Typy logů](#typy-logů)
   2. [Logy v Linuxu](#logy-v-linuxu)
   3. [Logy ve Windows](#logy-ve-windows)
   4. [Analýza logů](#analýza-logů-1)
5. [Forenzní nástroje](#forenzní-nástroje)
   1. [Vytváření obrazů - Imaging](#vytváření-obrazů---imaging)
   2. [Analýza souborových systémů](#analýza-souborových-systémů)
   3. [Analýza paměti (RAM)](#analýza-paměti-ram)
   4. [Síťová forenzika](#síťová-forenzika)
6. [Forenzní postupy](#forenzní-postupy)
7. [Indicators of Compromise (IOC)](#indicators-of-compromise-ioc)
   1. [Typy IOC](#typy-ioc)
   2. [Sdílení IOC](#sdílení-ioc)
8. [Dokumentace a reporting](#dokumentace-a-reporting)
   1. [Obsah forenzního reportu](#obsah-forenzního-reportu)


# Úvod do digitální forenzní analýzy
## Digitální forenzní analýza
**Vědecká disciplína zabývající se sběrem a analýzou digitálních důkazů**

**Využívá se zejména při**
- Vyšetřování kybernetických útoků
- Odhalování trestné činnosti
- Interních firemních kontrolách
- Soudních řízeních


## Cíle forenzní analýzy
**Identifikace bezpečnostního incidentu**  
**Určení rozsahu napadení** (kompromitace)  
**Zjištění způsobu útoku** (např. malware, phishing)  
**Identifikace útočníka** (pokud je to možné)  
**Vytvoření časové osy událostí** (timeline)


## Typy
**Počítačová forenzika**: Analýza počítačů, disků, souborů  
**Síťová forenzika**: Analýza síťového provozu  
**Mobilní forenzika**: Analýza mobilních zařízení  
**Cloudová forenzika**: Analýza cloudových prostředí  
**Paměťová forenzika**: Analýza operační paměti (RAM)

---

# Sběr a uchování důkazů
## Metody sběru důkazů
**Live acquisition**: Sběr dat **z běžícího systému**
- Umožňuje získat volatilní data (RAM, procesy)
- Riziko změny dat

**Dead acquisition**: Sběr dat z vypnutého zařízení
- Bezpečnější, ale bez přístupu k RAM


**Forenzní obraz** (image): Přesná kopie datového média

### Bitová kopie vs. logická kopie

**Bitová kopie**: Kopíruje všechna data
- (i smazaná, nealokovaný prostor)

**Logická kopie**: Pouze viditelné soubory

## Zachování integrity důkazů

Aby byly důkazy použitelné u soudu, musí být nezměněné

**Hashovací funkce**: Např. MD5, SHA-256
- Slouží k ověření, že data nebyla změněna

**Write-blocker**: Zařízení, které zabrání zápisu na disk

**Práce s kopiemi**: Analýza probíhá pouze na kopii
  - Aby se originál nikdy nezměnil

---

# Analýza logů
## Typy logů
**Systémové logy**: Informace o běhu operačního systému  
**Aplikační logy**: Logy jednotlivých programů  
**Bezpečnostní logy**: Přihlášení, pokusy o přístup  
**Síťové logy**: Firewall, proxy, IDS/IPS  
**Webové logy**: Přístupy na web (access log, error log)

## Logy v Linuxu
**Hlavní adresář: `/var/log/`**

**Nástroj**: `journalctl` - Práce se `systemd` logy

**Důležité soubory**
- `/var/log/syslog`
- `/var/log/messages`
- `/var/log/auth.log`: Přihlášení
- `/var/log/secure`: Bezpečnostní události


## Logy ve Windows
**Prohlížeč událostí** - Event Viewer

**Základní logy**
- **Security**: Bezpečnostní události
- **System**: Systémové události
- **Application**: Aplikační logy

## Analýza logů

**Sleduje se**
- **Aanomálie**: Neobvyklé chování
- **Podezřelé vzorce**: Opakované pokusy o přihlášení, atd.
- **Korelace událostí**: Propojení více logů
- **časová osa** (timeline): Rekonstrukce průběhu incidentu

---

# Forenzní nástroje
## Vytváření obrazů - Imaging

**`dd`**: Základní nástroj v Linuxu
- Vytváří **bitovou kopii disku**
- Jednoduchý, ale bez pokročilých funkcí

**`dcfldd`**: Rozšířená verze dd
- Podporuje výpočet hashů během kopírování
- Umožňuje logování průběhu

**FTK Imager**: GUI nástroj pro windows
- Jednoduché použití
- Podporuje tvorbu image i analýzu

## Analýza souborových systémů
**[Autopsy](https://www.autopsy.com/)**: Open-source nástroj
- Grafické rozhraní
- Vhodný pro začátečníky i pokročilé

**[Sleugh kit](https://sleuthkit.org/)**: Sada příkazových nástrojů
- Často používána spolu s Autopsy

**[FTK](https://www.exterro.com/ftk-downloads)** (**F**orensics **T**ool**K**it): Profesionální nástroj
- Pokročilé funkce analýzy

**[EnCase](https://www.opentext.com/products/forensic)**: Komerční nástroj používaný policií
- Široké možnosti analýzy a reportingu

## Analýza paměti (RAM)

**[Volatility](https://volatilityfoundation.org/)**: Nejpoužívanější nástroj
- Analýza procesů, síťových spojení, DLL apod.


**[Rekall](https://forensics.wiki/rekall/)**: Alternativa k Volatility
- Rychlejší v některých scénářích

## Síťová forenzika

Viz. [Analýza síťového provozu](./05%20-%20analýza%20síťového%20provozu.md)

**[Wireshark](./05%20-%20analýza%20síťového%20provozu.md#wireshark)**: Analýza síťového provozu (`pcap` soubory)


---

# Forenzní postupy

1. **Identifikace**: Rozpoznání bezpečnostního incidentu
    - Určení rozsahu problému
    - Stanovení priority řešení
2. **Izolace**: Odpojení napadených systémů od sítě
    - Zabránění šíření útoku
    - Ochrana ostatních zařízení
3. **Sběr důkazů**: Sběr volatilních dat (RAM, běžící procesy)
    - Vytvoření forenzních obrazů disků
    - Dokumentace prostředí (čas, konfigurace, stav systému)
4. **Analýza**: Detailní zkoumání důkazů
    - Rekonstrukce průběhu útoku
    - Identifikace [IOC](#indicators-of-compromise-ioc)
5. **Dokumentace**: Zaznamenání všech kroků
    - Zachování řetězce důkazů (chain of custody)
    - Vytvoření závěrečného reportu

---

# Indicators of Compromise (IOC)

**Indikátory kompromitace**, tedy stopy, které naznačují, že systém byl napaden

## Typy IOC
**IP adresy a domény** útočníků  
**Hashe souborů** (detekce malware podle hashe)  
**URL adresy**  
**E-mailové adresy**  
**Registry klíče** (Windows)  
**Názvy souborů** a jejich cesty

## Sdílení IOC
**`STIX`/`TAXII`**: Standardy pro sdílení bezpečnostních informací  
**Threat intelligence platformy**: Systémy pro sdílení hrozeb mezi organizacemi  
**MISP** (**M**alware **I**nformation **S**haring **P**latform)
- Open-source platforma
- Sdílení IOC mezi organizacemi
- Spolupráce v oblasti kybernetické bezpečnosti

---

# Dokumentace a reporting

## Obsah forenzního reportu

1. **Executive summary** - Shrnutí
    - Stručný přehled celého incidentu určený i pro netechnické osoby (management)
      - Co se stalo
      - Jaký to mělo dopad
      - Hlavní závěry
2. **Metodologie**
    - Popis použitých postupů a nástrojů
    - Jak byly důkazy získány a analyzovány
    - Zajištění opakovatelnosti (reproducibility)
3. **Časová osa událostí** - Timeline
    - Chronologické seřazení všech důležitých událostí
    - Klíčová část reportu
4. **Nalezené důkazy**: Konkrétní technické nálezy
    - Může zahrnovat:
      - Logy a jejich analýzu
      - Podezřelé soubory
      - Malware (včetně hashů)
      - Síťovou komunikaci
      - [IOC](#indicators-of-compromise-ioc) (indikátory kompromitace)
5. **Závěry a doporučení** - Shrnutí zjištění
    - Jak k incidentu došlo
    - Co bylo zasaženo
    - Jak závažný byl útok
