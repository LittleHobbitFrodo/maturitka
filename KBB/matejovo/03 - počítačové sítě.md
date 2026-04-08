# 03. Počítačové sítě

1. [Historie](#historie)
    1. [Vznik a vývoj](#vznik-a-vývoj)
2. [Technologie a protokoly](#technologie-a-protokoly)
    1. [Packet switching](#packet-switching)
    2. [TCP - Transmission Control Protocol](#tcp---transmission-control-protocol)
    3. [IP - Internet Protocol](#ip---internet-protocol)
3. [TCP/IP model](#tcpip-model)
    1. [Vrstvy](#vrstvy)
4. [IP adresy](#ip-adresy)
    1. [Maska sítě (subnet mask)](#maska-sítě-subnet-mask)
    2. [Síťová adresa](#síťová-adresa)
    3. [Broadcast adresa](#broadcast-adresa)
    4. [IPv4 vs IPv6](#ipv4-vs-ipv6)
    5. [Veřejná vs privátní IP adresa](#veřejná-vs-privátní-ip-adresa)
5. [Porty a protokoly](#porty-a-protokoly)
    1. [Port](#port)
        1. [Známé porty (well-known ports) (0-1023)](#známé-porty-well-known-ports-0-1023)
    2. [Protokoly](#protokoly)
        1. [TCP (Transmission Control Protocol)](#tcp-transmission-control-protocol)
        2. [UDP (User Datagram Protocol)](#udp-user-datagram-protocol)
        3. [Aplikační vrstvy](#aplikační-vrstvy)
            1. [`HTTPS` (443 - TCP)](#https-443---tcp)
            2. [`DNS` (53 - TCP/UDP)](#dns-53---tcpudp)
            3. [`SSH` (22 - TCP)](#ssh-22---tcp)
            4. [`FTP` (21 - TCP)](#ftp-21---tcp)
6. [Routování](#routování)
    1. [Router](#router)
    2. [Routovací tabulka](#routovací-tabulka)
    3. [Statické routování](#statické-routování)
    4. [Dynamické routování](#dynamické-routování)
    5. [Default gateway](#default-gateway)
    6. [Putování paketů](#putování-paketů)
        1. [Lokální síť](#lokální-síť)
        2. [Internet](#internet)
7. [DNS (Domain Name Service)](#dns-domain-name-service)
    1. [Princip](./06%20-%20síťové%20protokoly.md#princip)
    2. [Hierarchie](./06%20-%20síťové%20protokoly.md#hierarchie)
    3. [Druhy záznamů](./06%20-%20síťové%20protokoly.md#druhy-záznamů)
    4. [Konfigurace](#konfigurace)
        1. [DNS resolver](#dns-resolver)
        2. [Lokální DNS cache](#lokální-dns-cache)
        3. [`/etc/hosts`](#etchosts)
        4. [`/etc/resolv.conf`](#etcresolvconf)
8. [DHCP (Dynamic Host Configuration Protocol)](#dhcp-dynamic-host-configuration-protocol)
    1. [DHCP handshake (DORA (the explorer :D))](./06%20-%20síťové%20protokoly.md#dhcp-handshake-dora-the-explorer-d)
    2. [Konfigurace](/06%20-%20síťové%20protokoly.md#konfigurace-1)
9. [Síťování v GNU/Linux](#síťování-v-gnulinux)
    1. [Získání aktuální konfigurace](#získání-aktuální-konfigurace)
        1. [Fyzické rozhraní: `ip link`](#fyzické-rozhraní-ip-link)
        2. [Síťové rozhraní: `ip a`](#síťové-rozhraní-ip-a)
        3. [Routovací tabulka: `ip route`](#routovací-tabulka-ip-route)
        4. [Zjištění default gateway: `ip route | grep default`](#zjištění-default-gateway-ip-route--grep-default)
        7. [Zjištění ARP tabulky: `ip neigh` 🐴](#zjištění-arp-tabulky-ip-neigh-)
    2. [Nastavení síťových rozhraní](#nastavení-síťových-rozhraní)
        1. [Aktivace a deaktivace rozhraní](#aktivace-a-deaktivace-rozhraní)
        2. [Přiřazení, odebrání a změna IP konfigurace](#přiřazení-odebrání-a-změna-ip-konfigurace)
        3. [Zobrazení](#zobrazení)
    3. [Přidání a odebrání routovacích pravidel](#přidání-a-odebrání-routovacích-pravidel)
    4. [Nastavení default gateway](#nastavení-default-gateway)
    5. [Nástroje pro diagnostiku](#nástroje-pro-diagnostiku)
    6. [Testování konektivity: `ping <IP/domena>`](#testování-konektivity-ping-ipdomena)
    7. [Trasování cesty paketů: `traceroute <IP/domena>`](#trasování-cesty-paketů-traceroute-ipdomena)
    8. [Zobrazení síťových spojení](#zobrazení-síťových-spojení)
    9. [Statistiky síťových rozhraní: `ip -s link`](#statistiky-síťových-rozhraní-ip--s-link)
    10. [Zobrazení otevřených portů: `ss -ltn`](#zobrazení-otevřených-portů-ss--ltn)
10. [Konfigurace služeb](#konfigurace-služeb)
    1. [Konfigurace DNS](#konfigurace-dns)
        1. [`/etc/bind/named.conf`](#etcbindnamedconf)
        2. [`/etc/bind/named.conf.options`](#etcbindnamedconfoptions)
        3. [`/etc/bind/named.conf.local`](#etcbindnamedconflocal)
        4. [`/etc/bind/example-com.zone`](#etcbindexample-comzone)
        5. [Restartování služby - aplikace konfigurace](#restartování-služby---aplikace-konfigurace)
    2. [Konfigurace DHCP](#konfigurace-dhcp)
        1. [Instalace](#instalace)
        2. [Výběr interfaců](#výběr-interfaců)
        3. [Autoritativní DHCP server](#autoritativní-dhcp-server)
        4. [DNS servery](#dns-servery)
        5. [Leasing](#leasing)
        6. [Subnety](#subnety)
        7. [Start/Restart serveru](#startrestart-serveru)

---

# Historie
["Brief" history of internet](https://www.internetsociety.org/internet/history-internet/brief-history-internet/)  
[wikipedie](https://en.wikipedia.org/wiki/History_of_the_Internet#1973%E2%80%931989:_Merging_the_networks_and_creating_the_Internet)
## Vznik a vývoj
1. **Výzkumný projekt agenturou ARPA** (**A**dvanced **R**esearch **P**rojects **A**gency)
    - **60. léta**
    - Propojit univerzity a výzkumná centra - (**WAN** - **W**ide **A**rea **N**etwork)
    - Vvytvořit odolnou síť, která by fungovala i při výpadku části infrastruktury
    - [Packet switching](#packet-switching)
    - 1969 - První funkční packetová síť
      - Uzly UCLA, SRI, UCSB, Utah
      - Používal NCP
2. **Přechod na internet**
    - **80. léta**
    - Zavedení [**TCP**](#tcp---transmission-control-protocol)
    - Postupné propojování více síťí (network of networks)
    - Rozvoj univerzitních a výzkumných sítí
3. **W**orld **W**ide **W**eb
    - **90. léta**
    - Vytvořeno v 1989 - **Tim Berners-Lee** (Sir Timothy John Berners-Lee 🤌🤌)
      - HTTP, HTML, URL
    - Masově použitelný internet
4. **Moderní internet**
    - Mobilní internet, cloud, sociální sítě
    - Streamování, 5G, IoT
    - Důraz na bezpečnost a šifrování (HTTP**S**), dostupnost (5G), škálovatelnost


Postupně se síť rozšiřovala i mimo akademický prostor
- V 90. letech se otevřela komerčnímu využití

A stala se globální komunikační infrastrukturou

# Technologie a protokoly

---

## Packet switching
- Rozdělení dat na packety
- Každý packet může jít jinou cestou
- V destinaci se zase složí

## **TCP** - **T**ransmission **C**ontrol **P**rotocol
Zajišťuje bezpečný přenos informací
- pořadí dat, kontrola a oprava chyb
- **UDP** (**U**ser **D**atagram **P**rotocol) zařizuje rychlé spojení bez kontroly chyb

## **IP** - **I**nternet **P**rotocol
Zajišťuje směrování mezi sítěmi
- IPv4 se stal protokolem v roce 1983
  - V budoucnu nahrazen IPv6

---

# TCP/IP model
> Jak jsou data přenášena na internetu
- Praktičnější a jednodušší než **OSI**
- [Random video (actually useful)](https://youtu.be/XIgniNnM1wg?si=ZIl9cPGTuh6Bm4d1&t=173)
- [GeeksForGeeks](https://www.geeksforgeeks.org/computer-networks/tcp-ip-model/)

Zapouzdření dat - každá vrstva přidá vlastní hlavičku

![TCP/IP model](assets/tcp-ip.png)

## Vrstvy
1. **Application**: Bridge mezi nižšímy vrstvami a uživately (př. HTTP, FTP, DNS)
2. **Transport**: Zajišťuje spolehlivý přenos dat
    - Basically [TCP](#tcp---transmission-control-protocol) a UDP
3. **Internet**
    - Adresování: adresace IP
    - Routing: propočítání nejlepší cesty do cíle
    - Fragmentace a znovu-sestavení: větší packety se rozpadnou na menší pro lepší dopravu (sestaví se v cíli)
    - Protokoly: hlavně **IP** podpořené [**ICMP**](https://www.geeksforgeeks.org/computer-networks/internet-control-message-protocol-icmp/) a [**ARP**](https://www.geeksforgeeks.org/ethical-hacking/how-address-resolution-protocol-arp-works/)
4. **Network Access/Link**
    - Zajišťuje přenos dat mezi síťovím hardwarem (kabely, switche, ...)
    - Přístup k hw: posílá jednotlivé bity přes médium
    - MAC adresy: identifikuje zařízení podle MAC adres
    - Kontrola přístupu: řídí způsob, jakým několik zařízení přistupuje k jednomu fyzickému médiu


---

# IP adresy
- **Struktura**
    1. Síťová část: `192.168.10`
    2. Hostitelská část: `200`

## Maska sítě (subnet mask)
- Která část IP adresy patří síti a která zařízení?
- |IP|Maska|
  |--|-----|
  |`192.168.10.200`|`255.255.255.0`|
  |`11000000.10101000.00001010.11001000`|`11111111.11111111.11111111.00000000`|
  -> Síť je `192.168.10.0/24`
## Síťová adresa
- Bit **AND** mezi adresou a její maskou:
- |Stuff|Desítkově|Binárně|
  |-----|---------|-------|
  |IP|192.168.1.34|`11000000.10101000.00000001.00100010`|
  |Maska|255.255.255.0|`11111111.11111111.11111111.00000000`|
  |Síťová|192.168.1.0|`11000000.10101000.00000001.00000000`|

## Broadcast adresa
  - Výpočet: `sitova_adresa | (!mask)`

## IPv4 vs IPv6
**IPv4**: 32 bitů -> **~4.3 miliardy** adres -> **nedostatek**
- Běžně používá **NAT** pro zvýšení počtu adres
- 4 oktety (0..255) => `192.168.10.200/24`

**IPv6**: 128 bitů -> víc než **340 trilionů** adress -> mohlo by stačit :D
- Lepší podpora zabezpečení autoconfigu

- **CIDR** (**C**lassless **I**nter-**D**omain **R**outing) notace
  - `IP_adresa / počet_bitů_sítě` - `192.168.1.0/24`
    - Síť má `24` bitů
    - Host má `32-24` bitů


## Veřejná vs privátní IP adresa
- **Veřejná**: unikátní na celém internetu
  - Přiděluje ISP
- **Privátní**: osobní lokální adresa
  - Pouze v LAN

---

# Porty a protokoly
## Port
Port = identifikátor služby/aplikace na zařízení (číslo `0-65535`)

IP adresa určuje zařízení, port určuje službu
- `192.168.1.10:80` (web. http server na portu 80)

#### Známé porty (well-known ports) (0-1023)

|Port|Služba| Port | Služba|
|----|------|------|-------|
|20/21|`FTP`|80|`HTTP`|
|22|`SSH`|110| `POP3` (email)|
|23|`telnet`|143| `IMAP` (email)|
|25|`SMTP`|442|`HTTPS`|
|53|`DNS`|

## Protokoly

### TCP (**T**ransmission **C**ontrol **P**rotocol)
- [TCP/UDP model](#tcp---transmission-control-protocol)

- Spolehlivý, kontroluje doručení dat
- Spolehlivé navázání spojení (3-way handshake)
- Řídí přenášení paketů
- Pomalejší ale bezpečnější přenos

Použití: HTTP, SSH, FTP, ...

### UDP (**U**ser **D**atagram **P**rotocol)
- Rychlý
- Nezaručuje doručení paketů
- Nenavazuje spojení

Použití: DNS, online hry, streamování, ...


### Aplikační vrstvy
#### `HTTPS` (443 - TCP)
`HTTP` + TLS šifrování
- Bezpečná verze `HTTP`
- Používá certifikáty

#### `DNS` (53 - TCP/UDP)
**D**omain **N**ame **S**ystem
- Překládá jména domén na adresy

#### `SSH` (22 - TCP)
Bezpečné a šifrováné vzdálené přihlášení

#### `FTP` (21 - TCP)
**F**ile **T**ransfer **P**rotocol
- Nahrazen SFTP kvůli bezpečnosti

---

# Routování

## Router
Propojuje různé sítě
- Přeposílá pakety mezi sítěmi
  - Nalézá cestu k cíli

1. Přujmutí paketu
2. Podívá se na cílovou adresu
3. Najde jí v routovací tabulce
4. Najde nejlepší cestu pro paket

## Routovací tabulka
Seznam pravidel, kam posílat pakety
- Vždycky vybere nejpřesnější shodu v tabulce

Zaznamy Obsahují:
- Cílovou síť
- Masku sítě
- Next hop (kterému routeru paket poslat)
- Výstupní rozhraní (ethernet port, ...)

## Statické routování

Nastaveno ručně adminem

Vhodné pro malé sítě

## Dynamické routování

Vyhledávání optimální cesty pomocí protokolu
- Routery si mezi sebou vyměňují informace
- Reakce na změny v síti

Vhodné pro větší sítě (WAN)

Protokoly:
- `RIP` - Cesta s nejméně hopy
- `OSPF` - Dijkstra algo (weighted graph)
- `BGP` - mezi poskytovateli

## Default gateway

„Všechno, co neznám, pošli sem.“
- IP adresa routeru (`192.168.22.1`)
- V rout. tabulce se zapisuje se jako `0.0.0.0`

## Putování paketů
### Lokální síť
- Komputor posílající data: 192.168.2.20
  - Cíl: 142.250.74.36
- Router:
  - Default gateway: 192.168.1.1
  - IP adresa: 85.160.12.34

### Internet

1. Vytvoření paketu
    - Source IP: 192.168.2.20
    - Dest IP: 142.250.74.36

    IP není v síťi => pošle na default gateway
2. Lokální router
    Zapouzdřeno do ethernetového rámce
    - Source MAC: MAC zdroj. PC
    - Dest MAC: MAC routeru
3. NAT (**N**etwork **A**ddress **T**ranslation)
    Protože `192.168.x.y` jsou privátní adresy
    - Router změní:
      - Source (`192.168.2.20`) na Veřejnou IP routeru (`85.160.12.34`)
    - Dest IP zůstává
4. Putování internetem
    IP adresy se nemění  
    Každý router: upraví hlavičku ether. rámce
    - IP zůstávájí stejné po celou cestu (kromě NATu)
5. Příchod do destinace
    Server dostane:
    - Source IP: `85.160.12.34`
    - Dest IP: `142.250.74.36`
    A odpoví:
    - Source IP: `142.250.74.36`
    - Dest IP: `85.160.12.34`

---

# DNS (**D**omain **N**ame **S**ervice)

- [here](./06%20-%20síťové%20protokoly.md#dns-domain-name-service)


## [Konfigurace](#konfigurace-dns)

### DNS resolver
Systémová komponenta, většinou `systemd-resolved`, `bind` nebo `dnsmasq`

**Funkce**: Překládá domény na žádost jiných programů
- Používá lokální cache: `/etc/hosts`, nebo odešle request na [DNS server](#hierarchie)

**Restart**: `systemctl restart systemd-resolved`

**Nastavení `systemd-resolved`**
- [Arch wiki](https://wiki.archlinux.org/title/Systemd-resolved)
- Conf. soubor: `/etc/systemd/resolved.conf`
  - nebo `/usr/lib/systemd/resolved.conf` 🤷‍♂️
Ukázka:
```ini
[Resolve]
DNS=8.8.8.8 1.1.1.1
FallbackDNS=9.9.9.9
Domains=local
```

**CMD**: `systemd-resolved google.com`

### Lokální DNS cache

Výhody:
- Rychlejší lookup
- Menší síťový provoz

Nevýhody:
- Nízká kapacita cache

### `/etc/hosts`
Ruční přiřazování IP adres doménám, přednost před resolverem
- část cache?
- See hosts(5)

```txt
127.0.0.1   localhost
192.168.1.10 server.local
```

### `/etc/resolv.conf`
Určuje, které DNS servery se mají používat
- Často automaticky generovaný, nebo je symlink

```txt
nameserver 127.0.0.53
options edns0 trust-ad
search skola.ssps.cz ssps.cz
```
`nameserver`: IP adresa DNS serveru

`search`: doména doplněná při zadání neúplného jména

`domain`: výchozí doména

---

# DHCP (**D**ynamic **H**ost **C**onfiguration **P**rotocol)

- [here](./06%20-%20síťové%20protokoly.md#dhcp-dynamic-host-configuration-protocol)

---

# Síťování v GNU/Linux

## Získání aktuální konfigurace

### Fyzické rozhraní: `ip link`
- fyzická nebo virtuální síťová rozhraní
- `lo` = loopback
- `eth0` = ethernet port
- `wlan0` = wifi karta
- `UP/DOWN` = je aktivní?
- `mtu` = maximálmí velikost rámce

### Síťové rozhraní: `ip a`
- Přidělené IP adresy
output:  
```
2: eth0: <UP>
  inet 192.168.1.25/24
```

### Routovací tabulka: `ip route`

output:  
```
default via 192.168.33.1 dev wlp1s0f0 proto dhcp src 192.168.33.165 metric 600
192.168.33.0/24 dev wlp1s0f0 proto kernel scope link src 192.168.33.165 metric 600
```
Význam:
| Položka         | Význam        |
| --------------- | ------------- |
| default         | výchozí route |
| via 192.168.1.1 | gateway       |
| dev eth0        | rozhraní      |
| src             | zdrojová IP   |

### Zjištění default gateway: `ip route | grep default`

### Zjištění ARP tabulky: `ip neigh` 🐴
- Nebo `arp -n`

output:  
`192.168.33.1 dev wlp1s0f0 lladdr 0e:ea:14:69:22:a0 REACHABLE`
| položka     | význam       |
| ----------- | ------------ |
| 192.168.33.1| IP           |
| lladdr      | MAC adresa   |
| REACHABLE   | stav záznamu |


## Nastavení síťových rozhraní

### Aktivace a deaktivace rozhraní
`ip link set eth0 `**`up/down`**

### Přiřazení, odebrání a změna IP konfigurace
`ip addr `**`add/del`**` 192.168.1.10/24 dev eth0`
- Lze stejně přidat i více adres

Změna:  
`ip addr `**`del`**` 192.168.1.10/24 dev eth0`  
`ip addr `**`add`**` 192.168.1.10/24 dev eth0`

### Zobrazení
`ip addr show eth0`

## Přidání a odebrání routovacích pravidel
`ip route `**`add/del`**` 10.0.0.0/24 via 192.168.1.1`

## Nastavení default gateway
`ip route `**`add/del`**` default via 192.168.1.1`

## Nástroje pro diagnostiku

### Testování konektivity: `ping <IP/domena>`

output:  
`64 bytes from 8.8.8.8: icmp_seq=1 ttl=118 time=16.2 ms`
- `icmp_seq` - Pořadí paketu
- `ttl` - **T**ime **T**o **L**ive (v hopech)
- `time` - Latence

Omezení počtu paketů: `ping -c 4 <IP/domena>`

### Trasování cesty paketů: `traceroute <IP/domena>`

output:  
```
1  192.168.1.1
2  10.0.0.1
3  203.0.113.5
...
```
Každý řádek je router (hop) mezi zdrojem a cílem
- Routery vrací ICMP zprávy

### Zobrazení síťových spojení

Zobrazit všchny spojení: `ss -a`
- Pouze TCP: `ss -t`
- Pouze naslouchající porty: `ss -l`
- Bez dns překladu: `ss -n`


### Statistiky síťových rozhraní: `ip -s link`

output:
```
2: wlp1s0f0: <BROADCAST,MULTICAST,UP,LOWER_UP> mtu 1500 qdisc fq_codel state UP mode DORMANT group default qlen 1000
    link/ether 1a:51:cf:23:4e:f4 brd ff:ff:ff:ff:ff:ff permaddr 80:65:7c:c6:e3:5a
    RX:  bytes packets errors dropped  missed   mcast           
      79100585   70683      0      12       0    3202 
    TX:  bytes packets errors dropped carrier collsns           
       6068779   29866      0       0       0       0 
    altname wlx80657cc6e35a
```

`RX`: Received  
`TX`: Transmitted

### Zobrazení otevřených portů: `ss -ltn`

output:

| State  | Recv-Q | Send-Q | Local Address:Port | Peer Address:Port |
|--------|--------|--------|--| --|
|`LISTEN`|`0`|`4096`| `127.0.0.54:53`| `0.0.0.0:*`|
|Poslouchání| Receive count | Send count

# Konfigurace služeb
## Konfigurace DNS
- [haxagon - Konfigurace DNS serveru](https://haxagon.xyz/challenge/6440da131ef0fb6d4f86978a)

**Adresář pro konfiguraci**: `/etc/bind/`

**Instalace**: `sudo apt install bind9 bind9-utils`

**Spuštění**: `sudo systemctl start bind9`

### `/etc/bind/named.conf`

example:
```
include "/etc/bind/named.conf.options";
include "/etc/bind/named.conf.local";
include "/etc/bind/named.conf.default-zones";
```

### `/etc/bind/named.conf.options`
Uchovává globální nastavení DNS serveru
- Nastavení cache, přesměrování dotazů, atd.

example:
```
acl internalNetwork { 192.168.1.0/24; };

options {
  directory "/var/cache/bind";
  forwarders { 8.8.8.8; 9.9.9.9; };
  allow-query { internalNetwork; };
  version "one does not simply get my version";
};
```
- `acl internalNetwork {...}`: Seznam adres síťí, které budou k serveru mít přístup
  - `acl` = **A**ccess **C**ontol **L**ist
- `directory <path>`: Ukazuje na umístění souborů s cachovanými záznamy
- `forwarders { <IPs> }`: IP adresy na servery, na které dotaz přeposlat když server neví odpověď
- `allow-query { <nets> }`: Adresy, které mohou využívat DNS k vyhledávání záznamů
- `version <string>`: Text, který bude v SOA záznamech reprezentovat verzi serveru

### `/etc/bind/named.conf.local`
Deklarace zón, která má DNS server spravovat

```
zone "example.com" IN {
        type master;
        file "/etc/bind/example-com.zone";
};
```

- `zone <name> IN {}`: Jméno zóny, které spravujeme
  - `IN` je pro internetové adresy (**IN**ternet)
- `type master`: Tato zóna je `master` zońou, tedy zdrojem pro záznamy v této  zóně.
- `file /etc/bind/example-com.zone`: umístění soubory s daty zóny

### `/etc/bind/example-com.zone`
Obsahuje záznamy pro konkrétní zónu

```
$TTL    1d
@ IN SOA example.com. info.example.com. (
  2023041901      ; Serial [!!Replace with today's date!!]
  10h             ; Refresh [10 hours]
  15m             ; Retry   [15 minutes]
  1w              ; Expire  [1 weeks]
  1h              ; Negative Cache TTL [1 hour]
)
```
- `$TTL 1d`: Nastaví **T**ime **T**o **L**ive na jeden den pro všechny záznamy
- `@ IN SOA example.com. info.example.com (...)`
  - `@`: Kořenová doména, tedy `example.com`
  - `SOA`: Záznam pro doménu `example.com`
  - `example.com`: Primární **jméno serveru** pro tuto zónu
  - `info.example.com`: **Email** správce DNS serveru pro tuto zónu
    - `@` je nahrazen tečkou
  - `2023041901`: **Sériové číslo**
    - Inkrementuje se pokaždé, když dojde ke změně zóny
  - `10h`: **Refresh**, jak často dotazovat primární server o této zóně
  - `15m`: **Retry**, jak dlouho čekat, než se pokusí znovu kontaktovat primární server, pokud došlo k chybě
  - `1w`: **Expiry**, jak dlouho má sekundární server používat záznamy v této zóně
  - `1h`: Mínusové TTL neexistujícího záznamu, tedy pokud se klient zeptá na neexistující záznam, srver mu odpoví negativním TTL


`ns IN NS 192.168.1.10` je záznam NS pro doménu `example.com`  
`ns IN A 192.168.1.10` je záznam typu `A` pro doménu `example.com`

### Restartování služby - aplikace konfigurace
`sudo systemctl restart bind9`


## Konfigurace DHCP
- [haxagon - Konfigurace DHCP serveru](https://haxagon.xyz/challenge/642fe6e4eb2ce99aa3ff84e4)
- [Arch wiki](https://wiki.archlinux.org/title/Dhcpd) - konfigurace `dhcpd`

Konfigurační soubor: `/etc/default/isc-dhcp-server`


### Instalace
`sudo apt install isc-dhcp-server`

### Výběr interfaců
```txt
INTERFACESv4="<interface pro IPv4>"
INTERFACESv6="<interface pro IPv6>"
```
- Více interfaců rozděleno mezerou


### Autoritativní DHCP server
- **Autoritativní** = Oficiální správce subnetu
  - Může klientovi říct, že je adresa neplatná (`DHCPNAK`)
- Přidat `authoritative;` na první řádek

### DNS servery
`option domain-name-servers <nameservery>`
- Více nameserverů rozděleno mezerou


### Leasing
Lease time = Doba propůjčení IP adresy

1. DHCP server **přiřadí** klientovi **adresu**
2. Po uplynutí 50% času leasu Klient **požádá o prodloužení** času
3. Pokud **čas uplynul** bez prodloužení, je **adresa zneplatněna** a vrácena do poolu

**Defaultní lease time**: `default-lease-time <počet sekund>;`
- Pokud klient nezažádá o přesný lease time

**Maximální lease time**: `max-lease-time <počet sekund>;`
- Maximální délká leasu (pokud si klient zažádá o přesnou délku)

### Subnety

Subnety se konfigurují pomocí bloku

```txt
subnet <IP> netmask <MASK> {
  range 192.168.0.10 192.168.0.99;
  option routers 192.168.0.1;
}
```

Options:
- `range <start IP> <end IP>;`: Určuje rozsah sítě
- `option routers <IP router/ů>;`: Určuje adresu routeru

### Start/Restart serveru
`sudo service isc-dhcp-server restart`  
nebo  
`sudo systemctl restart isc-dhcp-server`
