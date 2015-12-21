using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labametr1
{
    class Program
    {
        static List<string> arrayStringsOfCod = new List<string>();

        static public List<string> GetArrayStringsOfCod()
        {
            return arrayStringsOfCod;
        }

       
        static void Main(string[] args)
        {
            ReadCodFromFile();
            MetrikHolsteda.CountMetrik();
            MetrikSpena.CountMetrik();
            Console.ReadKey();
        }

        public static void ReadCodFromFile()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Laba1\ruby.txt");
            while ((line = file.ReadLine()) != null)
            {
                arrayStringsOfCod.Add(line);
            }
            file.Close();
        }

    }
}
