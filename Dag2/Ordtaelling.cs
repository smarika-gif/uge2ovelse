using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Dag2
{
    internal class Ordtaelling
    {

       

        // method: counts with two lists
        public static void TælMedLister(string[] ord, List<string> unikkeOrd, List<int> antal)
        {
            //go through every word in the input, one at a time
            foreach (string etOrd in ord)
            {
                // -1 means "not found yet"
                int plads = -1;

                for (int i = 0; i < unikkeOrd.Count; i++)      // search the word list from the start
                {
                    if (unikkeOrd[i] == etOrd)
                    {
                        plads = i;     // remember where it is found
                        break;
                    }

                }

                if (plads >= 0)
                {
                    antal[plads]++;     // found: add 1 to the count

                }
                else
                {
                    unikkeOrd.Add(etOrd);     // not found: add the new word
                    antal.Add(1);             // and its count, which starts at 1
                }
            }
        }

        // method: counts words with a Dictionary
        public static Dictionary<string, int> TælMedDictionary(string[] ord)
        {
            // start with an empty Dictionary (key = word, value = count)
            Dictionary<string, int> antal = new Dictionary<string, int>();

            // go through every word in the input, one at a time
            foreach (string etOrd in ord)
            {
                if(antal.ContainsKey(etOrd))
                {
                    antal[etOrd]++;
                }
                else
                {
                    antal[etOrd] = 1;

                } 

            }
            return antal;
            
        }
    }
}
