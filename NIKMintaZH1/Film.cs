using System;
using System.Collections.Generic;
using System.Text;

namespace NIKMintaZH1
{
    class Film
    {
        // Kezdes 20:20
        //olvashato cim, ár, értékelések, és átlag
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
                    throw new FilmHibaException(this);
                }
                return atlag;
            }}
        //konstruktor
        public Film(string _cim, int _ar)
        {
            Ar = _ar;
            Cim = _cim;
        }
        void Értékel(int érték)
        {
            if (Ertekelesek.Count < 10)
            {
                Ertekelesek.Add(érték);
            }
            else
            {
                throw new ÚjÉrtékelésHiba(this, érték);
            }
        }
    }
    // uj ertekeles hiba
    // benne referencia a filmra ahol dobódott, és az értékeléssel, ami dobott
    class ÚjÉrtékelésHiba : FilmHibaException
    {
        public int Ertek { get; private set; }
        public ÚjÉrtékelésHiba(Film _film, int _ertek) : base(_film)
        {
            Ertek = _ertek;
        }
    } 
    class ÁtlagSzámításHiba : FilmHibaException
    {
        public ÁtlagSzámításHiba(Film _film) : base(_film) {}
    }
    //FilmHiba Kivétel benne a Film referenciával
    class FilmHibaException : Exception
    {
        public Film Film { get; private set; }
        public FilmHibaException(Film _film) : base()
        {
            Film = _film;
        }
    }
}
