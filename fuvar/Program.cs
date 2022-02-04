using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fuvar> fuvarok = new List<Fuvar>();

            foreach (var sor in File.ReadAllLines("fuvar.csv").Skip(1))
	        {
                fuvarok.Add(new Fuvar(sor));
	        }

            Console.WriteLine($"3. feladat: {fuvarok.Count} fuvar");

            double Bevétel = 0;
            int db = 0;
            foreach (var f in fuvarok)
	        {
                if (f.TaxiID == 6185)
	            {
                    Bevétel += f.Viteldíj + f.Borravaló;
                    db++;
	            }
	        }
            Console.WriteLine($"4. feladat: {db} fuvar alatt: {Bevétel}");
            
            /*
            int bankkártyás = 0;
            int készpénz = 0;

            foreach (var f in fuvarok)
	        {
                if (f.FizetésMód == "bankkártya")
	            {
                    bankkártyás++;
	            }
                if (f.FizetésMód == "készpénz")
	            {
                    készpénz++;
	            }
	        }*/
            
            Dictionary<string, int> stat = new Dictionary<string, int>();
            foreach (var f in fuvarok)
	        {
                if (stat.ContainsKey(f.FizetésMód))
	            {
                    stat[f.FizetésMód]++;
	            }
                else
                {
                    stat.Add(f.FizetésMód, 1);
                }
	        }
            Console.WriteLine($"5. feladat: ");
            foreach (var s in stat)
	        {
                Console.WriteLine($"\t{s.Key}: {s.Value} fuvar");
	        }

            //6. feladat
            double ÖsszM = 0;
            foreach (var f in fuvarok)
            {
             
                ÖsszM += f.Távolság;
            }
            Console.WriteLine($"6. feladat: {ÖsszM*1.6:0.00km}");


            Console.ReadKey();
        }
    }
}
