using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestione_dati
{
    internal class Program
    {
        struct Clientela
        {
            public int index;
            public string id, cognome, nome, azienda;
        }
        const string PERCORSO = "clienti.csv";


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

        static void Modifica(Clientela[] z, Clientela p, int dim, int indice)
        {
            if (indice >= 0)
            {
                z[indice] = p;
            }
        }

        static int Cancella(Clientela[] y, ref int dim, int indice)
        {
            for (int i = indice; i < dim; i++)
            {
                y[i] = y[i + 1];
            }
            dim--;
            return dim;
        }

        static int Somma(Clientela[] p, int dim, int n)
        {
            int somma =0;
            for (int i = 0; i < dim; i++)
            {
                if (p[i].index > n)
                {
                    somma = somma+ p[i].index;
                }
            }
            return somma;
        }

        //*************************************FUNZIONI CSV****************************************


        // LETTURA: carica nell'array i primi 5 campi di ogni riga e restituisce il numero di record letti
        static int CaricaDaCsv(Clientela[] z, string percorso, int max)
        {
            int dim = 0;
            using (StreamReader sr = new StreamReader(percorso))
            {
                string riga = sr.ReadLine();                 // prima riga = intestazione, la salto

                // mi fermo quando ho caricato "max" record, o se l'array è pieno, o a fine file
                while (dim < max && dim < z.Length && (riga = sr.ReadLine()) != null)
                {
                    string[] c = riga.Split(',');   // separo i campi con la virgola
                    int idx;
                    if (c.Length < 5 || !int.TryParse(c[0], out idx))
                    {
                        continue;                            // riga vuota o malformata
                    }

                    Clientela r;
                    r.index = idx;
                    r.id = c[1];
                    r.nome = c[2];                           // colonna "First Name"
                    r.cognome = c[3];                        // colonna "Last Name"
                    r.azienda = c[4];
                    z[dim] = r;
                    dim++;
                }
            }
            return dim;
        }





        // SCRITTURA: accoda UN record in fondo al file esistente (append = true)
        static void AccodaSuCsv(Clientela c, string percorso)
        {
            using (StreamWriter sw = new StreamWriter(percorso, true))
            {
                // Il file originale ha 12 colonne: dopo i 5 campi aggiungo 7 virgole
                // (7 campi vuoti) cosi' la riga resta coerente con le altre.
                sw.WriteLine(c.index + "," + c.id + "," + c.nome + "," + c.cognome + "," + c.azienda + ",,,,,,,");
            }
        }



        static void Main(string[] args)
        {
            Clientela c;
            Clientela[] x;
            x = new Clientela[100];
            string s;
            int scelta, d = 0, z, b, n = 0,y;
            do
            {
                Console.WriteLine("Digita 0 uscire dal menù");
                Console.WriteLine("Digita 1 per aggiungere");
                Console.WriteLine("Digita 2 per visualizare");
                Console.WriteLine("Digita 3 per ricercare un elemento");
                Console.WriteLine("Digita 4 per modificare");
                Console.WriteLine("Digita 5 per cancellare");
                Console.WriteLine("Digita 6 per la somma");
                Console.WriteLine("Digita 7 per caricare i dati csv su array struct");
                Console.WriteLine("Digita 8 per scrivere su file csv");
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
                        b = Ricerca(x, d, z);
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

                    case 6:
                        Console.WriteLine("Inserisci il numero che deve essere superato dai campi numerici per fare la somma");
                        y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Somma(x, d, y));
                        break;

                    case 7:
                        if (File.Exists(PERCORSO))
                        {
                            Console.WriteLine("Quanti record vuoi caricare dal file?");
                            z = Convert.ToInt32(Console.ReadLine());
                            d = CaricaDaCsv(x, PERCORSO, z);
                            Console.WriteLine("Letti " + d + " record dal file " + PERCORSO);
                            Console.WriteLine(Visualizza(x, d));
                        }
                        else
                        {
                            Console.WriteLine("File non trovato.");
                        }
                        break;


                    case 8:
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
                        AccodaSuCsv(c, PERCORSO);
                        Console.WriteLine("Record accodato al file " + PERCORSO + " (usa 7 per rileggere il file)");
                        break;
                }
            } while (scelta != 0);
        }
    }
}
