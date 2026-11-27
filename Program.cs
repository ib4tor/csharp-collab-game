using System;
using System.Runtime.CompilerServices;
// WSPOLNY KONTRAKT. Wszystkie dane inicjalizujemy przed Start().
const int MAKS_ENERGIA = 10;
int pokoj = 1;
int energia = MAKS_ENERGIA;
bool karta = false;
bool bezpiecznik = false;
bool zasilanie = false;
bool koniec = false;
bool wygrana = false;
int movesCounter = 0;
string[] pokoje = ["Recepcja", "Magazyn", "Serwerownia", "Wyjscie"];

DziennikWypraw dziennikWypraw = new DziennikWypraw();

string OcenaEnergii(int wartosc) {
    if (wartosc > MAKS_ENERGIA || wartosc < 0) return "Nieprawidłowa wartość";
    if (wartosc >= 7) {
        return "Duży zapas";
    } else if (wartosc >= 4) {
        return "Uważaj na zbędne ruchy";
    } else if (wartosc >= 1) {
        return "Niski zapas";
    } else {
        return "Brak energii";
    }
}

string EnergiaPasek() {
    string bar = "[";
    for (int i = 0; i < energia; i++) {
        bar += '#';
    }
    for (int i = 0; i < MAKS_ENERGIA - energia; i++) {
        bar += "_";
    }
    return bar + "]";
}

void Podsumowanie() {
    PokazOdkrycia();
    Dziennik(true);
}

void PokazOdkrycia() {
    for (int i = 1; i <= 4; i++) {
        if (dziennikWypraw.CzyOdwiedzono(i)) {
            Console.WriteLine($"{i} {pokoje[i - 1]}");
        }
    }
    Console.WriteLine($"Odkryte: {dziennikWypraw.IloscOdkrytych()}");
    if (dziennikWypraw.IloscOdkrytych() == "2/4") {
        Console.WriteLine("Odkryto połowę mapy.");
    } else if (dziennikWypraw.IloscOdkrytych() == "4/4") {
        Console.WriteLine("Odkryto całą mapę.");
    }
}

string progresPasek() {
    int count = 0;
    if (wygrana) {
        count++;
    }
    if (zasilanie) {
        count += 2;
    }
    if (bezpiecznik) {
        count++;
    }
    if (karta) {
        count++;
    }
    string bar = "progres: ";
    for (int i = 0; i < count; i++) {
        bar += "#";
    }

    return bar;
}

string listaPostepu() {
    char marker = '*';
    char kartaMarker = karta ? marker : ' ';
    char bezpiecznikMarker = bezpiecznik ? marker : ' ';
    if (!bezpiecznik && zasilanie) bezpiecznikMarker = marker;
    char zasilanieMarker = zasilanie ? marker : ' ';
    char wygranaMarker = wygrana ? marker : ' ';

    return $"[{kartaMarker}] znaleziono kartę\n[{bezpiecznikMarker}] znaleziono bezpiecznik\n[{zasilanieMarker}] przywrócono zasilanie\n[{wygranaMarker}] Wygrana!";
}

void Dziennik(bool sort) {
    // wypisz 3 ostatnie wpisy
    if (dziennikWypraw.LiczbaWpisow == 0) {
        Console.WriteLine("Historia jest pusta. Brak wpisów.");
    } else {
        if (sort) {
            for (int i = 3; i >= 0; i--) {
                if (dziennikWypraw.LiczbaWpisow >= i + 1) {
                    Console.WriteLine($"{dziennikWypraw.PobierzWpis(i)}");
                }
            }
        } else {
            for (int i = 0; i < 3; i++) {
                if (dziennikWypraw.LiczbaWpisow >= i + 1) {
                    Console.WriteLine($"{i + 1}. {dziennikWypraw.PobierzWpis(i)}");
                }
            }
        }
    }
}

