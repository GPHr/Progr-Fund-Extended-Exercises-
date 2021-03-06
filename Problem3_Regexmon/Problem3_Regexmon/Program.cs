﻿using System;
using System.Text.RegularExpressions;
namespace Problem3_Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string didimonPattern = @"[^A-Za-z-]+";
            string bojomonPattern = @"[A-Za-z]+-[A-Za-z]+";

            bool goDidi = true;
            while (input.Length > 0)
            {
                string pattern = (goDidi) ? didimonPattern : bojomonPattern;
                goDidi = !goDidi;

                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                    input = input.Substring(match.Index + match.Value.Length);
                }
                else
                {
                    break;
                }
            }
        }
    }
}