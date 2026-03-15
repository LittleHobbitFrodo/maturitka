# 04. Průzkum a diagnostika sítě

# Skenování sítě - `nmap`

`nmap` přepínače:
- `-sn`: Vypne port scan
- `-V`: Použije verbose output
- `-sV`: Skenuje porty pro version info spuštěných služeb
- `-p`: Skenuje pouze specifické porty
- `-F`: Fast scan - skenuje více portů než normálně
- `-O`: Detekce OS

## Host discovery - aktivní zařízení
`nmap -sn <subnet IP>/<subnet mask>`
`-sn` = ping scan

output:
```
Nmap scan report for net_c3_0388.localdomain (192.168.33.68)
Host is up (0.088s latency).
Nmap scan report for HF-LPT230.localdomain (192.168.33.76)
Host is up (0.0062s latency).
```

## TCP sken
`nmap <subnet IP>/<subnet mask>`
- Defaultně skenuje 1000 nejčastějších TCP portů
  - `http` (80), `ssh` (22), etc.
- `-sS` pro TCP `SYN` sken

output:
```
Nmap scan report for U5G-Max.localdomain (192.168.33.14)
Host is up (0.0076s latency).
Not shown: 999 closed tcp ports (conn-refused)
PORT   STATE SERVICE
22/tcp open  ssh
```


## UDP sken
Nepoužívá handshake -> pomalejší a méně spolehlivé

`nmap -sU <subnet IP>/<subnet mask>`

output:
```
PORT    STATE         SERVICE
53/udp  open          domain
161/udp open|filtered snmp
```

Služby používající UDP: `dns` (53), `dhcp` (67/68)

## Skenování všech portů
`nmap -p- <subnet IP>/<subnet mask>`
- `-p-` = všechny porty

## Skenování některých portů
### Konkrétní port
`nmap -p 80 ...`: Oskenuje pouze port 80

### Více portů
`nmap -p 22,80,443 ...`: Oskenuje porty 22, 80 a 443

### Rozsah
`nmap -p 1-1000 ...`: Oskenuje všechny porty v rozmezí 1 až 1000

---

# Pokročilé skenování
## Service scan
Pokusí se zjistit, které služby na zařízení běží  
1. Najde otevřené porty
2. pošle specifické dotazy (probes) na službu
3. Analyzuje odpověď

`nmap -sV ...`

## Detekce OS
`nmap -O ...`

Každý OS má trochu odlišné chování 

Analyzuje:
- TCP/IP stack
- TTL hodnoty
- Velikost TCP okna
- Odpovědi na různé pakety


## Různé typy skenů
### Kombinace

Často se používá kombinace `TCP SYN` sken, service detection a OS detection:

`nmap -sS -sV -O ...`

### TCP SYN (Half-open sken)

`nmap -sS ...`

Rychlý, relativně nenápadné skenování

Požádá o spojejí, ale když server odpoví, uzavře spojení
1. nmap: `SYN`
2. server: `SYN-ACK`
3. nmap: `RST`

### TCP connect (plné spojení)

`nmap -sT ...`

Pomalejší, nápadný, nepotřebuje root privilegia

Naváže plné TCP spojení

## TCP FIN sken

`nmap -sF ...`

Pošle tcp `FIN` packet
- Otevřený port -> žádná odpověď
- Zavřený port -> `RST`

Používá se pro obcházení některých firewallů

## TCP NULL sken

Pošle paket bez bez flagů

`nmap -sN ...`

Stealth skenování

Používá se pro detekci firewall pravidel

## Xmas sken

`nmap -sX ...`

Obchází některé firewally, paket vypadá jako stromeček
- Zapnuté flagy: `FIN`, `PSH`, `URG`

## Agresivní sken

`nmap -A ...`

Obsahuje:
- Detekci OS
- Detekci služeb
- Traceroute
- Script scanning


## `nmap` script engine

Nmap obsahuje skripty pro:
- Detekci zranitelností
- Brute-force
- Info gathering

