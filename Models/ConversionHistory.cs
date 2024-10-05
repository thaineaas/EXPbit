using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPbit.Models
{
    public class ConversionHistory
    {
         public int ConversionHistoryId { get; set; }
    public decimal BtcToUsdRate { get; set; }
    public decimal UsdToBtcRate { get; set; }
    public DateTime ConversionDate { get; set; }
    }
}