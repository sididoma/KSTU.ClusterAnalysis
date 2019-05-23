using KSTU.ClusterAnalysis.BLL.Interfaces;
using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.ClusterAnalysis.BLL.Services
{
    public class Hierarchical : IHierarchical
    {
        private IDistance _distance;
        private IClusterDistance _clusterDistance;
        public ClusterEntityDTO Clustering(List<ClusterEntityDTO> data, IDistance distance, IClusterDistance clusterDistance, int maxUnionInStep)
        {
            _distance = distance;
            _clusterDistance = clusterDistance;
            int step = 0;
            while (true)
            {
                data = Union(data, maxUnionInStep, ++step);
                if (data.Count == 1)
                    break;
            }
            data[0].Name = "Root";
            return data[0];
        }

        private List<ClusterEntityDTO> Union(List<ClusterEntityDTO> data, int maxUnion, int step)
        {
            int unionCount = maxUnion;
            List<ClusterEntityDTO> result = new List<ClusterEntityDTO>();
            List<HierarchicalUnionObjectsDTO> distances = new List<HierarchicalUnionObjectsDTO>();
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    distances.Add(new HierarchicalUnionObjectsDTO
                    {
                        FirstId = i,
                        SecondId = j,
                        Distance = _distance.GetDinstance(data[i], data[j])
                    });
                }
            }
            distances.Sort((x, y) => x.Distance.CompareTo(y.Distance));
            bool[] used = new bool[data.Count];
            int counter = 0;
            for (int i = 0; i < distances.Count; i++)
            {
                if (unionCount == 0)
                    break;
                if (!used[distances[i].FirstId] && !used[distances[i].SecondId])
                {
                    ClusterEntityDTO dTO = new ClusterEntityDTO();
                    dTO.Children = new List<ClusterEntityDTO>
                    {
                        data[distances[i].FirstId],
                        data[distances[i].SecondId]
                    };
                    if (step == 1)
                        dTO.Name = GetName(counter++);
                    else
                        dTO.Name = dTO.Children[0].Name + dTO.Children[1].Name;
                    used[distances[i].FirstId] = true;
                    used[distances[i].SecondId] = true;
                    result.Add(dTO);
                    --unionCount;
                }

            }

            for (int i = 0; i < data.Count; i++)
            {

                if (!used[i])
                {
                    ClusterEntityDTO temp = new ClusterEntityDTO(data[i]);
                    temp.Children = new List<ClusterEntityDTO>(new List<ClusterEntityDTO> { data[i] });
                    temp.Name = data[i].Children == null ? GetName(counter++) : data[i].Name;
                    result.Add(temp);
                }
            }

            for (int k = 0; k < result.Count; k++)
            {
                result[k].Interests = new List<Interest>(data[0].Interests);
                if (result[k].Children != null)
                {
                    for (int j = 0; j < result[k].Children[0].Interests.Count; j++)
                    {
                        double weight = 0.0;
                        for (int i = 0; i < result[k].Children.Count; i++)
                        {
                            weight += result[k].Children[i].Interests[j].Weight;
                        }
                        result[k].Interests[j].Weight = weight / result[k].Children.Count;
                    }
                }
            }

            return result;
        }

        private double[][] GetDistanceMatrix(List<ClusterEntityDTO> data)
        {
            double[][] result = new double[data.Count][];
            for (int i = 0; i < data.Count; i++)
                result[i] = new double[data[i].Interests.Count];

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = i + 1; j < data.Count; j++)
                {
                    double dist = _clusterDistance.GetDistance(data[i].Children ?? new List<ClusterEntityDTO> { data[i] }, data[j].Children ?? new List<ClusterEntityDTO> { data[j] }, _distance);
                    result[i][j] = dist;
                    result[j][i] = dist;
                }
            }

            return result;
        }

        private string GetName(int counter)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            StringBuilder builder = new StringBuilder();

            if (counter > alpha.Length)
            {

            }
            else
            {
                builder.Append(alpha[counter]);
            }

            return builder.ToString();
        }
    }

    class HierarchicalUnionObjectsDTO
    {
        public int FirstId { get; set; }
        public int SecondId { get; set; }
        public double Distance { get; set; }
    }
}
