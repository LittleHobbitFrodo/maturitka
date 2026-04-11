# 08 - Databáze

**Databáze** = Organizované úložiště dat, ve kterém je možné snadno vyhledávat, upravovat a mazat

# Co je to databáze

## Databáze vs. soubor

**Soubor** (excel, .txt)
- Data jsou **uložená jednoduše**
- **Hůř** se v nich **hledá a pracuje**
- Není vhodný pro velké množství dat

**Databáze** (např. SQL)
- **Data jsou strukturovaná** (např. tabulky)
- Rychlé vyhledávání
- Zvládá velké množství dat
- Více uživatelů může pracovat najednou

## DBMS - **D**atabase **M**anagemet **S**ystem

MySQL, PostgreSQL, Oracle, ...

**Umožňuje**
- Ukládat data
- Vyhledávat data
- Upravovat data
- Řídit přístup (kdo co může dělat)

## Typy databází
### Relační databáze (SQL)

Data jsou **uložena v tabulkách** (řádky a sloupce)
- Tabulky jsou mezi sebou propojené (relace)

| ID| Jméno | Třída |
| - | ----- | ----- |
| 1 | Jan | 4.A |
| 2 | Kuba | 3.B |

**Výhody**
- Přehlednost
- Přesná struktura
- Silná kontrola dat

### NoSQL databáze

Nemají pevnou strukturu (flexibilní schéma)
- Např. JSON

**Použití**: Aplikace s velkým množstvím dat
- Sociální sítě, ...

**Výhody**
- Flexibilita
- Škálovatelnost

### In-memory databáze

Data jsou uložená v operační paměti (RAM)
- Extrémně rychlý přístup

**Nevýhoda**: Data se mohou ztratit při vypnutí

**Použití**
- Cache (rychlé načítání dat)
- Real-time aplikace


## Využití databází

**Webové aplikace**: Ukládání uživatelů, hesel, příspěvků
- Např. sociální sítě

**Informační systémy**: Školy, firmy, nemocnice
- Evidence studentů, zaměstnanců

**E-commerce**: Produkty, objednávky, zákazníci

**Logging a analytika**: Ukládání logů
- Pozdější analýza dat

---

# Relační databáze

Ukládá data do tabulek
- Mezi sebou propojené pomocí klíčů
- Data nejsou izolovaná, ale vzájemně souvisí (relace)

## Základní pojmy

**Tabulka** (table): Kolekce souvisejících dat
- Jako tabulka v Excelu

**Řádek** (row / record): Jeden konkrétní záznam  z tabulky
- Např: `ID: 1 | Jméno: Jan | Třída: 4.A`

**Sloupec** (column / field): Jeden atribut
- Např.: jméno, datum narození, třída

**Primární klíč** (Primary Key): Jedinečný identifikátor záznamu
- Má ho každý řádek
- Nesmí se opakovat

**Cizí klíč** (Foreign Key): Odkazuje na primární klíč v jiné tabulce
- Propojení tabulek
- Např. tabulka `Orders` obsahuje `customer_ID`
  - Ten odkazuje na tabulku Zákazníci

## Datové typy
Každý sloupec má svůj datový typ

**INT**: Celá čísla

**VARCHAR(N)**: Krátké texty ("proměnná" délka)
- Maximální délka záleží na implementaci
- `N` = Maximální počet charakterů

**TEXT**: Delší texty
- Články, ...

**FLOAT / DECIMAL**: Desetinná čísla
- Float: Méně přesný (např. výpočty)
- Decimal: Přesný (např. peníze)

**DATE / DATETIME**: Časové údaje
- Date: Datum (`2026-04-09`)
- DateTime: Datum + čas (`2026-04-09 14:30`)

**BOOLEAN**: `bool` (`TRUE` / `FALSE`)


## Relace mezi tabulkami

**1:1** (one-to-one): Jeden záznam odpovídá právě jednomu
- Osoba <=> Občanský průkaz

**1:N** (one-to-many): Jeden záznam má více jiných
- Zákazník => více objednávek

**M:N** (many-to-many): Více záznamů k více záznamům
- Studenti <=> Předměty

---

# SQL - **S**tructured **Q**uery **L**anguage

## Základní příkazy
### `SELECT` - Výběr dat

**Syntax**: `SELECT * <tabulka> WHERE <podminka>;`
- `*` = Všechno

```SQL
SELECT sloupec1, sloupec2 FROM tabulka;
SELECT * FROM tabulka;
SELECT * FROM tabulka WHERE podminka;
SELECT * FROM tabulka ORDER BY sloupec ASC/DESC;
SELECT * FROM tabulka LIMIT 10;
```

### `INSERT` - Přidání nového záznamu

**Syntax**: `INSERT INTO <tabulka> (<nazvy sloupcu>, ...) VALUES (<val1>, ...);`

```sql
INSERT INTO tabulka (sloupec1, sloupec2) VALUES (hodnota1, hodnota2);
```

