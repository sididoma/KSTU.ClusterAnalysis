using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.DTOs
{
    public class ClusterEntityDTO : BaseEntity
    {
        public string Name { get; set; }
        public int CentroidId { get; set; } = -1;
        public int ClustersCount { get; set; } = 0;
        public List<Interest> Interests { get; set; }
        public List<ClusterEntityDTO> Children { get; set; }
        public ClusterEntityDTO(ClusterEntityDTO dTO)
        {
            Name = dTO.Name;
            CentroidId = dTO.CentroidId;
            ClustersCount = dTO.ClustersCount;
            Interests = new List<Interest>(dTO.Interests);
            Children = dTO.Children == null ? null : new List<ClusterEntityDTO>(dTO.Children);
        }
        public ClusterEntityDTO()
        {

        }
    }
}
