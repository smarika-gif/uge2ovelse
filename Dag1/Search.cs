using System;
using System.Collections.Generic;
using System.Text;

namespace Dag1
{
    internal class Search
    {

       public static int BinSøg(int[] høstak, int nål)
        {
            int min = 0;
            int max = høstak.Length -1;
            int midt = min + (max - min) / 2;
            

            int count = 0;

            while (min <= max)
            {
                count++;

                if (høstak[midt] == nål)
                {
                    return midt;

                }

                if (høstak[midt] > nål)
                {
                    max = midt - 1;
                }

                else
                {
                    min = midt + 1;
                }

                int d = max - min;
                midt = d / 2 + min;
            }
            return -1;
        }
    }
}
