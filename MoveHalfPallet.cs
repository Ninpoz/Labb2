using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class MoveHalfPallet
    {
        public static bool IsThereSpace(int rowIndex, int columIndex)
        {
            return WareHouse.WareHouseIndex[rowIndex, columIndex] == null;
        }
        public static void HalfPalletMove(PalletInfo palletInfo) 
        {
            Console.Clear();
            PrintOutArray.PrintArray();
            int rowIndex = 0;
            int columIndex = 0;
            bool loopTillMoveIsDone = false;
            while (!loopTillMoveIsDone) 
            {
                Console.WriteLine("Ange först vilken rad du vill flytta till rad [0] eller [1]");
                Console.Write("Ange Rad : ");
                try 
                {
                    rowIndex = int.Parse(Console.ReadLine());
                    if (rowIndex > 1)
                    {
                        Console.WriteLine("Felaktig indata, Ange rad 0 eller 1");
                        continue; //återgå till början av loopen om fel indata
                    }
                    Console.WriteLine("Ange först vilken kolumn, 0-19 ");
                    Console.Write("Ange kolumn : ");

                    columIndex = int.Parse(Console.ReadLine());
                    if(columIndex > 19)
                    {
                        Console.WriteLine("Felaktig indata, Ange kolumn mellan 0-19");
                        continue; //återgå till början av loopen om fel indata
                    }

                    if(IsThereSpace(rowIndex,columIndex))
                    {
                        palletInfo = new PalletInfo(palletInfo.PalletSize, palletInfo.Arrival, palletInfo.PalletID);

                        WareHouse.WareHouseIndex[rowIndex, columIndex] = palletInfo;
                        Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} och pallen behåller in ingång tid på: {palletInfo.Arrival} och pallen är en {palletInfo.PalletSize} vi lägger den i lager plats {rowIndex}:{columIndex}");
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
