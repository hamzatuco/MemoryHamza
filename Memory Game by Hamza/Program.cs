using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;


namespace Memory_Game_by_Hamza
{
    class Program
    {




        static void Main(string[] args)
        {


            int[] arr1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            int p = 0;
            int[,] izborPloca = new int[4, 4];
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    izborPloca[y, x] = arr1[p];
                    p++;

                }

            }


            //ogranicavanje niza na 2x 8
            char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '1', '2', '3', '4', '5' };//ekran

            int j = 0;
            char[,] prikaziPlocu = new char[4, 4];
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    prikaziPlocu[y, x] = arr[j];
                    j++;

                }

            }





            //SLOVA
            char[] slova = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };//kartice

            Random random = new Random();
            slova = slova.OrderBy(x => random.Next()).ToArray();

            int i = 0;
            char[,] prikaziSlova = new char[4, 4];

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    prikaziSlova[y, x] = slova[i];
                    i++;

                }

            }


            Console.WriteLine("Dobrodosli u najinovativniju memory igru\n------------------------------");
            Console.Write("Molimo predstavite nam se: ");
            string ime = Console.ReadLine();
            string bin = Environment.CurrentDirectory;
            string folderProjekat = Directory.GetParent(bin).Parent.Parent.FullName;

            string filePath = System.IO.Path.Combine(folderProjekat, "data", "output.txt");
            int brojPokusaja = 0;
            int brojPoteza = 0;
            DateTime vrijemeIgre = DateTime.Now;




            Console.WriteLine("------------------------------");
            Console.Write("Drago nam je " + ime + ", koliko imate godina? - ");
            int godine;
            godine = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Hvala na upoznavanju, sretno u igranju! :)\n\nPritisnite bilo koju tipku da biste nastavili");
            Console.ReadKey();
            Console.Clear();

            int prviIzbor;
            int drugiIzbor;
            int red1;
            int kolona1;
            int red2;
            int kolona2;
            bool igranje = true;
            string nastavak;
            int brojPogodjenih = 0;



            while (igranje == true)

            {

                for (int red = 0; red < 4; red++)
                {
                    for (int kolona = 0; kolona < 4; kolona++)
                    {
                        Console.Write(prikaziPlocu[red, kolona] + "  ");
                    }
                    Console.WriteLine();
                }


                Console.WriteLine("----Ovo samo stoji da provjerim jel dobro usporedjuje------");
                for (int red = 0; red < 4; red++)
                {
                    for (int kolona = 0; kolona < 4; kolona++)
                    {
                        Console.Write(prikaziSlova[red, kolona] + " ");
                    }
                    Console.WriteLine();
                }



                Console.Write("Unesite prvi izbor: ");
                prviIzbor = Convert.ToInt32(Console.ReadLine());
                // int tempa = prviIzbor;
                char tempa = Convert.ToChar(prviIzbor);

                for (red1 = 0; red1 < 4; red1++)
                {
                    for (kolona1 = 0; kolona1 < 4; kolona1++)
                    {
                        if (izborPloca[red1, kolona1] == prviIzbor)
                        {
                            prikaziPlocu[red1, kolona1] = prikaziSlova[red1, kolona1];
                        }
                    }
                }



                Console.Write("Unesite drugi izbor: ");
                drugiIzbor = Convert.ToInt32(Console.ReadLine());
                //int tempb = drugiIzbor;
                char tempb = Convert.ToChar(drugiIzbor);
                for (red2 = 0; red2 < 4; red2++)
                {
                    for (kolona2 = 0; kolona2 < 4; kolona2++)
                    {
                        if (izborPloca[red2, kolona2] == drugiIzbor)
                        {
                            prikaziPlocu[red2, kolona2] = prikaziSlova[red2, kolona2];
                        }
                    }
                }




                if (prikaziSlova[prviIzbor / 4, prviIzbor % 4] == prikaziSlova[drugiIzbor / 4, drugiIzbor % 4])
                {
                    Console.WriteLine("Pogodak");
                    brojPogodjenih++;
                    Thread.Sleep(2000);
                }
                else
                {

                    Console.WriteLine("Pokusajte ponovo :(");
                    for (red1 = 0; red1 < 4; red1++)
                    {
                        for (kolona1 = 0; kolona1 < 4; kolona1++)
                        {
                            
                                prikaziPlocu[red1, kolona1] =  tempa;
                            
                        }
                    }

                    for (red2 = 0; red2 < 4; red2++)
                    {
                        for (kolona2 = 0; kolona2 < 4; kolona2++)
                        {

                            prikaziPlocu[red2, kolona2] = tempb;

                        }
                    }
                    Thread.Sleep(1000);
                }
                Console.Clear();
                for (int red = 0; red < 4; red++)
                {
                    for (int kolona = 0; kolona < 4; kolona++)
                    {
                        Console.Write(prikaziPlocu[red, kolona] + "  ");
                    }
                    Console.WriteLine();
                }

                if (brojPogodjenih == 8)
                {
                    Console.WriteLine("Cestitamo pobijedili ste igricu!");
                    igranje = false;
                    string ponovo;
                    Console.Write("Zelite li igrati ispocetka? Y/N ");
                    ponovo = Console.ReadLine();
                    if (ponovo == "Y" || ponovo == "y")
                    {
                        igranje = true;
                        Console.Clear();


                    }
                    else if (ponovo == "N" || ponovo == "n")
                    {

                        Console.Clear();
                        Console.WriteLine("Hvala na igri!");
                        Console.WriteLine("\n" + vrijemeIgre + " | Korisnik " + ime + " koji ima " + godine + " godina je odigrao " + brojPokusaja + " puta, sa " + brojPoteza + " brojem poteza");
                        break;

                    }
                }




                bool unos = false;
                if (prviIzbor == drugiIzbor)
                {
                    while (unos == false)
                    {
                        Console.WriteLine("Greska");
                        Console.Write("Zelite li nastaviti ispocetka? Y/N ");
                        nastavak = Console.ReadLine();
                        if (nastavak == "Y" || nastavak == "y")
                        {
                            brojPokusaja++;
                            Console.Clear();
                            break;

                        }
                        else if (nastavak == "N" || nastavak == "n")
                        {
                            igranje = false;
                            Console.Clear();
                            Console.WriteLine("Hvala na igri!");
                            Console.WriteLine("\n" + vrijemeIgre + " | Korisnik " + ime + " koji ima " + godine + " godina je odigrao " + brojPokusaja + " puta, sa " + brojPoteza + " brojem poteza");
                            unos = true;
                        }
                        else
                        {
                            Console.WriteLine("Unos nije validan");
                            Console.Clear();
                            unos = false;
                        }
                    }





                }
                brojPoteza++;

                if (brojPoteza == 8)
                {
                    igranje = false;
                    string ponovo;
                    Console.Write("Zelite li igrati ispocetka? Y/N ");
                    ponovo = Console.ReadLine();
                    if (ponovo == "Y" || ponovo == "y")
                    {
                        igranje = true;
                        Console.Clear();


                    }
                    else if (ponovo == "N" || ponovo == "n")
                    {

                        Console.Clear();
                        Console.WriteLine("Hvala na igri!");
                        Console.WriteLine("\n" + vrijemeIgre + " | Korisnik " + ime + " koji ima " + godine + " godina je odigrao " + brojPokusaja + " puta, sa " + brojPoteza + " brojem poteza");
                        break;

                    }

                }






            }
            File.AppendAllText(filePath, "\n" + vrijemeIgre + "| Korisnik " + ime + " koji ima " + godine + " godina je odigrao " + brojPokusaja + " puta, sa " + brojPoteza + " brojem poteza, pogodio je " + brojPogodjenih + " polja");






        }











    }
}

