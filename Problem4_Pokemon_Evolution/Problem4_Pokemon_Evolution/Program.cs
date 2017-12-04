using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main() // 100/100
    { 
        //четем входа
        string input = Console.ReadLine();
        //пражим речник от ключ - стринг и стойност -лист от стринг 
        Dictionary<string, List<string>> Dictionaty = new Dictionary<string, List<string>>();
        // изпълни докато няма...
        while (input != "wubbalubbadubdub")
        {
            //правим масив от токени разделени по..
            string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            //името на покемона е първата стйност от масива
            string pokeName = tokens[0];
            //ако дължината на токена е по голяма от 1
            if (tokens.Length > 1)
            {
                //ако името не се съдържа в речника
                if (!Dictionaty.ContainsKey(pokeName))
                {
                    //тогава името отива в нов лист
                    Dictionaty[pokeName] = new List<string>();
                }
                // стринга... = 2-та + 3-тата стойност от масива
                string pointsEvolutionType = tokens[1] + " <-> " + int.Parse(tokens[2]);
                //към името на покемона добавяме второто име и стоиността
                Dictionaty[pokeName].Add(pointsEvolutionType);
            }
            else
            {
                // ако името се съдържа в речника
                if (Dictionaty.ContainsKey(pokeName))
                {
                    //изписваме
                    Console.WriteLine("# " + pokeName);
                    //въртим цикъл в листа 
                    foreach (string evolution in Dictionaty[pokeName])
                    {
                        Console.WriteLine(evolution);
                    }
                }
            }
            input = Console.ReadLine();
        }
        foreach (var item in Dictionaty)
        {
            Console.WriteLine("# " + item.Key);
            foreach (string typeandNumber in item.Value.OrderByDescending(x => int.Parse(x.Split(new[] { " <-> " }, StringSplitOptions.None).Skip(1).First())))
            {
                Console.WriteLine(typeandNumber);
            }
        }
    }
}