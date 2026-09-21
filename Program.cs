using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding2
{
    internal class Program
    {
        struct Clientela
        {
            public int index;
            public string id, cognome, nome, azienda;
        }

        static void Aggiunta(Clientela[] z, Clientela y, ref int dim)
        {
            z[dim] = y;
            dim++;
        }
        static void Main(string[] args)
        {
            Clientela c;
            Clientela[] x;
            string s;
            int scelta, dim;
            Console.WriteLine("Digita 0 uscire dal menù");
            Console.WriteLine("Digita 1 per aggiungere");
            Console.WriteLine("Digita 2 per visualizare");
            Console.WriteLine("Digita 3 per ricercare un elemento");
            Console.WriteLine("Digita 4 per modificare");
            Console.WriteLine("Digita 5 per cancellare");
            Console.WriteLine("Scegli ciò che vuoi fare");
            scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {   case 1:
                    Console.WriteLine("Inserisci l'indice");

                    Console.WriteLine("Inserisci ID");
                    Console.WriteLine("Inserisci cognome");
                    Console.WriteLine("Inserisci nome");
                    Console.WriteLine("Inserisci nome dell'azienda");
            }
        }
    }
