using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Text;

namespace Dag4
{
    internal class Huffman
    {
        // method: builds the Huffman tree and returns the root
        public static Node? BygTræMedListe(int[] frekvenser)
        {
            List<Node> liste = new List<Node>();

            // Step 1: make a leaf(blad) for every byte that appears
            for (int b = 0; b < 256; b++)
            {
                if (frekvenser[b] > 0)
                {
                    liste.Add(new Node((byte)b, frekvenser[b]));
                }
            }

            // Step 2: no data means no tree
            if (liste.Count == 0)
            {
                return null;
            }

            int næsteId = 256;   // the Id of the next inner node

            // Step 3: repeat until only one node is left
            while (liste.Count > 1)
            {
                // Sort by frequency first, then by Id if the frequencies are equal
                liste.Sort((a, b) =>
                {
                    int resultat = a.Frekvens.CompareTo(b.Frekvens);
                    if (resultat != 0)
                    {
                        return resultat;
                    }
                    return a.Id.CompareTo(b.Id);
                });

                // Take the two smallest nodes
                Node venstre = liste[0];
                Node højre = liste[1];

                // RemoveAt(0) removes the first item. After the first call, the second smallest is at place 0, so we call it twice
                liste.RemoveAt(0);
                liste.RemoveAt(0);

                // Make the inner node and put it back in the list
                Node indre = new Node(venstre, højre, næsteId);
                næsteId++;
                liste.Add(indre);
            }

            // Step 4: the last node is the root
            return liste[0];
        }

        // opgave 5
        // recursive method: prints the tree with indentation
        // ind = the spaces in front of the line (grows 4 for each level)
        public static void UdskrivTre(Node? node, string ind = "", string side = "")
        {
            // Stop case 1: no node here, so nothing to print
            if (node == null)
            { return; }

            if (node.ErBlad)
            {
                // Stop case 2: a leaf. Print the character and its frequency
                Console.WriteLine($"{ind}{side} {(char)node.Værdi} ({node.Frekvens})");
            }
            else
            {
                
                Console.WriteLine($"{ind}{side} * ({node.Frekvens})");

                
                UdskrivTre(node.Venstre, ind + "    ", "0: ");
                UdskrivTre(node.Højre, ind + "    ", "1: ");
            }
        }

        //opgave 6

        // method: makes the codes for the whole tree (Returns a string[256]: place b holds the code of byte value b)

        public static string[] LavKoder(Node? rod)
        {
            string[] koder = new string[256];    //all places start as null
            if (rod == null)
            {
                return koder;                   // no data, so no codes
            }

            if (rod.ErBlad)   //special case: a tree with only ONE leaf (The path would be empty, so we give it the code "0")
            {
                koder[rod.Værdi] = "0";
                return koder;
            }

            GemKoder(rod, "", koder);
            return koder;
        }

        // method: walks through the tree and saves the codes
        public static void GemKoder(Node? node, string sti, string[] koder)
        {
            if (node == null)     // Stop case: no node here
            { return; }

            if (node.ErBlad)
            {
                // case 1: a leaf. Save the path as this byte's code
                koder[node.Værdi] = sti;      //sti: the path walked so far
            }
            else
            {
                // case 2: an inner node. Go left with "0" and right with "1"
                GemKoder(node.Venstre, sti + "0", koder);
                GemKoder(node.Højre, sti + "1", koder);
            }
        }

        // Opgave 7

        // method: replaces every byte with its code (Returns one long string of '0' and '1')
        public static string KomprimerTilTekst(byte[] data, string[] koder)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in data)
            {
                sb.Append(koder[b]);      // add this byte's code to the end
            }

            return sb.ToString();         // turn the StringBuilder into a string


        }

        // opgave 8

        public static byte[] DekomprimerFraTekst(string bits, Node? rod)
        {
            List<byte> resultat = new List<byte>();

            if (rod == null)   // no tree means no data
            {
                return resultat.ToArray();
            }

            if (rod.ErBlad)  // when the tree is only one leaf (for example "aaaaa")
            {
                for (int i = 0; i < bits.Length; i++)
                {
                    resultat.Add(rod.Værdi);
                }
                return resultat.ToArray();
            }
            Node node = rod;   // start at the root

            foreach (char c in bits)
            {
                if (c == '0')
                {
                    node = node.Venstre!;     //! tells C#: "I know this is not null"
                }
                else
                {
                    node = node.Højre!;
                }

                if (node.ErBlad)
                {
                    resultat.Add(node.Værdi);      // write the byte
                    node = rod;                    // start again at the root
                }

            }
            return resultat.ToArray();
        }

    }
}