### `UPDATE` - Aktualizace dat

**Syntax**: `UPDATE <tab> SET <val> = <new val> WHERE <podminka>;`

```sql
UPDATE tabulka SET sloupec = hodnota WHERE podminka;
```

### `DELETE` - Mazání dat

**Syntax**: `DELETE FROM <tab> WHERE <podminka>;`

## Tvorba a správa struktury

### `CREATE` - Vytvoření databáze/tabulky

#### **Vytvoření databáze**

```sql
CREATE DATABASE <nazev_databaze>;
```

#### **Vytvoření tabulky**
**Syntax**:
```sql
CREATE TABLE <name> (
    <column_name> <type> <options>
);
```

```sql
CREATE TABLE nazev_tabulky (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nazev VARCHAR(255) NOT NULL,
    vytvoreno DATETIME DEFAULT CURRENT_TIMESTAMP
);
```

### `ALTER` - Změna struktury tabulky

#### **Přidání sloupce**
```sql
ALTER TABLE <table_name> ADD <column_name> <column_type>;
```
- Např: `ALTER TABLE studenti ADD datum_narozeni DATE;`

#### **Smazání sloupce**
```sql
ALTER TABLE studenti DROP COLUMN datum_narozeni;
```

#### **Změna sloupce**
```sql
ALTER TABLE studenti MODIFY datum_narozeni INT;
```
- Změní atribut `datum_narozeni` na typ `INT`


## `DROP` - Smazání tabulky nebo databáze

```sql
DROP TABLE tabulka;
DROP DATABASE databaze;
```

## Pokročilé dotazy

### `JOIN` – spojování tabulek
Data ve více tabulkách a chceš je spojit dohromady

#### **`INNER JOIN`**
Jen záznamy, které se shodují v obou tabulkách

```sql
SELECT * FROM studenti INNER JOIN tridy ON studenti.trida_id = tridy.id;
```
- Jen studenty, kteří mají přiřazenou třídu
  - Jen odpovídající dvojice

#### **`LEFT JOIN`**
Všechny z levé + odpovídající z pravé (`NULL` pokud neexistuje)

```sql
SELECT * FROM studenti LEFT JOIN tridy ON studenti.trida_id = tridy.id;
```
- Všichni studenti (i bez třídy)

#### **`RIGHT JOIN`**
Opak `LEFT JOIN` - všechny z pravé tabulky

```sql
SELECT * FROM studenti RIGHT JOIN tridy ON studenti.trida_id = tridy.id;
```
- Všechny třídy i bez studentů



## Agregační funkce
Výpočty nad více řádky

### `COUNT()` – počet
```sql
SELECT COUNT(*) FROM studenti;
SELECT COUNT(email) FROM studenti;
```
- `COUNT(*)` spočítá všechny řádky
- `COUNT(email)` spočítá všechny řádky, kde `email` není `NULL`

### `SUM()` – součet
```sql
SELECT SUM(platy) FROM zamestnanci;
```
- Sečte všechny `platy` zaměstnanců
- Ignoruje `NULL`

### `AVG()` – průměr
```sql
SELECT AVG(znamka) FROM znamky;
```
- Zprůměruje všechny známky
- Ignoruje `NULL`

### `MIN()` a `MAX()`
```sql
SELECT MIN(znamka), MAX(znamka) FROM znamky;
```
- Vrátí nejmenší a největší známky


## Filtrování a řazení
### `WHERE` – podmínka
```sql
SELECT * FROM studenti WHERE vek > 18;
```
- Vybere všechny studenty starší 18-ti let

### `AND` / `OR`
```sql
SELECT * FROM studenti WHERE vek > 18 AND mesto = 'Ostrava';
```
- Starší 18-ti let a z Ostravy

### `LIKE` – hledání podle vzoru
```sql
SELECT * FROM studenti WHERE jmeno LIKE 'P%';
```
- `P%` = začíná na "P"
- `%a` = končí na "a"
- `%etr%` = obsahuje „etr“


### `IN` – výběr z více možností

```sql
SELECT * FROM studenti WHERE mesto IN ('Ostrava', 'Brno');
```
- Všechny studenty z Brna a nebo Ostravy

### `BETWEEN` – rozsah
```sql
SELECT * FROM studenti WHERE vek BETWEEN 18 AND 25;
```
- Studenty s věkem v rozmezí 18 až 25

### `GROUP BY` – seskupení
```sql
SELECT mesto, COUNT(*) FROM studenti GROUP BY mesto;
```
- Rozdělí studenty podle měst a po té je spočítá
  - Kolik studentů je v každém městě?

