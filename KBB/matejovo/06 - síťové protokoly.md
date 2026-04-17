# 06 - Síťové protokoly

1. [06 - Síťové protokoly](#06---síťové-protokoly)

2. [Protokoly obecně](#protokoly-obecně)
   1. [Co jsou to protokoly a k čemu slouží](#co-jsou-to-protokoly-a-k-čemu-slouží)
   2. [TCP/IP model](#tcpip-model)
   3. [Nástroje pro práci s protokoly](#nástroje-pro-práci-s-protokoly)
      1. [`ping` - ICMP](./03%20-%20počítačové%20sítě.md#testování-konektivity-ping-ipdomena)
      2. [`nc` (netcat) - TCP/UDP](./04%20-%20průzkum%20a%20diagnostika%20sítě.md#netcat)
      3. [`curl` - HTTP](#httphttps---hypertext-transfer-protocol)

3. [TCP/UDP](#tcpudp)
   1. [TCP - Transmission Control Protocol](#tcp---transmission-control-protocol)
      1. [Vlastnosti a principy](#vlastnosti-a-principy)
      2. [Three way handshake](#three-way-handshake)
      3. [Spolehlivý přenos dat](#spolehlivý-přenos-dat)
   2. [UDP - User Datagram Protocol](#udp---user-datagram-protocol)
      1. [Vlastnosti a principy](#vlastnosti-a-principy-1)
      2. [Nespolehlivý přenos](#nespolehlivý-přenos)
   3. [TCP vs UDP](#tcp-vs-udp)

4. [DHCP (Dynamic Host Configuration Protocol)](#dhcp-dynamic-host-configuration-protocol)
   1. [DHCP handshake (DORA)](#dhcp-handshake-dora)
   2. [DHCP server vs klient](#dhcp-server-vs-klient)

5. [DNS (Domain Name Service)](#dns-domain-name-service)
   1. [Princip](#princip)
   2. [Hierarchie](#hierarchie)
   3. [Druhy záznamů](#druhy-záznamů)
   4. [Nástroje](#nástroje)
      1. [`nslookup` - jednoduchý lookup tool](#nslookup---jednoduchý-lookup-tool)
      2. [`dig` - pokročilý nástroj](#dig---pokročilý-nástroj)
      3. [`host` - rychlý, jednoduchý](#host---rychlý-jednoduchý)
   5. [Diagnostika problémů s DNS resolverem](#diagnostika-problémů-s-dns-resolverem)

6. [ARP (Address Resolution Protocol)](#arp-address-resolution-protocol)
   1. [Mapování IP na MAC adresy](#mapování-ip-na-mac-adresy)
   2. [Zobrazení ARP tabulky](#zobrazení-arp-tabulky)
   3. [ARP tabulka/cache](#arp-tabulkacache)

7. [ICMP - Internet Control Message Protocol](#icmp---internet-control-message-protocol)
   1. [Typy ICMP zpráv](#typy-icmp-zpráv)
   2. [`ping`](#ping)
   3. [`traceroute`](#traceroute)
   4. [Diagnostika síťových problémů](#diagnostika-síťových-problémů)

8. [NTP - Network Time Protocol](#ntp---network-time-protocol)
   1. [Stratum - hierarchie NTP serverů](#stratum---hierarchie-ntp-serverů)
   2. [NTP server vs klient](#ntp-server-vs-klient)
   3. [Konfigurace v Linuxu](#konfigurace-v-linuxu)
      1. [`chrony`](#chrony)
      2. [`systemd-timesyncd`](#systemd-timesyncd)
   4. [Time shifting útoky](#time-shifting-útoky)
   5. [Ochrana proti útokům](#ochrana-proti-útokům)

9. [SSH - Secure Shell](#ssh---secure-shell)
   1. [Autentizace (heslo, klíče)](#autentizace-heslo-klíče)
   2. [SSH tunelování](#ssh-tunelování)
   3. [SCP a SFTP](#scp-a-sftp)
      1. [SCP - Jednoduché](#scp---jednoduché)
      2. [SFTP - Interaktivní](#sftp---interaktivní)
   4. [Instalace a konfigurace OpenSSH Server](#instalace-a-konfigurace-openssh-server)

10. [HTTP(S) - HyperText Transfer Protocol](#https---hypertext-transfer-protocol)
    1. [HTTP metody](#http-metody)
    2. [Stavové kódy](#stavové-kódy)
    3. [HTTPS - HTTP Secure](#https---http-secure)
       1. [Průběh spojení](#průběh-spojení)
       2. [Šifrování (TLS/SSL)](#šifrování-tlsssl)
       3. [Certifikáty](#certifikáty)
    4. [HTTP vs HTTPS](#http-vs-https)

11. [VPN (Virtual Private Network) protokoly](#vpn-virtual-private-network-protokoly)
    1. [OpenVPN](#openvpn)
    2. [WireGuard](#wireguard)
    3. [IPsec](#ipsec)
    4. [L2TP - Kombinace s IPsec](#l2tp---kombinace-s-ipsec)

12. [(Ne)bezpečné protokoly pro vzdálenou správu](#nebezpečné-protokoly-pro-vzdálenou-správu)
    1. [Bezpečné protokoly](#bezpečné-protokoly)
       1. [`RDP` - Remote Desktop Protocol](#rdp---remote-desktop-protocol)
    2. [Nebezpečné protokoly](#nebezpečné-protokoly)
       1. [`telnet` - Předchůdce SSH](#telnet---předchůdce-ssh)

13. [Ostatní protokoly](#ostatní-protokoly)
    1. [`SMTP`](#smtp)
    2. [`POP3 / IMAP`](#pop3--imap)

# Protokoly obecně
## Co jsou to protokoly a k čemu slouží
**Soubor pravidel**, podle kterých spolu zařízení komunikují
- Jak se data **odesílají a přijímají**
- Jak jsou **data strukturována** (formát)
- Jak se řeší **chyby při přenosu**
- Jak se **zařízení identifikují**

## TCP/IP model
[Vysvětlení](./03%20-%20počítačové%20sítě.md#tcpip-model)

![TCP/IP model](./assets/tcp-ip.png)

## Nástroje pro práci s protokoly
### [`ping`](./03%20-%20počítačové%20sítě.md#testování-konektivity-ping-ipdomena) - [ICMP](./04%20-%20průzkum%20a%20diagnostika%20sítě.md#icmp-internet-control-message-protocol)

`ping google.com`
- Odešle ICMP echo a čeká na odezvu => zjistíme
  - Jestli je druhá strana dostupná
  - Latence odezvy
  - Packet loss

### [`nc`](./04%20-%20průzkum%20a%20diagnostika%20sítě.md#netcat) (netcat) - TCP/UDP
Základní nástroj pro TCP nebo UDP komunikaci

### `curl` - HTTP
Utilitka pro posílání HTTP požadavků

`curl -X GET google.com/`

---

# TCP/UDP

## TCP - **T**ransmission **C**ontrol **P**rotocol
### Vlastnosti a principy
Connection oriented - nejdřív se naváže spojení
- Spolehlivý přenos
- Pomalejší než UDP

### Threee way handshake
> `SYN`, `ACK`, `RST` jsou flagy (bity) v hlavičce paketu

1. **Klient**: Pošle `SYN` paket na server
    - **"Chci komunikovat"**
2. **Server**: Odpoví `SYN` + `ACK` paketem
    - **"Souhlasím"**
3. **Klient**: `ACK` pro potvrzení
    - **"Potvrzuji"**
4. Začne přenos dat

### Spolehlivý přenos dat

TCP zajišťuje spolehlivý přenos dat:
- Doručení všech dat
- Správné pořadí paketů
- Opakované odeslání při ztrátě
- Řízení toku (flow control)
- Řřízení zahlcení (congestion control)
- Kontrola chyb
- Používá potvrzování (`ACK`)

## UDP - **U**ser **D**atagram **P**rotocol
### Vlastnosti a principy
- Connectionless – žádné navazování spojení
- Rychlý přenos
- Žádná kontrola doručení
- Žádné potvrzování
- Žádné zajištění pořadí 

### Nespolehlivý přenos
Pakety se mohou:
- Ztratit
- Dorazit v jiném pořadí

Neprobíhá žádná oprava

**Minimální režie = vyšší rychlost**

## TCP vs UDP
| Vlastnost | TCP | UDP |
| ------------- | --------- | ---------- |
| Spojení | Ano | Ne |
| Spolehlivost | Vysoká | Nízká |
| Rychlost | Pomalejší | Rychlá |
| Kontrola chyb | Ano | Ne |
| Pořadí paketů | Zachováno | Nezaručeno |

**TCP** => Důležitá spolehlivost
- Web (HTTP(S))
- Email
- Přenos souborů

**UDP** => Rychlost přednostní před spolehlivostí
- Streamování videí
- ...

---

# DHCP (**D**ynamic **H**ost **C**onfiguration **P**rotocol)
Automaticky přiděluje IP adresu a konfiguruje zařízení
- IP adresa, maska sítě, default gateway, defaultní DNS server, atd.

## DHCP handshake (DORA (the explorer :D))
1. **D**iscover  
    **„Je tu nějaký DHCP server?“**

    Zařízení pošle "Je tu nějaký DHCP server?"


2. **O**ffer  
    **„Mohu ti přidělit tuto IP adresu.“**

    DHCP server odpovídá
    - Odpověď obsahuje:
      - Navrhovanou **IP** adresu
      - **Lease** (doba propůjčení adresy)
      - atd.


3. **R**equest
    **„Tuto IP adresu přijímám.“**

    Zařízení adresu přijme
    - Vybere si jeden server pokud jich odpovědělo víc


4. **A**cknowledge  
    **„IP adresa je tvoje.“**

    Server potvrdí připsání IP adresy

[**Konfigurace**](./03%20-%20počítačové%20sítě.md#konfigurace-dhcp)


## DHCP server vs klient
**Server**: Přiděluje IP adresy, spravuje rozsah adres (pool)
- Typicky router, dedikovaný server

**Klient**: Žádá o IP adresu a připojení do sítě
- Počítač, mobil, tiskárna

---

# DNS (**D**omain **N**ame **S**ervice)

## Princip
Překlad jmen domén na IP adresy:
1. Lookup v lokálním cache
2. Pokud nenalezeno, dotaz jde na **rekurzivní DNS server** (ISP nebo veřejný)
3. DNS server vyhledá IP adresu nebo dotaz předá jinému DNS serveru
4. Server pošle IP adresu zpátky

## Hierarchie
1. **Root** servery
    - Neznají konkrétní adresy
    - Ukazují na TLD servery
2. **TLD** (**T**op-**L**evel **D**omain)
    - Spravují koncovky (`.cz`, `.com`, ..)
    - Koncovku `.cz` spravuje `CZ.NIC`
3. Autoritativní servery
    - Poskytují finální odpověď

Dotaz -> `Root` -> `TLD` -> `Autoritativní` -> odpověď


## Druhy záznamů

**`A`**: Doménu na `IPv4` adresu
- `google.com` -> `8.8.8.8`

**`AAAA`**: Doménu na `IPv6` adresu

**`CNAME`** (**C**anonical **NAME**)
- Alias domény: `www.google.com` -> `google.com`

**MX** (**M**ail e**X**change)
- Určuje poštovní server pro danou doménu
  - `...@example.com` je spravováno na doméně `mail.example.com`

**PTR** (Pointer)
- Opak `A` a `AAAA` záznamů
- Umožňuje tzv. reverse dns lookup, tedy adresu na doménu

**SOA** (**S**tart **O**f **A**uthority)
- Označuje, že daný DNS server je autoritou pro určitou zónu

**NS** (**N**ame**S**erver)
- určuje, který DNS server je autoritativní pro danou doménu


**TXT**: Textové info
- SPF (ochrana proti spamům)
- DKIM (ověření emailu)
- Ověření vlastnictví domény (např. pro Google služby)

[**Konfigurace**](./03%20-%20počítačové%20sítě.md#konfigurace-dns)

## Nástroje
### `nslookup` - jednodychý lookup tool
`nslookup google.com`

### `dig` - pokročilý nástroj
`dig google.com`
Zobrazí
- Odpověď serveru
- Čas (latence)
- DNS záznamy

### `host` - rychlý, jednoduchý
`host google.com`

## Diagnostika problémů s DNS resolverem

Typické problémy
- Stránka se nenačte
- Chyba „server nenalezen“
- Pomalé načítání

### Řešení
1. Otestovat DNS: `nslookup example.com`
    - Pokud funguje, test není v DNS
2. Jiný DNS server
    - Např: `8.8.8.8` (google) nebo `1.1.1.1` (cloudflare)
3. Vyčistit DNS cache: `sudo resolvectl flush-caches`
4. Ověřit připojení: `ping 8.8.8.8`
    - Pokud funguje => chyba v DNS
5. Zkontrolovat konfiguraci
    - Špatně nastavený DNS server
    - Problém v routeru

---

# ARP (**A**dress **R**esolution **P**rotocol)

Převést IP adresu na MAC adresu

## Mapování IP na MAC adresy

1. Podívá se do ARP tabulky (cache), když v ní je zařízení zaznamenané, pošle paket
2. Když zařízení v tabulce není, pošle **ARP request**: `Who has 192.168.33.174?`
3. Cílové zařízení **odpoví**: `192.168.33.174 is at c4:f7:c1:6b:9c:71`
4. MAC adresa se uloží do tabulky
5. Odešle data

## Zobrazení ARP tabulky

Databáze záznamů o IP a MAC adresách zařízení v lokální síti

Záznamy:
- **Dynamic**: vytvoří se automaticky
- **Static**: Nastaveny manuálně

## ARP tabulka/cache

Dočasná paměť, kde si zařízení ukládá IP <-> MAC mapování
- Zrychluje komunikaci (nemusí se pořád ptát)
- Záznamy mají časovou platnost (timeout)

---

# ICMP - **I**nternet **C**ontrol **M**essage **P**rotocol

Diagnostika, hlášení chyb a řízení komunikace
- Hlášení chyb: nedostupný server
- Diagnostiku sítě: testování dostupnosti a latence
- Řízení toku dat: upozornění na přetížení

## Typy ICMP zpráv
**Chybové zprávy**
- Destination Unreachable: Cílový host nebo síť není dostupná  
- Time Exceeded: Vypršel TTL (traceroute)  
- Redirect: Router doporučuje lepší cestu

**Informační zprávy**
- Echo request/reply: ping
- Timestamp: Měření času (málo používané)

## `ping`
1. Pošle se **Echo Request** - "ping"
2. Cílové zařízení odpoví **Echo Reply** - "pong"

Informace
- Dostupnost zařízení (odpovídá/neodpovídá)
- Latenci (RTT) – čas odezvy
- Ztrátovost paketů

## `traceroute`

Využívá postupně zvyšované TTL

Každý router
- Sníží TTL o 1
- Při TTL = 0 zahodí paket a pošle ICMP Time Exceeded

**Výsledek**
- Seznam routerů (hopů), přes které paket prochází
- U každého hopu je vidět latenci


## Diagnostika síťových problémů
1. Nedostupný server -> Destination Unreachable
2. Vysoká latence -> pomalá síť
3. Kde se paket ztratí -> `traceroute`
4. Firewall blokuje ICMP -> ping nefunguje


---

# NTP - **N**etwork **T**ime **P**rotocol

**Umožňuje**
- Synchronizovat se s přesnými časovými zdroji (atomové hodiny, GPS)
- Kompenzovat zpoždění sítě (latenci)
- Postupně upravovat čas

**Používá**
- UDP port 123
- Algoritmy pro výpočet:
- Offset (rozdíl času)
- Delay (zpoždění)
- Jitter (kolísání)

## Stratum - hierarchie NTP serverů

**Stratum 0**: Referenční zdroje (atomové hodiny, GPS)

**Stratum 1**: Synchronizováno se stratum 0

**Stratum 2**: Synchronizováno se stratum 1

...

**Stratum 15**: Nejnižší použitelná vrstva

**Stratum 16**: Nesynchronizováno

## NTP server vs klient

**Klient**: Dotazuje se serveru na čas
- Upravuje svůj systémový čas

**Server**: Poskytuje čas dalším klientům
- Synchronizuje se s nadřazenými servery

## Konfigurace v Linuxu

Možnosti: `chrony`, `ntpd` (zastaralé), `systemd-timesyncd`

### `chrony`
1. Installace: `sudo apt install chrony`
2. Konfigurace: `sudo nano /etc/chrony/chrony.conf`
    - `server 0.pool.ntp.org iburst`
    - `server 1.pool.ntp.org iburst`
3. Kontrola: `chronyc sources`
    - A `chronyc tracking`

### `systemd-timesyncd`
1. Zapnutí: `timedatectl set-ntp true`
2. Kontrola: `timedatectl status`

## Time shifting útoky
Útočník změní čas na zařízení

**Důsledky**
- Neplatné TLS certifikáty
- Špatné logy (forenzní problém)
- Selhání autentizace (Kerberos je citlivý na čas)
- Problémy v distribuovaných systémech

**Jak útok probíhá**
- Podvržené NTP odpovědi (MITM)
- Falešný NTP server
- DNS spoofing (přesměrování na útočníka)

## Ochrana proti útokům
**Autentizace NTP**
- Symetrické klíče (MD5/SHA)
- NTS (Network Time Security) – moderní řešení

**Omezení přístupu**
- Firewall (povolit jen důvěryhodné servery)
- Nepovolit veřejné dotazy (u serverů)

**Použití více serverů**
- Klient porovnává více zdrojů
- Ignoruje odlehlé hodnoty

**Monitorování**
- Změn času
- Offsetu
- Podezřelých skoků

**Interní NTP infrastruktura**
- Jeden důvěryhodný server v síti
- Ostatní zařízení synchronizují z něj

---

# SSH - **S**ecure **SH**ell

Bezpečný vzdálený přístup k systému

## Autentizace (heslo, klíče)

**Heslo**
- Uživatel zadá login + heslo
- Jednoduché, ale méně bezpečné


**SSH klíče** (doporučeno)
- Asymetrická kryptografie:
  - Privátní klíč (u klienta)
  - Veřejný klíč (na serveru)
- Vyšší bezpečnost

**Připojení na server**: `ssh user@server`
- Např: `ssh student@192.168.1.43`

**Specifikace portu**: `ssh --p <port> user@server`

## SSH tunelování

Umožňuje přesměrovat síťový provoz


**Lokální tunel**: `ssh -L 8080:localhost:80 user@server`

**Remote tunel**: `ssh -R 9090:localhost:3000 user@server`

**Dynamický tunel**: `ssh -D 1080 user@server`
- SOCKS proxy

## SCP a SFTP

### SCP - Jednoduché

**Local -> server**: `scp soubor.txt user@server:/home/user/`
- Zkopíruje `soubor.txt` na server (`/home/user/soubor.txt`)

**Server -> local**: `scp user@server:/home/user/soubor.txt .`
- Stáhne `/home/user/soubor.txt`

### SFTP - Interaktivní

**Příkazy**: `cd`, `ls`, `get`, `put`

`sftp user@server`

## Instalace a konfigurace OpenSSH Server

**Instalace**
- `sudo apt update`
- `sudo apt install openssh-server`

**Stav**: `sudo systemctl status ssh`

**Konfigurace**
- `vim /etc/ssh/sshd_config`

### Bezpečnostní nastavení

**Zakázat root login**: `PermitRootLogin no`  
**Zakázat hesla** (jenom klíče): `PasswordAuthentication no`  
**Změnit port**: `Port 2222`  
**Pouze konkrétní uživatelé**: `AllowUsers user1 user2`  
**Omezit pokusy o přihlášení**: `MaxAuthTries 3`

---

# HTTP(**S**) - **H**yper**T**ext **T**ransfer **P**rotocol

Port `80`

Princip request -> response
1. Klient (prohlížeč) pošle požadavek (request)
2. Server odpoví (response)

**Vlastnosti**
Bezstavový (stateless) -> každý požadavek je nezávislý
- Běží typicky na portu 80
- Nešifrovaný


**Request**: `curl -X GET example.com/index.html`
- ```http
  GET /index.html HTTP/1.1
  Host: example.com
  ```

**Response**
- ```http
  HTTP/1.1 200 OK
  Content-Type: text/html

  <data>
  ```

## HTTP metody

**`GET`**: Získání dat (nemění stav serveru)
- Např: Načtení stránky

**`POST`**: Odeslání dat na server (vytváří nový zdroj)
- Např: Formulář

**`PUT`**: Aktualizace nebo vytvoření zdroje
- Přepisuje celý obsah

**`DELETE`**: Odstranění zdroje
- Např: Smazání uživatele


## Stavové kódy

[HTTP 🐈🐈🐈🐈](https://http.cat/)

**`1xx`**: Informativní
- `100` (Continue)

**`2xx`** – Úspěch
- `200` OK
- `201` CREATED

**`3xx*`**: Přesměrování
- `301` Moved Permanently
- `302` Found

**`4xx`** – Chyba klienta
- `400` Bad Request
- `401` Unauthorized
- `403` Forbidden
- `404` Not Found

**`5xx`** – Chyba serveru
- `500` Internal Server Error
- `502` Bad Gateway
- `503` Service Unavailable


## HTTPS - HTTP **S**ecure

Port `443`

### Průběh spojení

1. **Klient se připojí** na server
2. **Server pošle certifikát**
3. Klient **ověří certifikát**
4. Proběhne **výměna klíčů** (handshake)
5. Vznikne šifrovaný kanál

### Šifrování (TLS/SSL)
Zajišťuje:
- Důvěrnost (nikdo nevidí obsah)
- Integritu (data nebyla změněna)
- Autenticitu (ověření serveru)


### Certifikáty


Digitální dokument potvrzující identitu serveru, obsahuje:
- Doménu
- Veřejný klíč
- Podpis autority

Vydávají certifikační autority (`CA`):
- Let's Encrypt
- DigiCert

#### **Ověření certifikátu**

Prohlížeč kontroluje:
- Zda certifikát vydala důvěryhodná CA
- Zda sedí doména
- Zda není expirovaný

### HTTP vs HTTPS
| Vlastnost | HTTP | HTTPS |
| ---------- | --------- | -------- |
| Šifrování | Ne | Ano |
| Bezpečnost | nízká | vysoká |
| Port | 80 | 443 |
| Použití | testování | produkce |

---

# VPN (**V**irtual **P**rivate **N**etwork) protokoly

**Šifrovaný tunel** mezi dvěma stranami
- Bezpečný přístup, anonymita nebo propojení poboček

## OpenVPN
**Vlastnosti**:
- Využívá TLS
- Běží nad UDP (často port 1194) nebo TCP
- Silné šifrování (AES, ChaCha20)
- Autentizace pomocí:
  - Certifikátů
  - Uživatelského jména/hesla

**Výhody**
- Velmi bezpečný
- Flexibilní (funguje téměř všude, i přes firewally)

**Nevýhody**
- Složitější konfigurace
- Vyšší režie -> pomalejší než moderní protokoly

## WireGuard

Novější alternativa zaměřená na jednoduchost a výkon

**Vlastnosti**
- Používá moderní kryptografii: ChaCha20, Curve25519
- Běží nad UDP
- Velmi malý kód -> méně chyb


**Výhody**
- Rychlost
- Jednoduchá konfigurace
- Vysoká bezpečnost

**Nevýhody**
- Méně funkcí než OpenVPN
- Statické klíče (méně flexibilní identity)

## IPsec
Sada protokolů pro zabezpečení IP komunikace

**Režimy**
- Transport mode: Šifruje jen payload
- Tunnel mode: 3ifruje celý paket (typické pro VPN)

**Typy použití**
- Site-to-site: Propojení dvou sítí (pobočky firmy)
- Client-to-site: Vzdálený přístup uživatele


**Komponenty**
- **AH** (Authentication Header) – integrita
- **ESP** (Encapsulating Security Payload) – šifrování

**Výhody**
- Standardizované řešení
- Široká podpora (routery, firewally)

**Nevýhody**
- Složitá konfigurace
- Problémy s NAT (řeší NAT-T)

## L2TP (**L**ayer 2 **T**unnel **P**rotocol) - Kombinace s IPsec

Zapouzdřuje data do tunelu, nešifruje data

**Jak to funguje**
- L2TP vytvoří tunel
- IPsec zajistí šifrování


**Výhody**
- Jednoduché nasazení
- Podpora v OS (Windows, Linux, mobilní zařízení)

**Nevýhody**
- Pomalejší (dvojité zapouzdření)
- Dnes považováno za zastaralejší řešení

---

# (Ne)bezpečné protokoly pro vzdálenou správu

## Bezpečné protokoly
[**`SSH`**](#ssh---secure-shell)  
[**`SFTP`**](#sftp---interaktivní)  
[**`HHTPS`**](#https---http-secure)  

### **`RDP`** - **R**emote **D**esktop **P**rotocol
Bezpečné s TLS

Vzdálená plocha (Windows)

Při správném nastavení:
- Šifrování TLS
- Network Level Authentication (NLA)

## Nebezpečné protokoly

**`FTP`**: Nešifrované `sftp`
**`HTTP`**: Nešifrovaná komunikace


### `telnet` - Předchůdce ssh
Přenos dat v otevřeném textu

Hesla lze snadno odposlechnout


---

# Ostatní protokoly

[**`(S)FTP`**](#sftp---interaktivní): Přenos souborů  


### `SMTP`**
Odesílání e-mailů

E-mailoví klienti -> server
- Servery mezi sebou

**Porty**
- `25`: Mezi servery
- `587`: Klient -> server (submission)
- `465`: SMTPS (šifrovaný)

### `POP3` / `IMAP`
Příjem e-mailů

`POP3`: Stáhne e-maily do zařízení
- Často je maže ze serveru

`IMAP`: Pracuje přímo se zprávami na serveru
- Synchronizace mezi více zařízeními






