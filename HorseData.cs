using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9_5
{
    public static class HorseData
    {
        public static Double[] RandomOrder(int nr)
        {
            Random rnd = new Random();
            Double[] order = new Double[nr];
            for (int i = 0; i < order.Length; i++)
            {
                order[i] = rnd.NextDouble();
            }

            return order;
        }
        
        public static string[] HorseNames = { 
                                      "Old Fart", 
                                      "Lazy Bastard", 
                                      "Lightning Lue", 
                                      "Geespot", 
                                      "Cookie Monster", 
                                      "Roadrunner", 
                                      "Run Forrest", 
                                      "Wicked Wizard" 
                                  };

        public static ConsoleColor[] HorseColors = {
                                            ConsoleColor.Blue, 
                                            ConsoleColor.Yellow, 
                                            ConsoleColor.Gray, 
                                            ConsoleColor.Green, 
                                            ConsoleColor.Cyan, 
                                            ConsoleColor.Magenta, 
                                            ConsoleColor.White, 
                                            ConsoleColor.Red 
                                        };

        public static int[] HorseOdds  = {
                                            1, 
                                            1, 
                                            1, 
                                            1, 
                                            1, 
                                            1, 
                                            1, 
                                            1 
                                        };

        public static int[] CreateRandomOdds(int min, int max)
        {
            Random oddrnd = new Random();        

            for (int i = 0; i < HorseOdds.Length; i++)
            {
                HorseOdds[i] = oddrnd.Next(min, max);
            }

            return HorseOdds;
        }

        public static int NumberOfHorses = 5;
        
    }
}
