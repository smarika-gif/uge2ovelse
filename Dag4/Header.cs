using System;
using System.Collections.Generic;
using System.Text;

namespace Dag4
{
    internal class Header
    {
        // Opgave 5
        // makes the header: the length first, then all 256 frequencies
        public static byte[] LavHeader(int længde, int[] frekvenser)
        {
            byte[] header = new byte[4 + 256 * 4];

            BitConverter.GetBytes(længde).CopyTo(header, 0);    //CopyTo puts the 4 bytes into the header, starting at the given place

            for (int b = 0; b < 256; b++)
            {
                BitConverter.GetBytes(frekvenser[b]).CopyTo(header, 4 + b * 4);
            }
            return header;

        }

        public static int LæsLængde(byte[] data)      // reads the original length from the header
        {
            return BitConverter.ToInt32(data, 0);
        }

        public static int[] LæsFrekvenser(byte[] data)
        {
            int[] frekvenser = new int[256];

            for (int b = 0; b < 256; b++)
            {
                frekvenser[b] = BitConverter.ToInt32(data, 4 + b * 4);
            }

            return frekvenser;
        }
    }
}
