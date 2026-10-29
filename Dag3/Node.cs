using System;
using System.Collections.Generic;
using System.Text;

namespace Dag3
{
    public class Node
    {
       //opgave 2
            
            public byte Værdi;        // the byte value 
            public int Frekvens;      
            public int Id;            
            public Node? Venstre;     
            public Node? Højre;       

            // Property: true when the node has no children.
            // It has only "get", so it is calculated each time asked for it
            public bool ErBlad
            {
                get { return Venstre == null && Højre == null; }
            }

            // Constructor 1: for a leaf (a byte and its frequency)
            public Node(byte værdi, int frekvens)
            {
                Værdi = værdi;
                Frekvens = frekvens;
                Id = værdi;           // a leaf's Id is its byte value
            }

            // Constructor 2: for an inner node (two children and an Id)
            public Node(Node venstre, Node højre, int id)
            {
                Venstre = venstre;
                Højre = højre;
                Frekvens = venstre.Frekvens + højre.Frekvens;   // the sum of the children
                Id = id;
            }
        }
    }

