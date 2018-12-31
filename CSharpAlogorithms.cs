using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class ProblemSamples
    {
        public static char FindCharacterOfLongestConsecutiveRepeatingCharacter(string s)
        {
            //Setup initial conditions
            //What has been found
            int longestStringCount = 1;
            int longestStringStart = 0;
            //What we're currently checking
            int currentStringCount = 1;
            int currentStringStart = 0;
            for (int i = 1; i < s.Length; i++)
            {
                //Check if the current character si the same the last
                if (s[i] == s[i - 1])
                {
                    currentStringCount++;
                }
                //else new character
                else
                {
                    //Check fi the alst series of characters was the longest encountered
                    if (currentStringCount > longestStringCount)
                    {
                        longestStringCount = currentStringCount;
                        longestStringStart = currentStringStart;
                    }
                    //Reset initial conditions
                    currentStringCount = 1;
                    currentStringStart = i;
                }
            }
            //REturn the first character of the first, longest consecutive string
            return s[longestStringStart];
        }


        public static int[] MergeSortTwoSortedIntegerArrays(int[] A = null, int[] B = null)
        {

            int currentA = 0;
            int currentB = 0;

            int[] Final = new int[A.Length + B.Length];
            for (int i = 0; i < Final.Length; i++)
            {
                if (currentA == A.Length)
                {
                    Final[i] = B[currentB];
                    currentB++;
                }
                else if (currentB == B.Length)
                {
                    Final[i] = A[currentA];
                    currentA++;
                }
                else if (A[currentA] < B[currentB])
                {
                    Final[i] = A[currentA];
                    currentA++;
                }
                else
                {
                    Final[i] = B[currentB];
                    currentB++;
                }
            }

            return Final;
        }

        public static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int checkAgainstIndex;
                int currentValue = array[i];

                //Loop through each elements preceeding the current value
                for (checkAgainstIndex = i-1; checkAgainstIndex >= 0 ; checkAgainstIndex--)
                {
                    //If the current value is greater than the value being checked, you're done looping
                    if (array[checkAgainstIndex] <= currentValue)
                        break;
                    //else, increase the index of the value being checked to make space for the current value
                    array[checkAgainstIndex + 1] = array[checkAgainstIndex];
                }
                //Once we've found where all previous values are less than the current value, insert
                array[checkAgainstIndex + 1] = currentValue;
            }

            return array;
        }
        /// <summary>
        /// Check if any two values in an array, if one is subtracted from the other, 
        /// the difference equals the queried value
        /// </summary>
        public static int[] checkForDifferenceCompliment(int query, int[] array)
        {
            //Iterate through each element
            for (int i = 0; i < array.Length - 1; i++)
            {
                //Iterate through each element after the first selected element
                for (int j = i + 1; j < array.Length; j++)
                {
                    //Check Condition
                    if (array[j] - array[i] == query || array[i] - array[j] == query)
                    {
                        //Return values if condition met
                        return new int[] { array[i], array[j] };
                    }
                }
            }

            return new int[] { };
        }

        /// <summary>
        /// Looks for a value in a sorted array by selecting a middle index and checking it against
        /// the searchValue. If the searchValue is less than the guesse value, the top half of the array is
        /// eliminated
        /// </summary>
        /// <param name="array"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] array, int searchValue)
        {
            int max = array.Length - 1;
            int min = 0;

            while(max >= min)
            {
                int guess = (max + min) / 2;
                if (array[guess] == searchValue)
                    return guess;
                else if (array[guess] < searchValue)
                {
                    min = ++guess;
                }
                else
                {
                    max = --guess;
                }             
            }

            return -1;
        }

        /// <summary>
        /// Takes an array and target anc find if any of the values can be subtracted from eachother to 
        /// equal the target value
        /// </summary>
        /// <param name="arrayToCheck"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public static int[] SumOfTarget(int[] arrayToCheck, int targetSum)
        {
            HashSet<int> hashedArray = new HashSet<int>(arrayToCheck);

            foreach (int num in hashedArray)
            {
                if (hashedArray.Contains(num - targetSum))
                {
                    return new int[] { num, num - targetSum };
                }

            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Returns a string containing all characters that were not repeated in a received string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string findSingleElements(string s)
        {
            var nonDC = "";

            //Create a dictionary for storing all values in the string and the count of occurences.
            Dictionary<char, int> d = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!d.ContainsKey(c))
                    d.Add(c, 1);
                else
                    d[c] += 1;
            }
            //Check which elements have a count of 1
            foreach (var item in d)
            {
                if (item.Value == 1)
                    nonDC = nonDC + item.Key + ",";
            }

            return nonDC;
        }
        
        /// <summary>
        /// Implements the Hashset to isolate values and return an array with no duplicates
        /// </summary>
        /// <param name="initialArray"></param>
        /// <returns></returns>
        static int[] RemoveArrayDuplicateUsingHashset(int[] initialArray)
        {
            HashSet<int> h = new HashSet<int>();
            for (int i = 0; i < initialArray.Length; i++)
            {
                if (!h.Contains(initialArray[i]))
                {
                    h.Add(initialArray[i]);
                }
            }
            int[] newArray = new int[h.Count]; 
                h.CopyTo(newArray);
            return newArray;
        }
        /// <summary>
        /// Implements temporary arrays to isolate values and return an array with no duplicates
        /// </summary>
        /// <param name="initialArray"></param>
        /// <returns></returns>
        static int[] RemoveArrayDuplicatesUsingArrays(int[] initialArray)
        {
            Array.Sort(initialArray);
            int[] tempArray = new int[initialArray.Length];
            int j = 0;

            //Move forward through the array until the last occurance on an integer and add that to our temp array
            for (int i = 0; i < initialArray.Length-1; i++)
            {
                //If the next integer is a new integer, save the current integer to our tempArray
                if (initialArray[i] != initialArray[i + 1])
                    tempArray[j++] = initialArray[i];             
            }
            //Add last integer
            tempArray[j] = initialArray[initialArray.Length - 1];
            //Clone temp array to array to return of correct size
            int[] returnArray = new int[j+1];
            for (int i = 0; i <= j; i++)
            {
                returnArray[i] = tempArray[i];
            }

            return returnArray;
        }
    }
}
