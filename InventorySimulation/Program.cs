using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryModels;
using InventoryTesting;

using System.Threading;

namespace InventorySimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    partial class Interaction
    {
        public Interaction() { }
        public string content { get; set; }
        public List<string> myFile = new List<string>();
        System.Random random = new System.Random();
        public string filePath { get; set; }

        public InventoryModels.SimulationSystem mySystem = new InventoryModels.SimulationSystem();

        void Format_File()
        {
            string str = "";
            this.content += '\n';
            foreach (char ch in this.content)
            {
                if (ch == '\n')
                {
                    this.myFile.Add(str);
                    str = "";
                }
                else str += ch;
            }
        }

        public List<string> Split(string line)
        {
            List<string> ret = new List<string>();
            string tmp = "";
            //MessageBox.Show("hii");

            for (int i = 0; i < line.Length; i++)
            {
                while (i < line.Length && line[i] != ',')
                {
                    tmp += line[i]; i++;
                }
                ret.Add(tmp);
                tmp = "";
                i++;
            }

            return ret;
        }
        public void init()
        {
            myFile.Clear();
            mySystem = new SimulationSystem();

            Format_File();
            // code 

            mySystem.OrderUpTo = int.Parse(myFile[1]);
            mySystem.ReviewPeriod = int.Parse(myFile[4]);
            mySystem.StartInventoryQuantity = int.Parse(myFile[7]);
            mySystem.StartLeadDays = int.Parse(myFile[10]);
            mySystem.StartOrderQuantity = int.Parse(myFile[13]);
            mySystem.NumberOfDays = int.Parse(myFile[16]);

            for (int i = 0; i < 5; i++)
            {
                List<string> tmp = Split(myFile[19 + i]);


                mySystem.DemandDistribution.Add(new InventoryModels.Distribution());

                mySystem.DemandDistribution[i].Value = int.Parse(tmp[0]);
                mySystem.DemandDistribution[i].Probability = decimal.Parse(tmp[1]);

                if (i == 0)
                {
                    mySystem.DemandDistribution[i].CummProbability = mySystem.DemandDistribution[i].Probability;
                    mySystem.DemandDistribution[i].MinRange = 1;
                    mySystem.DemandDistribution[i].MaxRange = (int)Math.Round(mySystem.DemandDistribution[i].CummProbability * 100);

                }
                else
                {
                    mySystem.DemandDistribution[i].CummProbability = mySystem.DemandDistribution[i].Probability + mySystem.DemandDistribution[i - 1].CummProbability;
                    mySystem.DemandDistribution[i].MinRange = mySystem.DemandDistribution[i - 1].MaxRange + 1;
                    mySystem.DemandDistribution[i].MaxRange = (int)Math.Round(mySystem.DemandDistribution[i].CummProbability * 100);

                }
            }


            for (int i = 0; i < 3; i++)
            {
                List<string> tmp = Split(myFile[26 + i]);


                mySystem.LeadDaysDistribution.Add(new InventoryModels.Distribution());

                mySystem.LeadDaysDistribution[i].Value = int.Parse(tmp[0]);
                mySystem.LeadDaysDistribution[i].Probability = decimal.Parse(tmp[1]);

                if (i == 0)
                {

                    mySystem.LeadDaysDistribution[i].CummProbability = mySystem.LeadDaysDistribution[i].Probability;
                    mySystem.LeadDaysDistribution[i].MinRange = 1;
                    mySystem.LeadDaysDistribution[i].MaxRange = (int)(mySystem.LeadDaysDistribution[i].CummProbability * 100);

                }
                else if (i == 2)
                {
                    mySystem.LeadDaysDistribution[i].CummProbability = mySystem.LeadDaysDistribution[i].Probability + mySystem.LeadDaysDistribution[i - 1].CummProbability;
                    mySystem.LeadDaysDistribution[i].MinRange = 0;
                    mySystem.LeadDaysDistribution[i].MaxRange = 0;
                }
                else
                {
                    mySystem.LeadDaysDistribution[i].CummProbability = mySystem.LeadDaysDistribution[i].Probability + mySystem.LeadDaysDistribution[i - 1].CummProbability;
                    mySystem.LeadDaysDistribution[i].MinRange = mySystem.LeadDaysDistribution[i - 1].MaxRange + 1;
                    mySystem.LeadDaysDistribution[i].MaxRange = (int)(mySystem.LeadDaysDistribution[i].CummProbability * 100);

                }
            }

            init_table();
        }

        int randomNum(int en)
        {
            int ret = 0;
            int num = random.Next(1, en);
            ret = num;
            return ret;
        }

        int calcDemand(int idx)
        {
            for (int i = 0; i < mySystem.DemandDistribution.Count(); i++)
            {
                if (mySystem.DemandDistribution[i].MinRange <= idx && idx <= mySystem.DemandDistribution[i].MaxRange)
                    return mySystem.DemandDistribution[i].Value;
            }
            return 0;
        }

        int calcLeadDay(int idx)
        {
            decimal cur = (decimal)(idx + 9) / 10;
            for (int i = 0; i < mySystem.LeadDaysDistribution.Count(); i++)
            {
                decimal min = (decimal)(mySystem.LeadDaysDistribution[i].MinRange + 9) / 10;
                decimal max = (decimal)(mySystem.LeadDaysDistribution[i].MaxRange + 9) / 10;

                if (min <= cur && cur <= max)
                    return mySystem.LeadDaysDistribution[i].Value;
            }
            return 0;
        }

        public void init_table()
        {
            for (int i = 0; i < mySystem.NumberOfDays; i++) mySystem.SimulationTable.Add(new SimulationCase());

            int delay = 0;
            int sum = 0;

            int sumEnding = 0, sumShortage = 0;

            int orderd_quantity = mySystem.StartOrderQuantity;

            for (int i = 0; i < mySystem.NumberOfDays; i++)
            {

                mySystem.SimulationTable[i].Day = i + 1;
                mySystem.SimulationTable[i].Cycle = (i + mySystem.ReviewPeriod) / mySystem.ReviewPeriod;
                mySystem.SimulationTable[i].DayWithinCycle = (i % mySystem.ReviewPeriod) + 1;
                mySystem.SimulationTable[i].RandomDemand = randomNum(100);
                mySystem.SimulationTable[i].Demand = calcDemand(mySystem.SimulationTable[i].RandomDemand);
                sum += mySystem.SimulationTable[i].Demand;


                if ((i + 1) % mySystem.ReviewPeriod == 0)
                {
                    int x = randomNum(10);
                    mySystem.SimulationTable[i].RandomLeadDays = x;
                    mySystem.SimulationTable[i].LeadDays = calcLeadDay(mySystem.SimulationTable[i].RandomLeadDays);
                    delay = mySystem.SimulationTable[i].LeadDays;
                    mySystem.SimulationTable[i].OrderQuantity = sum;
                    orderd_quantity = sum;
                    sum = 0;
                }


                if (i == 0)
                {
                    mySystem.SimulationTable[i].BeginningInventory = mySystem.StartInventoryQuantity;
                    delay = mySystem.StartLeadDays - 1;
                }
                else
                {
                    mySystem.SimulationTable[i].BeginningInventory = mySystem.SimulationTable[i - 1].EndingInventory;
                    if (delay == -1)
                    {
                        mySystem.SimulationTable[i].BeginningInventory += orderd_quantity;
                    }
                }
                mySystem.SimulationTable[i].ShortageQuantity += Math.Max(0, -mySystem.SimulationTable[i].BeginningInventory + mySystem.SimulationTable[i].Demand + (i == 0 ? 0 : mySystem.SimulationTable[i - 1].ShortageQuantity));


                mySystem.SimulationTable[i].EndingInventory += Math.Max(0, mySystem.SimulationTable[i].BeginningInventory - mySystem.SimulationTable[i].Demand - (i == 0 ? 0 : mySystem.SimulationTable[i - 1].ShortageQuantity));

                delay--;
                sumEnding += mySystem.SimulationTable[i].EndingInventory;
                sumShortage += mySystem.SimulationTable[i].ShortageQuantity;
            }
            mySystem.PerformanceMeasures.EndingInventoryAverage = (decimal)(sumEnding) / mySystem.NumberOfDays;
            mySystem.PerformanceMeasures.ShortageQuantityAverage = (decimal)sumShortage / mySystem.NumberOfDays;
        }

        public void showPerformanceData()
        {
            MessageBox.Show(mySystem.PerformanceMeasures.performanceMeasuresData());
        }

        public string[] getRow(int idx)
        {
            List<string> ret = new List<string>();

            ret.Add(this.mySystem.SimulationTable[idx].Day.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].Cycle.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].DayWithinCycle.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].BeginningInventory.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].RandomDemand.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].Demand.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].EndingInventory.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].ShortageQuantity.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].OrderQuantity.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].RandomLeadDays.ToString());
            ret.Add(this.mySystem.SimulationTable[idx].LeadDays.ToString());

            string[] arr = { ret[0], ret[1], ret[2], ret[3], ret[4], ret[5], ret[6], ret[7], ret[8], ret[9], ret[10] };
            ////debug(this.mySystem.SimulationTable[idx].NewsDayType.ToString());
            return arr;
        }

        private void debug(string s)
        {
            MessageBox.Show(s);
        }
        int get_test_num()
        {
            int ret = 0;

            if (this.filePath.Contains("TestCase1"))
            {
                ret = 1;
            }
            else if (this.filePath.Contains("TestCase2"))
            {
                ret = 2;
            }

            return ret;
        }
        public void show_testing_results()
        {
            int testNum = this.get_test_num();
            string testingResult = "NO RES";

            if (testNum == 1)
                testingResult = TestingManager.Test(this.mySystem, Constants.FileNames.TestCase1);
            else if (testNum == 2)
                testingResult = TestingManager.Test(this.mySystem, Constants.FileNames.TestCase2);

            MessageBox.Show(testingResult);
        }

    }

}
