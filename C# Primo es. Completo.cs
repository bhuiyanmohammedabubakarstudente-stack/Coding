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

        static string Visualizza(Clientela[] a, int dim)
        {
            string s = "";
            for (int i = 0; i < dim; i++)
            {
                s += a[i].index + "\t";
                s += a[i].id + "\t";
                s += a[i].cognome + "\t";
                s += a[i].nome + "\t";
                s += a[i].azienda + "\t" + "\n";

            }
            return s;

        }

        static int Ricerca(Clientela[] x, int dim, int y)
        {
            for (int i = 0; i < dim; i++)
            {
                if (x[i].index == y)
                {
                    return i;

                }

            }
            return -1;
        }

        static void Modifica(Clientela[]z, Clientela p,int dim,int indice)
        {
            if(indice >= 0)
            {
                z[indice] = p;
            }
        }

        static int Cancella(Clientela[]y,ref int dim, int indice)
        {
            for(int i = indice; i < dim; i++)
            {
                y[i] = y[i + 1];
            }
            dim--;
            return dim;
        }

        static void Main(string[] args)
        {
            Clientela c;
            Clientela[] x;
            x = new Clientela[10];
            string s;
            int scelta, d = 0, z, b,n=0;
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
                        z = Convert.ToInt32(Console.ReadLine());
                        b = Ricerca(x, d, z);
                        if (b != -1)
                        {
                            Console.WriteLine("L'indice della record si trova nella"); Console.WriteLine(b); Console.WriteLine("posizione");

                        }
                        else
                        {
                            Console.WriteLine("Record non presente");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Inerisci indice del record da modificare");
                        z = Convert.ToInt32(Console.ReadLine());
                        b=Ricerca(x,d,z);
                        if (b >= 0)
                        {
                            Console.WriteLine("Inserisci il nuovo l'indice");
                            c.index = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Inserisci il nuovo ID");
                            c.id = Console.ReadLine();
                            Console.WriteLine("Inserisci il nuovo cognome");
                            c.cognome = Console.ReadLine();
                            Console.WriteLine("Inserisci il nuovo nome");
                            c.nome = Console.ReadLine();
                            Console.WriteLine("Inserisci il nuovo nome dell'azienda");
                            c.azienda = Console.ReadLine();
                            Modifica(x, c, d, b);

                        }
                        else
                        {
                            Console.WriteLine("Non esiste record con quest'indice");
                        }

                            break;

                    case 5:
                        Console.WriteLine("Inerisci indice del record da cancellare");
                        z = Convert.ToInt32(Console.ReadLine());
                        b = Ricerca(x, d, z);
                        if (b >= 0)
                        {
                            n = Cancella(x, ref d, b);
                        }
                        Console.WriteLine("Numero di record attuali sono"); Console.WriteLine(n);
                        break;
                }
            } while (scelta != 0);
        }
    }
}