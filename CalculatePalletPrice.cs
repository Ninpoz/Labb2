using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    public class CalculatePalletPrice
    {
        public static int CalculatePrice(PalletInfo palletInfo)
        {
            
            if (palletInfo.PalletSize.Equals("HalvPall"))
            {

                return (int)Math.Ceiling((DateTime.Now - palletInfo.Arrival).TotalHours) * 39;
            }
            else if (palletInfo.PalletSize.Equals("HelPall"))
            {
                return (int)Math.Ceiling((DateTime.Now - palletInfo.Arrival).TotalHours) * 75;
            }
            else
            {
                return 0; 
            }
        }
    }
}
