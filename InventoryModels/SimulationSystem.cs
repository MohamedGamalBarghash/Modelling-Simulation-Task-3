using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }

        ///////////// INPUTS /////////////

        public int OrderUpTo { get; set; }
        public int ReviewPeriod { get; set; }
        public int NumberOfDays { get; set; }
        public int StartInventoryQuantity { get; set; }
        public int StartLeadDays { get; set; }
        public int StartOrderQuantity { get; set; }
        public List<Distribution> DemandDistribution { get; set; }
        public List<Distribution> LeadDaysDistribution { get; set; }

        ///////////// OUTPUTS /////////////

        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        public string performanceMeasuresData(decimal dayCost)
        {
            string str = "here";

            //str += "Total Sales Revenue = ";
            //str += this.TotalSalesProfit.ToString(); str += "\n";
            //str += "Total Cost of Newspapers = ";
            //str += this.TotalCost.ToString(); str += "\n";
            //str += "Total Lost Profit from Excess Demand = ";
            //str += this.TotalLostProfit.ToString(); str += "\n";
            //str += "Total Salvage from sale of Scrap papers = ";
            //str += this.TotalScrapProfit.ToString(); str += "\n";
            //str += "Net Profit = ";
            //str += this.TotalNetProfit.ToString(); str += "\n";
            //str += "Number of days having excess demand = ";
            //str += this.DaysWithMoreDemand.ToString(); str += "\n";
            //str += "Number of days having unsold papers = ";
            //str += this.DaysWithUnsoldPapers.ToString(); str += "\n";
            //str += "Daily Cost = ";
            //str += dayCost.ToString(); str += "\n";
            return str;
        }
    }
}
