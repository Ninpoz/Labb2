using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
   
    public class PalletInfo
    {
       public string PalletSize {  get; set; }
        public string PalletID { get; set;}
        public  DateTime Arrival { get; set; }
        //public int PalletIndex { get; set; }

        public PalletInfo(string size, DateTime arrival, string palletID)
        {
            PalletSize = size;
            PalletID = palletID;
            Arrival = arrival;
            //PalletIndex = palletIndex;
        }
        public PalletInfo()
        {
            PalletSize = null;
            PalletID = PalletID;
            Arrival = DateTime.Now;
            //PalletIndex = 0;
        }



        public static string palletIdGenerator()
        {
            Random rnd = new Random();
            StringBuilder charBuilder = new StringBuilder();

            // generea två random bokstäver
            for (int i = 0; i < 2; i++)
            {
                char randomLetter = (char)('A' + rnd.Next(26));
                charBuilder.Append(randomLetter);
            }
            // generera 3 random nummer
            for (int i = 0; i < 3; i++)
            {
                int randomNumber = rnd.Next(10); // 0-9
                charBuilder.Append(randomNumber);
            }

            return charBuilder.ToString();
        }

      


    }

}
