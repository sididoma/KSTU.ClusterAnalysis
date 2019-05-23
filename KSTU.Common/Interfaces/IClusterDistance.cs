using KSTU.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.Interfaces
{
    public interface IClusterDistance
    {
        double GetDistance(List<ClusterEntityDTO> first, List<ClusterEntityDTO> second, IDistance distance);
    }
}
