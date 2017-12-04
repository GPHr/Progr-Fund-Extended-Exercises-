using System;
using System.Numerics;
namespace UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var uniCode = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                var code = $"{(int)text[i]:X4}".ToLower();
                uniCode += $"\\u{code}";
               //var chars = value
               //    .Select(c => (int)c)
               //    .Select(c => $@"\u{c:x4}");
            }

            Console.WriteLine(uniCode);
        }
    }
}
