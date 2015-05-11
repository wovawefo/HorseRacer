using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9_5
{
    class BettingScreen
    {
        public static void RunBets(int nrOfHorses, int[] HorseOdds)
        {
            int ymax = Console.WindowHeight - 1;
            int xmax = Console.WindowWidth - 2;

            
            //Listing the horses running
            Console.SetCursorPosition(xmax / 2 - 12, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("HORSES RUNNING - ODDS");
            Console.SetCursorPosition(xmax / 2 - 12, 4);
            Console.WriteLine("---------------------");

            for (int i = 0; i < nrOfHorses; i++)
            {
                Console.SetCursorPosition(xmax / 2 - 15, 6 + i);
                Console.ForegroundColor = HorseData.HorseColors[i];
                Console.WriteLine("{0}. {1} - {2}:1", i + 1, HorseData.HorseNames[i], HorseOdds[i]);
            }

            //Choosing horse and betting
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER THE NR. OF YOUR HORSE: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string HorseBetTemp = Console.ReadLine();
            int HorseBetValue;
            if (int.TryParse(HorseBetTemp, out HorseBetValue))
            {
                if (Int32.Parse(HorseBetTemp) > 0 && Int32.Parse(HorseBetTemp) <= nrOfHorses)
                {
                    PlayerData.Favorite = Int32.Parse(HorseBetTemp) - 1;
                }
                else
                {
                    PlayerData.Favorite = 0;
                }
            }
            else 
            {
                PlayerData.Favorite = 0;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER YOUR BET: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string BetTemp = Console.ReadLine();
            int BetValue;
            if (int.TryParse(BetTemp, out BetValue))
            {
                if (Int32.Parse(BetTemp) > 0)
                {
                    if (Int32.Parse(BetTemp) > PlayerData.Cash)
                    {
                        PlayerData.CurrentBet = PlayerData.Cash;
                    }  
                    else
                    {
                        PlayerData.CurrentBet = Int32.Parse(BetTemp);
                    }
                }
                else
                {
                    PlayerData.CurrentBet = 0;
                }
            }
            else
            {
                PlayerData.CurrentBet = 0;
            }

            //Substracting bet from cash
            PlayerData.Cash -= PlayerData.CurrentBet;
        }     
    }
}
