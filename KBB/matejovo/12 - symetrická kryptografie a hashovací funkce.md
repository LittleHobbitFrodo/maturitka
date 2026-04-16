# 12 - Symetrická kryptografie a hashovací funkce

1. [12 - Symetrická kryptografie a hashovací funkce](#12---symetrická-kryptografie-a-hashovací-funkce)
2. [Úvod do kryptografie](#úvod-do-kryptografie)
   1. [Základní pojmy](#základní-pojmy)
   2. [Cíle kryptografie - CIA triáda](#cíle-kryptografie---cia-triáda)
3. [Historie kryptografie](#historie-kryptografie)
   1. [1. Transpoziční šifry](#1-transpoziční-šifry)
   2. [2. Substituční šifry](#2-substituční-šifry)
   3. [Steganografie](#steganografie)
   4. [One-Time Pad (OTP)](#one-time-pad-otp)
4. [Symetrická kryptografie](#symetrická-kryptografie)
5. [Blokové šifry](#blokové-šifry)
   1. [AES (Advanced Encryption Standard)](#aes-advanced-encryption-standard)
   2. [DES (Data Encryption Standard)](#des-data-encryption-standard)
   3. [Triple DES](#triple-des)
   4. [Režimy blokových šifer](#režimy-blokových-šifer)
      1. [ECB (Electronic Codebook)](#ecb-electronic-codebook)
      2. [CBC (Cipher Block Chaining)](#cbc-cipher-block-chaining)
      3. [CTR (Counter mode)](#ctr-counter-mode)
      4. [GCM (Galois/Counter Mode)](#gcm-galoiscounter-mode)
6. [Proudové šifry](#proudové-šifry)
   1. [Vlastnosti](#vlastnosti)
   2. [Příklady](#příklady)
7. [Hashovací funkce](#hashovací-funkce)
   1. [Důležité vlastnosti](#důležité-vlastnosti)
   2. [Populární hashovací algoritmy](#populární-hashovací-algoritmy)
      1. [MD5](#md5)
      2. [SHA-1](#sha-1)
      3. [SHA-256 / SHA-512](#sha-256--sha-512)
      4. [SHA-3](#sha-3)
      5. [BLAKE3 (a BLAKE2)](#blake3-a-blake2)
8. [Využití hashovacích funkcí](#využití-hashovacích-funkcí)
   1. [Ukládání hesel](#ukládání-hesel)
   2. [Salt](#salt)
   3. [Kontrola integrity souborů](#kontrola-integrity-souborů)
   4. [Identifikace malware](#identifikace-malware)
9. [Útoky na hashe](#útoky-na-hashe)
   1. [Brute-force](#brute-force)
   2. [Slovníkový útok](#slovníkový-útok)
   3. [Rainbow tables](#rainbow-tables)
   4. [Rule-based útoky](#rule-based-útoky)
   5. [Mask attack](#mask-attack)
10. [Aplikace symetrické kryptografie](#aplikace-symetrické-kryptografie)
    1. [Aplikace symetrické kryptografie](#aplikace-symetrické-kryptografie-1)
    2. [Šifrovaná komunikace](#šifrovaná-komunikace)
    3. [Správa klíčů](#správa-klíčů)

# Úvod do kryptografie

## Základní pojmy

**Kryptologie**: Věda o šifrách (zahrnuje kryptografii i kryptoanalýzu)  
**Kryptografie**: Tvorba šifer a šifrování  
**Kryptoanalýza**: Prolamování šifer  
**Plaintext**: Původní čitelná zpráva  
**Ciphertext**: Zašifrovaná zpráva  
**Klíč** (key): Tajná informace pro šifrování/dešifrování  
**Keyspace**: Množina všech možných klíčů

## Cíle kryptografie - CIA triáda

**Confidentiality** (důvěrnost): Pouze oprávněné osoby mohou číst data  
**Integrity** (integrita): Detekce neautorizovaných změn dat  
**Authenticity** (autenticita): Ověření původu dat/identity

---

# Historie kryptografie

## 1. Transpoziční šifry

Nemění se znaky, jen jejich pořadí

**Sloupcová transpozice**: Text se zapíše do tabulky a čte se jinak  
**Skytala**: Proužek papíru omotaný kolem tyče
- Starověké Řecko (Sparta)
- Bez správného průměru tyče text nedává smysl

## 2. Substituční šifry
Nahrazení znaků jinými znaky

**Caesarova šifra**: Posun písmen v abecedě
- Např. posun o `3`: `A` -> `D`

**Vigenèrova šifra**: Používá klíčové slovo
- Každé písmeno se šifruje jiným posunem

## Steganografie
Utajení samotné existence zprávy

**Příklady**
- Neviditelný inkoust
- Skrytí dat v obrázku
- Ukrytý text v dokumentu

## One-Time Pad (OTP)
Teoreticky neprolomitelná šifra  
**Klíč stejně dlouhý jako zpráva, použitý pouze jednou**
- `XOR` operace s náhodným klíčem

**Nevýhoda**: Distribuce klíčů a délka klíče (1Gb soubor = 1Gb klíč)

---

# Symetrická kryptografie
Stejný klíč pro šifrování i dešifrování
- Obě strany ho musí znát

**Výhoda**: Velmi rychlá
- Vhodná pro velké objemy dat

**Nevýhody**
- Distribuce klíče: Jak bezpečně předat klíč?
- Každá dvojice uživatelů má svůj klíč
  - N uživatelů: `N * (N − 1) / 2`

---

# Blokové šifry

Data se rozdělí na **bloky pevné velikosti** (např. 128 bitů)
- Každý blok se zašifruje zvlášť

Při stejném vstupu a klíči dostaneš stejný výstup
- Může být problém

## AES (**A**dvanced **E**ncryption **S**tandard)
**Dnešní standard**  
Blok: `128` bitů  
klíče: `128` / `192` / `256` bitů

**Výhody**
- Velmi bezpečný
- Rychlý
- Skoro všude (disky, HTTPS, WiFi)

## DES (**D**ata **E**ncryption **S**tandard)
**Starý standard** (1977)  
Klíč: 56 bitů

**Problém**: Dnes **prolomitelný hrubou silou**

## Triple DES
DES použitý 3× za sebou  

**Výhoda**: Bezpečnější než DES  

**Nevýhody**
- Pomalý
- Dnes nahrazován AES

## Režimy blokových šifer

### ECB (**E**lectronic **C**ode**B**ook)
**Každý blok se šifruje samostatně**
- Stejné bloky -> stejný ciphertext
  - Odhaluje strukturu dat

**Nepoužívat**


### CBC (**C**ipher **B**lock **C**haining)

**Každý blok závisí na předchozím**
- Používá IV (inicializační vektor)


**Výhoda**: Lepší bezpečnost než ECB  
**Nevýhoda**: Špatná parallelizace


### CTR (Counter mode)
Bloková šifra se **chová jako proudová**
- Používá čítač

**Výhody**
- Rychlý
- Paralelizovatelný

### GCM (Galois/Counter Mode)
**Kombinuje šifrování a autentizaci**
- Zajišťuje: důvěrnost, integritu

---

# Proudové šifry
**Šifrování bit po bitu nebo byte po bytu**
- Generuje pseudonáhodnou posloupnost (keystream)
- `XOR` s plaintextem



## Vlastnosti
**Výhody**
- **Nízká latence**: Vhodné pro real-time
  - Např. hovory, streamy

**Nevýhody**
- Opakování klíče = katastrofa
  - Útočník může data odvodit

## Příklady

**RC4**: Dříve populární
- Dnes nebezpečný

**ChaCha20**: Moderní, rychlá, bezpečná

**Salsa20**:Ppředchůdce ChaCha20

---

# Hashovací funkce
**Jednosměrná funkce**: Nelze zpětně získat vstup
- Input je libovolně dlouhý

**Deterministická**: Stejný vstup = vždy stejný výstup

**Kolize**: 2 vstupy se stejným výstupem
- Teoreticky existují vždy (omezený výstup), ale:
- U kvalitních funkcí jsou **prakticky nenalezitelné**

## Důležité vlastnosti
1. **Jednosměrnost**: Z hashe nelze spočítat vstup
2. **Lavinový efekt**: Malá změna vstupu = velká změna hashe


## Populární hashovací algoritmy

### MD5
Výstup: 128 bitů
- Dnes **nebezpečný**

**NEpoužívat**
- Problém: Existují kolize (lze je spočítat)

Používá se už jen v kontrolních součtech (např. soubory)

### SHA-1
Výstup: 160 bitů

V roce 2017 **prokázány kolize**
- **Nepoužívat**

### SHA-256 / SHA-512
Patří do rodiny SHA-2

**Výstup**: 256 nebo 512 bitů

**Dnes**
- Standard
- Bezpečný
- Používá se skoro všude (např. HTTPS, blockchain)


### SHA-3
**Nový standard** (2015)

Jiná konstrukce než SHA-2
- Kdyby SHA-2 selahalo


### BLAKE3 (a BLAKE2)

**Moderní hashovací funkce**
- Velmi rychlá

**Výhoda**: Vyšší výkon a bezpečnost

---

# Využití hashovacích funkcí
## Ukládání hesel
**Nikdy jako plaintext**
- Uloží se pouze jejich hash

**Při přihlášení**
1. Uuživatel zadá heslo
2. Systém spočítá hash
3. Porovná s uloženým

**Správné funkce na hesla**: Bcrypt, Argon2, Scrypt
- Jsou pomalé a odolné proti brute-force


## Salt
K heslu se **přidá náhodná hodnota** (salt)
- Až pak se hashuje

**Chrání proti rainbow tables**

Každé heslo má unikátní salt

## Kontrola integrity souborů

1. Spočítáš hash souboru
2. Porovnáš s originálem

Používá se např.:
- Při stahování ISO souborů
- Kontrola aktualizací


## Identifikace malware:

Porovnání hashe souboru s databází známého malware
- VirusTotal, malware bazaar

---

# Útoky na hashe

## Brute-force
Zkoušení **všech kombinací**

**Problém**: Extrémně pomalé (u silných hesel)

## Slovníkový útok
Používá **seznam běžných hesel**

Rychlejší než brute-force

## Rainbow tables
**Předpočítané hashe**
- Obrana: Salt

## Rule-based útoky
**Upravují slova** podle pravidel
- „password“ -> „P@ssw0rd“

**Nástroje**
- Hashcat
- John the Ripper

## Mask attack
**Hádání podle vzoru**

**Např**: Velké písmeno + 3 malá + 2 čísla
- `?u?l?l?l?d?d`

---

# Aplikace symetrické kryptografie

## Aplikace symetrické kryptografie

`LUKS` (Linux), `BitLocker` (Windows), `FileVault` (macOS)

`VeraCrypt`: Multiplatformní

## Šifrovaná komunikace
TLS / SSL + VPN tunely


1. **Asymetrická** kryptografie -> Výměna klíče
2. **Symetrická** kryptografie -> samotná komunikace


## Správa klíčů

**Důležité**
- Dostatečně náhodné klíče
- Bezpečné uložení
- Pravidelná rotace

