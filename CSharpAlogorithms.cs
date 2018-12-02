using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Problemsamples
    {
        public char FindCharacterOfLongestConsecutiveRepeatingCharacter(string s)
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
        public int[] MergeSortTwoSortedIntegerArrays(int[] A = null, int[] B = null)
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
    }
}
