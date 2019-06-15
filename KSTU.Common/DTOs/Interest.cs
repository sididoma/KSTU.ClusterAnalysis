using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.DTOs
{
    [Serializable]
    public class Interest
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Weight2 { get; set; }
    }
}
