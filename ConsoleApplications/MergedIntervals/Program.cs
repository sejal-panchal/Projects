using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MergedIntervals
{
    //Merged Interval finds the overlapping intervals in any order.
    //time complexity of the alogrithm is O(nLogn) which is for sorting . Once the intervals is sorted merging takes linear time O(n)
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> intervals = new List<List<int>>();

            intervals.Add(new List<int> { 6, 8 });
            //intervals.Add(new List<int> { 1, 9 });
            intervals.Add(new List<int> { 2, 4 });
            intervals.Add(new List<int> { 4,7});
            intervals.Add(new List<int> { 10, 13 });
            intervals.Add(new List<int> { 14, 16 });

            intervals = GetMergedIntervals(intervals);
            foreach( var item in intervals)
            {
                Console.WriteLine("{" + item.ToArray().GetValue(0) + " , "+ item.ToArray().GetValue(1) + "}");
            }
        }

        private static List<List<int>> GetMergedIntervals(List<List<int>> intervals)
        {
            //rList has ordered items by row.
            IEnumerable<List<int>> rlist = intervals.Select(lst => lst.OrderBy(i => i).ToList());

            //sortedList is ordered by the value of first index.
            List<List<int>> sortedList = rlist.OrderBy(lst => lst[0]).ToList();

            //efficient/good way to sortedList
            //var sortedList = intervals
            //            .Select(lst => lst.OrderBy(i => i).ToList())
            //            .OrderBy(lst => lst[0]).ToList();

            intervals = sortedList;
            List<List<int>> result = new List<List<int>>();
            Stack stack = new Stack();

            //get the first interval in the stack.
            stack.Push(intervals[0]);
            List<int> top = new List<int>();

            //foreach interval in intervals 
            foreach(var item in intervals)
            {
                
                top = (List<int>)stack.Peek();

                //check top interval with each interval in intervals
                if(top[1] < item[0])
                {
                    stack.Push(item);
                }
                else if (top[1] < item[1])
                {
                    top[1] = item[1];
                    stack.Pop();
                    stack.Push(top);
                }
            }

            while (stack.Count != 0)
            {
                //empty stack into resultant intervals object.
                result.Add((List<int>)stack.Pop());
            }
            return result;
        }
    }
}
