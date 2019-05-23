using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.ClusterAnalysis.BLL.Interfaces
{
    public interface IHierarchical
    {
        ClusterEntityDTO Clustering(List<ClusterEntityDTO> data, IDistance distance, IClusterDistance clusterDistance, int maxUnionInStep);
    }
}
