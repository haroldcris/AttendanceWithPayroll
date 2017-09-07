using System.Collections.Generic;
using System.Linq;

namespace Dll.Payroll
{
    public class SSSTable
    {
        private readonly ICollection<SSS> ItemDataCollection;
        public SSSTable()
        {
            ItemDataCollection = new List<SSS>
            {
                new   SSS(){MinSalary=1000m,MaxSalary=1249.99m,Amount=36.3m},
                new   SSS(){MinSalary=1250m,MaxSalary=1749.99m,Amount=54.5m},
                new   SSS(){MinSalary=1750m,MaxSalary=2249.99m,Amount=72.7m},
                new   SSS(){MinSalary=2250m,MaxSalary=2749.99m,Amount=90.8m},
                new   SSS(){MinSalary=2750m,MaxSalary=3249.99m,Amount=109m},
                new   SSS(){MinSalary=3250m,MaxSalary=3749.99m,Amount=127.2m},
                new   SSS(){MinSalary=3750m,MaxSalary=4249.99m,Amount=145.3m},
                new   SSS(){MinSalary=4250m,MaxSalary=4749.99m,Amount=163.5m},
                new   SSS(){MinSalary=4750m,MaxSalary=5249.99m,Amount=181.7m},
                new   SSS(){MinSalary=5250m,MaxSalary=5749.99m,Amount=199.8m},
                new   SSS(){MinSalary=5750m,MaxSalary=6249.99m,Amount=218m},
                new   SSS(){MinSalary=6250m,MaxSalary=6749.99m,Amount=236.2m},
                new   SSS(){MinSalary=6750m,MaxSalary=7249.99m,Amount=254.3m},
                new   SSS(){MinSalary=7250m,MaxSalary=7749.99m,Amount=272.5m},
                new   SSS(){MinSalary=7750m,MaxSalary=8249.99m,Amount=290.7m},
                new   SSS(){MinSalary=8250m,MaxSalary=8749.99m,Amount=308.8m},
                new   SSS(){MinSalary=8750m,MaxSalary=9249.99m,Amount=327m},
                new   SSS(){MinSalary=9250m,MaxSalary=9749.99m,Amount=345.2m},
                new   SSS(){MinSalary=9750m,MaxSalary=10249.99m,Amount=363.3m},
                new   SSS(){MinSalary=10250m,MaxSalary=10749.99m,Amount=381.5m},
                new   SSS(){MinSalary=10750m,MaxSalary=11249.99m,Amount=399.7m},
                new   SSS(){MinSalary=11250m,MaxSalary=11749.99m,Amount=417.8m},
                new   SSS(){MinSalary=11750m,MaxSalary=12249.99m,Amount=436m},
                new   SSS(){MinSalary=12250m,MaxSalary=12749.99m,Amount=454.2m},
                new   SSS(){MinSalary=12750m,MaxSalary=13249.99m,Amount=472.3m},
                new   SSS(){MinSalary=13250m,MaxSalary=13749.99m,Amount=490.5m},
                new   SSS(){MinSalary=13750m,MaxSalary=14249.99m,Amount=508.7m},
                new   SSS(){MinSalary=14250m,MaxSalary=14749.99m,Amount=526.8m},
                new   SSS(){MinSalary=14750m,MaxSalary=15249.99m,Amount=545m},
                new   SSS(){MinSalary=15250m,MaxSalary=15749.99m,Amount=563.2m},
                new   SSS(){MinSalary=15750m,MaxSalary=100000m,Amount=581.3m}
            };
        }

        public decimal GetContributionOf(decimal salary)
        {
            if (salary == 0) return 0;

            var item = ItemDataCollection.FirstOrDefault(_ => _.MinSalary <= salary && salary <= _.MaxSalary);

            return item?.Amount ?? 0;
        }



        protected class SSS
        {
            public decimal MinSalary { get; set; }
            public decimal MaxSalary { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
