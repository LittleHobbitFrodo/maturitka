# 17 - Webové technologie


1. [17 - Webové technologie](#17---webové-technologie)
2. [Základy webových technologií](#základy-webových-technologií)
   1. [Od statických stránek k aplikacím](#od-statických-stránek-k-aplikacím)
   2. [Architektura webu](#architektura-webu)
      1. [Hlavní technologie](#hlavní-technologie)
      2. [Model klient–server](#model-klient–server)
      3. [Jak funguje komunikace](#jak-funguje-komunikace)
   3. [URL - Uniform Resource Locator](#url---uniform-resource-locator)
3. [Doménový sysém](#doménový-sysém)
   1. [Domény](#domény)
   2. [DNS](./03%20-%20počítačové%20sítě.md#dns-domain-name-service)
4. [HTTP(s) - HyperText Transfer Protocol](./06%20-%20síťové%20protokoly.md#https---hypertext-transfer-protocol)
   1. [Verze HTTP](#verze-http)
   2. [Bezstavovost](#bezstavovost)
   3. [HTTP hlavičky](#http-hlavičky)
      1. [Request headers](#request-headers)
      2. [Response headers](#response-headers)
      3. [Custom headers](#custom-headers)
   4. [Cookies](#cookies)
      1. [Typy cookies](#typy-cookies)
      2. [Atributy cookies](#atributy-cookies)
5. [HTTPS a šifrování](#https-a-šifrování)
   1. [SSL/TLS](./13%20-%20asymetrická%20kryptografie,%20podpisy%20a%20certifikáty.md#ssltls-certifikáty)
      1. [TLS handshake (zjednodušeně)](#tls-handshake-zjednodušeně)
      2. [Šifrování](#šifrování)
      3. [Certifikáty](./13%20-%20asymetrická%20kryptografie,%20podpisy%20a%20certifikáty.md#digitální-certifikáty)
6. [Webový server](#webový-server)
   1. [Statický](#statický)
   2. [Dynamický obsah](#dynamický-obsah)
7. [Frontend technologie](#frontend-technologie)
   1. [HTML - HyperText Makrup Language](#html---hypertext-makrup-language)
      1. [Struktura dokumentu](#struktura-dokumentu)
      2. [Základní elementy](#základní-elementy)
      3. [Sémantické značky](#sémantické-značky)
   2. [CSS - Cascading Style sheet](#css---cascading-style-sheet)
      1. [Selektory](#selektory)
      2. [Responzivní design](#responzivní-design)
   3. [JavaScript](#javascript)
8. [Backend - Serverside](#backend---serverside)
   1. [Backend jazyky a technologie](#backend-jazyky-a-technologie)
9. [API - Application Programming Interface](#api---application-programming-interface)
   1. [REST API](#rest-api)
10. [Praktické nástroje](#praktické-nástroje)
    1. [Developer tools](#developer-tools)
    2. [Linuxový terminál](#linuxový-terminál)


# Základy webových technologií
## Od statických stránek k aplikacím
**Dříve**: Jednoduché HTML stránky (jen text a obrázky)  
**Dnes**: Plnohodnotné aplikace (např. Facebook nebo YouTube)

1. **Web 1.0**
    - statické stránky
    - **Uživatel jen čte**
2. **Web 2.0**
    - Interaktivní obsah
    - **Uživatel tvoří** obsah (komentáře, sociální sítě)
3. **Web 3.0**
    - Decentralizace, AI, personalizace
    - Spojeno s technologiemi jako Ethereum

## Architektura webu

### Hlavní technologie
**HTML** (**H**yper**T**ext **M**arkup **L**anguage): Struktura stránky  
**CSS** (**C**ascading **S**tyle **S**heet): Vzhled (barvy, layout)  
**JavaScript**: Interaktivita (tlačítka, animace)

### Model klient–server
**Klient**: Prohlížeč (např. Firefox)  
**Server**: Počítač, který poskytuje data

### Jak funguje komunikace

**Protokol**: **HTTP** nebo **HTTPS**

**Request–response cyklus**
1. Zadáš URL do prohlížeče
2. Prohlížeč pošle request (požadavek)
3. Server pošle response (odpověď)
4. Prohlížeč vykreslí stránku

## URL - **U**niform **R**esource **L**ocator

`https://www.example.com/index.html?id=5#top`
1. Protokol: `https:`
2. Doména: `www.example.com`
3. Path: `/index.html`
4. Parametry: `id=5`
5. Kotva: `#top`

**Absolutní URL**: Celá adresa
- `https://example.com/page`

**Relativní URL**: Jen část
- `/page`

---

# Doménový sysém

## Domény
**Struktura domény**: `www.google.com`
- TLD (**T**op-**L**evel **D**omain): `.com`, `.cz`
- SLD: `google`
- Subdoména: `www`

**Registrace domén**: Registrují firmy (registrátoři)
- V ČR např. `CZ.NIC`

**WHOIS**: Databáze informací o doméně
- vlastník, datum registrace, atd.

## [DNS](./03%20-%20počítačové%20sítě.md#dns-domain-name-service)

---

# [HTTP(s)](./06%20-%20síťové%20protokoly.md#https---hypertext-transfer-protocol) - **H**yper**T**ext **T**ransfer **P**rotocol

## Verze HTTP
1. **HTTP/1.1**: Základní verze, stále používaná
2. **HTTP/2**: Rychlejší (více požadavků najednou – multiplexing)
3. **HTTP/3**: Využívá moderní transport (QUIC)
- Lepší výkon a nižší latence
- [Wiki: QUIC](https://en.wikipedia.org/wiki/QUIC)

## Bezstavovost
HTTP je bezstavový (stateless)
- Každý požadavek je nezávislý
- Server si nepamatuje předchozí komunikaci
  - Proto existují cookies a sessions


## HTTP hlavičky
### Request headers
`Host`: Cílový server  
`User-Agent`: Info o prohlížeči (např. Mozilla Firefox)  
`Accept`: Jaký formát chci  
`Authorization`: Přihlášení

### Response headers
`Content-Type`: Typ dat (HTML, JSON)  
`Content-Length`: Velikost  
`Cache-Control`: Cachování

### Custom headers
Vlastní hlavičky aplikace
- Např. API klíče

## Cookies

**Ukládají informace** o uživateli
- Např. přihlášení, nastavení

### Typy cookies
**Session cookies**: Smažou se po zavření prohlížeče  
**Persistent cookies**: Zůstávají uložené delší dobu

### Atributy cookies
`HttpOnly`: Nepřístupné z JavaScriptu  
`Secure`: Jen přes HTTPS  
`SameSite`: Ochrana proti [CSRF](./18%20-%20principy%20bezpečného%20vývoje.md#csrf---cross-site-request-forgery) útokům

---

# HTTPS a šifrování

**HTTP**: Nešifrované  
**HTTPS**: Šifrované HTTP

## [SSL/TLS](./13%20-%20asymetrická%20kryptografie,%20podpisy%20a%20certifikáty.md#ssltls-certifikáty)


### TLS handshake (zjednodušeně)
1. Klient se připojí na server
2. Server pošle certifikát
3. Ověření certifikátu
4. Dohodnutí klíče
5. Začátek šifrované komunikace

### Šifrování
**Asymetrické**: Veřejný + soukromý klíč
- Používá se při navázání spojení

**Symetrické**: Jeden sdílený klíč
- Rychlé: používá se pro přenos dat

### [Certifikáty](./13%20-%20asymetrická%20kryptografie,%20podpisy%20a%20certifikáty.md#digitální-certifikáty)

---

# Webový server

**Webový server**: Software, který přijímá HTTP požadavky a vrací odpovědi
- Apache HTTP server, Nginx

**Zpracování požadavků**
1. Klient (prohlížeč) pošle požadavek
2. Server ho zpracuje
3. Pošle odpověď (HTML, JSON, obrázek, ...)

## Statický
**Pevné soubory** (HTML, CSS)
- Vždy stejný obsah
## Dynamický obsah
Generovaný backendem
- Mění se podle uživatele (např. účet, e-shop)

---

# Frontend technologie

**Frontend**: To, co vidí uživatel v prohlížeči

## HTML - **H**yper**T**ext **M**akrup **L**anguage

### Struktura dokumentu
`<html>`: Označuje konec/začátek html kódu  
`<head>`: Označuje sekci s informacemi o stránce  
`<body>`: Sekce s kódem s tránky

### Základní elementy
Nadpisy: `<h1>`  
Odstavce: `<p>`  
Odkazy: `<a>`  
Obrázky: `<img>`

### Sémantické značky
`<header>`, `<nav>`, `<main>`, `<article>`, `<footer>`

## CSS - **C**ascading **S**tyle **sheet**
**Stylování**: Barvy, fonty, layout

### Selektory
Podle elementu: `p`  
Podle třídy: `.class`  
Podle ID: `#id`

### Responzivní design
Přizpůsobení mobilům  
- Media queries

Flexibilní layout (`flexbox`, `grid`)

## JavaScript

**Interaktivita**
reakce na kliknutí
validace formulářů

**Manipulace s DOM** (**D**ocument **O**bject **M**odel)
- DOM: Struktura stránky v paměti
- JS může:
  - Měnit obsah
  - Přidávat prvky

**Události** (events): Spouštění kódu když
- Např: Kliknutí, pohyb myši, stisk klávesy

---

# Backend - Serverside

**Backend**: „Mozek“ aplikace

**Účel**
- Zpracování požadavků
- Práce s databází
- Autentizace (přihlášení)
- Autorizace (co smí uživatel)
- Business logika (např. výpočet ceny)

## Backend jazyky a technologie
**PHP**: WordPress, Laravel  
**Python**: Např. Django, Flask, FastAPI  
**Node.js**: Node.js, Express.js  
**Java**: Spring Boot  
**Go**: Výkonné služby  
**Ruby**: Ruby on Rails

---

# API - **A**pplication **P**rogramming **I**nterface
## REST API
Způsob komunikace mezi systémy

**Principy REST**
- Používá HTTP metody (GET, POST…)
- Bezstavové
- Pracuje se zdroji (resources)

**Endpointy a zdroje**: URL reprezentuje data
- `/users`
- `/products/1`

**JSON** (**J**ava**S**cript **O**bject **N**otation)
- Textový interface pro lidmi čitelnou výměnu dat
- ```json
  {
    "name": "Jan",
    "age": 20
  }
  ```

---

# Praktické nástroje

## Developer tools

Built-in pomocné nástroje pro testování webových aplikací
- V prohlížeči (Chromium-based i Firefox), klávesa F12
- Např.
  - **Elements**: Inspekce/úprava HTML
  - **Console**: Logy, output a errory z javascriptu
  - **Debugger**: Nastavení breakpointů v javascriptu
    - Problém: minimalizovaný nebo obfuskovaný javascript
  - **Network**: Sledování HTTP komunikace

## Linuxový terminál
**`curl`**: Posílání HTTP požadavků  
**`wget`**: Stahování souborů  














