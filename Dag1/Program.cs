
using Dag1;
using System.Diagnostics;
using System.Text;

byte[] data = Encoding.UTF8.GetBytes("Skab");
string text = Encoding.UTF8.GetString(data);



foreach (byte b in data)
{
    Console.WriteLine($"{b}");
    Console.WriteLine();
    Console.WriteLine(string.Join(",", data));
}

void BytesOgTegn()
{
    string str = "æøå";
    byte[] bStr = Encoding.UTF8.GetBytes(str);

    Console.WriteLine();
    Console.WriteLine("String Length: " + str.Length);
    Console.WriteLine("Bytes Length: " + bStr.Length);
    Console.WriteLine("Byte-værdier: [ " + string.Join(",", bStr) + " ]");


}

BytesOgTegn();

byte[] original = Encoding.UTF8.GetBytes("Skab");
byte[] førstkopi = Kompression.KopiKomprimer(original);
byte[] secondkopi = Kompression.KopiDekomprimer(førstkopi);

Console.WriteLine();
Console.WriteLine("Kopierer data: " + string.Join(",", secondkopi));


byte[] a = { 1, 2, 3 };
byte[] d = {1, 2, 3 };


Console.WriteLine(Kompression.ErEns(a, d)); 
Console.WriteLine(a == d);              /* Even though a and b have the same content, a == b gives False,
                                           because == on arrays compares if they are the same object in memory.
                                           a and b are two seperate arrays, so the answer is False. That is why we
                                           need ErEns, which compares content, one byte at a time.*/

//byte[] c = a;   (c points at the same array as a)
//Console.WriteLine(a == c);  // so the result becomes True


KoerTests(Kompression.KopiKomprimer, Kompression.KopiDekomprimer);


List<byte[]> LavTestData()
{
    List<byte[]> liste = new List<byte[]>();

    liste.Add(new byte[0]);
    liste.Add(Encoding.UTF8.GetBytes("s"));
    liste.Add(Encoding.UTF8.GetBytes("sssssssss"));
    liste.Add(Encoding.UTF8.GetBytes("æøå"));
    liste.Add(Encoding.UTF8.GetBytes("En længere tekst."));

    byte[] alle = new byte[256];

    for (int i = 0; i < 256; i++)
    {
        alle[i] = (byte)i;
    }
    liste.Add(alle);

    byte[] tilfaeldige = new byte[500];
    Random ord = new Random();
    ord.NextBytes(tilfaeldige);
    liste.Add(tilfaeldige);

    return liste;
}

void KoerTests(Func<byte[], byte[]> komprimer, Func<byte[], byte[]> dekomprimer)
{
    List<byte[]> alleTests = LavTestData();
    int nummer = 1; 

    foreach (byte[] input in alleTests)
    {
        byte[] komp = komprimer(input);
        byte[] dekomp = dekomprimer(komp);

        bool ok = Kompression.ErEns(input, dekomp);

        string resultat;
        if(ok)
        {
            resultat = "OK";
        }
        else
        {
            resultat = "FEJL";
        }

        Console.WriteLine($"Test {nummer}: {resultat} (før: {input.Length}, efter: {komp.Length})");
        nummer++;
    }
}

UdskrivFrekvenser(Encoding.UTF8.GetBytes("Rødgrød med fløde"));

void UdskrivFrekvenser(byte[] data)
{
    int[] antal = Kompression.TælFrekvenser(data);

    for (int b = 0; b < 256; b++)
    {
        if (b >= 32 && b <= 126)
        {
            Console.WriteLine($"{b} '{(char)b}: {antal[b]}");
        }
        else
        {
            Console.WriteLine($"{b}: {antal[b]}");
        }



    }
}

void BinærSøgning()
{
    Random r = new Random();

    int[] hø = new int[100];
    for (int i = 0; i < hø.Length; i++)
    {
        hø[i] = r.Next(0, 500);
    }
    int nål = hø[0];

    hø.Sort();

    int idx = Dag1.Search.BinSøg(hø, nål);
    Console.WriteLine($"nålen({nål}) findet på index{idx}");
}

BinærSøgning();






