using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousCache
{
    class Program
    {
        static void Main()
        {

            Dictionary<string, Dictionary<string, long>> tokens = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> cache = new Dictionary<string, Dictionary<string, long>>();

            var input = " ";
            while ((input = Console.ReadLine()) != "thetinggoesskrra")
            {
                string[] text = input.Split(new[] {' ', '-', '>', '|'}, StringSplitOptions.RemoveEmptyEntries);

                if (text.Length == 1)
                {
                    string dataSet = text[0];
                    if (cache.ContainsKey(dataSet))
                    {
                        tokens[dataSet] = new Dictionary<string, long>(cache[dataSet]);
                        cache.Remove(dataSet);
                    }
                    else
                    {
                        tokens[dataSet] = new Dictionary<string, long>();
                    }
                }
                else
                {
                    string dataKey = text[0];
                    long dataSize = long.Parse(text[1]);
                    string dataSet = text[2];

                    if (!tokens.ContainsKey(dataSet))
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache[dataSet] = new Dictionary<string, long>();
                        }
                        cache[dataSet][dataKey] = dataSize;
                    }
                    else
                    {
                        tokens[dataSet][dataKey] = dataSize;
                    }
                }
            }
            if (tokens.Count > 0)
            {
                KeyValuePair<string, Dictionary<string, long>> result =
                    tokens.OrderByDescending(x => x.Value.Sum(t => t.Value)).First();
                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(t => t.Value)}");

                foreach (var value in result.Value)
                {
                    Console.WriteLine("$.{0}", value.Key);
                }
            }
        }
    }
}
