
# PVA – maturita 2045 - PROKOP SCHOVANEC

### Konvence, klíčová slova, datové a výčtové typy, proměnná, konstanta, přetypování, konverze datových typů

---

### KONVENCE

- **dohoda, úmluva**, společenské pravidlo, ustálený způsob jednání
- doporučený styl zápisu programu, postupy, metody pro daný programovací jazyk
  - adresářová struktura
  - komentáře, deklarace, příkazy
- lepší čitelnost a udržitelnost

#### Příklady konvencí

- `PascalCase` / `camelCase`
- smysluplné názvy proměnných a metod
  - `_privateVariable`
  - `IMujInterface`
- vertikálně zarovnané složené závorky

```csharp
DoSomethingPlease(hi: "cus", numero: 54334);
```

---

### KLÍČOVÁ SLOVA

- identifikátory se speciálním významem pro kompilátor
- vyhrazená slova programovacího jazyka

#### Kontextová klíčová slova

- nejsou vyhrazená
- význam mají pouze v určitém kontextu

---

### DATOVÉ A VÝČTOVÉ TYPY

#### Datové typy

##### Hodnotové typy

- ukládají hodnotu přímo
- `int`, `decimal`, `char`, `bool`, `struct`, `enum`

#### Referenční typy

- ukládají referenci na objekt
- `string`, `class`, `array`

### Výčtové typy (`enum`)

```csharp
enum Stav
{
    Start,
    Stop,
    Pause
}
```

- konečná množina pojmenovaných hodnot
- standardně typu `int`

---

## PROMĚNNÁ A KONSTANTA

### Proměnná

- jazykový konstrukt pro ukládání dat
- proměnné nesmí mít ve stejném rozsahu stejný název

### Konstanty

```csharp
const int Max = 10;
```

- neměnné
- hodnota musí být známa při kompilaci

---

## PŘETYPOVÁNÍ A KONVERZE DATOVÝCH TYPŮ

### Explicitní konverze (casting)

```csharp
double x = (double)myInt;
```

### Implicitní konverze

```csharp
double x = 1 + 2.5;
```

### Pomocné třídy

- `Convert`
- `Int32.Parse()`
- `TryParse()`

---

## REFERENČNÍ A HODNOTOVÉ DATOVÉ TYPY

### Stack (zásobník)

- lokální proměnné
- rychlý
- automatické uvolnění paměti

### Heap (halda)

- objekty
- dynamická alokace
- garbage collector

### Value types

- kopíruje se hodnota
- nemohou být `null`

### Reference types

- kopíruje se reference
- mohou být `null`

---

## TŘÍDĚNÍ

- algoritmy pro řazení prvků

### Typy řazení

- bubble sort
- heap sort
- quick sort
- merge sort
- insertion sort
- selection sort

---

# PRAVOMIL LEFTICZ

## Řízení toku programu, prvočísla

---

## ŘÍZENÍ TOKU PROGRAMU

### Výběr

```csharp
if
else
switch
```

### Iterace

```csharp
for
while
do-while
foreach
```

### Skok

```csharp
break
continue
goto
return
```

---

## DEFINICE PRVOČÍSLA

- přirozené číslo větší než 1
- dělitelné pouze:
  - jedničkou
  - samo sebou

---

## ALGORITMY PRO URČENÍ PRVOČÍSLA

### Zkusmé dělení

- testujeme dělitele

### Eratostenovo síto

- vyškrtávání násobků prvočísel

---

# ROMAN

## Kolekce, frekvenční analýza

---

## KOLEKCE

### List

```csharp
List<int> list = new List<int>();
```

### Dictionary

```csharp
Dictionary<string, int> dict =
    new Dictionary<string, int>();
```

### Stack

```csharp
Stack<int> stack = new Stack<int>();
```

---

## FREKVENČNÍ ANALÝZA

- nástroj kryptoanalýzy
- využívá četnosti znaků
- používá se proti substitučním šifrám

---

# REGULÁRNÍ VÝRAZY

## REGEX

```csharp
Regex rg = new Regex(pattern);
```

- `IsMatch()`
- `Match()`
- `Matches()`
- `Replace()`

---

# SOUBORY A STREAMY

## PRÁCE SE SOUBORY

### Namespaces

```csharp
System.IO
```

### Třídy

- `File`
- `Directory`
- `Path`
- `StreamReader`
- `StreamWriter`

---

## FILESTREAM

```csharp
FileStream fs =
    new FileStream(path, FileMode.Open);
```

- práce po bytech
- `ReadByte()`
- `WriteByte()`
- `Seek()`

---

# METODY

## METODY

- pojmenovaný blok kódu

### Parametry

#### Předávání hodnotou

```csharp
void Fn(int x)
```

#### Předávání referencí

```csharp
void Fn(ref int x)
void Fn(out int x)
```

---

# OOP

## TŘÍDY

```csharp
class Human
{
}
```

## KONSTRUKTOR

```csharp
public Human(string name)
{
}
```

## DĚDIČNOST

```csharp
class Dog : Animal
{
}
```

## POLYMORFISMUS

```csharp
virtual void Speak()
override void Speak()
```

---

# ABSTRAKTNÍ TŘÍDY A INTERFACES

## ABSTRAKTNÍ TŘÍDA

```csharp
abstract class Animal
{
}
```

## INTERFACE

```csharp
interface IFlyable
{
}
```

---

# DELEGÁTY A LAMBDA

## DELEGATE

```csharp
public delegate int Calc(int x, int y);
```

## LAMBDA

```csharp
x => x * x
```

---

# KRYPTOGRAFIE

## SYMETRICKÉ ŠIFROVÁNÍ

- AES
- DES
- RC4

## ASYMETRICKÉ ŠIFROVÁNÍ

- RSA
- veřejný a soukromý klíč

## HASHOVÁNÍ

- MD5
- SHA-256
- SHA-512

---

# POLE

## JEDNOROZMĚRNÉ POLE

```csharp
int[] arr = new int[10];
```

## DVOUROZMĚRNÉ POLE

```csharp
int[,] matrix = new int[5,5];
```

## JAGGED ARRAY

```csharp
int[][] jagged =
{
    new int[] {1,2},
    new int[] {3,4,5}
};
```

---

# VÝJIMKY

## TRY / CATCH

```csharp
try
{
}
catch(Exception e)
{
}
finally
{
}
```

---

# DATUM A ČAS

## DATETIME

```csharp
DateTime.Now
```

## TIMESPAN

```csharp
TimeSpan.FromHours(5)
```

## STOPWATCH

```csharp
Stopwatch sw = new Stopwatch();
```

---

# NÁVRHOVÉ VZORY

## SINGLETON

- jedna instance třídy

## OBSERVER

- pozorovatelé reagují na změny

## PROXY

- zástupce jiného objektu

---

# STRUKTURA PROJEKTU

## `.csproj`

- konfigurace projektu

## Příkazy

```bash
dotnet new
dotnet run
dotnet build
```
