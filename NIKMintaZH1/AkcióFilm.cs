namespace NIKMintaZH1
{
    internal class AkcióFilm : Film, IKorhatáros
    {
        #region Public Constructors

        public AkcióFilm(string _cim, int _ar, int _alsokorhatar) : base(_cim, _ar)
        {
            AlsoKorhatar = _alsokorhatar;
        }

        #endregion Public Constructors

        #region Public Properties

        public int Korhatar => AlsoKorhatar;

        #endregion Public Properties

        #region Private Properties

        private int AlsoKorhatar { get; set; }

        #endregion Private Properties

        #region Public Methods

        public int Buntetes(int eletkor)
        {
            return (eletkor - Korhatar) * Ar;
        }
        public override void Értékel(int érték)
        {
            // ha az érték nem 5 csak akkor fut le ellenkező esetben nyilván szép dolog lenne, ha
            // dobna egy kivételt, de nem fog
            if (érték < 5)
            {
                base.Értékel(érték);
            }
        }

        #endregion Public Methods
    }
}
