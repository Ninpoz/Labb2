using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labb2
{
    public class MoveWholePallet
    {
        //en metod för att kolla om det finns plats
        public static bool IsThereSpace(int rowIndex, int columIndex)
        {
            return WareHouse.WareHouseIndex[rowIndex, columIndex] == null && WareHouse.WareHouseIndex[rowIndex + 1, columIndex] == null;
        }
        public static void WholePalletMove(PalletInfo palletInfo)
        {
            Console.Clear();
            PrintOutArray.PrintArray();
            Console.WriteLine("Vi utgår från grundraden 0");
            Console.WriteLine("Ange vilken kolumn du vill flytta till, t.ex 0:19 :");

            int rowIndex = 0;

            bool loopTillMoveIsDone = false;
            int columnIndex = 0;
            while (!loopTillMoveIsDone) // eftersom vi plockar ut pallen i en annan metod har vi en loop som fortsätter tills flytten är gjord.
            {
                Console.Write("Ange andra formatet : ");
                try
                {
                    columnIndex = int.Parse(Console.ReadLine());
                    if (columnIndex > 19)
                    {
                        Console.WriteLine("Felaktig indata, Ange första formatet mellan 0 eller 19:");
                        continue; //återgå till början av loopen om fel indata
                    }

                    if (IsThereSpace(rowIndex, columnIndex)) // kallar på min metod för att se om det finns plats vid angivet index
                    {
                        

                        palletInfo = new PalletInfo(palletInfo.PalletSize,palletInfo.Arrival, palletInfo.PalletID);

                        WareHouse.WareHouseIndex[rowIndex, columnIndex] = palletInfo;
                        WareHouse.WareHouseIndex[rowIndex + 1, columnIndex] = palletInfo;  // Lägger till att en helpall tar upp två platser

                        Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} och pallen behåller in ingång tid på: {palletInfo.Arrival} och pallen är en {palletInfo.PalletSize} vi lägger den i lager plats {rowIndex}:{columnIndex} / {rowIndex + 1}:{columnIndex} ");
                        Console.ReadLine();
                        break; // Bryt loopen efter framgångsrik flytt
                    }
                    else
                    {
                        Console.WriteLine("Tyvärr platsen är upptagen. Försök igen.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Felaktig inmatnings data försök igen");

                }




            }
        }
    }
}
