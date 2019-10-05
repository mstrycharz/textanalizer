using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            int choice;
            do
            {
                Console.Clear(); //Clear console each time menu is loaded
                Console.WriteLine("1. Pobierz plik z internetu");
                Console.WriteLine("2. Zlicz liczbę liter w pobranym pliku");
                Console.WriteLine("3. Zlicz liczbę wyrazów w pliku");
                Console.WriteLine("4. Zlicz liczbę znaków interpunkcyjnych w pliku");
                Console.WriteLine("5. Zlicz liczbę zdań w pliku");
                Console.WriteLine("6. Wygeneruj raport o użyciu liter (A-Z)");
                Console.WriteLine("7. Zapisz statystyki z punktów 2-5 do pliku statystyki.txt");
                Console.WriteLine("8. Wyjście z programu");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Filedown();
                        break;
                    case 2:
                        CountLetters();
                        break;
                    case 3:
                        CountWord();
                        break;
                    case 4:
                        //TBD
                        break;
                    case 5:
                        //TBD
                        break;
                    case 6:
                        //TBD
                        break;
                    case 7:
                        //TBD
                        break;
                    case 8:
                        Console.WriteLine("Zamykanie programu. Naciśnij dowolny klawisz, aby kontynuować");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Zły wybór");
                        break;
                }
            } while (choice != 8);
        }
        public static void Filedown()
        {
            WebClient Client = new WebClient();
            Client.DownloadFile("https://s3.zylowski.net/public/input/1.txt", "C:1.txt");
            Console.WriteLine("File downloaded succesfully");
            Console.ReadKey();
        }
       
        public static void CountLetters()
        {
            if (File.Exists("1.txt"))
            {
                string text = File.ReadAllText("1.txt");
                Console.WriteLine("Liczba liter w pliku: " + text.Count(char.IsLetter));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Brak pliku");
                Console.ReadKey();
            }
            
        }
        public static void CountWord()
        {
            if (File.Exists("1.txt"))
            {
                            
               StreamReader sr = new StreamReader("1.txt");

                int counter = 0;
                string delim = " ;,."; //maybe some more delimiters like ?! and so on
                string[] fields = null;
                string line = null;

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();//each time you read a line you should split it into the words
                    line.Trim();
                    fields = line.Split(delim.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    counter += fields.Length; //and just add how many of them there is
                }


                sr.Close();
                Console.WriteLine("The word count is {0}", counter);
            
            Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Brak pliku");
                Console.ReadKey();
            }
        }
    }
}
