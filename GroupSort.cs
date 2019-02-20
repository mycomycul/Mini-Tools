using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlogorithms
{
    //TODO: Pass in pointer to getpriority method relevant to type
    /// <summary> Sorts an array of T into 3 groups based on their priority level provided by a given
    ///           getpriority method 
    /// </summary>
    ///
    /// <remarks> Method checks for how many of each priority there are to determine how big each group
    ///           in the array is and then sorts each item into the first available slot in the appropriate section </remarks>
    class Sort<T>
    {
        void GroupSort(T[] productCodes)
        {

            int high = 0, medium = 0;

            //Determine how big the section for each priority is
            // Used for determining where to start looking for available space to sort in to
            for (int i = 0; i < productCodes.Length; i++)
            {
                int priority = getPriority(productCodes[i]);
                switch (priority)
                {
                    case 1:
                        high++;
                        medium++;
                        break;
                    case 2:
                        medium++;
                        break;
                }
            }

            //Single buffer sorting due to large dataset
            int hIndex = 0, mIndex = high, lIndex = medium, currentPriority = 1;
            for (int i = 0; i < productCodes.Length; i++)
            {
                currentPriority = i < high ? 1 : i < medium ? 2 : 3;
                int p = getPriority(productCodes[i]);
                if (currentPriority == p)
                {
                    continue;
                }
                if (p == 1)
                {
                    while (getPriority(productCodes[hIndex]) == 1)
                    {
                        hIndex++;
                    }
                    Swap(i, hIndex, productCodes);
                }
                else if (p == 2)
                {
                    while (getPriority(productCodes[mIndex]) == 2)
                    {
                        mIndex++;
                    }
                    Swap(i, mIndex, productCodes);
                    i--;
                }
                else
                {
                    while (getPriority(productCodes[lIndex]) == 3)
                    {
                        lIndex++;
                    }
                    Swap(i, lIndex, productCodes);
                    i--;
                }
            }
        }

        /// <summary>Swaps two elements in an array using a buffer </summary>
        ///
        /// <remarks>   Michael, 2/20/2019. </remarks>
        ///
        /// <param name="source">   Source for the. </param>
        /// <param name="index">    Zero-based index of the. </param>
        /// <param name="items">    The items. </param>

        static void Swap(int source, int index, T[] items)
        {
            T buffer = items[index];
            items[index] = items[source];
            items[source] = buffer;
        }
        static int getPriority(T p)
        {
            int i = p.length;
            int currentPriority = i <= 3 ? 1 : (i > 8 ? 3 : 2);
            return currentPriority;
        }
    }
}
