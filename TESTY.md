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


## Nasza droga zwycięska

karta > prawo > bezpiecznik > prawo > napraw > prawo > wyjdz

## Znaleziony błąd
- Wersja/commit: 
- Kroki od startu: 
- Oczekiwane: monit: 
- Rzeczywiste:
- Poprawka i ponowna próba:
