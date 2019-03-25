using System;

namespace NIKMintaZH1
{
    class Program
    {
        // Kezdes 20:20
        static void Main(string[] args)
        {
            #region Filmek
            Film[] filmek = new Film[5];
            filmek[0] = new AkcióFilm("AkcióFilmVagyok", 3000, 16);
            filmek[1] = new Film("PistaÉsBéla", 1500);
            filmek[2] = new Film("KiaJani", 500);
            filmek[3] = new AkcióFilm("Akcijó!", 5000, 18);
            filmek[4] = new Film("MivanMár", 2500);
            Film legolcsobbfilm = filmek[MinimumKereses(filmek)];
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
            #endregion



            Console.ReadKey();
        }
        static int MinimumKereses(Film[] filmek)
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
    }
}
