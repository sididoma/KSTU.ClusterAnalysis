using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.ClusterAnalysis.BLL.Interfaces
{
    public interface IKMeans
    {
        List<ClusterEntityDTO> Clustering(List<ClusterEntityDTO> clusters, IDistance distance, int clustersCount);
    }
}
