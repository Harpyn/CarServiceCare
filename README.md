# CarServiceCare
CarServiceCare system for customers
Online servisní kniha
Technologie
ASP.NET MVC 5
EF Code first
Bootstrap 3
Javascript 
Repository Pattern
Web Api
Asp.Net Identity
GitHub
Popis projektu
Vytvoření elektronické servisní knihy pro účely firmy Car service care s.r.o. Systém bude rozlišovat dvě role admina a uživatele.

Github
https://github.com/Harpyn/CarServiceCare.git
Struktura technických řešení
Entity
Uživatel
Uživatel bude mít možnost si nastavit jaké sekce z entit bude chtít zobrazovat a používat
změnit si heslo, email
ID uživatel
Jméno
Příjmení
Obrázek
Moje auta - přehled
Admin i zákazník může přidávat a upravovat + fotodokumentace
ID auta
Značka
Model
Karoserie
Palivo
Objem:
Výkon
Označení
Rok
Barva
SPZ
VIN
Km při koupi
Zakoupeno
Majitelů

Státní technické kontroly - přehled
Admin i zákazník může přidávat a upravovat + fotodokumentace
ID auta
Datum
Platná do
Stanice
Poznámka
Tachometr
Cena
Prošla

Pojištění auta - přehled
Admin i zákazník může přidávat a upravovat + fotodokumentace
ID auta
Datum
Typ pojištění
Pojišťovna
Období
Platná do
Cena

Výměny pneumatik - přehled
Admin i zákazník může přidávat a upravovat + fotodokumentace
ID auta
Datum
Původ
Počet
Značka
Znovu vyváženo
Servis
Typ
Tachometr
Cena

Hotové servisní zásahy - přehled
Admin i zákazník může přidávat a upravovat + fotodokumentace
ID auta
Datum
Kategorie
Servis
Rozsah
Tachometr
Cena


Zbývající a plánované opravy - přehled
Admin i zákazník může přidávat a upravovat + fotodokumentace
ID auta
Oprava
Odhadovaná cena
Priorita


Vedlejší výdaje - přehled
Admin i zákazník může přidávat a upravovat + fotodokumentace
ID auta
Datum
Druh
Poznámka
Cena


Tankování paliva - přehled
Zákazník může přidávat a upravovat + fotodokumentace (účtenky)
ID auta
Datum
Stanice
Palivo
Trasa
Styl jízdy
Tachometr
Ujeto
Spotřeba
Litrů
Cena za litr
Cena
Registrace
Jméno
Příjmení
Email
Telefonní číslo

Google api
Facebook api
Upozornění
Systém může uživatele upozorňovat v případech
blížící se další kontroly (výměna oleje, roční kontrola)
blížící se konec platnosti STK
Upozornění budou zasílána elektronicky na e-mailovou adresu v kartě uživatele