Start();
while (true) {
    Console.Write("> ");
    string? wejscie = Console.ReadLine();
    if (wejscie == null) {
        Console.WriteLine("Koniec wejscia. Zamykam program.");
        break;
    }

    string polecenie = wejscie.Trim().ToLowerInvariant();
    if (polecenie == "koniec") {
        Console.WriteLine("Do zobaczenia!");
        break;
    }
    if (polecenie == "") {
        Console.WriteLine("Wpisz polecenie albo pomoc.");
        continue;
    }

    switch (polecenie) {
        case "start": Start(); break;
        case "pomoc": Pomoc(); break;
        case "status": Status(); break;
        case "mapa": Mapa(); break;
        case "opis": Rozejrzyj(); break;
        case "lewo": Idz("lewo"); break;
        case "prawo": Idz("prawo"); break;
        case "karta": Akcja("karta"); break;
        case "bezpiecznik": Akcja("bezpiecznik"); break;
        case "napraw": Akcja("napraw"); break;
        case "wyjdz": Akcja("wyjdz"); break;
        case "odkrycia": PokazOdkrycia(); break;
        case "dziennik": Dziennik(false); break;
        case "dziennik2": Dziennik(true); break;
        case "podsumowanie": Podsumowanie(); break;
        default: Console.WriteLine("Nieznane polecenie. Wpisz pomoc."); break;
    }
}

void Start() {
    movesCounter = 0;
    pokoj = 1;
    energia = MAKS_ENERGIA;
    karta = false;
    bezpiecznik = false;
    zasilanie = false;
    koniec = false;
    wygrana = false;
    dziennikWypraw.Reset();
    Console.WriteLine("UCIECZKA Z SERWEROWNI: PIATEK, 16:59.");
    Console.WriteLine("Administrator napisal: u mnie dziala. Drzwi twierdza inaczej.");
    Console.WriteLine("Masz " + MAKS_ENERGIA + " energii. Wpisz pomoc. Koniec zamyka program.");
    Rozejrzyj();
    Console.WriteLine("Odkryto nowy pokój!!! Witaj w " + pokoje[pokoj - 1]);
}

void ZakonczTure() {
    energia = energia - 1;
    // Console.WriteLine("Pozostala energia: " + energia);
    Console.WriteLine("Energia: " + EnergiaPasek());
    if (wygrana) {
        koniec = true;
        Console.WriteLine("WYGRANA! Drzwi otwarte. Weekend uratowany.");
    } else if (energia <= 0) {
        koniec = true;
        Console.WriteLine("PRZEGRANA. Energia sie skonczyla. Wpisz start albo koniec.");
    }
}

void Status() {
    Console.WriteLine("Pokoj: " + pokoj);
    Console.WriteLine("Odkryte pokoje: " + dziennikWypraw.IloscOdkrytych());
    Console.WriteLine("Ilosc krokow: " + movesCounter);
    Console.WriteLine("Energia: " + EnergiaPasek());
    Console.WriteLine(listaPostepu());
    Console.WriteLine(progresPasek());
    Console.WriteLine("Energia: " + EnergiaPasek() + " - " + OcenaEnergii(energia));
    Console.WriteLine("Karta: " + karta);
    Console.WriteLine("Bezpiecznik: " + bezpiecznik);
    Console.WriteLine("Zasilanie: " + zasilanie);
    Console.WriteLine("Koniec: " + koniec);
    Console.WriteLine("Wygrana: " + wygrana);
}

string NazwaPokoju(int numer) {
    if (numer < 1 || numer > pokoje.Length) {
        return "Pokoj " + numer;
    }
    return pokoje[numer - 1];
}

