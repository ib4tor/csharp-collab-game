# Próby odbiorowe

Każdą próbę zaczynamy od start. Po sekwencji wpisujemy status. Komendy z tabeli wpisujemy osobno, każdą zatwierdzając Enterem. Oczekiwania odnoszą się do limitu 10.

**tester: Igorroo**

| Nr | Próba i komendy po start | Oczekiwane | Otrzymane / osoba |
| --- | --- | --- | --- |
| 1 | mapa, pomoc, opis, status | 4 pokoje, 1 znacznik przy recepcji; energia 10 | OK |
| 2 | lewo, gora, pusty Enter | Pokój 1, energia 10 | OK |
| 3 | prawo | Pokój 2, energia 9 | OK |
| 4 | prawo, prawo, prawo, prawo | Pokój 4, energia 7; ostatni ruch odrzucony | OK |
| 5 | karta, karta | Karta True, energia 9 | OK |
| 6 | bezpiecznik | Bezpiecznik False, energia 10 | OK |
| 7 | prawo, prawo, napraw | Pokój 3, energia 8, zasilanie False | OK |
| 8 | karta, prawo, prawo, prawo, wyjdz | Brak zasilania; pokój 4, energia 6, koniec False | OK |
| 9 | prawo, bezpiecznik, prawo, napraw, prawo, wyjdz | Brak karty; pokój 4, energia 5, koniec False | OK |
| 10 | karta, prawo, bezpiecznik, prawo, napraw, lewo, bezpiecznik | Energia 4, zasilanie True, bezpiecznik False; nie odradza się | OK |
| 11 | Znajdźcie drogę zwycięską i zapiszcie ją poniżej | Jedna wygrana, bez jednoczesnej przegranej | OK |
| 12 | Pięć razy para prawo, lewo | Pokój 1, energia 0, koniec True, wygrana False | OK |
| 13 | Po próbie 12: prawo, karta, status | Stan nie zmienia się; informacje nadal działają | OK |
| 14 | Po końcu gry: start, status | Pokój 1, energia 10, wszystkie flagi False | OK |
| 15 | Wpisz spacje + PRAWO + spacje | Pokój 2, energia 9; wielkość liter i skrajne spacje nie przeszkadzają | OK |
| 16 | koniec | Aplikacja wraca do terminala | OK |
| 17 | start, status | wszystkie etapy nie wykonane | OK |
| 18 | start, prawo, bezpiecznik, prawo, napraw, status | Zdobycie bezpiecznika i naprawa wykonane; karta i wyjście niewykonane | OK |
| 19 | Po dowolnej wygranej: status, start, status | Najpierw wszystkie etapy wykonane, następnie wszystkie wyzerowane. | OK |
| 20 | prawo, **status**, prawo, lewo, prawo, **status**, prawo, lewo, prawo, **status**, lewo, prawo, lewo, **status** | Duzy zapas > Uważaj na zbędne ruchy > Niski zapas > Brak energii | OK |
| 21 | prawo, opis | Jestes w: Magazyn, Poprzedni pokój: Recepcja, Następny pokój: Serwerownia, Możliwe kierunki: prawo, lewo | OK |
| 22 | opis | Jestes w: Recepcja, Następny pokój: Magazyn, Możliwy kierunek: prawo | OK |
| 23 | opis | Jestes w: Recepcja | OK |
| 24 | prawo, lewo, mapa | dwa odkryte `[*]` i dwa nie odkryte `[ ]` | OK |

## Nasza droga zwycięska

karta > prawo > bezpiecznik > prawo > napraw > prawo > wyjdz

## Znaleziony błąd

- Wersja/commit:
- Kroki od startu:
- Oczekiwane: monit:
- Rzeczywiste:
- Poprawka i ponowna próba:

# Próby odbiorowe R2

Każdą próbę zaczynamy od `start`. Komendy wpisujemy osobno, każdą zatwierdzając Enterem.

