using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Labametr1
{
    static class MetrikHolsteda
    {
        static int allOperators;           
        static int allOperands;           
        static int uniqueOperators;          
        static int uniqueOperands;
        static List<string> arrayOperators = new List<string>();
        static List<string> arrayOperands = new List<string>();

        static public void CountMetrik()
        {
            FindAllOperators();
            FindUniqueOperators();
            FindAllOperands();
            FindUniqueOperands();
            OutputMetrik();
        }

        static void FindAllOperators()
        {
            string pattern = @"\+ | ={1,2} | \* | [<>%-/&^|] | <= | >= | != | and | xor | or |[A-Za-z]\w+\(|\+{2}|\-{2}]";
            RegexOptions option = RegexOptions.None;
            Regex newReg = new Regex(pattern, option);
            foreach (string line in Program.GetArrayStringsOfCod())
            {
                foreach (Match match in newReg.Matches(line))
                {
                    arrayOperators.Add(match.Value);
                    allOperators++;
                }
            }
        }

        static void FindAllOperands()
        {
            string pattern = @"\$\w+";
            RegexOptions option = RegexOptions.None;
            Regex newReg = new Regex(pattern, option);
            foreach (string line in Program.GetArrayStringsOfCod())
            {
                foreach (Match match in newReg.Matches(line))
                {
                    arrayOperands.Add(match.Value);
                    allOperands ++;
                }
            }
        }

        static void FindUniqueOperators()
        {
            int count = 0;
            arrayOperators.Sort();
            for (int i = 0; i < arrayOperators.Count - 1; i++)
            {
                if (arrayOperators[i] != arrayOperators[i + 1])
                {
                    count++;
                }
            }
            count++;
            uniqueOperators = count;
        }

        static void FindUniqueOperands()
        {
            int count = 0;
            arrayOperands.Sort();
            for (int i = 0; i < arrayOperands.Count - 1; i++)
            {
                if (arrayOperands[i] != arrayOperands[i + 1])
                {
                    count++;
                }
            }
            count++;
            uniqueOperands = count;
        }

        static void OutputMetrik()
        {
            int volumeOfProgram = (int)((allOperands + allOperators)*Math.Log(uniqueOperands+uniqueOperators,2));
            int potentionalVolumeOfProgram = (int)((uniqueOperands + uniqueOperators) * Math.Log(uniqueOperands + uniqueOperators, 2));
            int theoreticalLengthOfProgram = (int)((uniqueOperators) * Math.Log(uniqueOperators, 2) + (uniqueOperands) * Math.Log(uniqueOperands, 2));
            float levelOfProgram = (float)potentionalVolumeOfProgram / volumeOfProgram;
            float intellectualContentOfAlgorithm = levelOfProgram * volumeOfProgram;
            double necessaryIntellectualEffort = theoreticalLengthOfProgram * Math.Log((uniqueOperands + uniqueOperators) / levelOfProgram, 2);

            Console.WriteLine("Метрик Холстеда:");
            Console.WriteLine("Cловарь программы:{0}",uniqueOperands+uniqueOperators);
            Console.WriteLine("Длина программы:{0}",allOperands+allOperators);
            Console.WriteLine("Объем программы:{0}", volumeOfProgram);
            Console.WriteLine("Потенциальный объем программы:{0}", potentionalVolumeOfProgram);
            Console.WriteLine("Теоретическая длинна программы:{0}", theoreticalLengthOfProgram);
            Console.WriteLine("Уровень программы:{0}", levelOfProgram);
            Console.WriteLine("Интеллектуальное содержание алгоритма {0}", intellectualContentOfAlgorithm);
            Console.WriteLine("Необходимые интеллектуальные усилия:{0}", necessaryIntellectualEffort);
        }

    }
}