void Pomoc() {
    Console.WriteLine("Z czym potrzebujesz pomocy?\n 1.RUCH \n 2.PRZEDMIOTY \n 3.INFORMACJE \n 4.STEROWANIE ROZGRYWKA");
    string? dPomoc = Console.ReadLine();
    if (dPomoc == "1") {
        Console.WriteLine("------ R U C H ------");
        Console.WriteLine("lewo  - ruch o jeden pokój w lewo (zabiera 1 energii)");
        Console.WriteLine("prawo  - ruch o jeden pokój w prawo (zabiera 1 energii)");
    } else if (dPomoc == "2") {
        Console.WriteLine("------ P R Z E D M I O T Y i D Z I A Ł A N I A ------");
        Console.WriteLine("karta        - próba zabrania karty (zabiera 1 energii)");
        Console.WriteLine("bezpiecznik  - próba zabrania bezpiecznika (zabiera 1 energii)");
        Console.WriteLine("napraw       - próba naprawy zasilania (zabiera 1 energii, mozna naprawic gdy ma sie bezpiecznik)");
        Console.WriteLine("wyjdz        - próba otwarcia drzwi (czynność w grze, nie wyjście z programu)");
    } else if (dPomoc == "3") {
        Console.WriteLine("------ I N F O R M A C J E ------");
        Console.WriteLine("pomoc        - polecenia i zasady");
        Console.WriteLine("status       - dane rozgrywki");
        Console.WriteLine("mapa         - cztery pokoje i jeden znacznik");
        Console.WriteLine("opis         - rozejrzenie się w aktualnym pokoju");
        Console.WriteLine("odkrycia     - odkryte pomieszczenia");
        Console.WriteLine("dziennik     - dziennik ostatnich udanych czynności");
        Console.WriteLine("dziennik2    - dziennik ostatnich udanych czynności sortowany od najnowszych");
        Console.WriteLine("podsumowanie - podsumowanie twojej rozgrywki");
    } else if (dPomoc == "4") {
        Console.WriteLine("start        - nowa gra");
        Console.WriteLine("koniec       - zamknięcie programu (wyjście z gry)");
    } else {
        Console.WriteLine("Nieznane polecenie");
    }
}

void Mapa() {
    Console.WriteLine("-------- M A P A --------");
    for (int i = 1; i <= 4; i++) {
        string space = "";
        for (int s = 0; s <= i - 1; s++) { space += "  "; }
        string marker = "";
        if (pokoj == i) { marker = "<-- jesteś tutaj"; }
        string visitedMarker = "[ ]";
        if (dziennikWypraw.CzyOdwiedzono(i)) { visitedMarker = "[*]"; }
        Console.WriteLine(space + " " + visitedMarker + " " + NazwaPokoju(i) + " " + marker);
    }
    Console.WriteLine($"\n----- L E G E N D A -----\n[ ] - nieodkryty pokój\n[*] - odkryty pokój\n<-- - aktualna lokalizacja");
}

void Rozejrzyj() {
    Console.WriteLine("Jestes w: " + NazwaPokoju(pokoj));
    if (pokoj == 1) {
        Console.WriteLine($"Następny pokój: {NazwaPokoju(pokoj + 1)}");
        Console.WriteLine($"Możliwy kierunek: prawo");
    } else if (pokoj < 4) {
        Console.WriteLine($"Poprzedni pokój: {NazwaPokoju(pokoj - 1)}");
        Console.WriteLine($"Następny pokój: {NazwaPokoju(pokoj + 1)}");
        Console.WriteLine($"Możliwe kierunki: prawo, lewo");

    } else if (pokoj == 4) {
        Console.WriteLine($"Poprzedni pokój: {NazwaPokoju(pokoj - 1)}");
        Console.WriteLine($"Możliwy kierunek: lewo");
    }
    if (energia == 0) {
        Console.WriteLine("Brak energi. Nałożono blokade ruchu.");
    }

    if (pokoj == 1) {
        Console.WriteLine("karta jest na biurku tylko przed zabraniem");
    } else if (pokoj == 2) {
        Console.WriteLine("bezpiecznik jest na półce tylko, gdy nie ma go w kieszeni i nie jest zamontowany");
    } else if (pokoj == 3) {
        if (zasilanie) Console.WriteLine("zasilanie włączone");
        if (!zasilanie) Console.WriteLine("zasilanie wyłączone");
    } else if (pokoj == 4) {
        Console.WriteLine("przypomnij kartę i prąd");
    }
}

