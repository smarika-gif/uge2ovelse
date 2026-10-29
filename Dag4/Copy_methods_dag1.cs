using System;
using System.Collections.Generic;
using System.Text;

namespace Dag4
{
    internal class Copy_methods_dag1
    {
       public static List<byte[]> LavTestData()
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

       public static void KoerTests(Func<byte[], byte[]> komprimer, Func<byte[], byte[]> dekomprimer)
        {
            List<byte[]> alleTests = LavTestData();
            int nummer = 1;

            foreach (byte[] input in alleTests)
            {
                byte[] komp = komprimer(input);
                byte[] dekomp = dekomprimer(komp);

                bool ok = Kompression.ErEns(input, dekomp);

                string resultat;
                if (ok)
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


    }
}