### `HAVING` – podmínka pro skupiny
```sql
SELECT mesto, COUNT(*) FROM studenti GROUP BY mesto HAVING COUNT(*) > 10;
```
- Provede [`GROUP BY`](#group-by--seskupení), ale vrátí jen skupiny s více jak 10 členy

### `ORDER BY` – řazení

```sql
SELECT * FROM studenti ORDER BY vek ASC;
```
- `ASC`: řazení vzestupně (podle abecedy)
- `DESC`: sestupně

---

# Bezpečnost databází
## Přístupová práva

**Role**: skupina oprávnění (např. admin, čtenář)

## `GRANT` / `REVOKE`
```sql
GRANT SELECT ON studenti TO uzivatel;
REVOKE SELECT ON studenti FROM uzivatel;
```
- `GRANT`: Přidá oprávnění pro uživatele
- `REVOKE`: Odstraní oprávnění pro uživatele

Typy oprávnění:
- `SELECT`: Čtení
- `INSERT`: Vkládání
- `UPDATE`: Úpravy
- `DELETE`: Mazání

**Princip nejmenších oprávnění**: Uživatel má jen to, co nutně potřebuje
- Least Privilege
- Např. běžný uživatel => jen `SELECT`, admin => všechno

**Důvod**: Omezení škod při chybě nebo útoku


## SQL Injection
### Princip útoku

Útočník vloží SQL kód do vstupu:
- ```sql
  SELECT * FROM users WHERE name = '<input>';
  ```
- Útočník vloží: `Franta' OR 1=1 OR name = 'Pepa`

Query pak vypadá:
  - ```sql
    SELECT * FROM users WHERE name = 'Franta' OR 1=1 OR name = 'Pepa'`
    ```
  - Přečte celou databázi




### Prepared statements jako ochrana

Dovoluje "předkompilovat" query pro oddělení dat a samotného query
- ```sql
  SELECT * FROM users WHERE name = ?;
  ```
  - `?` je placeholder pro data

### Validace vstupů

Kontrola délky  
**Povolené znaky**: Zakáže např. `;`, `=`, ... pro zabránění SQL injekcí  
**Typ dat** (číslo vs text)

## Zálohování

**Proč zálohovat?**
- **Ztráta dat** (chyba, hack, HW problém)
- Návrat do minulosti

**Pravidelné zálohy**: Nejlépe automaticky (cron)

**Typy záloh**
- **Full backup**: Celá databáze  
- **Incremental**: Jen změny od poslední zálohy
- **Diferencial**: Změny od poslední plné zálohy

### Nástroje
#### **`mysqldump`**
**Backup**: `mysqldump db_name > backup-file.sql`  
**Restore**: `mysql db_name < backup-file.sql`

#### **`pg_dump`**
**Backup**: `pg_dump mydb > db.sql`  
**Restore**: `pg_restore -d newdb db.dump`


---

# NoSQL databáze
## Typy NoSQL databází

### Dokumentové

Data uložená např. jako JSON
- MongoDB

```json
{
  "jmeno": "Jan",
  "vek": 20
}
```

**Výhoda**: Felxibilní struktura

### Key-value - Redis

`"uzivatel:1" → "Jan"`

**Výhoda**: Extrémně rychlé
- V paměti

### Sloupcové - Apache Cassandra

**Optimalizované pro**
- Velké objemy dat
- Čtení

Distribuované systémy: Kubernetes (?)

### Grafové - Neo4j

Vztahové databáze - např. sociální sítě
- Uzly - lidé
- Hrany - vztahy

**Ideální pro**
- Sociální sítě
- Doporučovací systémy

## Kdy použít NoSQL

**Kdy použít**
- Neznáš přesnou strukturu dat
  - Např. posty na sociálních sítích:
    - Obrázek
    - Text
    - Video
    - Kombinace Obrázku a textu
    - ...
- Data se často mění
- Potřebuješ škálovat (více serverů)
- Pracuješ s velkými daty


## SQL vs NoSQL

**SQL**
- Tabulky (řádky + sloupce)
- Pevné schéma
- Vztahy (JOIN)
- ACID (**A**tomicity **C**onsistency **I**solation **D**urability)
- Vhodné pro
  - Banky
  - Účetnictví
  - Systémy, kde musí být přesnost

**NoSQL**
- Flexibilní struktura
  - Horizontální škálování
  - Vysoký výkon
- Vhodné pro
  - Sociální sítě
  - Real-time aplikace
  - Big data
- BASE místo ACID
  - **BASE**: **B**asically **A**vailable **S**oft state, **E**ventual consistency

---

# Populární databáze
## Relační

**MySQL / MariaDB**
- Jednoduché
- Hodně používané na webu
- Open-source

**PostgreSQL**
- Velmi pokročilé
- Podporuje JSON, GIS, atd.

**SQLite**
bez serveru (soubor)
mobilní aplikace


**Microsoft SQL Server**
- Enterprise řešení od Microslopu 👎👎👎

**Oracle Database**
- Velké firmy
- Vysoký výkon, ale drahé

## NoSQL

**MongoDB**: Nejznámější dokumentová DB
- Dokumentová databáze

**Redis**: Cache, session storage
- In-memory key-value

**Elasticsearch**: Vyhledávání (např. Google-like search)
- Fulltextové vyhledávání










