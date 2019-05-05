using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSTU.Common.DistanceCheckers
{
    public class EuclideanSquareDistance : IDistance
    {
        public double GetDinstance(ClusterEntityDTO first, ClusterEntityDTO second)
        {
            double distance = 0.0;

            for (int i = 0; i < first.Interests.Count; i++)
            {
                double diff = first.Interests[i].Weight - second.Interests[i].Weight;
                distance += (diff * diff);
            }

            return distance;
        }
    }
}
