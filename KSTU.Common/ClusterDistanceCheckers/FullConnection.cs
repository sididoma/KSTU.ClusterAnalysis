using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.ClusterDistanceCheckers
{
    public class FullConnection : IClusterDistance
    {
        public double GetDistance(List<ClusterEntityDTO> first, List<ClusterEntityDTO> second, IDistance distance)
        {
            double dist = double.MinValue;

            foreach (var frs in first)
            {
                foreach (var sc in second)
                {
                    dist = Math.Max(dist, distance.GetDinstance(frs, sc));
                }
            }

            return dist;
        }
    }
}
