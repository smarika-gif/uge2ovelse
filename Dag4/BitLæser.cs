using System;
using System.Collections.Generic;
using System.Text;

namespace Dag4
{


    internal class BitLæser
    {
        // Opgave 3
        private byte[] data;
        private int byteIndex;
        private int bitIndex;

        public BitLæser(byte[] data, int startIndex)    // constructor: gets the bytes and the index where the bits start
        {
            this.data = data;
            byteIndex = startIndex;
            bitIndex = 0;
        }

        public int LæsBit()
        {
            // shift the wanted bit down to the bottom, and keep only that bit
            int bit = (data[byteIndex] >> (7 - bitIndex)) & 1;

            bitIndex++;

            if(bitIndex == 8)
            {
                byteIndex++;
                bitIndex = 0;          // start at the leftmost bit again
            }

            return bit;
        }
    }
}
