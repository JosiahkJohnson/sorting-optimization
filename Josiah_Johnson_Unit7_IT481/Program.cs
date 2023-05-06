using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Josiah_Johnson_Unit7_IT481
{
    internal class Program
    {
        //This simple program is going to use bubble sort and quick sort to compare the efficentcy
        //Of two algoritims that both serve the same purpose
        //This programs illustrates the importance of optimization and how small changes to some base
        //algorithims can make a program run better

        //stopwatch object will track efficency
        private static Stopwatch stopWatch = new Stopwatch();

        //executable section
        static void Main(string[] args)
        {

            //create a small integer array for testing
            int[] smallArray = getArray(10, 100);
            int[] newSmallArray = new int[smallArray.Length];
            Array.Copy(smallArray, 0, newSmallArray, 0, newSmallArray.Length);

            //Another deep copy for quicksort comparison
            int[] quickSortSmallArray = new int[newSmallArray.Length];
            Array.Copy(newSmallArray, 0, quickSortSmallArray, 0, quickSortSmallArray.Length);

            //call the bubble sort method
            BubbleArray(smallArray, "small");



            //create a medium integer array for testing
            int[] medArray = getArray(1000, 100);
            int[] newMedArray = new int[medArray.Length];
            Array.Copy(medArray, 0, newMedArray, 0, newMedArray.Length);

            //Another deep copy for quicksort comparison
            int[] quickSortMedArray = new int[newMedArray.Length];
            Array.Copy(newMedArray, 0, quickSortMedArray, 0, quickSortMedArray.Length);

            //call the bubble sort method
            BubbleArray(medArray, "medium");


            //create a large integer array for testing
            int[] LargeArray = getArray(10000, 100);
            int[] newLargeArray = new int[LargeArray.Length];
            Array.Copy(LargeArray, 0, newLargeArray, 0, newLargeArray.Length);

            //Another deep copy for quicksort comparison
            int[] quickSortLargeArray = new int[newLargeArray.Length];
            Array.Copy(newLargeArray, 0, quickSortLargeArray, 0, quickSortLargeArray.Length);

            //call the bubble sort method
            BubbleArray(LargeArray, "large");


            //In this section duplicates will be removed before running the sorting
            //to check how much more efficent this makes the algorythim
            newSmallArray = onlyUniqueElements(newSmallArray);
            BubbleArray(newSmallArray, "small unique");

            newMedArray = onlyUniqueElements(newMedArray);
            BubbleArray(newMedArray, "medium unique");

            newLargeArray = onlyUniqueElements(newLargeArray);
            BubbleArray(newSmallArray, "large unique");

            //run the quick sort methods
            //for counting time spent sorting
            Console.WriteLine();
            long elapsedTime = 0;
            //start counting
            stopWatch = Stopwatch.StartNew();
            SortArray(quickSortSmallArray, 0, quickSortSmallArray.Length-1, "small");
            //stop counting
            stopWatch.Stop();
            elapsedTime = stopWatch.ElapsedTicks;
            //print the result time
            Console.WriteLine("The quicksort took " + elapsedTime + " for " + "small array");

            Console.WriteLine();
            elapsedTime = 0;
            //start counting
            stopWatch = Stopwatch.StartNew();
            SortArray(quickSortMedArray, 0, quickSortMedArray.Length-1, "medium");
            //stop counting
            stopWatch.Stop();
            elapsedTime = stopWatch.ElapsedTicks;
            //print the result time
            Console.WriteLine("The quicksort took " + elapsedTime + " for " + "medium array");

            Console.WriteLine();
            elapsedTime = 0;
            //start counting
            stopWatch = Stopwatch.StartNew();
            SortArray(quickSortLargeArray, 0, quickSortLargeArray.Length - 1, "large");
            //stop counting
            stopWatch.Stop();
            elapsedTime = stopWatch.ElapsedTicks;
            //print the result time
            Console.WriteLine("The quicksort took " + elapsedTime + " for " + "large array");

            //keep console open
            Console.Read();

        }

        //method for deleting duplicates
        public static int[] onlyUniqueElements(int[] array)
        {
            //create a set
            HashSet<int> set = new HashSet<int>();

            //tempoary array for storage
            int[] temp = new int[array.Length];
            int index = 0;

            //use the properties of sets to disallow duplicates from being added
            foreach (int i in array)
            {
                if(set.Add(i))
                {
                    temp[index++] = i;
                }
            }
            
            //return the result
            return set.ToArray();
        }

        //create a set length array of random numbers of a maximum given value
        public static int[] getArray(int size, int max)
        {
            //declare the new array
            int[] array = new int[size];

            //startup the random generator
            Random rnd = new Random();

            //fill the entire array with random data
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, max);
            }

            //return the new array
            return array;
        }

        //bubble sort
        //credit: CodeMaze Jun 5 2022
        //https://code-maze.com/csharp-bubble-sort/
        //loops through array and if the current index value is greater than the next one, it swaps them
        //uses nesting loop method
        public static void BubbleArray(int[] array, string arraySize)
        {
            //for counting time spent sorting
            long elapsedTime = 0;

            string size = arraySize;
            var n = array.Length;

            //start counting
            stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        var tempVar = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempVar;
                    }

            Console.WriteLine();

            //stop counting
            stopWatch.Stop();
            elapsedTime = stopWatch.ElapsedTicks;

            //print the result time
            Console.WriteLine("The bubblesort took " + elapsedTime + " for " + size);
        }

        //quick sort
        //credit: CodeMaze October 11 2022
        //https://code-maze.com/csharp-quicksort-algorithm/
        //basically splits the array in half and uses recursion to call itself and more efficently sort an array
        public static void SortArray(int[] array, int leftIndex, int rightIndex, string ArraySize)
        {
            string size = ArraySize;
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j, size);

            if (i < rightIndex)
                SortArray(array, i, rightIndex, size);
        }
    }
}
