using System;
using System.Collections.Generic;
using System.Text;

namespace NIKMintaZH1
{
    class Film
    {
        //olvashato cim, ár, és átlag
        public string Cim { get; private set; }
        public int Ar { get; private set; }
        private List<int> Ertekelesek { get; } = new List<int>();
        public double Átlag {
            get
            {
                double atlag = 0;
                if (Ertekelesek.Count > 0)
                {
                    foreach (int item in Ertekelesek)
                    {
                        atlag += item;
                    }
                    // ez vajon valóban jót ad vissza?
                    atlag /= (double)Ertekelesek.Count;
                }
                else
                {
                    throw new ÁtlagSzámításHiba(this);
                }
                return atlag;
            }}
        //konstruktor
        public Film(string _cim, int _ar)
        {
            Ar = _ar;
            Cim = _cim;
        }
        public virtual void Értékel(int érték)
        {
            if (Ertekelesek.Count <= 10)
            {
                Ertekelesek.Add(érték);
            }
            else
            {
                throw new ÚjÉrtékelésHiba(this, érték);
            }
        }
    }
    // Nem a legelegánsabb mert a FilmHibaException egy az egybenn ugyanaz, mint az
    // ÁtlagSzámításHiba, de a feladat azt írta legyen egy közös ősük
    // lehetne az ÁtlagSzámításHiba, mint közös ős, attól függ, hogy értelmezzük a feladatot
    // uj ertekeles hiba benne referencia a
    // filmra ahol dobódott, és az értékeléssel, ami dobott
    class ÚjÉrtékelésHiba : FilmHibaException
    {
        public int Ertek { get; private set; }
        public ÚjÉrtékelésHiba(Film _film, int _ertek) : base(_film, "Az értékelések száma meghaladja a tizet, nem adható le több értékelés!")
        {
            Ertek = _ertek;
        }
    } 
    class ÁtlagSzámításHiba : FilmHibaException
    {
        public ÁtlagSzámításHiba(Film _film) : base(_film, "Nem lett még leadva egy értékelés se, így az átlag nem számolható ki!") {}
    }
    //FilmHiba Kivétel benne a Film referenciával
    class FilmHibaException : Exception
    {
        public Film Film { get; private set; }
        public FilmHibaException(Film _film, string message) : base(message)
        {
            Film = _film;
        }
    }
}
