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
                myPlayer.Play();
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
                for (int i = 0; i < HorseData.NumberOfHorses; i++)
                {
                    Horse h1 = new Horse(HorseData.HorseNames[i], i + 1, HorseData.HorseColors[i], HorseData.HorseOdds[i]);
                    Thread t1 = new Thread(new ThreadStart(h1.Run));
                    t1.IsBackground = true;
                    t1.Start();
                }

                if (Console.ReadLine() != "")
                {
                    break;
                }

                Horse.Place = 0;

                Console.Clear();
            }

            GameOverScreen.Run();
        }
    }
}
