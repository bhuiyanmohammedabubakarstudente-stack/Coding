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


       //*************************************FUNZIONI*********************************************************
        static void Aggiunta(Clientela[] z, Clientela y, ref int dim)
        {
            z[dim] = y;
            dim++;
        }

        static string Visualizza(Clientela[]a,int dim)
        {
            string s = "";
            for (int i = 0; i < dim; i++) {
              s += a[i].index + "\t";
                s += a[i].id + "\t";
                s += a[i].cognome + "\t";
                s += a[i].nome + "\t";
                s += a[i].azienda + "\t"+"\n";

            }
            return s;
            
        }

        static int Ricerca(Clientela[]x,int dim,int y)
        {
            for(int i = 0; i < dim; i++)
            {
                if (x[i].index == y)
                {
                    return i;
                   
                }
                
            }
            return -1;
        }

        static void Main(string[] args)
        {
            Clientela c;
            Clientela[]x;
            x= new Clientela[10];
            string s;
            int scelta, d=0,z,b;
            do
            {
                Console.WriteLine("Digita 0 uscire dal menù");
                Console.WriteLine("Digita 1 per aggiungere");
                Console.WriteLine("Digita 2 per visualizare");
                Console.WriteLine("Digita 3 per ricercare un elemento");
                Console.WriteLine("Digita 4 per modificare");
                Console.WriteLine("Digita 5 per cancellare");
                Console.WriteLine("Scegli ciò che vuoi fare");
                scelta = Convert.ToInt32(Console.ReadLine());

                switch (scelta)

                {
                    case 1:
                        Console.WriteLine("Inserisci l'indice");
                        c.index = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Inserisci ID");
                        c.id = Console.ReadLine();
                        Console.WriteLine("Inserisci cognome");
                        c.cognome = Console.ReadLine();
                        Console.WriteLine("Inserisci nome");
                        c.nome = Console.ReadLine();
                        Console.WriteLine("Inserisci nome dell'azienda");
                        c.azienda = Console.ReadLine();
                        Aggiunta(x, c, ref d);
                        break;

                    case 2:
                        Console.WriteLine(Visualizza(x, d));
                        break;

                    case 3:
                        Console.WriteLine("Inserisci l'indice del record di cui vuoi sapere la posizione");
                        z=Convert.ToInt32(Console.Read());
                       b= Ricerca(x,d,z);
                        if (z != -1)
                        {
                            Console.WriteLine("L'indice della record si trova nella");Console.WriteLine(b);Console.WriteLine("posizione");

                        }
                        else
                        {
                            Console.WriteLine("Record non presente");
                        }
                        break;

                    case 4:

                        break;

                    case 5:

                        break;
                }
            } while (scelta != 0);
        }
    }
}
