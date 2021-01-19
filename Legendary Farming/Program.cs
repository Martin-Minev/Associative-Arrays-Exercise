using System;
using System.Linq;
using System.Collections.Generic;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;
            bool hasToBreak = false;

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ");

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string materials = input[i + 1].ToLower();

                    if (materials == "shards" || materials == "motes" || materials == "fragments")
                    {
                        keyMaterials[materials] += quantity;
                        if (keyMaterials[materials] >= 250)
                        {
                            keyMaterials[materials] -= 250;
                            if (materials == "shards")
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                            }
                            else if (materials == "motes")
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
                            }
                            else if (materials == "fragments")
                            {
                                Console.WriteLine($"Valanyr obtained!");
                            }
                            hasToBreak = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(materials))
                        {
                            junk.Add(materials, 0);
                        }
                        junk[materials] += quantity;
                    }
                }
                if (hasToBreak == true)
                {
                    break;
                }
            }
            Dictionary<string, int> filteredKeyMaterials = keyMaterials
                                                           .OrderByDescending(v => v.Value)
                                                           .ThenBy(k => k.Key)
                                                           .ToDictionary(k => k.Key, v => v.Value);
            foreach (var item in filteredKeyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
