using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class PerformanceMeasures
    {
        public PerformanceMeasures()
        {

        }
        public decimal EndingInventoryAverage { get; set; }

        public decimal ShortageQuantityAverage { get; set; }

        public string performanceMeasuresData()
        {
            string str = "";
            str += "Ending Inventory Average = " + this.EndingInventoryAverage.ToString() + "\n";
            str += "Shortage Quantity Average = " + this.ShortageQuantityAverage.ToString() + "\n";


            return str;
        }
    }
}
