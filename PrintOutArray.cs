using Spectre.Console;
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

            Console.Clear();
            var table = new Table();
            table.AddColumn("[green]Row[/]");
            table.AddColumn("Column");
            table.AddColumn("PalletID");
            table.AddColumn("PalletSize");
            table.AddColumn("Arrival");

            for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0); row++)
            {
                for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                {
                    PalletInfo _palletinfo = WareHouse.WareHouseIndex[row, column];
                    if (_palletinfo != null)
                    {
                        table.AddRow(row.ToString(), column.ToString(), _palletinfo.PalletSize, _palletinfo.PalletID, _palletinfo.Arrival.ToString());
                    }
                    else
                    {
                        table.AddRow(row.ToString(), column.ToString(), "[red]This Spot is Empty [/]", "", "");
                    }
                }
            }

            AnsiConsole.Render(table);
            //Console.ReadLine();

            //for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0); row++)
            //{
            //    for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
            //    {
            //        PalletInfo _palletinfo = WareHouse.WareHouseIndex[row, column];
            //        if (_palletinfo != null)
            //        {
            //            Console.WriteLine($"Row: {row}, Column: {column}, PalletID: {_palletinfo.PalletID}, PalletSize: {_palletinfo.PalletSize}, Arrival: {_palletinfo.Arrival}");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Row: {row}, Column: {column}, This Spot is Empty");
            //        }
            //    }
            //}
            //Console.ReadLine();
            //return;
        }
    }
}
