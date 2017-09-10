using System;

namespace Biometric
{
    public class TransactionEventArgs : EventArgs
    {
        public DateTime TransactionDate { get; set; }
        public DeviceUser UserData { get; set; }
        public bool IsInvalid { get; set; }
        public int State { get; set; }
    }
}
