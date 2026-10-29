using System;
using System.Collections.Generic;
using System.Text;

namespace Dag4
{
    internal class Kompressor
    {
        // compress the data: header first, then the Huffman bits
        public static byte[] Komprimer(byte[] råData)
        {
            // to count, build the tree, make the codes
            int[] frekvencer = Kompression.TælFrekvenser(råData);
            Node? rod = Huffman.BygTræMedListe(frekvencer);
            string[] koder = Huffman.LavKoder(rod);

            // the header (the length and all 256 frequencies)
            byte[] header = Header.LavHeader(råData.Length, frekvencer);


            BitSkriver skriver = new BitSkriver();   // write the code of every byte, bit by bit

            foreach (byte b in råData)
            {
                skriver.SkrivKode(koder[b]);
            }

            byte[] bitBytes = skriver.TilArray();    // fills the last byte with 0 bits


            // same array for header and bits
            byte[] resultant = new byte[header.Length + bitBytes.Length];

            header.CopyTo(resultant, 0);                // header at the start
            bitBytes.CopyTo(resultant, header.Length);   // puts the bits after the header
            return resultant;
        }

        // decompresses the data made by Komprimer
        public static byte[] Dekomprimer(byte[] komprimeretData)
        {
            // read the header
            int længde = Header.LæsLængde(komprimeretData);
            int[] frekvenser = Header.LæsFrekvenser(komprimeretData);

            // empty input, so there is nothing to decode
            if (længde == 0)
            {
                return new byte[0];
            }

            // build the same tree as the compressor
            Node? rod = Huffman.BygTræMedListe(frekvenser);

            byte[] resultant = new byte[længde];

            if (rod!.ErBlad)   // the root is a leaf (only one different byte)
            {
                for (int i = 0; i < længde; i++)
                {
                    resultant[i] = rod.Værdi;
                }
                return resultant;
            }

            // the bits start right after the header (index 1028)
            BitLæser læser = new BitLæser(komprimeretData, 4 + 256 * 4);

            for (int i = 0; i < længde; i++)   // decode exactly "længde" bytes
            {
                Node node = rod;

                while (!node.ErBlad)      // !node.ErBlad means: node is not a leaf (! in front of a bool turns true into false)
                {
                    if (læser.LæsBit() == 0)
                    {
                        node = node.Venstre!;      // node.Venstre! means its not null

                    }
                    else
                    {
                        node = node.Højre!;
                    }
                   
                }
                resultant[i] = node.Værdi;     // the leaf's byte
            }
            return resultant;

        }

    }
}
