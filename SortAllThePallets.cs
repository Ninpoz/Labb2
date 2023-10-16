using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class SortAllThePallets
    {

        public static List<PalletInfo> ExtractAllPallets(PalletInfo palletInfo)
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
                        WareHouse.WareHouseIndex[row, column] = null;
                    }
                }
            }

            for (int i = 0; i < extractedPallet.Count; i++)
            {
                if (extractedPallet[i].PalletSize.Equals("HalvPall"))
                {
                    HalfPallet.IfHalfPallet(extractedPallet[i]);
                }
                if (extractedPallet[i].PalletSize.Equals("HelPall"))
                {
                    WholePallet.IfWholePallet(extractedPallet[i]);
                }
            }
            return null;
        }

    }

}
