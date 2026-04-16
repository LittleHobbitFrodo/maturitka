# 11 - Virtualizace a kontejnerizace

1. [11 - Virtualizace a kontejnerizace](#11---virtualizace-a-kontejnerizace)
2. [Virtualizace](#virtualizace)
   1. [Typy virtualizace](#typy-virtualizace)
      1. [Plná virtualizace](#plná-virtualizace)
      2. [Paravirtualizace](#paravirtualizace)
      3. [Hardwarová virtualizace](#hardwarová-virtualizace)
   2. [Hypervizory](#hypervizory)
      1. [Typ 1 - Baremetal](#typ-1---baremetal)
      2. [Typ 2 - Hosted](#typ-2---hosted)
   3. [Komponenty VM](#komponenty-vm)
      1. [Virtuální hardware](#virtuální-hardware)
      2. [Snapshoty](#snapshoty)
   4. [Síťování ve virtualizaci](#síťování-ve-virtualizaci)
      1. [NAT - Překlad adres přes host](#nat---překlad-adres-přes-host)
      2. [Bridged (most)](#bridged-most)
      3. [Host-only](#host-only)
      4. [Internal](#internal)

3. [Kontejnerizace](#kontejnerizace)
   1. [VM vs kontejner](#vm-vs-kontejner)
      1. [Virtuální stroj (VM)](#virtuální-stroj-vm)
      2. [Kontejner](#kontejner)

4. [Docker](#docker)
   1. [Základní koncepty](#základní-koncepty)
   2. [Základní příkazy](#základní-příkazy)
   3. [Dockerfile - Instrukce](#dockerfile---instrukce)
   4. [Volumes - Persistentní data](#volumes---persistentní-data)

5. [Networking v dockeru](#networking-v-dockeru)
   1. [Bridge network (výchozí)](#bridge-network-výchozí)
   2. [Host network](#host-network)
   3. [Overlay network - clustery](#overlay-network---clustery)

6. [Docker compose](#docker-compose)
   1. [Příkazy](#příkazy)

7. [Kubernetes (K8s)](#kubernetes-k8s)
   1. [Základní koncepty](#základní-koncepty-1)
      1. [Pod](#pod)
      2. [Service](#service)
   2. [Deployment](#deployment)
      1. [Namespace](#namespace)

8. [Bezpečnost virtualizace a kontejnerů](#bezpečnost-virtualizace-a-kontejnerů)
   1. [Bezpečnost VM](#bezpečnost-vm)
   2. [VM Escape](#vm-escape)
   3. [Hardening (zabezpečení)](#hardening-zabezpečení)
   4. [Bezpečnost kontejnerů](#bezpečnost-kontejnerů)
      1. [Image security](#image-security)
      2. [Runtime security](#runtime-security)
         1. [bezpečnostní mechanismy Linuxu](#bezpečnostní-mechanismy-linuxu)
      3. [Bezpečnostní rizika](#bezpečnostní-rizika)

9. [Využití v kybernetické bezpečnosti](#využití-v-kybernetické-bezpečnosti)
   1. [Izolované testovací prostředí](#izolované-testovací-prostředí)
   2. [Reprodukovatelnost](#reprodukovatelnost)
   3. [Honeypoty](#honeypoty)
      1. [Nasazení pomocí kontejnerů](#nasazení-pomocí-kontejnerů)


# Virtualizace

Vytvořit „virtuální počítač“ uvnitř skutečného počítače
- Fyzický hardware (CPU, RAM, disk) se „rozdělí“ na více částí
- Každá část se tváří jako samostatný počítač
- Více operačních systémů současně

**Abstrakce hardwaru**: Software „schová“ skutečný hardware a vytvoří virtuální

**Izolace prostředí**
- Každá VM je oddělená
- Když se jedna pokazí, ostatní fungují dál


## Typy virtualizace

### Plná virtualizace

Stroj simuluje celý hardware  
Operační systém uvnitř VM neví, že je ve virtuálu
- Není potřeba ho upravovat

**Příklad:** Linux ve virtuálu na Windows

**Výhody**: Kompatibilita (funguje skoro vše)  
**Nevýhody:** Pomalejší (protože se HW „napodobuje“)

### Paravirtualizace

Operační systém je upravený - komunikuje přímo s virtualizační vrstvou (hypervisorem)

**Výhody**: Vyšší výkon než plná virtualizace  
**Nevýhody**: Upravený OS (nelze použít každý)

### Hardwarová virtualizace

**Virtualizace přímo v CPU**
- Procesor má speciální funkce jako: `Intel VT-x`, `AMD-V`

**Výhody**
- Vysoký výkon
- Není potřeba upravovat OS

## Hypervizory

**Hypervizor**: Software, který umožňuje virtualizaci – vytváří a spravuje virtuální stroje
- Prostředník mezi hardwarem a virtuálními počítači

### Typ 1 - Baremetal

Přímo na fyzickém hardware
- Nemá klasický operační systém pod sebou
- Rychlejší a efektivnější

**Příklady**
- VMWare ESXi
- Microslop Hyper-V
- Xen
- KVM

**Použití**: servery, datacentra, cloud (např. hostingy)

**Výhody**
- Vysoký výkon
- Lepší bezpečnost


### Typ 2 - Hosted

Program v operačním systému
- Na OS běží hypervisor jako aplikace

**Příklady**
- VirtualBox
- WMWare workstation

**Použití**
- Vývoj
- Testování
- Běžné použití na PC

**Výhody**: Jednoduché na instalaci

**Nevýhody**: Nižší výkon než baremetal

## Komponenty VM

### Virtuální hardware

**vCPU** (virtuální procesor) - Kolik „výkonu CPU“ VM dostane  
**vRAM** (virtuální paměť) - Kolik operační paměti VM používá  
**Virtuální disk** (VHD, VMDK apod.) - Soubor, který se chová jako pevný disk  
**Virtuální síťová karta**: Umožňuje připojení k síti/internetu  
**Virtuální řadiče** (storage controllers): Řídí komunikaci s disky (např. SATA, SCSI)

### Snapshoty

Uložení aktuálního stavu VM

**Ukládá**:
- Obsah RAM
- Stav disku
- Konfiguraci

**Umožňuje**
- Návrat zpět (rollback)
- Bezpečné testování
- Dočasná „záloha“

**Příklad použití**
1. Uděláš snapshot
2. Nainstaluješ malware
3. Po analýze vrátíš zpět

**Výhody**
- Rychlé obnovení
- Ideální pro experimenty


## Síťování ve virtualizaci
### NAT - Překlad adres přes host
VM má soukromou IP adresu
  - Komunikace jde ven přes hosta (překlad adres)
  - Z internetu se na VM přímo nedostaneš
  - Nejčastější konfigurace

**Výhody**: Funguje hned, bezpečné
**Nevýhoda**: Horší přístup zvenčí

### Bridged (most)
VM je jako normální počítač v síti
- Dostane IP ze stejné sítě jako host
- Ostatní zařízení ho vidí

**Výhoda**: Plná komunikace
**Nevýhody**: Méně bezpečné, závislé na síti

### Host-only

Izolovaná síť mezi hostem a VM
- VM <-> host komunikují
- Internet nedostupný

**Výhoda**: Bezpečné testování
**Nevýhoda**: Bez přístupu ven

### Internal

Jen mezi virtuálními stroji
- VM komunikují mezi sebou
- Bez přístupu k internetu nebo hostovi

**Výhoda**: Úplná izolace

---

# Kontejnerizace

**Izolované prostředí**, ve kterém běží aplikace
- Sdílí kernel hostitelského OS
  - Mnohem lehčí než virtuální stroj

**„U mě to funguje" přestává být problém**

**Obsahuje**
- Samotnou aplikaci
- Knihovny a závislosti
- Konfiguraci

Nejsou oddělené pomocí celého OS, ale pomocí funkcí jádra:
- `namespaces`: Oddělení procesů, sítě, souborů
- `cgroups`: Omezení CPU, RAM

## VM vs kontejner

### Virtuální stroj (VM)
1. Vlastní OS
2. Běží přes hypervisor
3. Větší nároky na RAM a CPU
4. Pomalejší start (sekundy až minuty)

**Použití**
- Různé operační systémy
- Silná izolace

### Kontejner

1. Sdílí kernel hosta
2. Neobsahuje celý OS
3. Malý a rychlý (start v ms–sekundách)


**Použití**
- Mikroservisy
- Nasazení aplikací
- DevOps

---

# Docker

## Základní koncepty

**Image** - „Šablona“ pro kontejner
- Obsahuje aplikaci + knihovny + konfiguraci
- Read-only
- Image s Ubuntu + `Node.js`

**Container** - Běžící instance image
- Vlastní procesy, síť, filesystem

**Dockerfile**: Textový soubor s instrukcemi, jak postavit kontejner
- Automatizuje build

**Registry**: Úložiště imagů
- Např DockerHub - [`hub.docker.com`](https://hub.docker.com/)


## Základní příkazy

[Cheatsheet](https://docker.how/)

**PULL**: Stáhne image
- `docker pull nginx`

**RUN**: Spustí image -> vytvoří kontejner
- `docker run -d -p 8080:80 nginx`
  - `-d` (detach): Spustí na pozadí
  - `-p` (port mapping): `host:cont.` -> Namapuje port z kontejneru na host
  - `nginx`: Jméno image
  - `--name`: Pojmenuje kontejner
  - `-it`: Interaktivní režim (terminál)
    - `docker run -it ubuntu bash` spustí bash

**PS**: Výpis běžících kontejnerů
- `docker ps`
  - `-a`: I zastavené
  - `--filter "status=exited"`: Filtruje kontejneru
  - **Output**:
    - ID kontejneru
    - Image
    - Porty
    - Stav

**BUILD**: Vytvoří image z Dockerfile
- `docker build -t myapp:1.0 .`
  - `-t`: Name and tag
  - `.`: Path k dockerfile

**START**: Spustí existující kontejner
- `docker start my_container`
  - `run`: Vytvoří nový
  - `start`: Spustí existující

**RM/RMI**: Smaže kontejner/image
- `docker rm web`: Smaže kontejner `web`
- `docker rmi nginx`: Smaže image nginx

## Dockerfile - Instrukce

**FROM**: Základní/base image
- `FROM ubuntu`

**RUN**: Spustí příkaz
- `RUN apt update`

**COPY/ADD**: Kopírování souborů do image
- `COPY ./config.json /app`: Přidá `./config.json` do `/app` (uvnitř kontejneru)
  - `COPY`: Jednoduché kopírování souborů, nic víc
  - `ADD`: "Chytřejší verze" - rozbalí archivy, Stáhne z url, atd.

**EXPOSE**: Otevře port pro vnější prostředí
- `EXPOSE 80`

**CMD / ENTRYPOINT**: Příkaz při spuštění kontejneru
- `CMD ["node", "app.js"]`
- `CMD`: Lze přepsat při `docker run ...`
  - Např `docker run myimage python app.py` spustí `python app.py` místo daného `CMD`
- `ENTRYPOINT`: Nelze přepsat

## Volumes - Persistentní data

**Také umí**
- Sdílení mezi kontejnery
- Propojení s hostem

**Typy**
- Volume (spravované Dockerem)
- Bind mount (napojení složky z hosta)

`docker run -v /data:/app/data`
- `-v HOST:CONTAINER`: Nabinduje bind mount volume

---

# Networking v dockeru

## Bridge network (výchozí)

Docker vytvoří **virtuální síť** (bridge) na hostiteli
- Každý kontejner dostane vlastní IP adresu
- Kontejnery spolu komunikují uvnitř této sítě
- Zvenku přes port mapping

**Příklad**
- Kontejner běží web na portu 80
- Port mapping na hostu na port 8080

**Výhody**
- Izolace (bezpečnější)
- Jednoduché použití

**Nevýhoda**: Musíš mapovat porty

## Host network
Kontejner sdílí síť přímo s hostitelem
- Žádná izolace sítě
- Kontejner používá stejnou IP jako host
- Nepotřebuješ port mapping

Aplikace běží na portu 80 -> běží rovnou na hostovi

## Overlay network - clustery

Hlavně Docker Swarm nebo Kubernetes
- Spojuje kontejnery na více různých serverech
- Vytváří virtuální síť přes více hostitelů
- Kontejnery spolu komunikují, jako by byly na jedné síti

**Výhody**
- Ideální pro cluster / distribuované aplikace
- Transparentní komunikace mezi kontejnery

**Nevýhody**
- Složitější nastavení
- Menší výkon než host network

---

# Docker compose

**Yaml soubor pro automatizaci nasazení** více kontejnerů
- Definice multi-kontejnerových aplikací (např. web + databáze)
- Konfigurace v jednom souboru (docker-compose.yml)
- Jednoduchá orchestrace více služeb

```yaml
version: "3.8"

services:
  db:   # kontejner databáze
    image: mysql:8
    environment:
      MYSQL_ROOT_PASSWORD: root
      MYSQL_DATABASE: testdb

  web:  # kontejner web serveru
    image: nginx
    ports:
      - "8080:80"
    depends_on: # db se spusí první
      - db
```

## Příkazy

`docker compose up`: Spustí všechny služby  
`docker compose down`: Zastaví a odstraní všechny kontejnery

---

# Kubernetes (K8s)

Automaticky:
- Orchestrace kontejnerů
  - Ve velkém: více clusterů/serverů
- Škálování
- Self-healing (když něco spadne, automaticky to restartuje)
- Load balancing

## Základní koncepty
### Pod
Jeden nebo více kontejnerů
- Sdílí: síť (IP), storage
- Nespouštíš kontejnery přímo, ale Pody

### Service
Zajišťuje přístup k Podům
- Dává jim stálou IP / DNS jméno
- Funguje jako load balancer
- Pody se často mění -> zajišťuje stabilní přístup

## Deployment

Definuje „desired state“
- Kolik Podů má běžet
- Jaký image použít
- Kubernetes to automaticky udržuje

### Namespace

Logické rozdělení clusteru
- Odděluje např. projekty / týmy
- `dev`, `test`, `prod`, ...

---

# Bezpečnost virtualizace a kontejnerů

## Bezpečnost VM
**Izolace**: VM běží jako „počítač v počítači“
- Hostitel k němu nemá přímý přístup (jen přes hypervisor)
- Když je VM napadený, hostitel by měl zůstat bezpečný

**Oddělení VM mezi sebou**: Každá VM má vlastní OS, paměť, procesy
- Navzájem se nevidí, pokud to explicitně nepovolíš

## VM Escape

**Největší bezpečnostní hrozba**
- Útok, kdy se útočník dostane **z VM -> do hypervisoru -> na hostitele**
- Vzácné ale velmi nebezpečné

## Hardening (zabezpečení)

1. **Aktualizace hypervisoru**
    - Pravidelné update opravují bezpečnostní chyby
      - Kvůli VM escape
2. **Omezení sdílených prostředků**
    - Vypnout nebo omezit:
      - Sdílené složky
      - Clipboard (copy-paste mezi hostem a VM)
      - USB passthrough
3. **Síťová segmentace**

## Bezpečnost kontejnerů

### Image security

**Důvěryhodné base images**
- Používej oficiální nebo ověřené image (např. z Docker Hubu)
- Vyhýbej se náhodným neznámým repozitářům

**Skenování zranitelností**
- Kontrola image na známé chyby (CVE)
- Nástroje: [`Trivy`](https://trivy.dev/), [`Clair`](https://clairproject.org/) (open source)

**Minimalizace velikosti image**
- Menší image = méně balíčků = méně zranitelností
- Alpine images

### Runtime security

**Neprivilegované kontejnery**
- Nespouštět jako root
- Root v kontejneru = větší riziko útoku na hostitele

**Read-only filesystem**
- Zakáže zápis do souborového systému
- Útočník nemůže upravit aplikaci nebo nahrát malware

**Resource limits**
- Omezení CPU a RAM
- DoS útokům - „sežrání“ všech zdrojů

#### **bezpečnostní mechanismy Linuxu**

**Seccomp** (**SEC**ure **COMP**uting Mode)
- Omezuje systémová volání (syscalls)

**AppArmor**: Kontroluje přístup k souborům

**SELinux** (**S**ecurity **E**nhanced **L**inux)
- Pokročilé řízení přístupů

### Bezpečnostní rizika

**Escape z kontejneru**
- Horší než u VM - sdílí kernel
- Útok z kontejneru na hostitele


**Zranitelnosti v base image**
- Staré knihovny = bezpečnostní díry
- Řešení: pravidelné rebuildy image

**Špatná konfigurace**
- Běh jako root
- Otevřené porty
- Žádné limity

**Secrets management**
- Hesla, API klíče
- Ukládat do:
  - Environment variables
  - Docker secrets
  - Kubernetes secrets

---

# Využití v kybernetické bezpečnosti

## Izolované testovací prostředí

**Sandboxing malware**
- Spouštíš malware v izolovaném prostředí a sleduješ jeho chování
- VM nebo kontejner

**Penetrační testování**
- Testování zranitelností systémů
- Často ve VM (oddělení od reálného systému)
  - Nebo v kontejnerech (rychlé spuštění)

**Bezpečná analýza**
- Analýza podezřelých souborů, exploitů, síťového provozu
- Pak VM smažeš nebo resetuješ -> čistý stav

## Reprodukovatelnost
Velká výhoda kontejnerů

**Konzistentní prostředí**
- „funguje u mě“ problém mizí
- Všichni mají stejné knihovny a verze

**CI/CD pro bezpečnostní nástroje**
- **CI/CD**: **C**ontinuous **I**ntegration and **C**ontinuous **D**elivery/Deployment
  - Automatizace (např) buildu a deploymentu
- **Automatické testování** bezpečnosti
- **Bezpečnost se kontroluje průběžně**, ne až na konci
- Např:
  - Skenování image (Trivy)
  - Kontrola závislostí
  - Automatické testy

## Honeypoty

Systém, který láká útočníky

### Nasazení pomocí kontejnerů
**Rychlé vytvoření falešné služby (např. SSH, web)**

**Rychlá obnova**
- Když je honeypot kompromitován:
  - Smažeš kontejner
  - Spustíš nový
- Minimální dopad























