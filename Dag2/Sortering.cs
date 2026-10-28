using System;
using System.Collections.Generic;
using System.Text;

namespace Dag2
{
    internal class Sortering
    {
        // opgave 6

        //method: sorts the array(smallest first)
        // void, because it changes the array you give it
        public static void SelectionSort(int[] tal)
        {
            // outer loop: the place we are filling now(0, 1, 2, ...)
            for (int i = 0; i < tal.Length - 1; i++)
            {
                int mindst = i;     // assume the smallest number is at place i

                for (int j = i + 1; j < tal.Length; j++)    // Inner loop: look at the rest to find a smaller number

                {
                    if (tal[j] < tal[mindst])
                    {
                        mindst = j;    // remember the place of the new smallest              
                    }
                }

                int temp = tal[i];
                tal[i] = tal[mindst];
                tal[mindst] = temp;
            }

        }

        // opgave 7
        public static byte[] SorterEfterFrevens(int[] frekvenser)   //method: gives the byte values that appear, sorted by frequency (biggest first)

        {
            // step1: count how many different bytes appear 
            int antalForskellige = 0;
            for (int b = 0; b < 256; b++)
            {
                if (frekvenser[b] > 0)
                {
                    antalForskellige++;

                }
            }

            // Step2: collect the byte values that appear
            byte[] værdier = new byte[antalForskellige];
            int plads = 0;

            for (int b = 0; b < 256; b++)
            {
                if ((frekvenser[b] > 0))
                 {
                    værdier[plads] = (byte)b; //(byte) is a cast, ikke before
                    plads++;

                }
            }

            //step 3: selection sort, but biggest count first
            for (int i = 0; i < værdier.Length - 1; i++)
            {
                int størst = i;  // assume the biggest count is at place i

                for (int j = i + 1; j < værdier.Length; j++)
                {
                    //compare the COUNTS of the byte values, not the values themselves
                    if (frekvenser[værdier[j]] > frekvenser[værdier[størst]])
                    {
                        størst = j;
                    }
                }

                // swap the byte values (not the counts)
                byte temp = værdier[i];
                værdier[i] = værdier[størst];
                værdier[størst] = temp;
            }

            return værdier;
        }
    }
}
