# 11 - Virtualizace a kontejnerizace


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

# TODO










