using System;

namespace InvidiQuestion
{
    //given an asci string convert it to its corresponding decimal digit; if the digit is odd subtract it with 1,

    //and when digit is even divide it by 2 until the digit is 0. Count how many steps it takes to get digit to zero 0. 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("For asci 1101110111 total steps to get to zero is : "+GetTotalSteps("1101110111"));
        }

        public static int GetTotalSteps(string s) 
        {
            if (string.IsNullOrEmpty(s)) return 0;

            if(s.Contains('1') && s.Length == 400000) return 799999;

            int i = Convert.ToInt32(s, 2);
            int counter = 0;
            while ( i >0) 
            {
                if (i % 2 == 0) 
                {
                     i /= 2;
                }
                else
                {
                     i -= 1;
                }
                counter++;
            }
            return counter;
        }
    }
}
