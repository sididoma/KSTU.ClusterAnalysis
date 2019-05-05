using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSTU.Web.Models
{
    public class ClusteringResultView
    {
        public string Name { get; set; }
        public int CentroidId { get; set; } = 0;
        public int ClustersCount { get; set; } = 0;
        public List<ClusteringInterestView> Interests { get; set; }
    }

    public class ClusteringInterestView
    {
        public string Name { get; set; }
        public double Weight { get; set; }
    }
}
