using Dag1;
using Dag2;
using System.Text;
using System.Diagnostics;


//opgave 1
UdskrivDictionary(Encoding.UTF8.GetBytes("Rødgrød med fløde"));

void UdskrivDictionary(byte[] data)
{
    Dictionary<byte, int> tabel = Kompression_copy.TælFrekvenserDictionary(data);

    //foreach over a Dictionary gives one key-value pair at a time
    foreach (KeyValuePair<byte, int> par in tabel)
    {
        Console.WriteLine($"{par.Key}: {par.Value}");
        // par.Key is the byte value, and par.Value is the count.(Both are properties, so no parentheses)

    }
}

Console.WriteLine();

//opgave 2
string[] ord = { "a", "b", "a", "c", "a", "d" };

List<string> unikkeOrd = new List<string>();
List<int> antal = new List<int>();

Ordtaelling.TælMedLister(ord, unikkeOrd, antal);
for (int i = 0; i < unikkeOrd.Count; i++)
{
    Console.WriteLine($"{unikkeOrd[i]}: {antal[i]}");
}

Console.WriteLine();
// opgave 3 
Dictionary<string, int> resultat = Ordtaelling.TælMedDictionary(ord);

foreach (KeyValuePair<string, int> par in resultat)
{
    Console.WriteLine($"{par.Key}: {par.Value}");
}

Console.WriteLine();


//OPGAVE 4


int[] storrelser = { 2000, 4000, 8000, 16000, 32000};

Console.WriteLine("Ord\t liste (ms) \t Dictionary (ms)");

foreach (int n in storrelser)
{
    MaalTid(n);
}

// method: measures both methods for n words
void MaalTid(int n)
{
    //make n random words (the same words are used for both methods)
    Random tilfaeldig = new Random();
    string[] ord = new string[n];
    for (int i = 0;i < n;i++)
    {
        ord[i] = "ord" + tilfaeldig.Next(n / 2);
    }

    // measure the list version
    List<string> unikkeOrd = new List<string>();
    List<int> antal = new List<int>();

    Stopwatch ur = Stopwatch.StartNew();
    Ordtaelling.TælMedLister(ord, unikkeOrd, antal);
    long listeTid = ur.ElapsedMilliseconds;

    //measure the dictionary version
    ur.Restart();
    Ordtaelling.TælMedDictionary(ord);
    long dictTid = ur.ElapsedMilliseconds;

    Console.WriteLine($"{n}\t {listeTid} \t\t {dictTid}");

}

Console.WriteLine();

// opgave 6

int[] test = { 5, 3, 8, 1 };

Sortering.SelectionSort(test);     // sorts the array
Console.WriteLine(string.Join(",", test));  // should write 1,3,5,8

//mål tiden

int[] storrelse = { 5000, 10000, 20000, 40000 };

Console.WriteLine("OPGAVE 6");
Console.WriteLine();
Console.WriteLine("Tal \t Selection (ms) \t Array.Sort (ms)");

foreach (int n in storrelse)
{
    MaalSortering(n);
}

void MaalSortering(int n)
{
    // make n random numbers
    Random tilfældig = new Random();
    int[] original = new int[n];
    for (int i = 0; i < n; i++)
    {
        original[i] = tilfældig.Next();
    }

    // clone makes a copy,so both methods sort the Same numbers
    int[] kopi1 = (int[])original.Clone();
    int[] kopi2 = (int[])original.Clone();

    Stopwatch ur = Stopwatch.StartNew();
    Sortering.SelectionSort(kopi1);
    long selectionTid = ur.ElapsedMilliseconds;

    ur.Restart();
    Array.Sort(kopi2);
    long arrayTid = ur.ElapsedMilliseconds;

    Console.WriteLine($"{n}\t {selectionTid}\t\t {arrayTid}");

}
Console.WriteLine();
//opgave 7

UdskrivTop10(Encoding.UTF8.GetBytes("Rødgrød med fløde"));

void UdskrivTop10(byte[] data)
{
    int[] frekvenser = Kompression_copy.TælFrekvenser(data);
    byte[] sorteret = Sortering.SorterEfterFrevens(frekvenser);

    // print 10, or fewer if the text has fewer different bytes
    int antal = Math.Min(10, sorteret.Length);

    for( int i = 0;i < antal; i++ )
    {
        byte b = sorteret[i];

        if (b >= 32 && b<= 126)
        {
            Console.WriteLine($"{b} '{(char)b}': {frekvenser[b]}");
        }
        else
        {
            Console.WriteLine($"{b}: {frekvenser[b]}");
        }
    }
}