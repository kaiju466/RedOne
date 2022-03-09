using System;
using System.Net;
using System.IO;
using System.Threading;

namespace swapiClient
{
    class main
    {
        static void Main(string[] args)
        {

            Theatrics lol = new Theatrics();//sorry this was too much fun
            lol.Opening();//yes i have the humor of a 10 year old child

            Console.WriteLine("List of Starwars Ships (with length greater than 10) and Their Pilots" );
            SwApi swapi = new SwApi();
            swapi.execute("https://swapi.dev/api/starships/");

            lol.Scroll(500);
        }
    }
}
