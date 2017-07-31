using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTech.Biometric
{
    public class TransactionEventArgs : EventArgs
    {
        public DateTime TransactionDate { get; set; }
        public DeviceUser UserData { get; set; }
        public bool IsInvalid { get; set; }
        public int State { get; set; }
    }
}
