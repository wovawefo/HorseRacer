using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace CSharp9_5
{
    
    class Horse
    {
        public string Name;
        private int Track;
        private ConsoleColor Color;
        private int Distance;
        public int Odds;
        public static int Place;
        static Random rand = new Random();

        public Horse(string Name, int Track, ConsoleColor Color, int Odds)
        {
            this.Name = Name;
            this.Track = Track;
            this.Color = Color;
            this.Odds = Odds;
        }
        
        public void Run()
        {
            DateTime start = DateTime.Now;

            for (int i = 0; i < 45; i++)
            {
                Distance++;
                
                lock (rand)
                {
                    Console.ForegroundColor = Color;
                    Console.SetCursorPosition(0, Track * 2 + 2);
                    Console.Write(new String(' ', Console.BufferWidth));
                    Console.SetCursorPosition(Distance, Track * 2 + 2);
                    Console.Write("~-0-¤");
                }

                Thread.Sleep(50 + 5 * rand.Next(200));
            }

            lock (rand)
            {
                DateTime stop = DateTime.Now;
                TimeSpan time = stop - start;
                string finishTime = time.TotalSeconds.ToString();

                Console.SetCursorPosition(0, 15 + Place);
                Console.ForegroundColor = Color;
                Place++;
                Console.Write("{0} - {1} : {2}", Place, Name, finishTime.Substring(0, 5));

                if (Place == 1 && PlayerData.Favorite == (Track - 1))
                {
                    PlayerData.Winner = true;
                    PlayerData.Cash += PlayerData.CurrentOdds * PlayerData.CurrentBet;
                }
                else 
                {
                    PlayerData.Winner = false;
                }
                
                if (Place == 1)
                {
                    PlayerData.RaceWinner = Track - 1;

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.SetCursorPosition(18, 21);
                    Console.Write("The winner of the race is ");
                    Console.ForegroundColor = HorseData.HorseColors[PlayerData.RaceWinner];
                    Console.Write(HorseData.HorseNames[PlayerData.RaceWinner]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    if(PlayerData.Winner)
                    {
                        Console.SetCursorPosition(20, 22);
                        Console.Write("Lucky bastard! You WON!!!");
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 22);
                        Console.Write("You dont know anything about horses do you? You LOST!");
                    }
                }

                if (Place == HorseData.NumberOfHorses)
                {
                    PlayerData.IsRaceOver = true;

                    while (true)
                    {
                        //Check in the background if key is pressed. If it is spacebar, quit
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                break;
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(18, 24);
                        Console.Write("Press SPACEBAR to continue ...");
                    }
                }
            }
        }

    }
}
