using System;
using System.Linq;
using System.Collections.Generic;

namespace ForceBook                               // only 30/100
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            SortedDictionary<string, string> light = new SortedDictionary<string, string>();
            SortedDictionary<string, string> dark = new SortedDictionary<string, string>();
            string subOne = "|";
            string subTwo = "->";
            string forceSide = string.Empty;
            string forceUser = string.Empty;
            string zeroValueLight = string.Empty;
            string zeroValueDark = string.Empty;
          
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] comArgs = new string[] { };

                if (input.Contains(subOne))
                {
                    comArgs = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    forceSide = comArgs[0];
                    forceUser = comArgs[1];

                    if (!light.ContainsKey(forceUser) && forceSide.Contains("Light"))
                    {
                        light.Add(forceUser, forceSide);
                    }
                    else if (!dark.ContainsKey(forceUser) && forceSide.Contains("Dark"))
                    {
                        dark.Add(forceUser, forceSide);
                    }
                }
                else if (input.Contains(subTwo))
                {
                    comArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    forceUser = comArgs[0];
                    forceSide = comArgs[1];
                    if (light.ContainsKey(forceUser))
                    {
                        dark.Add(forceUser, forceSide);
                        light.Remove(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else if (!light.ContainsKey(forceUser) && forceSide.Contains("Light"))
                    {
                        light.Add(forceUser, forceSide);
                        dark.Remove(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else if (dark.ContainsKey(forceUser))
                    {
                        light.Add(forceUser, forceSide);
                        dark.Remove(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else if (!dark.ContainsKey(forceUser) && forceSide.Contains("Dark"))
                    {
                        dark.Add(forceUser, forceSide);
                        light.Remove(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }
            if (light.Count > dark.Count)
            {
                zeroValueLight = light.Select((Val, Index) => new { Val, Index })
                                            .Single(viPair => viPair.Index == 0) //Selecting dictionary item with it's index using index
                                            .Val                                 //Extracting KeyValuePair from dictionary item
                                            .Value;
                Console.WriteLine($"Side: {zeroValueLight}, Members: {light.Count}");
                foreach (var item in light)
                {
                    Console.WriteLine($"! {item.Key}");
                }
                if (dark.Count > 0)
                {
                    zeroValueDark = dark.Select((Val, Index) => new { Val, Index })
                                       .Single(viPair => viPair.Index == 0) //Selecting dictionary item with it's index using index
                                       .Val                                 //Extracting KeyValuePair from dictionary item
                                       .Value;
                    Console.WriteLine($"Side: {zeroValueDark}, Members: {dark.Count}");
                    foreach (var item in dark)
                    {
                        Console.WriteLine($"! {item.Key}");
                    }
                }
            }
            else if (dark.Count >= light.Count)
            {
                zeroValueDark = dark.Select((Val, Index) => new { Val, Index })
                                      .Single(viPair => viPair.Index == 0) //Selecting dictionary item with it's index using index
                                      .Val                                 //Extracting KeyValuePair from dictionary item
                                      .Value;
                Console.WriteLine($"Side: {zeroValueDark}, Members: {dark.Count}");
                foreach (var item in dark)
                {
                    Console.WriteLine($"! {item.Key}");
                }
                if (light.Count > 0)
                {
                    zeroValueLight = light.Select((Val, Index) => new { Val, Index })
                                            .Single(viPair => viPair.Index == 0) //Selecting dictionary item with it's index using index
                                            .Val                                 //Extracting KeyValuePair from dictionary item
                                            .Value;
                    Console.WriteLine($"Side: {zeroValueLight}, Members: {light.Count}");
                    foreach (var item in light)
                    {
                        Console.WriteLine($"! {item.Key}");
                    }
                }
            }
        }
    }
}
