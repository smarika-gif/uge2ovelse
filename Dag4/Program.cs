
using Dag4;
using System.Text;


// Modulus %

for (int i = 0; i < 25; i++)
{
    if (i % 5 == 0)
    {
        Console.Write(" ");
    }
    Console.WriteLine($"{i} % 5 {i%5}");
 }

Console.WriteLine();

//BitSkriver - opgave 2
var bs = new Dag4.BitSkriver();

bs.SkrivBit(0);
bs.SkrivBit(0);
bs.SkrivBit(0);
bs.SkrivBit(0);

bs.SkrivBit(1);
bs.SkrivBit(0);
bs.SkrivBit(1);
bs.SkrivBit(1);

bs.SkrivBit(0);
bs.SkrivBit(0);
bs.SkrivBit(0);
bs.SkrivBit(0);

bs.SkrivBit(1);
bs.SkrivBit(0);
bs.SkrivBit(1);
bs.SkrivBit(1);

bs.SkrivKode("0000 0010");
bs.SkrivBit(1);
bs.SkrivBit(0);

var Byte = bs.TilArray();

foreach(var b in Byte)
{
    Console.WriteLine($"{b}");

}
Console.WriteLine();

Console.WriteLine(bs.PaddedBits);

Console.WriteLine();

// Opgave 3
var skriver = new Dag4.BitSkriver();
skriver .SkrivKode("101");
byte[] bytes2 = skriver.TilArray();

Console.WriteLine(Convert.ToString(bytes2[0], 2).PadLeft(8, '0'));
Console.WriteLine();


// Opgave 4

var skriver2 = new Dag4.BitSkriver();
skriver2.SkrivKode("101");
byte[] bytes = skriver2.TilArray();

var laeser = new Dag4.BitLæser(bytes, 0);      //start at index 0

for (int i = 0; i < 8; i++)
{
    Console.Write(laeser.LæsBit());
}


// Opgave 5
Console.WriteLine();
byte[] data = Encoding.UTF8.GetBytes("abracadabra");
int[] frekvenser = Kompression.TælFrekvenser(data);

byte[] header = Header.LavHeader(data.Length, frekvenser);

Console.WriteLine(header.Length);
Console.WriteLine(Header.LæsLængde(header));
Console.WriteLine();

int[] tilbage = Header.LæsFrekvenser(header);
Console.WriteLine(tilbage[97]);
Console.WriteLine(tilbage[99]);

