using System;
using System.Collections;
using System.Collections.Generic;

namespace CircularPrinter
{
    class Program
    {
        static int shortdist = 0;
        static void Main(string[] args)
        {
            String s = "AZGB";
            Console.WriteLine("Time to print: "+GetTime(s));
            Console.ReadLine();
        }

        private static int GetTime(string s)
        {
            char[] alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] input = s.ToCharArray();
            Dictionary<char, int> alphab = new Dictionary<char, int>();

            for (int i = 0; i < alphabets.Length; i++)
                alphab.Add(alphabets[i], i);

            //rec(alphabets, input, 0, 0);
            //rec1(alphabets, input, 0, 0);

            rec(alphab, input, 0, 0);

            //int dist = Math.Abs(5 - 26);
            //int j = Math.Min(26 - dist,dist);

            return shortdist;
        }

        private static void rec(Dictionary<char, int> AlphaB, char[] Input, int InputIndex, int StartIndex)
        {
            int dist;

            for (int i = StartIndex; i < Input.Length; i++)
            {
                dist = Math.Abs(AlphaB.Count - AlphaB[Input[i]]);
                shortdist += Math.Min(AlphaB.Count - dist, dist);

                //if (InputIndex < Input.Length - 1)
                    //rec(AlphaB, Input, InputIndex + 1, i);
            }

            //if (InputIndex < Input.Length)
            //{
            //    int dist = Math.Abs((AlphaB[Input[0]] + AlphaB[Input[InputIndex]]) - AlphaB.Count);
            //    shortdist += Math.Min(AlphaB.Count - dist, dist);
            //    rec(AlphaB, Input, InputIndex + 1);
            //}
        }

        private static void rec(char[] Alphabets, char[] Input, int CurrentIndex, int NextIndex)
        {
            for (int i = CurrentIndex; i < Alphabets.Length; i++)
            {
                if (Alphabets[i] == Input[NextIndex])
                {
                    int dist = Math.Abs(i - 26);
                    shortdist += Math.Min(26 - dist, dist);
                    
                    if (NextIndex < Input.Length - 1)
                        rec(Alphabets, Input, i, NextIndex++);
                }


            }
                       
        }

        private static void rec1(char[] Alphabets, char[] Input, int CurrentIndex, int NextIndex)
        {
            for (int i = Alphabets.Length - 1; i >= 0; i--)
            {
                if (Alphabets[i] == Input[NextIndex])
                {
                    int dist = Math.Abs(i - 26);
                    shortdist += Math.Min(26 - dist, dist);

                    if (NextIndex < Input.Length - 1)
                        rec1(Alphabets, Input, i, NextIndex++);
                }

            }
        }

    }
}