`nmap --script vuln`: Spustí skript pro detekci zranitelností


## Typicoký postup mapování

1. **Host discovery**: `nmap -sn ...`
2. **Port scan**: `nmap -sS ...`
3. **Service detection**: `nmap -sV ...`
4. **OS detection**: `nmap -O ...`
5. **Vulnebrality scripts**: `nmap --script vuln ...`

---

# ICMP (**I**nternet **C**ontrol **M**essage **P**rotocol)



IP protokol pro diagnostiku a řízení komunikace
- Testování dostupnosti
- Diagnostika trasy

Využití:
- `ping`
- `traceroute`
- Některé funkce routerů


## Testování dostupnosti zařízení (ICMP echo - ping)

1. Počítač pošle ICMP echo
2. server odpoví pomocí ICMP response

Pokud přijde odpověď:
- Zařízení je dostupné v síti

Pokud ne:
- Zařízení je offline
- Firewall blokuje ICMP
- Problém v síti

## Nástroj `ping`

Základní nástroj pro testování konektivity
- Udělá ICMP echo request
- Počítá čas odezvy

`ping 8.8.8.8` nebo `ping google.com`

output:
```
64 bytes from 8.8.8.8: icmp_seq=1 ttl=117 time=23.5 ms
64 bytes from 8.8.8.8: icmp_seq=2 ttl=117 time=24.1 ms
```

## Interpretace výsledků
### RTT (**R**ound **T**rip **T**ime): Čas, který paketu trvá dorazit do cíle a zpět
V milisekundách

|RTT|Význam|
|---|------|
|< 1ms| Lokální síť|
|10 - 50ms| dobré internetové spojení|
|> 100| Vysšší latence|
|> 300 | Pomalé spojení|

### Packet loss
Ztráta paketů

```
Packets: Sent = 4, Received = 4, Lost = 0 (0% loss)
```

**Příčiny**:

přetížená síť
- Wi-Fi rušení
- Špatný kabel
- Firewall / filtr

### TTL

**T**ime **T**o **L**ive - v hopech

Někdy může pomoci odhadnout operační systém:
- Linux 64
- Windows 128
- cisco 255

---

# Získání informací o zařízeních

## MAC (**M**edia **A**ccess **C**ontrol) adresa
- 48-bitová adresa pro komunikaci na vrstvě L2
  - nebo pro P2P komunikace (např. bluetooth)

`00:1A:2B:3C:4D:5E`

Rozdělení
|`00:1A:2B`|`3C:4D:5E`|
|----------|----------|
|výrobce zařízení (OUI)|identifikátor zařízení|

## ARP (**A**dress **R**esolution **P**rotocol)

Převést IP adresu na MAC adresu

Počítač chce poslat paket na zařízení v LAN:
1. Podívá se do ARP tabulky, když v ní je zařízení zaznamenané, pošle paket
2. Když zařízení v tabulce není, pošle **ARP request**: `Who has 192.168.33.174?`
3. Cílové zařízení **odpoví**: `192.168.33.174 is at c4:f7:c1:6b:9c:71`
4. MAC adresa se uloží do tabulky
5. Pošle paket

## ARP tabulka

Databáze záznamů o IP a MAC adresách zařízení v lokální síti

Záznamy:
- Dynamic: vytvoří se automaticky
- Static: Nastaveny manuálně




## Zjištění MAC adresy zařízení v LAN

1. Poslat ping na adresu zařízení
    - Tím se zapíše do arp tabulky  
    - `ping 192.168.33.174`
2. Vypsat arp tabulku  
    - `ip neigh` nebo `arp -a`

output:  
- `ip neigh`: `fe80::1cb6:38ff:7ebf:f4a1 dev wlp1s0f0 lladdr c4:f7:c1:6b:9c:71 router STALE`
- `arp -a`: `Obyvaci-pokoj.localdomain (192.168.33.174) at c4:f7:c1:6b:9c:71 [ether] on wlp1s0f0`



# Netcat (`nc`)

