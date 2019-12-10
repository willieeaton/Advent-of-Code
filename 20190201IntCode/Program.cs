using System;
using System.Collections.Generic;
using System.IO;

namespace _20190201IntCode
{
    class Program
    {
        static IntCodeProgram programToRun; 
        static void Main(string[] args)
        {
            programToRun = new IntCodeProgram(GetProgram());
            programToRun = programToRun.PerformInstructions();
            programToRun.OutputResults();
        }

        static List<int> GetProgram()
        {
            List<int> output = new List<int>();
            var fileName = "input.txt";
            using (var reader = new StreamReader(fileName))
            {
                string[] readStream = reader.ReadToEnd().Split(',');
                foreach(string s in readStream)
                {
                    output.Add(int.Parse(s));
                }
            }
            return output;
        }
    }
}
