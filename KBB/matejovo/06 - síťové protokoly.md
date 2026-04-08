# 06 - Síťové protokoly

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

# TODO





