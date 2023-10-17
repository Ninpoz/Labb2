using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labb2
{

    // Klassen WareHouse innehåller metoder och en array för att hantera pallar i lagret.
    public class WareHouse
    {
        // skapar en 2D-array för att lagra information om pallar.
        public static PalletInfo[,] WareHouseIndex = new PalletInfo[2, 20];

        // Metod för att lägga till pallar i lagret
        public static void AddIntoWareHouse(PalletInfo palletInfo)
        {
            // En loop som hanterar om det är en hel eller halv pall

            bool BreakMenuLoop = false;
            while (!BreakMenuLoop)
            {
                
                
                PrintOutArray.PrintArray();
                Console.WriteLine(" Du vill lägga till en pall ange om det är en helpall eller halvpall");
                Console.WriteLine("1. HalvPall");
                Console.WriteLine("2. HelPall");
                Console.WriteLine("3. Återgå till huvudmeny");
                Console.Write("Ditt val :");
                string palletSizeChoice = Console.ReadLine();

                if (Regex.IsMatch(palletSizeChoice, "^[1-3]{1}$")) // kollar med regex så inmatning blir korrek
                {
                    switch (palletSizeChoice)
                    {
                        case "1":
                            palletInfo.PalletSize = "HalvPall";
                            BreakMenuLoop = true;
                            break;
                        case "2":
                            palletInfo.PalletSize = "HelPall";
                            BreakMenuLoop = true;
                            break;
                        case "3":
                            BreakMenuLoop = true;
                            return;
                    }

                }
                else
                {
                    Console.WriteLine("Felakting inmatning, Tryck enter och försök igen ");
                    Console.ReadKey();
                }
            }
            // om det är en halvpall går vi in i detta kodblocket
            if (palletInfo.PalletSize.Equals("HalvPall"))
            {
                HalfPallet.IfHalfPallet(palletInfo);
            }
            else if (palletInfo.PalletSize.Equals("HelPall"))
            {
                WholePallet.IfWholePallet(palletInfo);
            }


        }

        public static PalletInfo GetFromWareHouse()
        {
            var palletToExtract = Extract.ExtractPallet();

            if (palletToExtract == null)
            {
                return null;
            }


            if (palletToExtract.PalletSize.Equals("HalvPall"))
            {
                PrintOutArray.PrintArray();
                Console.WriteLine("Kostnader för pallar i lagret är :halvpall kostar 39kr per påbörjad timme, helpall kostar 75kr per påbörjad timme");
                decimal priceForPallet = CalculatePalletPrice.CalculatePrice(palletToExtract);
                Console.WriteLine($"så din totala kostnad för din {palletToExtract.PalletSize} blir : {priceForPallet}");
                Console.WriteLine($" Då den kom {palletToExtract.Arrival}");
                SavePalletToPC.SavePalletInfoToFile(palletToExtract);
                Console.ReadKey();
            }

            if (palletToExtract.PalletSize.Equals("HelPall"))
            {
                PrintOutArray.PrintArray();
                Console.WriteLine("Kostnader för pallar i lagret är :halvpall kostar 39kr per påbörjad timme, helpall kostar 75kr per påbörjad timme");
                decimal priceForPallet = CalculatePalletPrice.CalculatePrice(palletToExtract);
                Console.WriteLine($"så din totala kostnad för din {palletToExtract.PalletSize} blir : {priceForPallet}");
                Console.WriteLine($" Då den kom {palletToExtract.Arrival}");
                SavePalletToPC.SavePalletInfoToFile(palletToExtract);
                Console.ReadKey();
            }



            return null;

        }
        public static void MovePallet(PalletInfo palletInfo)
        {
            PrintOutArray.PrintArray();
            var palletToMove = Extract.ExtractPallet();
            if (palletToMove == null)
            {
                return;
            }

            if (palletToMove.PalletSize == "HelPall")
            {
                MoveWholePallet.WholePalletMove(palletToMove);
            }
            if (palletToMove.PalletSize == "HalvPall")
            {
                MoveHalfPallet.HalfPalletMove(palletToMove);
            }





        }

    }
}
