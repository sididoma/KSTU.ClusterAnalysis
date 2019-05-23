using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.ClusterDistanceCheckers
{
    public class UnweightedCentroid : IClusterDistance
    {
        public double GetDistance(List<ClusterEntityDTO> first, List<ClusterEntityDTO> second, IDistance distance)
        {
            ClusterEntityDTO firstDTO = new ClusterEntityDTO();
            ClusterEntityDTO secondDTO = new ClusterEntityDTO();
            double dist = 0.0;

            for (int j = 0; j < first[0].Interests.Count; j++)
            {
                double weight = 0.0;

                for (int i = 0; i < first.Count; i++)
                {
                    weight += first[i].Interests[j].Weight;
                }

                firstDTO.Interests.Add(new Interest
                {
                    Name = first[0].Interests[j].Name,
                    Weight = weight / (double)first.Count
                });
            }

            for (int j = 0; j < second[0].Interests.Count; j++)
            {
                double weight = 0.0;

                for (int i = 0; i < second.Count; i++)
                {
                    weight += second[i].Interests[j].Weight;
                }

                secondDTO.Interests.Add(new Interest
                {
                    Name = first[0].Interests[j].Name,
                    Weight = weight / second.Count
                });
            }

            dist = distance.GetDinstance(firstDTO, secondDTO);

            return dist;
        }
    }
}
