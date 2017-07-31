using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiTech.Biometric
{
    [Serializable]
    public class DeviceUser 
    {
        public int BiometricId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Privilege { get; set; }
        public bool Enabled { get; set; }
        public string CardNumber { get; set; }

        //public FingerPrintManager FingerPrints { get; set; }

        public DeviceUser()
        {
           // FingerPrints = new FingerPrintManager();
        }
    }
}
