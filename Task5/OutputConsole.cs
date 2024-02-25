using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class OutputConsole : IOutput
    {
        public void Output(Dictionary<string, List<DateTime>> disctionary)
        {
            foreach (var VacationList in disctionary)
            {
                Console.WriteLine("Дни отпуска " + VacationList.Key + " : ");
                for (int i = 0; i < VacationList.Value.Count; i++) { 
                    Console.WriteLine(VacationList.Value[i]); 
                }
            }
        }
    }
}
