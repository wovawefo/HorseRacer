using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Media;
using System.IO;
using System.Reflection;

namespace CSharp9_5
{

    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("..//..//HorseSong.wav"))
            {
                var myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "..//..//HorseSong.wav";
                myPlayer.PlayLooping();
            }
         
            //Open up StartScreen
            StartScreen.RunStart();

            //Read player´s input name
            Console.ForegroundColor = ConsoleColor.Yellow;
            PlayerData.Name = Console.ReadLine().ToUpper();
            PlayerData.Cash = 100;

            Console.Clear();

            while (PlayerData.Cash > 0)
            {
                
                //Create Random object
                Random rnd = new Random();

                //Create data in HorseOdds array
                HorseData.HorseOdds = HorseData.CreateRandomOdds(2, 10);
                //Shuffling HorseNames array
                Array.Sort(HorseData.RandomOrder(HorseData.HorseNames.Length), HorseData.HorseNames);
                //Shuffling HorseColors array
                Array.Sort(HorseData.RandomOrder(HorseData.HorseColors.Length), HorseData.HorseColors);
                //Shuffling HorseOdds array
                Array.Sort(HorseData.RandomOrder(HorseData.HorseOdds.Length), HorseData.HorseOdds);

                //Setting current odds for player
                PlayerData.CurrentOdds = HorseData.HorseOdds[0];

                //Write player´s name and cash on left upper corner
                Console.ForegroundColor = ConsoleColor.Green;
                PlayerData.DisplayData(false);

                //Initialize betting screen
                BettingScreen.RunBets(HorseData.NumberOfHorses, HorseData.HorseOdds);

                Console.Clear();

                //Write player´s name and cash on left upper corner
                Console.ForegroundColor = ConsoleColor.Yellow;
                PlayerData.DisplayData(true);

                //Creating Horses           
                /*
                for (int i = 0; i < HorseData.NumberOfHorses; i++)
                {
                    Horse h1 = new Horse(HorseData.HorseNames[i], i + 1, HorseData.HorseColors[i], HorseData.HorseOdds[i]);
                    Thread t1 = new Thread(new ThreadStart(h1.Run));
                    t1.IsBackground = true;
                    t1.Start();
                    
                   if (PlayerData.KillThread == true)
                   {
                       t1.Abort();
                   }
                }
                 */

                //Creating Horses
                Horse h1 = new Horse(HorseData.HorseNames[0], 1, HorseData.HorseColors[0], HorseData.HorseOdds[0]);
                Horse h2 = new Horse(HorseData.HorseNames[1], 2, HorseData.HorseColors[1], HorseData.HorseOdds[1]);
                Horse h3 = new Horse(HorseData.HorseNames[2], 3, HorseData.HorseColors[2], HorseData.HorseOdds[2]);
                Horse h4 = new Horse(HorseData.HorseNames[3], 4, HorseData.HorseColors[3], HorseData.HorseOdds[3]);
                Horse h5 = new Horse(HorseData.HorseNames[4], 5, HorseData.HorseColors[4], HorseData.HorseOdds[4]);
                Thread t1 = new Thread(new ThreadStart(h1.Run));
                Thread t2 = new Thread(new ThreadStart(h2.Run));
                Thread t3 = new Thread(new ThreadStart(h3.Run));
                Thread t4 = new Thread(new ThreadStart(h4.Run));
                Thread t5 = new Thread(new ThreadStart(h5.Run));
                t1.IsBackground = true;
                t2.IsBackground = true;
                t3.IsBackground = true;
                t4.IsBackground = true;
                t5.IsBackground = true;
                t1.Start();
                t2.Start();
                t3.Start();
                t4.Start();
                t5.Start();

                while (true)
                {
                    //Check in the background if key is pressed. If it is SpaceBar, quit
                    if (Console.KeyAvailable && PlayerData.IsRaceOver == true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Spacebar)
                        {
                            t1.Abort();
                            t2.Abort();
                            t3.Abort();
                            t4.Abort();
                            t5.Abort();
                            break;
                        }
                    }
                }

                Horse.Place = 0;
                PlayerData.IsRaceOver = false;

                Console.Clear();
            }

            GameOverScreen.Run();
        }
    }
}
