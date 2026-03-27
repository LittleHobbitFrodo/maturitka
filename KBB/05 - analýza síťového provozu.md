# 05. Analýza síťového provozu

# Metody zachytávání síťového provozu

## Port mirroring - SPAN (**S**witched **P**ort **AN**alyzer)

Funkce na switchi, kopíruje provoz z jednoho nebo více portů na jiný port, kde může být připojeno analyzační zařízení

Switch duplikuje pakety a posílá je na jiný port
- Linuxový server je může zachytávat a analyzovat

### Výhody
- Bez zásahu do kabeláže
- Jednoduché nastavení (na switchi)
- Možnost sledovat více portů najednou

### Nevýhody
- Může dojít ke ztrátě paketů při vysokém zatížení
- Závislé na schopnostech switche
- Ne vždy zachytí úplně vše (např. chyby na fyzické vrstvě)

## Network taping (odposlechy)
### Pasivní
Vložené zařízení mezi dvě jiná zařízení
- Kopíruje a posílá data dál, kopie jde do odposlouchávacího zařízení

#### **Výhody**
- Žádná ztráta paketů
- Nezjistitelné
- Neovlivňuje provoz

#### **Nevýhody**
- Nutnost fyzického zásahu do sítě
- Vyšší cena

### Aktivní

Aktivně zpracovává a přeposílá provoz

Funguje podobně jako bridge/switch
- Kopíruje provoz a může ho i filtrovat nebo upravovat

#### **Výhody**
- Pokročilé funkce (filtrace, agregace)
- Možnost práce s více linkami

#### **Nevýhody**
- Při výpadku může přerušit komunikaci
- Může ovlivnit latenci

### Promiskuitní režim síťové karty

Karta přijímá všechny pakety, nejen ty určené pro její MAC adresu
- Spuštěno pomocí `tcpdump`, `wireshark`, `ip link set eth0 promisc on`

# `tcpdump`

`tcpdump -i eth0 -n`
- `-i eth0`: interface `eth0`
- `-n`: neresolvuje DNS (rychlejší, přehlednější)
- [capture.pcap](./assets/capture.pcap)


