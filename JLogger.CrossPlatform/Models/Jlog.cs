using System;
using System.Collections.Generic;

namespace JLogger.CrossPlatform.Models
{
    public partial class Jlog
    {
        public int SerialNo { get; set; }
        public DateTime Date { get; set; }
        public int Ntimes { get; set; }
        public string Reason { get; set; }
    }
}
