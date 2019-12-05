namespace _20190102RocketFuel
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            bool keepLooping = true;
            int runningTotal = 0;
            string userInput;
            int mass = 0;
            var fileName = "input.txt";
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (keepLooping)
                {
                    userInput = reader.ReadLine();

                    if (int.TryParse(userInput, out mass))
                    {
                        if (mass > 0)
                        {
                            int fuel = FuelCalculator(mass);
                            runningTotal += fuel;
                            Console.WriteLine($"That will require {fuel} fuel.");
                        }
                    }
                    else
                    {
                        keepLooping = false;
                    }
                }
            }
            Console.WriteLine($"The total fuel required by all modules is {runningTotal}.");
        }

        static int FuelCalculator(int mass)
        {
            if (mass > 0)
            {
                int fuel = (int)Math.Floor((double)mass / 3.0) - 2;
                return fuel + (Math.Max(FuelCalculator(fuel), 0));
            }
            else
            {
                return 0;
            }
        }
    }

}
