using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class PrintOutArray
    {
        public static void PrintArray()
            {

            for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0); row++)
            {
                for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                {
                    PalletInfo _palletinfo = WareHouse.WareHouseIndex[row, column];
                    if (_palletinfo != null)
                    {
                        Console.WriteLine($"Row: {row}, Column: {column}, PalletID: {_palletinfo.PalletID}, PalletSize: {_palletinfo.PalletSize}, Arrival: {_palletinfo.Arrival}");
                    }
                    //else
                    //{
                    //    Console.WriteLine($"Row: {row}, Column: {column}, This Spot is Empty");
                    //}
                }
            }
            Console.ReadLine();
            return;
        }
    }
}
