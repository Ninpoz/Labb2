using Spectre.Console;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Labb2
{  //Anton Bergman
    public class Program
    {
        static void Main(string[] args)
        {
            
            AddPalletsToArray.addPalletsToArray();
            PalletInfo palletInfo = new PalletInfo();
            bool closeProgram = false;
            while (!closeProgram)
            {
                
                PrintOutArray.PrintArray();
                Console.WriteLine("Välkommen till Lunds Långlager (LLL) ");
                Console.WriteLine("1. Inläming av pall");
                Console.WriteLine("2. Hämta ut din pall");
                Console.WriteLine("3. Flytta pall");
                Console.WriteLine("4. Kolla lager status");
                Console.WriteLine("5. Sortera Lagret");
                Console.WriteLine("6. Stäng av programmet");
                Console.Write("Ditt val :");

                string menuChoice = Console.ReadLine();

                if (Regex.IsMatch(menuChoice, "^[1-6]{1}$"))
                {
                    switch (menuChoice)
                    {
                        case "1":
                            WareHouse.AddIntoWareHouse(palletInfo);
                            break;
                        case "2":
                            WareHouse.GetFromWareHouse();
                            break;

                        case "3":
                            WareHouse.MovePallet(palletInfo);
                            break;

                        case "4":
                            PrintOutArray.PrintArray();

                            break;
                        case "5": SortAllThePallets.ExtractAllPallets();
                            //    List<PalletInfo> extractedPallets = new List<PalletInfo>();
                            //SortAllThePallets.deleteListWhenDone(extractedPallets);
                            break;
                        case "6": closeProgram = true; break;
                    }

                }
                else
                {
                    Console.WriteLine("Felakting inmatning, Tryck enter och försök igen ");
                    Console.ReadKey();
                }
            }

        }
    }
}