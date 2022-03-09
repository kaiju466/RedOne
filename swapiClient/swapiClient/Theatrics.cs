using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace swapiClient
{
    class Theatrics
    {
        public Theatrics(){}
        public void intro()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A long time ago in a galaxy far,far away....");
            
        }
        public void title()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("     _                                      ");
            Console.WriteLine(" ___| |_ __ _ _ __  __      ____ _ _ __ ___ ");
            Console.WriteLine("/ __| __/ _` | '__| \\ \\ /\\ / / _` | '__/ __|");
            Console.WriteLine("\\__ \\ || (_| | |     \\ V  V / (_| | |  \\__ \\");
            Console.WriteLine("|___/\\__\\__,_|_|      \\_/\\_/ \\__,_|_|  |___/");

        }
        public void Opening()
        {
            intro();
            Thread.Sleep(4000);
            title();
            Scroll(300);

        }

        public void Scroll(int speed)
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Thread.Sleep(speed);
                Console.WriteLine(String.Empty);

            }
        }
    }
}
