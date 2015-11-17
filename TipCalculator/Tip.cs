using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator
{
    public class Tip
    {
        public string BillAmount { get; set; }
        public string TipAmount { get; set; }
        public string TotalAmount { get; set; }
        public double MyPercentage { get; set; }
        public string myPercentage { get; set; }

        public Tip()
        {
            this.BillAmount = String.Empty;
            this.TipAmount = String.Empty;
            this.TotalAmount = String.Empty;
        }

        public void CalculatePercent(string originalValue)
        {
            double percentToCalc = 0.0;
            if (double.TryParse(originalValue.Replace('%', ' '), out percentToCalc))
            {
                MyPercentage = percentToCalc / 100;
            }
            
            
        }

        public void CalculateTip(string originalAmount, double tipPercentage)
        {
            double billAmount = 0.0;
            double tipAmount = 0.0;
            double totalAmount = 0.0;

            if (double.TryParse(originalAmount.Replace('£', ' '), out billAmount))
            {

                tipAmount = billAmount * tipPercentage;
                totalAmount = billAmount + tipAmount;
            }

            this.BillAmount = String.Format("{0:C}", billAmount);
            this.TipAmount = String.Format("{0:C}", tipAmount);
            this.TotalAmount = String.Format("{0:C}", totalAmount);
            var MyDisplayPercentage = MyPercentage * 100;
            this.myPercentage = String.Format("{0}%", MyDisplayPercentage);
            
        }
    }
}
