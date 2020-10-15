using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kosar2004
{
    class Program
    {
        static List<Meccs> meccsek = new List<Meccs>();

        static void MasodikFeladat()
        {
            StreamReader file = new StreamReader("eredmenyek.csv");

            file.ReadLine();
            
            while (!file.EndOfStream)
            {
                string[] adat = file.ReadLine().Split(';');
                meccsek.Add(new Meccs(adat[0], adat[1], int.Parse(adat[2]), int.Parse(adat[3]), adat[4], adat[5]));
            }
            file.Close();
        }

        static void HarmadikFeladat()
        {
            var hazai = from m in meccsek
                        where m.Hazai == "Real Madrid"
                        select new { Hazai = m.Hazai };

            int hazaiDB = hazai.ToList().Count;

            var idegen = from m in meccsek
                        where m.Idegen == "Real Madrid"
                        select new { Idegen = m.Idegen };

            int idegenDb = idegen.ToList().Count;

            Console.WriteLine($"3. feladat : Real Madrid : Hazai: {hazaiDB}, Idegen: {idegenDb}");
        }

        static void Main(string[] args)
        {
            //7up Joventut;Adecco Estudiantes;81;73;Palacio Mun. De Deportes De Badalona;2005-04-03

            MasodikFeladat();
            HarmadikFeladat();

            Console.ReadKey();
        }
    }
}
