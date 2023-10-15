using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labb2
{
    public class Extract
    {
        public static PalletInfo ExtractPallet()
        {
            Console.Clear();
            

            bool correctID = false;
            while (!correctID)
            {
                Console.WriteLine("Ange det pallID du vill plocka ut eller skriv Meny för att återgå till huvudmenyn");
                string sökPallId = Console.ReadLine();
                if (sökPallId.Equals("Meny"))
                {
                    correctID = true;

                }
                if (Regex.IsMatch(sökPallId, "^[A-Z]{2}[0-9]{3}$"))
                {
                    for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0); row++)
                    {
                        for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                        {
                            if (WareHouse.WareHouseIndex[row, column] != null && WareHouse.WareHouseIndex[row, column].PalletID.Equals(sökPallId))
                            {
                               
                                var pallToExtract = WareHouse.WareHouseIndex[row, column];

                                Console.WriteLine($"Vi plockar ut pallen med PallID :{sökPallId} som är en {pallToExtract.PalletSize} ");
                                WareHouse.WareHouseIndex[row, column] = null;
                                if (pallToExtract.PalletSize == "HelPall")
                                {
                                    WareHouse.WareHouseIndex[row + 1, column] = null;
                                }
                                Console.Write("trycke enter för att fortsätta");
                                Console.ReadLine();
                                
                                return pallToExtract;
                                
                                

                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Kunde inte hitta en pall med pallid {sökPallId}, kontrollera ditt pallid och försök igen");
                    continue;
                }
                
            }
            return null;

        }



    }
}
