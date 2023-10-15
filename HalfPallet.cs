using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class HalfPallet
    {
        public static void IfHalfPallet(PalletInfo palletInfo)
        {

            for (int row = 0; row < WareHouse.WareHouseIndex.GetLength(0); row++) // En dubbel forloop  för att iterera genom lagerplatser i 2D-arrayen.
            {
                for (int column = 0; column < WareHouse.WareHouseIndex.GetLength(1); column++)
                {
                    if (WareHouse.WareHouseIndex[row, column] == null) // om platsen på rad och kolumn är tom lägg till pall
                    {

                        palletInfo.PalletID = PalletInfo.palletIdGenerator(); //Auto-generar ett unikt pall-id

                        palletInfo = new PalletInfo(palletInfo.PalletSize, DateTime.Now, palletInfo.PalletID);// Skapa ett nytt PalletInfo-objekt för varje plats i arrayen.

                        try
                        {
                            WareHouse.WareHouseIndex[row, column] = palletInfo; // lägger till objektet som jag skapade ovanför i min 2d-Array


                            Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} som är en {palletInfo.PalletSize} och kom in i lagret {palletInfo.Arrival} och lades till i lager plats {row}:{column} ");
                            Console.ReadLine();
                            return;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Lagret är fullt. Kan inte lägga till fler pallar.");
                            Console.ReadLine();
                            return;

                        }


                    }
                    else
                    {

                        // om inte rad och kolumn är lediga t.ex 0:0 och 1:0 gå in i denna kodblock

                        if ( WareHouse.WareHouseIndex[row + 1, column] == null) //kollar om nästa rad och kolum är ledig t.ex 1:0, dvs att om 0:1 är upptagen lägg till om 1:1 är ledig 


                        {
                            //  om platsen är ledig lägg till
                            // Skapa ett nytt PalletInfo-objekt för varje plats i arrayen.
                            palletInfo.PalletID = PalletInfo.palletIdGenerator();

                            palletInfo = new PalletInfo(palletInfo.PalletSize, DateTime.Now, palletInfo.PalletID);

                            try
                            {
                                WareHouse.WareHouseIndex[row + 1, column] = palletInfo;
                                Console.WriteLine($"Vi har lagt till {palletInfo.PalletID} vid tiden {palletInfo.Arrival} och pallen är en {palletInfo.PalletSize} vi lägger den i lager plats {row + 1}:{column} ");
                                Console.ReadLine();
                                return;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Lagret är fullt. Kan inte lägga till fler pallar.");
                                Console.ReadLine();
                                return;
                            }
                            
                        }
                    }
                }
            }

        }
    }
}
