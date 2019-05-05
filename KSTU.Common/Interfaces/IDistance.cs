using KSTU.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.Interfaces
{
    public interface IDistance
    {
        double GetDinstance(ClusterEntityDTO first, ClusterEntityDTO second);
    }
}