| ID | Próba i komendy po `start` | Oczekiwane | Otrzymane / osoba |
| --- | --- | --- | --- |
| T2.1 | `start`, `odkrycia`, `mapa`, `status` | Odkryty tylko pokój 1; 1/4; energia 10; jeden znacznik bieżącej pozycji. | OK |
| T2.2 | `start`, `prawo`, `lewo`, `prawo`, `odkrycia`, `status` | Odkryte pokoje 1 i 2; 2/4; pokój 2; energia 7. Powroty nie zwiększają liczby różnych pokoi. | OK |
| T2.3 | `start`, `prawo`, `prawo`, `prawo`, `odkrycia` | 4/4; energia 7. Nazwy i znaczniki zgadzają się z pozycją. | OK |
| T2.4 | `start`, `lewo`, `gora`, pusty Enter, `odkrycia` | 1/4; pokój 1; energia 10. | OK |
| T2.5 | `start`, `prawo`, `odkrycia`, `mapa`, `opis`, `status`, `odkrycia` | Nadal 2/4 i energia 9; żadna informacja nie odkrywa nowego pokoju. | OK |
| T2.6 | Po T2.3: `start`, `odkrycia` | Ponownie tylko pokój 1; energia 10. | OK |
| T2.7 | `start`; pięć razy para `prawo`, `lewo`; `prawo`, `odkrycia`, `status` | Przegrana; pokój 1; energia 0; 2/4. Ruch po końcu nie działa, odczyt działa. | OK |
| T2.8 | `start`, `karta`, `prawo`, `bezpiecznik`, `prawo`, `napraw`, `prawo`, `wyjdz`, `odkrycia` | Wygrana; energia 3; 4/4; `odkrycia` nie zmieniają wyniku. | OK |
| T2.9 | Osobny test funkcji: nazwy dla 0 i 5; zliczenie pustej `bool[]` | Nieznane pomieszczenie dla obu numerów; wynik zliczenia 0; bez odwołania poza tablicę. | OK |
| T2.10 | `ODKRYCIA` ze skrajnymi spacjami | Ten sam odczyt co `odkrycia`; energia 10. | OK |

| ID | Próba | Oczekiwanie | Otrzymane |
| --- | --- | --- | --- |
| T3.1 | `start`, `dziennik`, `odkrycia`, `status` | Brak wpisów; 1/4; energia 10. | |
| T3.2 | `start`, `karta`, `karta`, `lewo`, `mapa`, `dziennik` | Jeden wpis o udanym zabraniu karty; odmowy i mapa nic nie dopisują; energia 9. | OK |
| T3.3 | `start`, `karta`, `prawo`, `bezpiecznik`, `prawo`, `dziennik` | Trzy wpisy: ruch do 2, zabranie bezpiecznika, ruch do 3. Najstarszy wpis o karcie zniknął; energia 6. | OK |
| T3.4 | Po T3.3: `start`, `dziennik`, `odkrycia` | Pusto i tylko pokój 1; brak starych wpisów po ponownym dodawaniu. | OK |
| T3.5 | `start`; powtórz parę (`prawo`, `lewo`) dokładnie 5 razy; następnie karta, prawo, dziennik, status | Energia 0, przegrana; ostatnie trzy wpisy odpowiadają lewo/prawo/lewo; odmowy po końcu nie zmieniają dziennika. | NUH UH |
| T3.6 | `start`, `karta`, `prawo`, `bezpiecznik`, `prawo`, `napraw`, `prawo`, `wyjdz`, `dziennik` | Wygrana, energia 3; trzy ostatnie wpisy: naprawa, ruch do 4, udane wyjście. | OK |
| T3.7 | Osobny projekt prób: dwa nowe obiekty a i b; a.Odwiedz(2), a.DodajWpis("A") | a: 2 odkrycia, 1 wpis; b: 1 odkrycie, 0 wpisów. | OK |
| T3.8 | Osobny obiekt: DodajWpis(null), DodajWpis(""), DodajWpis("   "), potem DodajWpis("  A  ") | Pierwsze trzy wywołania nic nie zapisują; jeden wpis dokładnie A po ostatnim. | OK |
| T3.9 | Osobny obiekt: Odwiedz(0), Odwiedz(5), CzyOdwiedzono(0), PobierzWpis(-1), PobierzWpis(0) | Odkrycia nadal 1; odczyt false, oba odczyty wpisu puste; bez awarii. | OK |
| T3.10 | Osobny obiekt: wpisy A, B, C, D, E; odczyt; Reset; wpis X; odczyt | Najpierw C, D, E; potem tylko X, liczba 1; bez starych tekstów. | OK |
| T3.11 | `start`, komenda DZIENNIK ze skrajnymi spacjami, `dziennik` | Dwa identyczne puste odczyty, energia 10. | OK |
| T3.12 | Całe T2.1–T2.10 oraz stare TESTY.md | Te same wyniki odkryć i reguł gry po zmianie struktury. W T2.9 zachowaj próby nazw dla 0 i 5. Próbę pustej tablicy zastąp odczytem LiczbaOdwiedzonych nowego obiektu i po Reset: oba wyniki 1; po dwukrotnym Odwiedz(2) wynik 2. | OK |
