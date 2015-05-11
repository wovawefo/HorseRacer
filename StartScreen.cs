using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Runtime.InteropServices;

namespace CSharp9_5
{
    class StartScreen
    {
        public static void RunStart()
        {
            //Set up Start Screen with title
            int ymax = Console.WindowHeight - 1;
            int xmax = Console.WindowWidth - 2;

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"      __ ______  ___  ________  ___  ___  ____________    ___  ___  ___  ___ ");
            Console.WriteLine(@"     / // / __ \/ _ \/ __/ __/ / _ \/ _ |/ ___/ __/ _ \  |_  |/ _ \/ _ \/ _ \");
            Console.WriteLine(@"    / _  / /_/ / , _/\ \/ _/  / , _/ __ / /__/ _// , _/ / __// // / // / // /");
            Console.WriteLine(@"   /_//_/\____/_/|_/___/___/ /_/|_/_/ |_\___/___/_/|_| /____/\___/\___/\___/ ");

            
            //Making blinking instructions to start game
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

                Console.SetCursorPosition(xmax / 2 - 12, ymax / 2 + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press SPACEBAR to play...");

                Thread.Sleep(500);

                Console.SetCursorPosition(xmax / 2 - 12, ymax / 2 + 1);
                Console.Write(new String(' ', Console.BufferWidth));
                
                Thread.Sleep(200);

            }

            Console.SetCursorPosition(xmax / 2 - 12, ymax / 2 + 1);
            Console.Write(new String(' ', Console.BufferWidth));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER NAME:  ");
            
        }
    }
}
