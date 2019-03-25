namespace NIKMintaZH1
{
    internal class Puzzle : IKorhatáros
    {
        #region Public Constructors

        public Puzzle(int db)
        {
            DarabSzam = db;
        }

        #endregion Public Constructors

        #region Public Properties

        public int DarabSzam { get; private set; }

        // Vajon ez lefut?
        public int Korhatar => DarabSzam / 500;

        public int Buntetes(int eletkor)
        {
            return (eletkor - Korhatar) * 1000;
        }

        #endregion Public Properties
    }
}
