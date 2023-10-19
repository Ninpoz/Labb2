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
            table.AddColumn("Row");
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
                        string palletSize = _palletinfo.PalletSize;
                        string colorTag = "[green]";
                        if (palletSize.Equals("HalvPall"))
                        {
                            colorTag = "[yellow]";
                        }
                      
                        table.AddRow(
                       row.ToString(),
                       column.ToString(),
                       $"{colorTag}{_palletinfo.PalletID}[/]",
                       $"{colorTag}{_palletinfo.PalletSize}[/]",
                       $"{colorTag}{_palletinfo.Arrival}[/]" 
                   );
                    }
                    else
                    {
                        table.AddRow(row.ToString(), column.ToString(), "[red]This Spot is Empty [/]", "", "");
                    }
                }
            }

            AnsiConsole.Render(table);

        }
    }
}
