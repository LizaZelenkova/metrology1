
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Labametr1
{
    static class MetrikSpena
    {
        static List<string> arrayIdentifiers = new List<string>();
        static List<int> arraySpensCount = new List<int>();
        static List<string> arraySpensValue = new List<string>();

        static public void CountMetrik()
        {
            FindIdentifier();
            CountEverySpen();
            OutputMetrik();
        }

        static void FindIdentifier()
        {
            string pattern = @"\$\w+";
            RegexOptions option = RegexOptions.None;
            Regex newReg = new Regex(pattern, option);
            foreach (string line in Program.GetArrayStringsOfCod())
            {
                foreach (Match match in newReg.Matches(line))
                {
                    arrayIdentifiers.Add(match.Value);
                }
            }
        }

        static void CountEverySpen()
        {
            int count = 0;
            arrayIdentifiers.Sort();
            for (int i = 0; i < arrayIdentifiers.Count - 1; i++)
            {
                if (arrayIdentifiers[i] == arrayIdentifiers[i + 1])
                {
                    count++;
                }
                else
                {
                    
                    arraySpensCount.Add(count);
                    arraySpensValue.Add(arrayIdentifiers[i]);
                    count = 0;
                }
            }
            count++;
        }

        static void OutputMetrik()
        {
            Console.WriteLine();
            Console.WriteLine("Метрик cпена: ");
            for (int i = 0; i < arraySpensCount.Count; i++)
            {
                Console.Write("Переменная {0} повторяется {1}", arraySpensValue[i], arraySpensCount[i]);
                Console.WriteLine();
            }
        }
    }
}
