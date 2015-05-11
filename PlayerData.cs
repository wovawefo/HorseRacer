using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9_5
{
    public static class PlayerData
    {
        public static string Name;
        public static int Cash;
        public static int Favorite;
        public static int CurrentBet;
        public static int CurrentOdds;
        public static int RaceWinner;
        public static bool Winner;


        public static void DisplayData(bool horsechosen)
        {
            if (horsechosen)
            {
                Console.Write("{0} - cash: {1}$, bet: {2}$, cashprize: {3}$, horse: ", PlayerData.Name, PlayerData.Cash, PlayerData.CurrentBet, PlayerData.CurrentBet * PlayerData.CurrentOdds);
                Console.ForegroundColor = HorseData.HorseColors[PlayerData.Favorite];
                Console.Write(HorseData.HorseNames[PlayerData.Favorite]);
            }
            else
            {         
                Console.Write("{0} - cash: {1}$", PlayerData.Name, PlayerData.Cash);
            }
        }
    }
}
