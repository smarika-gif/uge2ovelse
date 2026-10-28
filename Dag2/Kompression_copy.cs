using System;
using System.Collections.Generic;
using System.Text;

namespace Dag1
{
    internal class Kompression_copy
    {
        public static byte[] KopiKomprimer(byte[] råData)
        {
            byte[] kopi1 = new byte[råData.Length];

            for (int i = 0; i < råData.Length; i++)
            {
                kopi1[i] = råData[i];
            }

            return kopi1;
        }

        public static byte[] KopiDekomprimer(byte[] komprimeretData)
        {
            byte[] kopi2 = new byte[komprimeretData.Length];
            
            for (int i = 0; i <komprimeretData.Length;i++)
            {
                kopi2[i] = komprimeretData[i];
            }
            return kopi2;
        }

        public static bool ErEns(byte[] a, byte[] d)
        {
            if (a.Length != d.Length)
            {
                return false;                    // different sizes, so not the same
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != d[i])
                {
                    return false;       // found a difference

                }
               
            }

            return true;               // no difference found
        }

        public static int[] TælFrekvenser(byte[] data)
        {
            int[] antal = new int[256];

            foreach  (byte b in data)
            {
                antal[b]++;
            }
            return antal;
        }

        //Dag 2

        //opgave 1
        //method: counts bytes with a Dictionary
        public static Dictionary<byte, int> TælFrekvenserDictionary(byte[] data)
        {
            //start with an empty Dictionary (key = byte value, value = count)
            Dictionary<byte, int> antal = new Dictionary<byte, int>();

            foreach (byte b in data)
            {
                if (antal.ContainsKey(b))
                {
                    antal[b]++;             // seen before: add 1 to the count
                }
                else
                {
                    antal[b] = 1;           // first time: add it with count 1
                }


            }
            return antal;
        }
    }
}
