using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System.Collections.Generic;

namespace KSTU.Common.ClusterDistanceCheckers
{
    public class UnweightedPairwiseMean : IClusterDistance
    {
        public double GetDistance(List<ClusterEntityDTO> first, List<ClusterEntityDTO> second, IDistance distance)
        {
            double dist = 0.0;

            foreach (var frs in first)
            {
                foreach (var sc in second)
                {
                    dist = distance.GetDinstance(frs, sc);
                }
            }

            return dist / (first.Count * second.Count);
        }
    }
}
