    public class DziennikWyprawy
    {
        private bool[] odwiedzonePokoje = { true, false, false, false };
        private string[] historiaWpisow = new string[3] { "", "", "" };
        private int liczbaWpisow = 0;

        public DziennikWyprawy()
        {
            Reset();
        }
        public int LiczbaOdwiedzonych
        {
            get
            {
                int zliczone = 0;
                foreach (bool o in odwiedzonePokoje)
                {
                    if (o) zliczone++;
                }
                return zliczone;
            }
        }

        public int LiczbaWpisow
        {
            get { return liczbaWpisow; }
            private set { liczbaWpisow = value; }
        }

        public void Reset()
        {
            odwiedzonePokoje = new bool[] { true, false, false, false };
            liczbaWpisow = 0;
            for (int i = 0; i < historiaWpisow.Length; i++)
            {
                historiaWpisow[i] = "";
            }
        }

        void Odwiedz(int numer)
        {
            if(odwiedzonePokoje[numer-1] == false)
            {
                odwiedzonePokoje[numer-1] = true;
            }
            return;
        }

        bool czyOdwiedzono(int numer)
        {
            if(odwiedzonePokoje[numer-1]<0 || odwiedzonePokoje[numer - 1] > 3)
            {
                Console.WriteLine("False");
            } else
            {
                Console.WriteLine(odwiedzonePokoje[numer-1]);
            }
        }

        void dodajWpis(string? tresc)
        {
            
        }

        string pobierzWpis(int indeks)
        {
            
        }
    }