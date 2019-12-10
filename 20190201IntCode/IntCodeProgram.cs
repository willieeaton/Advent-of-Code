using System;
using System.Collections.Generic;
using System.Text;

namespace _20190201IntCode
{
    public class IntCodeProgram
    {
        public List<int> Values = new List<int>();

        public IntCodeProgram(List<int> codes) => Values = codes;
        
        public IntCodeProgram PerformInstructions()
        {
            IntCodeProgram output = this;
            for (int i = 0; i < Values.Count; i += 4)
            {
                int instruction = output.Values[i];
                int term1Location = output.Values[i + 1];
                int term2Location = output.Values[i + 2];
                int outputLocation = output.Values[i + 3]; 

                switch(instruction)
                {
                    case 1:
                        output.Values[outputLocation] = AddValues(term1Location, term2Location);
                        break;

                    case 2:
                        output.Values[outputLocation] = MultiplyValues(term1Location, term2Location);
                        break;

                    case 99:
                        i = Values.Count; 
                        break;

                    default:
                        Console.WriteLine($"Invalid opcode in position {i}");
                        Console.WriteLine("Running anyway, but don't trust the output!");
                        break;

                }
            }
            
            return output;

        }

        public int GetValueAt(int location)
        {
            return Values[location];
        }

        public int AddValues(int term1, int term2)
        {
            return GetValueAt(term1) + GetValueAt(term2);
        }

        public int MultiplyValues(int term1, int term2)
        {
            return GetValueAt(term1) * GetValueAt(term2);
        }

        public void OutputResults()
        {
            foreach(int i in Values)
            {
                Console.Write($"{i},");
            }
        }
    }
}
