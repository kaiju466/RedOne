using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace swapiClient
{
    class SwApi
    {
        public String urlStart = String.Empty;
        public WebClient client = new WebClient();

        public SwApi()
        {
            urlStart = "https://swapi.dev/api/planets/1/?format=json";
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

        }
        public String send(String url)
        {
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return s;
        }

        public void execute(String url)
        {

            Root StarshipResults = JsonConvert.DeserializeObject<Root>(send(url));

            while(!String.IsNullOrEmpty(StarshipResults.next))
            { 
                foreach (swapiClient.Starship starship in StarshipResults.results)
                {
                    if (double.Parse(starship.length) > 10)
                    {
                        Console.WriteLine("Starship Name: "+starship.name +" "+ starship.length.ToString());

                        if (starship.pilots.Count < 1)
                        {
                            Console.WriteLine("No Pilot Found".PadLeft(3));
                        }

                        int count = 1;
                        foreach (String pilot in starship.pilots)
                        {

                            person p = JsonConvert.DeserializeObject<person>(send(pilot));
                            Console.WriteLine(String.Format("Pilot {0} Name:{1}", count.ToString(), p.name).PadLeft(3));
                            count++;
                        }
                        Console.WriteLine(String.Empty);
                    }


                }
                StarshipResults = JsonConvert.DeserializeObject<Root>(send(StarshipResults.next));
            }




        }
    }
}
