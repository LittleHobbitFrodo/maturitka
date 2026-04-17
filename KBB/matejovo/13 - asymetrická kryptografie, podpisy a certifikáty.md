# 13 - Asymetrická kryptografie, podpisy a certifikáty


1. [13 - Asymetrická kryptografie, podpisy a certifikáty](#13---asymetrická-kryptografie-podpisy-a-certifikáty)
2. [Asymetrická kryptografie](#asymetrická-kryptografie)
   1. [Princip](#princip)
   2. [Veřejný klíč](#veřejný-klíč)
   3. [Soukromý klíč](#soukromý-klíč)
3. [Rozdíly oproti symetrické kryptografii](#rozdíly-oproti-symetrické-kryptografii)
4. [Využití asymetrické kryptografie](#využití-asymetrické-kryptografie)
   1. [Šifrování zpráv](#šifrování-zpráv)
   2. [Výměna symetrických klíčů](#výměna-symetrických-klíčů)
   3. [Digitální podpisy](#digitální-podpisy)
   4. [Autentizace](#autentizace)
5. [Algoritmy asymetrické kryptografie](#algoritmy-asymetrické-kryptografie)
   1. [RSA (Rivest-Shamir-Adleman)](#rsa-rivest-shamir-adleman)
   2. [Diffie–Hellman](#diffiehellman)
   3. [ECDH (Elliptic Curve Diffie-Hellman)](#ecdh-elliptic-curve-diffie-hellman)
   4. [ECC (Elliptic Curve Cryptography)](#ecc-elliptic-curve-cryptography)
6. [Digitální podpis](#digitální-podpis)
   1. [Princip](#princip-1)
   2. [Vlastnosti digitálního podpisu](#vlastnosti-digitálního-podpisu)
   3. [Formáty digitálních podpisů](#formáty-digitálních-podpisů)
   4. [Kde se používají](#kde-se-používají)
7. [PKI (Public Key Infrastructure)](#pki-public-key-infrastructure)
   1. [Komponenty PKI](#komponenty-pki)
      1. [CA (Certificate Authority)](#ca-certificate-authority)
      2. [RA (Registration Authority)](#ra-registration-authority)
      3. [Certifikát](#certifikát)
      4. [CRL (Certificate Revocation List)](#crl-certificate-revocation-list)
      5. [OCSP (Online Certificate Status Protocol)](#ocsp-online-certificate-status-protocol)
8. [Digitální certifikáty](#digitální-certifikáty)
   1. [Obsah certifikátu](#obsah-certifikátu)
   2. [Typy certifikátů](#typy-certifikátů)
   3. [Řetězec důvěry (Chain of Trust)](#řetězec-důvěry-chain-of-trust)
9. [Certifikační autority (CA)](#certifikační-autority-ca)
   1. [Veřejné CA](#veřejné-ca)
   2. [Interní/Firemní CA](#internífiremní-ca)
10. [SSL/TLS certifikáty](#ssltls-certifikáty)
    1. [Použití](#použití)
    2. [Proces ověření (TLS handshake)](#proces-ověření-tls-handshake)
11. [Bezpečná správa klíčů](#bezpečná-správa-klíčů)
    1. [Generování klíčů](#generování-klíčů)
    2. [Úložiště klíčů](#úložiště-klíčů)
    3. [Ochrana soukromého klíče](#ochrana-soukromého-klíče)
    4. [Rotace klíčů](#rotace-klíčů)
    5. [Zneplatnění klíčů (revocation)](#zneplatnění-klíčů-revocation)
12. [Praktické nástroje](#praktické-nástroje)
    1. [OpenSSL](#openssl)
    2. [PGP / GPG (Gnu Privacy Guard)](#pgp--gpg-gnu-privacy-guard)
    3. [SSH klíče](./06%20-%20síťové%20protokoly.md#ssh---secure-shell)
    4. [Typy klíčů](#typy-klíčů)

# Asymetrická kryptografie
## Princip

**Každý uživatel má**
- **Veřejný klíč** (public key): Může ho dát komukoli
- **Soukromý klíč** (private key): Musí si ho pečlivě chránit

Kíče jsou **matematicky svázané**:
- Co **zašifruješ veřejným** klíčem, jde **rozšifrovat jen soukromým**
- Co „zašifruješ **(podepíšeš) soukromým** klíčem, jde **ověřit veřejným**


## Veřejný klíč
Je **volně dostupný**: Např. na webu nebo v certifikátu

**Použití**: Šifrování zprávy pro majitele nebo k ověření digitálního podpisu

## Soukromý klíč

**Použití**:
- **Dešifrování** zpráv
- Vytvoření digitálního podpisu

---

# Rozdíly oproti symetrické kryptografii
|Vlastnos|Symetrická|Asymetrická|
|--------|----------|-----------|
|**Počet klíčů**|1 (sdílený)|2 (veřejný + soukromý)|
|**Distribuce klíčů**|Problematická|Snadná (veřejný klíč)|
|**Rychlost**|Rychlá|Pomalá|
|**Použití**|Velké objemy dat|Malá data, výměna klíčů|
|**Pro `N` uživatelů**|`N*(N-1)/2` klíčů|`2N` klíčů|

---

# Využití asymetrické kryptografie
## Šifrování zpráv
Odesílatel použije veřejný klíč příjemce  
Zprávu může přečíst jen ten, kdo má soukromý klíč
- **Nikdo** po cestě **si zprávu nepřečte**

## Výměna symetrických klíčů
**Hybridní šifrování**: Např. v TLS
1. Použije se na začátku pro bezpečné předání klíče
2. Pak se přejde na symetrické šifrování (rychlé)


## Digitální podpisy
**Vytvoření**: soukromý klíč
**Ověření**: veřejný klíč

**Zajišťuje**
- Autenticitu (kdo to poslal)
- Integritu (zpráva nebyla změněna)
- Nepopiratelnost (autor nemůže popřít, že to poslal)

## Autentizace

Použití **místo hesla**
- Například při přihlášení přes SSH
- **Server ověří**, že vlastníš **správný soukromý klíč**

Bezpečnější než autentizace heslem

---

# Algoritmy asymetrické kryptografie

## RSA (Rivest-Shamir-Adleman)

**Nejznámější** a dlouho **nejpoužívanější**  
Funguje na problému **rozklad velkých čísel na prvočísla**
- Doporučení:
  - Minimálně `2048` bitů
  - Ideálně `4096` bitů

**Použití**
- Šifrování
- Digitální podpisy
- Výměna klíčů

## Diffie–Hellman

**Výměna klíčů** přes nezabezpečený kanál

Založen na **problému diskrétního logaritmu**

**Nevýhoda**: Neověřuje identitu -> hrozí MITM útok
- Řeší certifikáty

## ECDH (Elliptic Curve Diffie-Hellman)

Moderní verze DH na **eliptických křivkách**

Stejná bezpečnost, ale:
- **Kratší klíče**
- **Rychlejší výpočty**

## ECC (Elliptic Curve Cryptography)

Kryptografie na **eliptických křivkách**
- **Bezpečnost**: `256-bit` ECC ≈ `3072-bit` RSA
- Rychlejší a efektivnější

**Varianty**
- `ECDSA`: Digitální podpis (používá se např. v HTTPS)
- `Ed25519`: Moderní podpis
  - Rychlý, bezpečný, doporučovaný

---

# Digitální podpis

**Ověřit, kdo zprávu vytvořil a že nebyla změněna**

## Princip
1. **Vytvoření hashe** dokumentu
2. **Zašifrování hashe soukromým klíčem** -> podpis
3. **Příjemce**
    - Dešifruje podpis pomocí veřejného klíče
    - Spočítá hash přijaté zprávy
    - Porovná oba hashe

## Vlastnosti digitálního podpisu

**Autenticita**: Potvrzení identity podepsaného  
**Integrita**: Detekce změn v dokumentu  
**Nepopiratelnost**: Autor nemůže popřít podpis

## Formáty digitálních podpisů

**Detached signature**: Podpis jako samostatný soubor  
**Enveloped signature**: Podpis součástí dokumentu  
**Enveloping signature**: Dokument součástí podpisu

## Kde se používají
**Podepisování software** (code signing)  
**E-mailové podpisy** (S/MIME, PGP)  
**Elektronické dokumenty** (PDF)  
**Bankovní transakce**  
**Blockchain a kryptoměny**

---

# PKI (**P**ublic **K**ey **I**nfrastructure)
**Zajišťuje důvěru ve veřejné klíče**

**Zajišťuje důvěryhodnost** veřejných klíčů
- **Propojení identity s veřejným klíčem**

## Komponenty PKI

### CA (**C**ertificate **A**uthority)
**Vydává certifikáty**
- „Ručí“ za to, že klíč patří dané identitě

### RA (**R**egistration **A**uthority)
**Ověřuje identitu žadatele**
- Funguje jako „kontrolor“ pro CA

### Certifikát
**Digitální dokument**: Veřejný klíč + identita + podpis CA

### CRL (Certificate Revocation List)
**Seznam zneplatněných certifikátů**
- Např. při kompromitaci klíče

### OCSP (**O**nline **C**ertificate **S**tatus **P**rotocol)
**Online ověření platnosti certifikátu**
- Rychlejší než CRL

---

# Digitální certifikáty

Elektronický dokument **propojující veřejný klíč s identitou**
- Je podepsán CA
- Standard: `X.509`

## Obsah certifikátu

**Veřejný klíč** subjektu  
**Identitu** subjektu (jméno, organizace, doména)  
**Vydavatele** (CA)  
**Doba platnosti** (od - do)  
**Sériové číslo**
**Digitální podpis** CA  
**Použití klíče** (např. šifrování, podpis)

## Typy certifikátů

**DV** (**D**omain **V**alidation): Ověření vlastnictví domény  
**OV** (**O**rganization **V**alidation): Ověření organizace  
**EV** (**E**xtended **V**alidation)
- Důkladná kontrola firmy
- Dříve „zelený proužek“ v prohlížeči

## Řetězec důvěry (Chain of Trust)

1. **Root CA**
    - Hlavní autorita
    - Self-signed (podepisuje sama sebe)
    - Uložená v prohlížeči nebo OS
2. **Intermediate CA**
    - Mezilehlá autorita
    - Podepsaná root CA
    - Root klíč se nepoužívá přímo
3. **End-entity certifikát**: Certifikát serveru/uživatele
    - Prohlížeče obsahují seznam důvěryhodných root CA


---

# Certifikační autority (CA)
## Veřejné CA:

**Let’s Encrypt**: Bezplatné DV certifikáty  
**DigiCert**, **Comodo**, **GlobalSign**: Komerční
- DV, OV, EV
- Vyšší důvěra, podpora

## Interní/Firemní CA:

Pro interní systémy organizace
- Vlastní root CA

Např. intranet

**Nevýhoda**: Ručně nastavit důvěru (např. v prohlížeči)

---

# SSL/TLS certifikáty

## Použití
**HTTPS** - zabezpečení webů  
**E-mail servery** (SMTP, IMAP)  
**VPN**

## Proces ověření (TLS handshake)
1. Klient se připojí k serveru
2. Server pošle svůj certifikát
3. Klient ověří certifikát (podpis CA, platnost, doména)
4. Výměna klíčů pro symetrické šifrování
5. Šifrovaná komunikace


---

# Bezpečná správa klíčů
Nejslabší místo bezpečnosti

## Generování klíčů

Používat **kryptograficky bezpečné generátory**
- Dostatečná délka klíče
  - **RSA: min. 2048 bitů**
  - **ECC: min. 256 bitů**

Špatně vygenerovaný klíč = slabá bezpečnost

## Úložiště klíčů
**HSM** (**H**ardware **S**ecurity **M**odule)
- Specializované zařízení
- Klíče **nikdy neopustí hardware**

**TPM** (**T**rusted **P**latform **M**odule)
- Čip v počítači
- Ukládá klíče bezpečně uvnitř zařízení

**Key management systémy**
- Správa klíčů v cloudu
- HashiCorp Vault, AWS KMS

**Šifrované soubory** (s heslem)

## Ochrana soukromého klíče
**Silné heslo** (passphrase)  
Omezená přístupová práva  
Zálohování na bezpečném místě  
**Nikdy nesdílet!**

## Rotace klíčů
**Pravidelná výměna klíčů**

**Proč**
- Snížení rizika zneužití
- Omezení dopadu úniku


**Key rollover**
- Starý i nový klíč chvíli fungují zároveň
- Plynulý přechod bez výpadku

## Zneplatnění klíčů (revocation)
Používá se, když: Klíč unikne
- Certifikát už nemá být důvěryhodný

**[CRL](#crl-certificate-revocation-list)**: Seznamy zneplatněných certifikátů  
**[OCSP](#ocsp-online-certificate-status-protocol)**: Online ověření platnosti

**Nutné při kompromitaci klíče**

---

# Praktické nástroje
## OpenSSL
Základní nástroj pro práci s kryptografií
- Linux a na serverech

**Generování klíčů**: RSA, ECC klíče


**Vytvoření vlastního certifikátu**
- Generování **CSR** (**C**ertificate **S**igning **R**equest)

## **PGP** / **GPG** (**G**nu **P**rivacy **G**uard)
**GPG**: Implementace PGP (**P**retty **G**ood **P**rivacy)

Šifrování e-mailů a souborů

**Web of Trust** model
- Uživatelé si **navzájem potvrzují klíče**
- Není potřeba centrální CA
- Rozdíl oproti PKI:
  - **PKI** = Hierarchie CA
  - **PGP** = Síť důvěry

## [SSH](./06%20-%20síťové%20protokoly.md#ssh---secure-shell) klíče

**Proč**: Autentizace bez hesla

**Generování klíčů**: `ssh-keygen`

## Typy klíčů:
**Ed25519**: Doporučeno (moderní, rychlé)  
**RSA**: Starší, ale stále používané
