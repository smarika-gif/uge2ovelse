using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Dag4
{
    internal class BitSkriver
    {
        // Opgave 2
       List<byte> Byte = new List<byte>();

       private  int aktuelByte = 0;
       private  int aktuelBits = 0;
       private int antalBits = 0;

        public int PaddedBits   // Property
        {
            get {  return aktuelBits; }
        }
        public void SkrivBit(int bit)
        {
            bit = bit & 0b1;                  //keep only the lowest bit
            aktuelByte = aktuelByte << 1;     // shifts one place to the left
            aktuelByte = aktuelByte | bit;    // put the new bit at the bottom
            antalBits += 1;
            if (antalBits == 8)                // the byte is full (1 byte = 8 bits)
            {
                Byte.Add((byte)aktuelByte);     
                aktuelByte = 0;
                antalBits = 0;
            }
        }

        public void SkrivKode(string kode)
        {
            foreach (char c in kode)
            {
                if (c == '1')
                {
                    SkrivBit(1);
                }
                else if (c == '0')
                {
                    SkrivBit(0);
                }  
                // any other character is ignored
       
            }
        }

        public byte[] TilArray()
        {
            if (antalBits > 0)
            {
                aktuelBits = 8 - antalBits;
                while(antalBits != 0)
                {
                    SkrivBit(0);
                }
            }
            return Byte.ToArray<byte>();
        }
         
    }

   
}

        

        
    


