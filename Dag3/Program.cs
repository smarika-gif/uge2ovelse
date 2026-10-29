using Dag3;
using System.Text;


//OPGAVE 2
Node a = new Node(97, 5);     
Node b = new Node(98, 2);     
Node indre = new Node(b, a, 256);   

Console.WriteLine(a.ErBlad);       
Console.WriteLine(indre.ErBlad);   
Console.WriteLine(indre.Frekvens); 
Console.WriteLine(indre.Id);       

Console.WriteLine();


byte[] data = Encoding.UTF8.GetBytes("abracadabra");
int[] frekvenser = Kompression.TælFrekvenser(data);

Node? rod = Huffman.BygTræMedListe(frekvenser);

Console.WriteLine(rod.Frekvens);   
Console.WriteLine(rod.Id);         
Console.WriteLine(rod.ErBlad);     

Console.WriteLine();


//opgave 5

Huffman.UdskrivTre(rod);

Console.WriteLine();

// opgave 6

string[] koder = Huffman.LavKoder(rod);

for (int f = 0; f < 256; f++)
{
    if (koder[f] != null)
    {
        Console.WriteLine($"{(char)f}: {koder[f]}");
    }
}
Console.WriteLine();

// Opgave 7

string bits = Huffman.KomprimerTilTekst(data, koder);
Console.WriteLine(bits);
Console.WriteLine(bits.Length);

Console.WriteLine();

// Opgave 8
byte[] tilbage = Huffman.DekomprimerFraTekst(bits, rod);

Console.WriteLine(Encoding.UTF8.GetString(tilbage));     //abracadabra