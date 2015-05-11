using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp9_5
{
    class GameOverScreen
    {
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(4, 3);
            Console.WriteLine("{0}, {0} .... You lost all your money! Try to explain this at home...", PlayerData.Name);
            
            Console.SetCursorPosition(18,8);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"  ________   __  _______  ____ _   _________ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(18, 9);
            Console.WriteLine(@" / ___/ _ | /  |/  / __/ / __ \ | / / __/ _ \");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(18, 10);
            Console.WriteLine(@"/ (_ / __ |/ /|_/ / _/  / /_/ / |/ / _// , _/");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(18, 11);
            Console.WriteLine(@"\___/_/ |_/_/  /_/___/  \____/|___/___/_/|_| ");


            Console.ReadLine();
        }
    }
}
