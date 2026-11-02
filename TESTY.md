# Próby odbiorowe

Każdą próbę zaczynamy od start. Po sekwencji wpisujemy status. Komendy z tabeli wpisujemy osobno, każdą zatwierdzając Enterem. Oczekiwania odnoszą się do limitu 10.

**tester: Igorroo**

| Nr | Próba i komendy po start | Oczekiwane | Otrzymane / osoba |
|---|---|---|---|
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
|---|---|---|---|
| T2.1 | `start`, `odkrycia`, `mapa`, `status` | Odkryty tylko pokój 1; 1/4; energia 10; jeden znacznik bieżącej pozycji. | OK |
| T2.2 | `start`, `prawo`, `lewo`, `prawo`, `odkrycia`, `status` | Odkryte pokoje 1 i 2; 2/4; pokój 2; energia 7. Powroty nie zwiększają liczby różnych pokoi. | OK |
| T2.3 | `start`, `prawo`, `prawo`, `prawo`, `odkrycia` | 4/4; energia 7. Nazwy i znaczniki zgadzają się z pozycją. | OK |
| T2.4 | `start`, `lewo`, `gora`, pusty Enter, `odkrycia` | 1/4; pokój 1; energia 10. | OK |
| T2.5 | `start`, `prawo`, `odkrycia`, `mapa`, `opis`, `status`, `odkrycia` | Nadal 2/4 i energia 9; żadna informacja nie odkrywa nowego pokoju. | OK |
| T2.6 | Po T2.3: `start`, `odkrycia` | Ponownie tylko pokój 1; energia 10. | OK |
| T2.7 | `start`; pięć razy para `prawo`, `lewo`; `prawo`, `odkrycia`, `status` | Przegrana; pokój 1; energia 0; 2/4. Ruch po końcu nie działa, odczyt działa. | OK |
| T2.8 | `start`, `karta`, `prawo`, `bezpiecznik`, `prawo`, `napraw`, `prawo`, `wyjdz`, `odkrycia` | Wygrana; energia 3; 4/4; `odkrycia` nie zmieniają wyniku. | OK |
| T2.9 | Osobny test funkcji: nazwy dla 0 i 5; zliczenie pustej `bool[]` | Nieznane pomieszczenie dla obu numerów; wynik zliczenia 0; bez odwołania poza tablicę. | OK |
| T2.10 | `  ODKRYCIA  ` ze skrajnymi spacjami | Ten sam odczyt co `odkrycia`; energia 10. | OK |

Wykonać również całe dotychczasowe próby z sekcji „Próby odbiorowe”.
