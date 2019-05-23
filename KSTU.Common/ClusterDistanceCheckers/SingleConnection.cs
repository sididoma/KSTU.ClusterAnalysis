using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.ClusterDistanceCheckers
{
    public class SingleConnection : IClusterDistance
    {
        public double GetDistance(List<ClusterEntityDTO> first, List<ClusterEntityDTO> second, IDistance distance)
        {
            double dist = double.MaxValue;

            foreach (var frs in first)
            {
                foreach (var sc in second)
                {
                    dist = Math.Min(dist, distance.GetDinstance(frs, sc));
                }
            }

            return dist;
        }
    }
}
