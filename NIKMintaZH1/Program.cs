using System;
using System.Collections.Generic;

namespace NIKMintaZH1
{
    internal class Program
    {
        #region Private Methods

        // Kezdes 20:20
        private static void Main(string[] args)
        {
            #region Filmek

            Film[] filmek = new Film[5];
            filmek[0] = new AkcióFilm("AkcióFilmVagyok", 3000, 16);
            filmek[1] = new Film("PistaÉsBéla", 1500);
            filmek[2] = new Film("KiaJani", 500);
            filmek[3] = new AkcióFilm("Akcijó!", 5000, 18);
            filmek[4] = new Film("MivanMár", 2500);
            Film legolcsobbfilm = filmek[MinimumKereses(filmek)];
            Console.WriteLine("Legolcsóbb film:");
            Console.WriteLine("A film címe: {0}" +
                "\nA film ára: {1}", legolcsobbfilm.Cim, legolcsobbfilm.Ar);
            // ÁTLAG KIVÉTELT DOB AZT LE KELL KEZELNI
            try
            {
                double atlag = legolcsobbfilm.Átlag;
                // ez nem fut le, ha exception-t dob az Film.Átlag
                Console.WriteLine("A film átlagos értékelés: {0}", atlag);
            }
            catch (ÁtlagSzámításHiba e)
            {
                Console.WriteLine(e.Message);
            }
            // ha akciófilm
            if (legolcsobbfilm is AkcióFilm)
            {
                Console.WriteLine("A film akciófilm\n" +
                    "A film korhatára: {1}", (legolcsobbfilm as AkcióFilm).Korhatar);
            }

            #endregion Filmek

            #region Puzzle

            IKorhatáros[] korhatarosok = IKorhatárosok(filmek);
            // korhatár függvényében visszaadja hány filmet lehet megnézni
            int buntetlenulnezheto = 0;
            // korhatár, amit gondolom be kell kérni, csak a feladat kretén és nem adja meg, mit
            // csináljak vele
            int kor = 16;
            // filmek között keresi a helyeseket
            foreach (Film item in filmek)
            {
                // ha nem akciófilm
                if (!(item is AkcióFilm))
                {
                    buntetlenulnezheto++;
                }
            }
            // korhatarosok között keres

            foreach (IKorhatáros item in korhatarosok)
            {
                // ha a korhatár kisebb egyenlő mint a kor
                if (item.Korhatar <= kor)
                {
                    buntetlenulnezheto++;
                }
            }
            Console.WriteLine("Büntetlenül vásárolható: {0}", buntetlenulnezheto);

            int osszbuntetes = 0;
            foreach (IKorhatáros item in korhatarosok)
            {
                // ha a korhatár nagyobb mint a kor akkor van bünti
                if (item.Korhatar > kor)
                {
                    osszbuntetes += item.Buntetes(kor);
                }
            }
            Console.WriteLine("Összbüntetetés: {0}", osszbuntetes);
            Console.WriteLine("A büntetés azért minusz mert a feladatban meg volt adva hogy a buntetés\n(életkor paraméter – korhatár) * ár/1000 (Puzzle vagy Akciófilm változó");

            #endregion Puzzle

            Console.ReadKey();
        }
        // visszaad egy tömböt az akciófilmekkel és pár puzzle-el
        private static IKorhatáros[] IKorhatárosok(Film[] filmek)
        {
            List<IKorhatáros> korhatarosok = new List<IKorhatáros>();
            foreach (Film item in filmek)
            {
                if (item is AkcióFilm)
                {
                    korhatarosok.Add(item as AkcióFilm);
                }
            }
            // random puzzle amiket bel kell rakni a feladat szerint
            korhatarosok.Add(new Puzzle(500));
            korhatarosok.Add(new Puzzle(1000));
            korhatarosok.Add(new Puzzle(1500));
            korhatarosok.Add(new Puzzle(2500));
            return korhatarosok.ToArray();
        }
        private static int MinimumKereses(Film[] filmek)
        {
            int minindex = 0;
            for (int i = 1; i < filmek.Length; i++)
            {
                if (filmek[i].Ar < filmek[minindex].Ar)
                {
                    minindex = i;
                }
            }
            return minindex;
        }

        #endregion Private Methods
    }
}
