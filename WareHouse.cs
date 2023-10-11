using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labb2
{
    
    //Här vill jag skapa min array
    public class WareHouse
    {
        
        public static PalletInfo[,] WareHouseIndex = new PalletInfo[2,20];

        public static void AddIntoWareHouse(PalletInfo palletInfo)
        {
            //PalletInfo palletInfo1 = new PalletInfo();
            bool BreakMenuLoop = false;
           
            while (!BreakMenuLoop) 
            {
                
                Console.Clear();
                Console.WriteLine(" Du vill lägga till en pall ange om det är en helpall eller halvpall");
                Console.WriteLine("1. HalvPall");
                Console.WriteLine("2. HelPall");
                Console.WriteLine("3. Återgå till huvudmeny");
                Console.Write("Ditt val :");
                string palletSizeChoice = Console.ReadLine();

                if (Regex.IsMatch(palletSizeChoice, "^[1-3]{1}$"))
                {
                    switch (palletSizeChoice)
                    {
                        case "1":palletInfo.PalletSize = "HalvPall";
                            BreakMenuLoop = true;
                            break ;
                        case "2": palletInfo.PalletSize = "HelPall";
                            BreakMenuLoop = true;
                            break;
                        case "3": BreakMenuLoop = true; break; 
                    }

                }
                else
                {
                    Console.WriteLine("Felakting inmatning, Tryck enter och försök igen ");
                    Console.ReadKey();
                }
            }

            if (palletInfo.PalletSize.Equals("HalvPall"))
            {
                for (int row = 0; row < WareHouseIndex.GetLength(0); row++)
                {
                    for (int column = 0; column < WareHouseIndex.GetLength(1); column++)
                    {
                       if (WareHouseIndex[row,column] == null)
                        {
                            WareHouseIndex[row, column] = palletInfo;
                            PalletInfo.Arrival = DateTime.Now;
                            
                            Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} som är en {palletInfo.PalletSize} i lager plats {row}:{column} ");
                            Console.ReadLine();
                            return;

                        }
                        else
                        {
                            if (WareHouseIndex[row+1,column ] ==null)
                            {
                                WareHouseIndex[row+1 ,column] = palletInfo;
                                PalletInfo.Arrival = DateTime.Now;
                                Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} som är en {palletInfo.PalletSize} i lager plats {row+1}:{column} ");
                                Console.ReadLine();
                                return;
                            }
                        }
                    }
                }
            }  
           else
            {
                if (palletInfo.PalletSize.Equals("HelPall"))
                {
                    for (int row = 0; row < WareHouseIndex.GetLength(0); row++)
                    {
                        for (int column = 0; column < WareHouseIndex.GetLength(1); column++)
                        {
                            if (WareHouseIndex[row, column] == null)
                            {
                                WareHouseIndex[row, column] = palletInfo;
                                WareHouseIndex[row +1, column] = palletInfo;
                                PalletInfo.Arrival = DateTime.Now;

                                Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} som är en {palletInfo.PalletSize} i lager plats {row}:{column} / {row+1}:{column} ");
                                Console.ReadLine();
                                return;

                            }
                            else
                            {
                                if (WareHouseIndex[row+1, column] == null)
                                {
                                    WareHouseIndex[row, column+1] = palletInfo;
                                    WareHouseIndex[row+1,column+1] = palletInfo;
                                    PalletInfo.Arrival = DateTime.Now;

                                    Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} som är en {palletInfo.PalletSize} i lager plats {row}:{column+1}/ {row+1}:{column+1} ");
                                    Console.ReadLine();
                                    return;

                                }
                            }

                        }
                    }
                }
                    
            }


        }
        public static PalletInfo? GetFromWareHouse()
        {

            Console.WriteLine("Ange det pallID du vill plocka ut");
            string sökPallId = Console.ReadLine();

            if (Regex.IsMatch(sökPallId, "^[A-Z]{2}[0-9]{3}$"))
            {
                for (int row = 0; row < WareHouseIndex.GetLength(0); row++)
                {
                    for (int column = 0; column < WareHouseIndex.GetLength(1); column++)
                    {
                        if (WareHouseIndex[row, column].PalletID.Equals(sökPallId))
                        {
                            var pall = WareHouseIndex[row, column];
                            TimeSpan timeInWarehouse = DateTime.Now - PalletInfo.Arrival;
                            Console.WriteLine($"Vi plockar ut pallen med PallID :{sökPallId} och den var i lagret i {timeInWarehouse}");
                            WareHouseIndex[row, column] = null;
                            return pall;
                        }
                    }
                }

            }
            return null;

        }

    }
}
