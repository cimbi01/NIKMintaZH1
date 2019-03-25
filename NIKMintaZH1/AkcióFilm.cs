using System;
using System.Collections.Generic;
using System.Text;

namespace NIKMintaZH1
{
    class AkcióFilm : Film, IKorhatáros
    {
        private int AlsoKorhatar { get; set; }

        public int Korhatar => AlsoKorhatar;

        public AkcióFilm(string _cim, int _ar, int _alsokorhatar) : base(_cim, _ar)
        {
            AlsoKorhatar = _alsokorhatar;
        }
        public override void Értékel(int érték)
        {
            // ha az érték nem 5 csak akkor fut le
            // ellenkező esetben nyilván szép dolog lenne, ha dobna egy kivételt, de nem fog
            if (érték < 5)
            {
                base.Értékel(érték);
            }
        }

        public int Buntetes(int eletkor)
        {
            return (eletkor - Korhatar) * Ar;
        }
    }
}
