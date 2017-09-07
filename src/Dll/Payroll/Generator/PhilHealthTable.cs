using System.Collections.Generic;
using System.Linq;

namespace Dll.Payroll
{
    public class PhilHealthTable
    {

        private readonly ICollection<PhilHealth> ItemDataCollection;
        public PhilHealthTable()
        {
            ItemDataCollection = new List<PhilHealth>()
            {
                new PhilHealth() {MinSalary = 1m, MaxSalary = 8999.99m, Amount = 100m},
                new PhilHealth() {MinSalary = 9000m, MaxSalary = 9999.99m, Amount = 112.5m},
                new PhilHealth() {MinSalary = 10000m, MaxSalary = 10999.99m, Amount = 125m},
                new PhilHealth() {MinSalary = 11000m, MaxSalary = 11999.99m, Amount = 137.5m},
                new PhilHealth() {MinSalary = 12000m, MaxSalary = 12999.99m, Amount = 150m},
                new PhilHealth() {MinSalary = 13000m, MaxSalary = 13999.99m, Amount = 162.5m},
                new PhilHealth() {MinSalary = 14000m, MaxSalary = 14999.99m, Amount = 175m},
                new PhilHealth() {MinSalary = 15000m, MaxSalary = 15999.99m, Amount = 187.5m},
                new PhilHealth() {MinSalary = 16000m, MaxSalary = 16999.99m, Amount = 200m},
                new PhilHealth() {MinSalary = 17000m, MaxSalary = 17999.99m, Amount = 212.5m},
                new PhilHealth() {MinSalary = 18000m, MaxSalary = 18999.99m, Amount = 225m},
                new PhilHealth() {MinSalary = 19000m, MaxSalary = 19999.99m, Amount = 237.5m},
                new PhilHealth() {MinSalary = 20000m, MaxSalary = 20999.99m, Amount = 250m},
                new PhilHealth() {MinSalary = 21000m, MaxSalary = 21999.99m, Amount = 262.5m},
                new PhilHealth() {MinSalary = 22000m, MaxSalary = 22999.99m, Amount = 275m},
                new PhilHealth() {MinSalary = 23000m, MaxSalary = 23999.99m, Amount = 287.5m},
                new PhilHealth() {MinSalary = 24000m, MaxSalary = 24999.99m, Amount = 300m},
                new PhilHealth() {MinSalary = 25000m, MaxSalary = 25999.99m, Amount = 312.5m},
                new PhilHealth() {MinSalary = 26000m, MaxSalary = 26999.99m, Amount = 325m},
                new PhilHealth() {MinSalary = 27000m, MaxSalary = 27999.99m, Amount = 337.5m},
                new PhilHealth() {MinSalary = 28000m, MaxSalary = 28999.99m, Amount = 350m},
                new PhilHealth() {MinSalary = 29000m, MaxSalary = 29999.99m, Amount = 362.5m},
                new PhilHealth() {MinSalary = 30000m, MaxSalary = 30999.99m, Amount = 375m},
                new PhilHealth() {MinSalary = 31000m, MaxSalary = 31999.99m, Amount = 387.5m},
                new PhilHealth() {MinSalary = 32000m, MaxSalary = 32999.99m, Amount = 400m},
                new PhilHealth() {MinSalary = 33000m, MaxSalary = 33999.99m, Amount = 412.5m},
                new PhilHealth() {MinSalary = 34000m, MaxSalary = 34999.99m, Amount = 425m},
                new PhilHealth() {MinSalary = 35000m, MaxSalary = 35999.99m, Amount = 437.5m},

            };
        }

        public decimal GetContributionOf(decimal salary)
        {
            if (salary == 0) return 0;

            var item = ItemDataCollection.FirstOrDefault(_ => _.MinSalary <= salary && salary <= _.MaxSalary);

            return item?.Amount ?? 0;
        }


        protected class PhilHealth
        {
            public decimal MinSalary { get; set; }
            public decimal MaxSalary { get; set; }
            public decimal Amount { get; set; }
        }
    }



}
