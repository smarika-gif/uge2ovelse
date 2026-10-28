using System;
using System.Collections.Generic;
using System.Text;

namespace Dag3
{
    internal class Kompression
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
    }
}
