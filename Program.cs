using System.Text.RegularExpressions;

namespace Labb2
{  //Anton Bergman
    public class Program
    {
        static void Main(string[] args)
        {

            //PalletInfo[,] WareHouseIndex = new PalletInfo[2, 20];
            PalletInfo palletInfo = new PalletInfo();
            bool closeProgram = false;
            while (!closeProgram)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till Lunds Långlager (LLL) ");
                Console.WriteLine("1. Inläming av pall");
                Console.WriteLine("2. Utlämninga av pall");
                Console.WriteLine("3. Sökning av pall");
                Console.WriteLine("4. Kolla lager status");
                Console.WriteLine("5. Stäng av programmet");
                Console.Write("Ditt val :");

                string menuChoice = Console.ReadLine();

                if (Regex.IsMatch(menuChoice, "^[1-5]{1}$"))
                { 
                    switch (menuChoice) 
                    {
                            case "1":

                            WareHouse.AddIntoWareHouse(palletInfo);
                            break;
                            case "2":
                            
                            WareHouse.GetFromWareHouse();
                            
                            break;
                            case "3": break;
                            case "4": break;
                            case "5": closeProgram = true; break;
                    }

                }
                else 
                {
                    Console.WriteLine("Felakting inmatning, Tryck enter och försök igen ");
                    Console.ReadKey();
                }
            }

        }   
    }
}