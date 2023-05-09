using FSIncome.Core;
using FSIncome.Core.Files;
using ScottPlot;
using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Windows
{
    public class PlotClass
    {
        private Color[] sliceColors = new Color[]
        {
            Color.Green,
            Color.Yellow,
            Color.Red,
            Color.Blue,
            Color.Magenta,
            Color.Cyan,
            Color.AliceBlue,
            Color.Gray
        };

        private string[] legendLabels { get; set; }
        public string[] LegendLabels
        {
            get { return legendLabels; }
        }
        public double TotalExpenditureAmount
        {
            get { return totalExpenditureAmount; }
        }
        private double totalExpenditureAmount { get; set; }
        public double TotalIncomeAmount
        {
            get { return totalIncomeAmount; }
        }
        private double totalIncomeAmount { get; set; }
        public PlotClass(WpfPlot plot) 
        {
            InitPlot(plot);
        }
        private void InitPlot(WpfPlot plot)
        {
            plot.Plot.Palette = ScottPlot.Palette.OneHalfDark;
            plot.IsEnabled = false;
            plot.Plot.Style(figureBackground: Color.Transparent, dataBackground: Color.Transparent);
        }
        public void InitPlotValues(WpfPlot plot, string plotCategory, int profileNumber, int farmProfileNumber)
        {
            //labels legend
            string[] legendLabelsIncome = new string[7];
            string[] legendLabelsExpenditure = new string[8];
            byte iterator = 0;
            if(plotCategory==ResourcesClass.PlotType.moneyExpenditure.ToString())
            {
                foreach (var i in Enum.GetValues(typeof(ResourcesClass.TransactionsCategoriesExpenditure)))
                {
                    legendLabelsExpenditure[iterator] = ResourcesMethods.SetCategoryString(i.ToString());
                    iterator++;
                }

                //for returning to the moneyPage
                this.legendLabels = legendLabelsExpenditure;
            }
            else if(plotCategory == ResourcesClass.PlotType.moneyIncome.ToString())
            {
                foreach (var i in Enum.GetValues(typeof(ResourcesClass.TransactionsCategoriesIncome)))
                {
                    legendLabelsIncome[iterator] = ResourcesMethods.SetCategoryString(i.ToString());
                    iterator++;
                }

                //for returning to the moneyPage
                this.legendLabels = legendLabelsIncome;
            }
            
            
            plot.Plot.AddPie(CountPercentageValues(this.legendLabels, plotCategory, profileNumber, farmProfileNumber)).SliceFillColors = sliceColors;
            plot.Refresh();
        }

        private double[] CountPercentageValues(string[] legendLabels, string plotCategory, int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();

            //check amount of each category
            Dictionary<string, double> values = new Dictionary<string, double>();
            double[] endingValues = new double[legendLabels.Length];

            //assigning starting value = 0
            for (int j = 0; j < legendLabels.Length; j++)
            {
                values[legendLabels[j]] = 0;
            }
            if (plotCategory == ResourcesClass.PlotType.moneyExpenditure.ToString())
            {
                foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsExpenditureTag.transactions)
                {
                    for (int j = 0; j < legendLabels.Length; j++)
                    {
                        if (i.category == legendLabels[j])
                        {
                            values[legendLabels[j]] += i.amount;
                        }
                    }
                }

                //checking percentage values
                totalExpenditureAmount = 0;
                foreach (var i in values)
                {
                    totalExpenditureAmount += i.Value;
                }

                if (totalExpenditureAmount != 0)
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        endingValues[i] = (values[legendLabels[i]] * 100) / totalExpenditureAmount;
                    }
                }
            }
            else if (plotCategory == ResourcesClass.PlotType.moneyIncome.ToString())
            {
                foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsIncomeTag.transactions)
                {
                    for (int j = 0; j < legendLabels.Length; j++)
                    {
                        if (i.category == legendLabels[j])
                        {
                            values[legendLabels[j]] += i.amount;
                        }
                    }
                }

                //checking percentage values
                totalIncomeAmount = 0;
                foreach (var i in values)
                {
                    totalIncomeAmount += i.Value;
                }

                if (totalIncomeAmount != 0)
                {
                    for (int i = 0; i < values.Count; i++)
                    {
                        endingValues[i] = (values[legendLabels[i]] * 100) / totalIncomeAmount;
                    }
                }
            }

            return endingValues;
        }
    }
}
