using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the sockMerchant function below.
    //refer:https://medium.com/@rezehnde/sock-merchant-challenge-solved-in-c-f2ec9235ddea
    ///For example, there are n = 7 socks with colors ar = [1, 2, 1, 2, 1, 3, 2].
    ///There is one pair of color 1 and one of color 2.
    ///There are three odd socks left, one of each color. 
    ///The number of pairs is 2.
    static int sockMerchant(int n, int[] ar)
    {
       
        int counter = 0;
        var comparlist = new Dictionary<int,int>();
        foreach (var i in ar) 
        {           
            if (comparlist.ContainsKey(i))
            {
                counter++;
                comparlist.Remove(i);
            }
            else {
                comparlist.Add(i,1);
            }          
           
        }
        
       return counter;

    }

    static void Main(string[] args)
    {
        int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
        int n = ar.Length;
        int result = sockMerchant(n, ar);

        Console.WriteLine("paired socks: " + result);

    }
}
