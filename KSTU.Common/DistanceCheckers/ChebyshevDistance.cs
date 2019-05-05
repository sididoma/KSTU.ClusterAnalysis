using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSTU.Common.DistanceCheckers
{
    public class ChebyshevDistance : IDistance
    {
        public double GetDinstance(ClusterEntityDTO first, ClusterEntityDTO second)
        {
            double distance = 0.0;
            double max = double.MinValue;

            for(int i = 0; i < first.Interests.Count; i++)
            {
                double diff = first.Interests[i].Weight - second.Interests[i].Weight;
                distance = Math.Max(Math.Abs(diff), max);
            }

            return distance;
        }
    }
}