"Švýcarský nůž sítí", umožňuje:
- Testovat porty
- Navazovat TCP/UDP spojení
- Přenášet data mezi počítači
- Vytvářet jednoduché servery

## Navázání TCP spojení

`nc <IP> <port>`
- Pokusí se navázat TCP spojení
- Můžeš zadávat text ručně

`echo -e "GET / HTTP/1.1 \n Host: example.com" | nc <IP> <port>`

Použití: testování otevřených portů nebo ruční komunikace se službou

## Navázání UDP spojení

`nc -u <IP> <port>`

Použití: testování UDP služeb, DNS nebo SNMP komunikace

Nevýhody:
- Težší rozpoznat stav portu
  - UDP často neposílá odpověď

## Otevření TCP portu (listener)

1. Počítač A spustí listener
    - `nc -l -p 1234`
2. Počítač B se připojí (na port listeneru)
    - `nc <IP> 1234`
3. Proběhne TCP spojení
4. Oba počítače si mohou posílat data

### TCP
`nc -l -p <port>`
- `-l` = listen

### UDP
`nc -u -l -p <port>`
- `-u`: UDP mód

## Posílání souborů

Přijímací zařizení: `nc -l -p 1234 > soubor.txt`

Odesilatel: `nc <IP> 1234 < soubor.txt`

## Chat mezi zařízeními

Zařízení A: `nc -l -p 1234`

Zařízení B: `nc <IP> 1234`

Po zadání textu se hned zobrazí na druhé obrazovce

# Nástroje pro diagnostiku

## `traceroute`
[here](./03%20-%20počítačové%20sítě.md#nástroje-pro-diagnostiku)

## Zobrazení síťových spojení

`netstat -an`
- `-a`: Všechna spojení
- `-n`: IP adresy a porty numericky

output:
|Proto|Recv-Q|Send-Q|Local Address|Foreign Address|State|
|-----|------|------|-------------|---------------|-----|
|tcp|0|0|0.0.0.0:514|0.0.0.0:*|LISTEN|
|tcp|0|0|0.0.0.0:5355|0.0.0.0:*|LISTEN|
|tcp|0|0|127.0.0.1:631|0.0.0.0:*|LISTEN|
|tcp|0|0|127.0.0.53:53|0.0.0.0:*|LISTEN|
|tcp|0|0|127.0.0.54:53|0.0.0.0:*|LISTEN|
|tcp|0|0|192.168.33.165:50070|185.199.111.133:443|ESTABLISHED|
|tcp|0|0|192.168.33.165:42586|34.107.243.93:443|TIME_WAIT|
|tcp|0|0|192.168.33.165:42602|34.107.243.93:443|ESTABLISHED|
|tcp|76|0|192.168.33.165:58846|151.101.65.91:443|CLOSE_WAIT|
|tcp|0|0|192.168.33.165:37346|151.101.1.91:443|ESTABLISHED|
|tcp|0|0|192.168.33.165:44886|104.18.32.47:443|ESTABLISHED|

States:
- `LISTEN`: Čekání na spojení
- `ESTABLISHED`: Spojení je aktivní
- `TIME_WAIT`: Čekání na ukončení

## Diagnostika DNS

`nslookup` nebo `dig`

Použití:
- Diagnostika DNS serverů nebo jejich odpovědí
- Ověření záznamů

`nslookup` output:
```
Server:		127.0.0.53
Address:	127.0.0.53#53

Non-authoritative answer:
Name:	google.com
Address: 142.251.38.142
Name:	google.com
Address: 2a00:1450:4014:80d::200e
```

## Testování dostupnosti portů

`nc`, `telnet` nebo `nmap` (a další...)

### Netcat
`nc -zv <IP> <port>`
- `-z`: Pouze test portu
- `-v`: Vervose output

output:
```
Ncat: Version 7.92 ( https://nmap.org/ncat )
Ncat: Connected to 142.251.209.14:80.
Ncat: 0 bytes sent, 0 bytes received in 0.05 seconds.
```



