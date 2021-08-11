using System;
using System.Collections.Generic;

namespace ContainsCommonItems
{
    class Program
    {
        //time complexity is O(M) ; M being the number of strings ;
        static void Main(string[] args)
        {
            string[] arr1=new string[]{"a","b","c","d"};
            string[] arr2=new string[]{"b","f","l","r"};
            Console.WriteLine("both arrays has any common values ? "+ContainsCommonItems(arr1,arr2).ToString());
        }

        public static bool ContainsCommonItems(string[] arr1,string[] arr2)
        {
            if(arr1.Length<=0) return false;
            Dictionary<string,bool> obj=new Dictionary<string,bool>();
            foreach(var item in arr1)
            {
                if(!obj.ContainsKey(item))
                {
                    obj.Add(item,true);
                }
            }
            
            foreach(var item in arr2){
                if(obj.ContainsKey(item)) 
                    return true;
            }
            return false;
        }
    }

       
}
