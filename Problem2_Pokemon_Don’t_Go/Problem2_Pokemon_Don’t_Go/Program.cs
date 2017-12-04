using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> distances = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            long sumRemovedElements = 0;
            while (distances.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                long removedElement = RemoveElement(distances, index);
                sumRemovedElements += removedElement;
                distances = IncreaseOrDecreaseElements(distances, removedElement);
            }

            Console.WriteLine(sumRemovedElements);
        }

        private static long RemoveElement(List<long> distances, int index)
        {
            long removedElement = 0;
            if (index < 0)
            {
                long lastElement = distances[distances.Count - 1];    //vzima poslednoto 4islo ot masiva
                removedElement = distances[0];                        //vzima parvoto 4islo ot masivq
                distances.RemoveAt(0);                                //maha parvoto 4islo ot masiva
                distances.Insert(0, lastElement);                     //zamenq parvoto 4islo s poslednoto
            }                                                         
            else if (index > distances.Count - 1)
            {
                long firstElement = distances[0];                      //vzima parvoto 4islo ot masivq
                removedElement = distances[distances.Count - 1];       //vzima poslednoto 4islo ot masiva
                distances.RemoveAt(distances.Count - 1);               //maha poslednoto 4islo ot masiva
                distances.Add(firstElement);                           //dobavq parvoto 4islo
            }
            else
            {
                removedElement = distances[index];
                distances.RemoveAt(index);
            }

            return removedElement;
        }

        private static List<long> IncreaseOrDecreaseElements(List<long> distances, long value)
        {
            return distances
                .Select(i =>
                    {
                        if (i <= value)
                            return i + value;
                        else
                            return i - value;
                    }
                )
                .ToList();
        }
    }
}