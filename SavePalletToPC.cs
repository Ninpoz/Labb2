using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class SavePalletToPC
    {
        public static void SavePalletInfoToFile(PalletInfo pallet)
        {
            string filePath = @"C:\Users\anton\Desktop\pallet_info.txt";  // Ange sökvägen till din textfil

            using (StreamWriter writer = new StreamWriter(filePath,true  ))
            {
                writer.WriteLine("Uthämtad Pall Information:");
                writer.WriteLine($"Uthämtningstid: {DateTime.Now}");
                writer.WriteLine($"Tid på pallplatsen: {DateTime.Now - pallet.Arrival}");
                writer.WriteLine($"Palltyp: {pallet.PalletSize}");
                decimal priceForPallet = CalculatePalletPrice.CalculatePrice(pallet); // Räkna ut priset
                writer.WriteLine($"Pris: {priceForPallet:C}"); // Lägg till priset
                writer.WriteLine(); // Lägg till en tom rad för separation
            }
        }
    }
}
