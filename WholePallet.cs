using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class WholePallet
    {
        public static void IfWholePallet(PalletInfo palletInfo)
        {
            bool isWareHouseFull = true;
            PrintOutArray.PrintArray();
            for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0) - 1; row++)
            {
                isWareHouseFull = true;
                for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                {

                    if (WareHouse.WareHouseIndex[row, column] == null && WareHouse.WareHouseIndex[row + 1, column] == null) // HelPall tar upp två platser t.ex 0:3 och 1:3 så det räcker med en if-sats. Båda platser måste vara tomma
                    {
                        isWareHouseFull = false;
                        // Skapa ett nytt PalletInfo-objekt för varje plats i arrayen.
                        palletInfo.PalletID = PalletInfo.palletIdGenerator();

                        palletInfo = new PalletInfo(palletInfo.PalletSize, DateTime.Now, palletInfo.PalletID);

                        WareHouse.WareHouseIndex[row, column] = palletInfo;
                        WareHouse.WareHouseIndex[row + 1, column] = palletInfo;  //lägger till att en helpall tar upp två platser, t.ex 0:3 / 1:3
                        PrintOutArray.PrintArray();
                        Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} vid tiden {palletInfo.Arrival} och pallen är en {palletInfo.PalletSize} vi lägger den i lager plats {row}:{column} / {row + 1}:{column} ");
                        Console.ReadLine();
                        return;

                    }
                }
            }
            if (isWareHouseFull)
            {
                Console.WriteLine("Lagret är fullt för helpallar.");
                Console.ReadLine();
            }


        }
    }
}
