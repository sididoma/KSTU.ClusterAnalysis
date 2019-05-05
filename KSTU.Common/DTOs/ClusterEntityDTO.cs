using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.DTOs
{
    public class ClusterEntityDTO : BaseEntity
    {
        public string Name { get; set; }
        public int CentroidId { get; set; } = - 1;
        public int ClustersCount { get; set; } = 0;
        public List<Interest> Interests { get; set; }
    }
}
