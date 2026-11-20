using System;
    public class DziennikWypraw
    {
        private bool[] odwiedzonePokoje = { true, false, false, false };
        private string[] historiaWpisow = new string[3] { "", "", "" };
        private int liczbaWpisow = 0;

        public DziennikWypraw()
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
            if(numer < 1 || numer > 4){
                return;
            }
            if(odwiedzonePokoje[numer-1] == false)
            {
                odwiedzonePokoje[numer-1] = true;
            }
            return;
        }

        bool CzyOdwiedzono(int numer)
        {
            if(numer < 1 || numer > 4)
            {
                Console.WriteLine("False");
                return false;
            } else
            {
                Console.WriteLine(odwiedzonePokoje[numer-1]);
                return odwiedzonePokoje[numer-1];
            }
        }

        public void DodajWpis(string? tresc)
        {
            if(tresc == null || tresc == "" || tresc.Trim() == "")
            {
                return;
            }
            tresc = tresc.Trim();
            if(historiaWpisow[0] == "")
            {
                historiaWpisow[0] = tresc;
                liczbaWpisow++;
                return;
            }
            if(historiaWpisow[1] == "")
            {
                historiaWpisow[1] = tresc;
                liczbaWpisow++;
                return;
            }
            if(historiaWpisow[2] == "")
            {
                historiaWpisow[2] = tresc;
                liczbaWpisow++;
                return;
            }
            historiaWpisow[0] = historiaWpisow[1];
            historiaWpisow[1] = historiaWpisow[2];
            historiaWpisow[2] = tresc;
            liczbaWpisow = 3;
            return;
        }

        public string PobierzWpis(int indeks)
        {
            if(indeks < 0 || indeks > liczbaWpisow - 1)
            {
                return "";
            }
            return historiaWpisow[indeks];
        }
    }