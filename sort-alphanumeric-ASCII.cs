using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ascii
{
    class Program
    {
        //Two simple solutions to sort a string in alphanumeric order based on the ASCII character codes
        //The first method uses the default ASCII codes to sort
        //The second method uses a delegate array of characters with adjusted ASCII codes so that uppercase chars are sorted with lowercase.
        static void Main(string[] args)
        {
            Console.WriteLine("Type a string and push enter to organize it in alphanumeric order. Input \"stop\" to exit");
            //Read string and convert string ascii character codes  
            byte[] byteSet = Encoding.ASCII.GetBytes(Console.ReadLine());

            while (Encoding.ASCII.GetString(byteSet) != "stop")
            {
                Console.WriteLine("If you would like treat uppercase and lowercase as the same letters, type \"yes\" and press \"enter\" or push \"enter\" to continue");
                var CapitalsMatter = Console.ReadLine();
                if (CapitalsMatter.ToLower() == "yes")
                { byteSet = SortUpperCaseFirst(byteSet); }
                else
                { byteSet = SortAllLettersTogether(byteSet); }

                Console.WriteLine(Encoding.ASCII.GetString(byteSet));
                Console.WriteLine("Type a string and push enter to organize it in alphanumeric order. Input \"stop\" to exit");
                byteSet = Encoding.ASCII.GetBytes(Console.ReadLine());
            };
        }

        public static byte[] SortAllLettersTogether(byte[] byteSet)
        {
            /*FIRST METHOD*/
            bool sort = true;
            //Sort boolean used to monitor if a change was made in the last sort iteration
            //If nothing gets changed than we don't need to sort again and the boolean value won't be updated.
            while (sort == true)
            {
                sort = false; //Initial assumption that the data is sorted.
                for (int i = 1; i < byteSet.Length; i++)
                {
                    if (byteSet[i] < byteSet[i - 1])
                    {
                        var saveByte = byteSet[i];
                        byteSet[i] = byteSet[i - 1];
                        byteSet[i - 1] = saveByte;
                        sort = true; //If the data was sorted go back and check again
                    }
                }
            }
            return byteSet;
        }

        public static byte[] SortUpperCaseFirst(byte[] byteSet)
        {
            /*SECOND METHOD*/
            //Create new byte array to use as a delegate for comparing byte values
            //while byteSet holds the original values.
            byte[] delegateByteSet = new byte[byteSet.Length];
            byte offSet = 32;
            for (int i = 0; i < delegateByteSet.Length; i++)
            {
                if (byteSet[i] < 97) delegateByteSet[i] = (byte)(byteSet[i] + offSet);
                else delegateByteSet[i] = byteSet[i];
            }


            //Sorting. 
            var sortAgain = true; //Sort boolean check if we should sort again
            while (sortAgain == true)
            {
                sortAgain = false; //If nothing gets changed than we don't need to sort again.
                for (int i = 1; i < delegateByteSet.Length; i++)
                {
                    if (delegateByteSet[i] < delegateByteSet[i - 1])
                    {
                        //Sort both arrays based on comparisons in the delegateByteSet
                        var saveByte = byteSet[i];
                        var delegateSaveByte = delegateByteSet[i];

                        byteSet[i] = byteSet[i - 1];
                        delegateByteSet[i] = delegateByteSet[i - 1];

                        byteSet[i - 1] = saveByte;
                        delegateByteSet[i - 1] = delegateSaveByte;

                        sortAgain = true;
                    }
                }
            }
            return byteSet;
        }
    }
}
