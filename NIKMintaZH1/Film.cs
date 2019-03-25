using System;
using System.Collections.Generic;

namespace NIKMintaZH1
{
    internal class ÁtlagSzámításHiba : FilmHibaException
    {
        #region Public Constructors

        public ÁtlagSzámításHiba(Film _film) : base(_film, "Nem lett még leadva egy értékelés se, így az átlag nem számolható ki!")
        {
        }

        #endregion Public Constructors
    }

    internal class Film
    {
        #region Public Constructors

        //konstruktor
        public Film(string _cim, int _ar)
        {
            Ar = _ar;
            Cim = _cim;
        }

        #endregion Public Constructors

        #region Public Properties

        public int Ar { get; private set; }
        public double Átlag
        {
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
                    atlag /= Ertekelesek.Count;
                }
                else
                {
                    throw new ÁtlagSzámításHiba(this);
                }
                return atlag;
            }
        }
        //olvashato cim, ár, és átlag
        public string Cim { get; private set; }

        #endregion Public Properties

        #region Private Properties

        private List<int> Ertekelesek { get; } = new List<int>();

        #endregion Private Properties

        #region Public Methods

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

        #endregion Public Methods
    }

    //FilmHiba Kivétel benne a Film referenciával
    internal class FilmHibaException : Exception
    {
        #region Public Constructors

        public FilmHibaException(Film _film, string message) : base(message)
        {
            Film = _film;
        }

        #endregion Public Constructors

        #region Public Properties

        public Film Film { get; private set; }

        #endregion Public Properties
    }

    // Nem a legelegánsabb mert a FilmHibaException egy az egybenn ugyanaz, mint az
    // ÁtlagSzámításHiba, de a feladat azt írta legyen egy közös ősük lehetne az ÁtlagSzámításHiba,
    // mint közös ős, attól függ, hogy értelmezzük a feladatot uj ertekeles hiba benne referencia a
    // filmra ahol dobódott, és az értékeléssel, ami dobott
    internal class ÚjÉrtékelésHiba : FilmHibaException
    {
        #region Public Constructors

        public ÚjÉrtékelésHiba(Film _film, int _ertek) : base(_film, "Az értékelések száma meghaladja a tizet, nem adható le több értékelés!")
        {
            Ertek = _ertek;
        }

        #endregion Public Constructors

        #region Public Properties

        public int Ertek { get; private set; }

        #endregion Public Properties
    }
}
