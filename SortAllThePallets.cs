using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class SortAllThePallets
    {

        public static List<PalletInfo> ExtractAllPallets()
        {
            List<PalletInfo> extractedPallet = new List<PalletInfo>();

            for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0); row++)
            {
                for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                {
                    PalletInfo pallet = WareHouse.WareHouseIndex[row, column];
                    if (WareHouse.WareHouseIndex[row, column] != null)
                    {
                        extractedPallet.Add(pallet);
                    }
                    WareHouse.WareHouseIndex[row, column] = null;
                }
            }

            foreach (PalletInfo pallet in extractedPallet.ToList())
            {
                if (pallet.PalletSize.Equals("HelPall")) // kollar om det finns en Helpall i listan
                {
                    for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0) - 1; row++)
                    {
                        for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                        {
                            if (WareHouse.WareHouseIndex[row, column] == null && WareHouse.WareHouseIndex[row + 1, column] == null)
                            {
                                PalletInfo newPallet = new PalletInfo(pallet.PalletSize, pallet.Arrival, pallet.PalletID); // Skapa en ny pall med samma egenskaper
                                WareHouse.WareHouseIndex[row, column] = newPallet; // Placera den nya pallen i nuvarande rad och kolumn
                                WareHouse.WareHouseIndex[row + 1, column] = newPallet; // Placera en kopia av den nya pallen i nästa rad och samma kolumn
                                extractedPallet.Remove(pallet); // Ta bort den behandlade pallen från listan
                                break; // Avsluta den innersta loopen
                            }
                        }
                    }
                }
                else if (pallet.PalletSize.Equals("HalvPall"))
                {
                    for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0) - 1; row++)
                    {
                        for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                        {
                            if (WareHouse.WareHouseIndex[row, column] == null) // Kontrollera om den aktuella cellen är tom
                            {
                                PalletInfo newPallet = new PalletInfo(pallet.PalletSize, pallet.Arrival, pallet.PalletID); // Skapa en ny pall med samma egenskaper
                                WareHouse.WareHouseIndex[row, column] = newPallet; // Placera den nya pallen i nuvarande rad och kolumn
                                extractedPallet.Remove(pallet); // Ta bort den behandlade pallen från listan
                                break; // Avsluta den innersta loopen
                            }
                            else if (row + 1 < WareHouse.WareHouseIndex.GetLength(0) && WareHouse.WareHouseIndex[row + 1, column] == null) // Kontrollera om nästa rad finns och är tom
                            {
                                PalletInfo newPallet = new PalletInfo(pallet.PalletSize, pallet.Arrival, pallet.PalletID); // Skapa en ny pall med samma egenskaper
                                WareHouse.WareHouseIndex[row + 1, column] = newPallet; // Placera den nya pallen i nästa rad och samma kolumn
                                extractedPallet.Remove(pallet); // Ta bort den behandlade pallen från listan
                                break; // Avsluta den innersta loopen
                            }
                        }
                    }
                }
            }

            return extractedPallet;

        }

        //public static void deleteListWhenDone(List<PalletInfo> extractedPallet)
        //{
        //    extractedPallet.Clear();
        //}
    }

}
