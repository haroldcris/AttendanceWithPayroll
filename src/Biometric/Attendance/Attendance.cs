﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AiTech.Biometric
{
    public class Attendance 
    {
        public int BiometricId { get; set; }
        public DateTime TimeLog { get; set; }
        public string Station { get; set; }
        /// <summary>
        /// In or Out
        /// </summary>
        public string EntryType { get; set; }

    }
}
