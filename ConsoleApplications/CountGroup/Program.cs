using System;
using System.Collections.Generic;

namespace CountGroup
{
    class Program
    {
        //count group formed in matrices by binaries (0 and 1) such that 1 represents relation and 0 does not. Example data below:
        //1100
        //1100
        //0010
        //0001
        //related[n]
        //related[0]
        //related[1]
        //related[2]

        //equals one group

        //and related[3] = not related to anybody else so it forms its own group

        //so total group here are 2 groups

        public static int Count(Char[][] related)
        {
            int noOfGroup = 0;
            Boolean[] visited = new bool[related.Length];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            for (int i = 0; i < related.Length; i++)
            {
                if (!visited[i])
                {
                    noOfGroup++;
                    visited[i] = true;
                    findRelation(related, visited, i);
                }
            }

            return noOfGroup;
        }

        public static void findRelation(Char[][] relation, Boolean[] visited, int p)
        {
            for (int q = 0; q < relation.Length; q++)
            {
                if (!visited[q] && p != q && relation[p][q] == '1')
                {
                    visited[q] = true; //relations are found here in form of node visited
                    findRelation(relation, visited, q);
                }
            }
        }

        static void Main(string[] args)
        {
            List<string> related = new List<string> { "1100", "1110", "0110", "0001" };
            //Char[,] bins= new Char[4,4]
            //{ {'1','1','0','0'},
            // {'1','1','1','0' },
            // {'0','1','1','0' },
            // { '0','0','0','1'}
            //};

            // create array of arrays
            char[][] possibleGroup = new char[related.Count][];
            // create arrays to put in the array of arrays
            for (int i = 0; i < related.Count; i++)
            {
                possibleGroup[i] = new char[related.Count];
                // put array in array of arrays
                possibleGroup[i] = related[i].ToCharArray();//row as array
            }
            Console.WriteLine("No of groups are: " + Count(possibleGroup));
        }
    }
}
