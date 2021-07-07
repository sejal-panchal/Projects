using System;

namespace BinaryGap
{
    /*Write a function
class Solution { public int solution(int N); }
that, given a positive integer N, returns the length of its longest binary gap. The function should return 0 if N doesn't contain a binary gap.
For example, given N = 1041 the function should return 5, because N has binary representation 10000010001 and so its longest binary gap is of length 5.
Given N = 32 the function should return 0, because N has binary representation '100000' and thus no binary gaps.
Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..2,147,483,647].*/
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Binary Gap for 1034 : "+solution(1034));
        }

        public static int solution(int N) 
        {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        if(N==0) return 0;
        String NBinary = Convert.ToString(N,2);
        System.Console.WriteLine(NBinary);

        if(!NBinary.Contains("0")) return 0;

        var binaries=NBinary.ToCharArray();
        
        int len=0;
      //  int[] cnt=new int[]{};
        int active=0; 
        int max =0;

        for(int i =0;i<binaries.Length;i++)
        {
            if(binaries[i]=='1')
            {
                if(active==1){
                    if(len > max)
                            max=len;
                    len =0;
                }
                 active=1;

            }
            else
            {     if(active==1)  
                        len=len+1;
            }
        }

        
        return max;
    }
    }  
}
