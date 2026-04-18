# 15 - Práce s firewallem

[Arch wiki: `iptables`](https://wiki.archlinux.org/index.php/iptables)  
[Arch wiki: `nftables`](https://wiki.archlinux.org/title/Nftables)  
[Fedora docs: `firewalld`](https://docs.fedoraproject.org/en-US/quick-docs/firewalld/)

---

1. [15 - Práce s firewallem](#15---práce-s-firewallem)
2. [Firewall obecně](#firewall-obecně)
   1. [Co je firewall](#co-je-firewall)
   2. [Typy firewallů](#typy-firewallů)
      1. [Síťový firewall](#síťový-firewall)
      2. [Host-based firewall](#host-based-firewall)
      3. [Aplikační firewall (WAF)](#aplikační-firewall-waf)
   3. [Stateful vs Stateless firewall](#stateful-vs-stateless-firewall)
      1. [Stateful - Stavový](#stateful---stavový)
      2. [Stateless - Bezstavový](#stateless---bezstavový)
   4. [Kde se firewall používá](#kde-se-firewall-používá)
3. [Terminologie firewallu](#terminologie-firewallu)
   1. [Chain - Řetězec](#chain---řetězec)
      1. [Input: Do zařízení](#input-do-zařízení)
      2. [Output: Ze zařízení](#output-ze-zařízení)
      3. [Forward: Routing - provoz procházející systémem](#forward-routing---provoz-procházející-systémem)
      4. [Prerouting: Před routováním](#prerouting-před-routováním)
      5. [Postrouting: Po routování](#postrouting-po-routování)
   2. [Table - Tabulka](#table---tabulka)
   3. [Rule - Pravidlo](#rule---pravidlo)
   4. [Targets - Cíle](#targets---cíle)
      1. [ACCEPT: Povolení průchodu paketu](#accept-povolení-průchodu-paketu)
      2. [DROP: Zahození paketu bez odpovědi](#drop-zahození-paketu-bez-odpovědi)
      3. [REJECT: Odmítnutí s ICMP odpovědí](#reject-odmítnutí-s-icmp-odpovědí)
      4. [LOG - Zalogování paketu (pokračuje ve vyhodnocování)](#log---zalogování-paketu-pokračuje-ve-vyhodnocování)
   5. [Policy - Politika](#policy---politika)
4. [NAT - Network Address Translation](#nat---network-address-translation)
   1. [Typy NAT](#typy-nat)
      1. [SNAT - Source NAT](#snat---source-nat)
      2. [DNAT - Destination NAT](#dnat---destination-nat)
      3. [Masquerade - Maškaráda](#masquerade---maškaráda)
   2. [Port forwarding](#port-forwarding)
5. [Firewally v GNU/Linux](#firewally-v-gnulinux)
   1. [`iptables`: Starší, ale stále používaný](#iptables-starší-ale-stále-používaný)
      1. [Zobrazení pravidel](#zobrazení-pravidel)
      2. [Správa pravidel](#správa-pravidel)
      3. [Match - definování pravidel](#match---definování-pravidel)
      4. [nastavení politiky](#nastavení-politiky)
      5. [Ukládání a obnova pravidel](#ukládání-a-obnova-pravidel)
         1. [Uložení](#uložení)
         2. [Obnova](#obnova)
   2. [`nftables` - Moderní náhrada iptables](#nftables---moderní-náhrada-iptables)
   3. [`firewalld` - Správce firewallu](#firewalld---správce-firewallu)
      1. [Zones - Zóny](#zones---zóny)
   4. [`ufw` - Uncomplicated Firewall](#ufw---uncomplicated-firewall)
   5. [Logování a monitoring firewallu](#logování-a-monitoring-firewallu)
      1. [Logování pravidel](#logování-pravidel)
      2. [Zobrazení logů](#zobrazení-logů)
      3. [Monitoring provozu](#monitoring-provozu)
6. [Bezpečnostní politiky a best practices](#bezpečnostní-politiky-a-best-practices)
   1. [Princip nejmenších oprávnění:](#princip-nejmenších-oprávnění)
   2. [Doporučená pravidla:](#doporučená-pravidla)
   3. [Dokumentace konfigurace](#dokumentace-konfigurace)

# Firewall obecně
## Co je firewall
**Bezpečnostní zařízení nebo software** sloužící k filtrování síťového provozu

**Kontroluje** podle předem definovaných pravidel
- Příchozí (incoming)
- Odchozí (outgoing) komunikaci

## Typy firewallů
### Síťový firewall
**Chrání celou síť**
- Umístěný **na hranici sítě** (perimetr)

### Host-based firewall
**Přímo na zařízení** (PC, server)
- Chrání konkrétní systém
- Windows Firewall


### Aplikační firewall (WAF)
Filtruje provoz **na úrovni aplikací** (např. HTTP)
- Chrání webové aplikace
- např. ModSecurity


## Stateful vs Stateless firewall

### Stateful - Stavový

**Sleduje stav spojení** (`connection tracking`)
- Ví, jestli paket patří do existující komunikace

Moderní firewally jsou většinou stateful
- Bezpečnější a chytřejší než stateless

### Stateless - Bezstavový
Kontroluje **každý paket zvlášť**
- Neví nic o předchozí komunikaci


## Kde se firewall používá

1. Dedikovaná síťová zařízení (hardware firewall)
2. Software na serverech a pracovních stanicích
3. Routery a síťové brány
4. Cloud prostředí (security groups, network ACLs)

---

# Terminologie firewallu
## Chain - Řetězec

**Sada pravidel aplikovaných na určitý typ provozu**

### Input: Do zařízení
**Příchozí provoz směřující na lokální systém**

### Output: Ze zařízení
**Odchozí provoz z lokálního systému**

### Forward: Routing - provoz procházející systémem

### Prerouting: Před routováním
**Zpracování paketů před routingem**

### Postrouting: Po routování
**Zpracování po routingu**

## Table - Tabulka
Typy tabulek
- **Filter**: Výchozí tabulka pro filtrování provozu
- **Nat**: Překlad síťových adres
- **Mangle**: Modifikace paketů
- **Raw**: Konfigurace výjimek z connection trackingu

## Rule - Pravidlo
**Definice podmínek a akce** pro odpovídající provoz

**Match**: Kritéria pro výběr paketů  
**[Target/Action](#targets]**: Akce pro odpovídající pakety

## Targets - Cíle

### ACCEPT: Povolení průchodu paketu

### DROP: Zahození paketu bez odpovědi

### REJECT: Odmítnutí s ICMP odpovědí

### LOG - Zalogování paketu (pokračuje ve vyhodnocování)

## Policy - Politika

**ýchozí chování firewallu**

**Default ACCEPT**: Povolí vše, co není explicitně zakázáno

**Default DROP**: Zakáže vše, co není explicitně povoleno (bezpečnější)

---

# NAT - **N**etwork **A**ddress **T**ranslation

**Překládá lokální IP adresy na veřejné**

**Účel NAT**
- Umožňuje sdílení jedné veřejné IP adresy pro více zařízení
- Šetří IPv4 adresy
- Skrývá vnitřní strukturu sítě (zvyšuje bezpečnost)

## Typy NAT

### SNAT - **S**ource **NAT**
**Mění zdrojovou IP adresu** při **odchozím provozu** do internetu

1. Zařízení v LAN odešle paket
2. Router změní zdrojovou IP na svoji (veřejnou)

**Konfigurace v chainu POSTROUTING**

### DNAT - **D**estination **NAT**
**Mění cílovou IP adresu** při **příchozím provozu** z internetu

1. Požadavek přijde na veřejnou IP
2. Ruter ho přesměruje na interní zařízení

**Konfigurace v chainu PREROUTING**

Např. zpřístupnění serveru v LAN

### Masquerade - Maškaráda

Speciální typ SNAT
- Když máš **dynamickou veřejnou IP**

Automaticky použije IP adresu rozhraní

## Port forwarding

**Přesměrování konkrétního portu** z veřejné IP **na interní zařízení**
- **Umožnění přístupu k interním službám z internetu**

1. Požadavek **přijde na veřejnou IP + port** (např. 8080)
2. Ruter ho přesměruje **na interní IP + jiný port** (např. 192.168.1.100:80)

`203.0.113.1:8080` -> `192.168.1.100:80`

---

# Firewally v GNU/Linux

## `iptables`: Starší, ale stále používaný

**Nástroj pro konfiguraci firewallu na nízké úrovni**

**Syntax**: `iptables [tabulka] [akce] [chain] [match] [cíl]`
- `iptables -A INPUT -p tcp --dport 22 -j ACCEPT`

### Zobrazení pravidel
```bash
iptables -L #   Výpis pravidel
iptables -L -v -n   #   detailní výpis s čísly
iptables -L -n --line-numbers   #   výpis s čísly řádků
```

### Správa pravidel
`-A` (**A**ppend): Přidání pravidla na konec  
`-I` (**I**nsert): Vložení pravidla na pozici  
`-D` (**D**elete): Smazání pravidla  
`-R` (**R**eplace): Nahrazení pravidla  
`-F` (**F**lush): Smazání všech pravidel

### Match - definování pravidel

`-p` / `--protocol`: Protokol (`tcp`, `udp`, `icmp`)  
`-s` / `--source`: Zdrojová IP adresa  
`-d` / `--destination`: Cílová IP adresa  
`-i` / `--in-interface`: Vstupní rozhraní
`-o` / `--out-interface`: Výstupní rozhraní  
`--sport` / `--source-port`: Zdrojový port  
`--dport` / `--destination-port`: Cílový port  
`-m conntrack --ctstate`: Stav spojení (`NEW`, `ESTABLISHED`, `RELATED`)

### nastavení politiky
```bash
iptables -P INPUT DROP  #   Default policy DROP
iptables -P FORWARD DROP    #   ...
iptables -P OUTPUT ACCEPT
```

### Ukládání a obnova pravidel
```bash
#   Uložení
iptables-save > /etc/iptables/rules.v4
#   Obnova
iptables-restore < /etc/iptables/rules.v4
```

## `nftables` - Moderní náhrada iptables

**Výhody oproti `iptables`**
- Jednotná syntaxe pro IPv4/IPv6
- Atomické aktualizace pravidel (bez rozbití pravidel během úprav)
- Čitelnější konfigurace

```bash
nft list ruleset    #   Zobrazení pravidel
nft add table   #   Přidání tabulky
nft add chain   #   Přidání řetězce
nft add rule    #   Přidání pravidla
```

## `firewalld` - Správce firewallu

### Zones - Zóny

**Předdefinované profily** podle důvěry
- `drop`: Vše zahodí
- `block`: Blokuje s odpovědí
- `public`: Veřejná síť
- `home`: Domácí síť
- `work`Pracovní síť
- `trusted`: Vše povoleno

```bash
firewall-cmd --state    #   Stav firewallu
firewall-cmd --list-all #   Zobrazení konfigurace
firewall-cmd --add-service=http #   Povolení služby
firewall-cmd --add-port=8080/tcp    #   Povolení portu
firewall-cmd --runtime-to-permanent #   Uložení změn
```

## `ufw` - **U**ncomplicated **F**ire**w**all

```bash
ufw enable  #   Zapnutí
ufw disable #   Vypnutí
ufw status verbose  #   Zobrazení stavu
ufw allow 22/tcp    #   Povolení SSH
ufw deny from 192.168.1.100 #   Blokování IP
ufw default deny incoming   #   Výchozí politika
```

## Logování a monitoring firewallu
### Logování pravidel
**Abys viděl**
- Co firewall blokuje/povoluje
- Kdo se pokouší připojit
- Jestli probíhá útok

```bash
iptables -A INPUT -j LOG --log-prefix "FIREWALL: "
```
- Zaznamená paket do logu
- Nezastaví zpracování (pokračuje dalšími pravidly)

Často kombinuje:
```bash
iptables -A INPUT -j LOG --log-prefix "DROP: "
iptables -A INPUT -j DROP
```

### Zobrazení logů

`systemd`: `journalctl -k | grep "IN=.*OUT=.*"`

Nebo ve `/var/log/kern.log` nebo `/var/log/messages`

### Monitoring provozu
**Analýza logů pro detekci podezřelých aktivit**
- Sledování odmítnutých spojení
- Identifikace pokusů o průnik

---

# Bezpečnostní politiky a best practices
## Princip nejmenších oprávnění:

**Povolit pouze nezbytný provoz**
- Default `DROP` pro příchozí provoz

## Doporučená pravidla:

Povolit loopback rozhraní: `iptables -A INPUT -i lo -j ACCEPT`

Povolit established a related spojení
- `iptables -A INPUT -m conntrack --ctstate ESTABLISHED,RELATED -j ACCEPT`
- Povolí odpovědi na již navázaná spojení

Povolit pouze konkrétní služby

Logovat odmítnutý provoz

## Dokumentace konfigurace

**Bez dokumentace**
- Nevíš, **proč pravidlo existuje**
- Hůř se hledají chyby

Komentáře v konfiguracích  
Verzování konfigurací  
Dokumentace změn: Co se změnilo a proč


