void Idz(string kierunek) {
    if (koniec) {
        Console.WriteLine("Koniec gry");
        return;
    }
    int nastepnyPokoj = pokoj;
    if (kierunek == "prawo") {
        nastepnyPokoj += 1;
    } else if (kierunek == "lewo") {
        nastepnyPokoj -= 1;
    } else {
        Console.WriteLine("Nieznany kierunek, stoisz w miejscu");
        return;
    }
    if (kierunek == "góra" || kierunek == "dół" || nastepnyPokoj == 5 && kierunek == "prawo" || nastepnyPokoj == 0 && kierunek == "lewo") {
        Console.WriteLine("Udzerzyłeś w ściane!!! Energia nie zostala zabrana.");
        return;
    }
    pokoj = nastepnyPokoj;

    if (dziennikWypraw.CzyOdwiedzono(pokoj) == false) {
        if (dziennikWypraw.IloscOdkrytych() == "1/4") {
            Console.WriteLine("To już Twój drugi odkryty pokój. Robisz postępy!");
        } else if (dziennikWypraw.IloscOdkrytych() == "2/4") {
            Console.WriteLine("Masz już 3 odkryte pokoje. Został ostatni!");
        } else if (dziennikWypraw.IloscOdkrytych() == "3/4") {
            Console.WriteLine("Gratulacje! Znasz już całą mapę.");
        }
    }

    dziennikWypraw.Odwiedz(pokoj);
    movesCounter += 1;
    dziennikWypraw.DodajWpis($"Wykonano ruch w {kierunek}");
    Rozejrzyj();
    ZakonczTure();
}

void Akcja(string co) {
    if (koniec == false) {
        if (co == "karta") {
            if (pokoj == 1 && karta == false) {
                karta = true;
                Console.WriteLine("Zbierasz karte.");
                movesCounter += 1;
                dziennikWypraw.DodajWpis($"Zebrano przedmiot {co}");
                ZakonczTure();
            } else if (pokoj != 1) {
                Console.WriteLine("Tutaj nie ma karty do zebrania.");
            } else if (karta == true) {
                Console.WriteLine("Posiadasz juz karte.");
            }
        }

        if (co == "bezpiecznik") {
            if (pokoj == 2 && bezpiecznik == false && zasilanie == false) {
                bezpiecznik = true;
                Console.WriteLine("Zbierasz bezpiecznik.");
                movesCounter += 1;
                dziennikWypraw.DodajWpis($"Zebrano przedmiot {co}");
                ZakonczTure();
            } else if (pokoj != 2) {
                Console.WriteLine("Tutaj nie ma bezpiecznika do zebrania.");
            } else if (zasilanie == true && pokoj == 2) {
                Console.WriteLine("Zasilanie jest juz wlaczone.");
            } else if (pokoj == 2 && bezpiecznik == true && zasilanie == false) {
                Console.WriteLine("Posiadasz juz bezpiecznik.");
            }
        }

        if (co == "napraw") {
            if (pokoj == 3 && bezpiecznik == true && zasilanie == false) {
                zasilanie = true;
                bezpiecznik = false;
                movesCounter += 1;
                Console.WriteLine("Naprawiasz skrzynke z bezpiecznikami. Przywrocono zasilanie.");
                dziennikWypraw.DodajWpis($"Naprawiono skrzynkę z bezpiecznikami");
                ZakonczTure();
            } else if (pokoj != 3) {
                Console.WriteLine("Tutaj nie ma skrzynki z bezpiecznikami.");
            } else if (zasilanie == true && pokoj == 3) {
                Console.WriteLine("Zasilanie jest juz wlaczone.");
            } else if (pokoj == 3) {
                Console.WriteLine("Nie posiadasz bezpiecznika."); //tak
            }
        }
    } else {
        Console.WriteLine("Brak energii.");
    }

    if (co == "wyjdz") {
        if (pokoj == 4 && karta && zasilanie) {
            wygrana = true;
            koniec = true;
            movesCounter += 1;
            dziennikWypraw.DodajWpis($"Gracz wyszedł z serwerowni");
            ZakonczTure();
        } else if (pokoj != 4) {
            Console.WriteLine("Tutaj nie ma wyjscia.");
        } else if (pokoj == 4 && karta == false && zasilanie == false) {
            Console.WriteLine("Nie posiadasz karty oraz zasilanie nie jest wlaczone.");
        } else if (pokoj == 4 && karta == false) {
            Console.WriteLine("Nie posiadasz karty.");
        } else if (pokoj == 4 && zasilanie == false) {
            Console.WriteLine("Zasilanie nie jest wlaczone.");
        }
    }
}
