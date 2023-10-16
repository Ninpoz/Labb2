using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class AddPalletsToArray
    {
        public static void addPalletsToArray()
        {
            WareHouse.WareHouseIndex[0, 0] = new PalletInfo("HalvPall", DateTime.Now.AddHours(-3), "AA000");
            WareHouse.WareHouseIndex[1, 0] = new PalletInfo("HalvPall", DateTime.Now.AddHours(-8), "AA001");
            WareHouse.WareHouseIndex[0, 1] = new PalletInfo("HalvPall", DateTime.Now.AddHours(-7), "AA002");
            WareHouse.WareHouseIndex[0, 2] = new PalletInfo("HelPall", DateTime.Now.AddHours(-2), "AA003");
            WareHouse.WareHouseIndex[1, 2] = new PalletInfo("HelPall", DateTime.Now.AddHours(-2), "AA003");
            WareHouse.WareHouseIndex[0, 3] = new PalletInfo("HelPall", DateTime.Now.AddHours(-6), "AA004");
            WareHouse.WareHouseIndex[1, 3] = new PalletInfo("HelPall", DateTime.Now.AddHours(-6), "AA004");

            //test av sortering =

            //WareHouse.WareHouseIndex[0, 4] = new PalletInfo("HalvPall", DateTime.Now.AddHours(-6), "AA005");
            //WareHouse.WareHouseIndex[0, 5] = new PalletInfo("HalvPall", DateTime.Now.AddHours(-2), "AA006");
            //WareHouse.WareHouseIndex[0, 6] = new PalletInfo("HalvPall", DateTime.Now.AddHours(-2), "AA007");
            //WareHouse.WareHouseIndex[0, 7] = new PalletInfo("HalvPall", DateTime.Now.AddHours(-2), "AA008");


        }
    }
}
