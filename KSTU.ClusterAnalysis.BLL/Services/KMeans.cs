using KSTU.ClusterAnalysis.BLL.Interfaces;
using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSTU.ClusterAnalysis.BLL.Services
{
    public class KMeans : IKMeans
    {
        private IDistance _distance;
        public List<ClusterEntityDTO> Clustering(List<ClusterEntityDTO> data, IDistance distance, int clustersCount)
        {
            _distance = distance;
            List<ClusterEntityDTO> clusters = Normlize(data);

            bool changed = true;
            bool success = true;

            List<ClusterEntityDTO> centroids = SetCentroids(ref data, clustersCount);
            int maxIter = clusters.Count * 10;
            int iterCount = 0;
            while (changed && iterCount < maxIter)
            {
                changed = UpdateClusters(ref clusters, ref centroids);
                success = UpdateCentroids(ref clusters, ref centroids);
                iterCount++;
            }

            return clusters.AsEnumerable().OrderBy(g => g.CentroidId).ToList();
        }

        private List<ClusterEntityDTO> Normlize(List<ClusterEntityDTO> clusters)
        {
            List<ClusterEntityDTO> result = new List<ClusterEntityDTO>(clusters);

            for (int j = 0; j < result[0].Interests.Count; j++)
            {
                double columnSum = 0.0;
                for (int i = 0; i < result.Count; i++)
                    columnSum += result[i].Interests[j].Weight;

                double mean = columnSum / result.Count;
                double sum = 0.0;

                for (int i = 0; i < result.Count; i++)
                    sum += (result[i].Interests[j].Weight - mean) * (result[i].Interests[j].Weight - mean);

                double sd = Math.Sqrt(sum / result.Count);

                for (int i = 0; i < result.Count; i++)
                    result[i].Interests[j].Weight = (result[i].Interests[j].Weight - mean) / sd;
            }

            return result;
        }

        private List<ClusterEntityDTO> SetCentroids(ref List<ClusterEntityDTO> clusters, int clustersCount)
        {
            Random rnd = new Random(0);
            List<ClusterEntityDTO> centroids = new List<ClusterEntityDTO>();
            for (int i = 0; i < clustersCount; i++)
            {
                ClusterEntityDTO dTO = clusters[rnd.Next(0, clusters.Count - 1)];
                if (centroids.Contains(dTO))
                {
                    i--;
                }
                else
                {
                    centroids.Add(dTO);
                }
            }
            return centroids;
        }

        private bool UpdateClusters(ref List<ClusterEntityDTO> clusters, ref List<ClusterEntityDTO> centroids)
        {
            double[] distance = new double[centroids.Count];
            bool changes = false;


            for (int i = 0; i < centroids.Count; i++)
            {
                centroids[i].ClustersCount = 0;
            }

            for (int i = 0; i < clusters.Count; i++)
            {
                for (int j = 0; j < centroids.Count; j++)
                {
                    distance[j] = _distance.GetDinstance(clusters[i], centroids[j]);
                }
                int clId = GetIndexOfMin(distance);

                if (clId != clusters[i].CentroidId)
                {
                    changes = true;
                    clusters[i].CentroidId = clId;
                }
                centroids[clId].ClustersCount++;
            }

            if (!changes)
                return false;

            if (centroids.Where(x => x.ClustersCount == 0).Count() > 0)
                return true;

            return changes;
        }

        private bool UpdateCentroids(ref List<ClusterEntityDTO> clusters, ref List<ClusterEntityDTO> centroids)
        {
            if (centroids.Where(x => x.ClustersCount == 0).Count() > 0)
                return true;

            for (int k = 0; k < centroids.Count; k++)
                for (int j = 0; j < centroids[k].Interests.Count; j++)
                {
                    centroids[k].Interests[j].Weight = 0.0;
                }

            for (int i = 0; i < clusters.Count; i++)
            {
                int clusterId = clusters[i].CentroidId;
                for (int j = 0; j < clusters[i].Interests.Count; j++)
                {
                    centroids[clusterId].Interests[j].Weight += clusters[i].Interests[j].Weight;
                }
            }

            for (int k = 0; k < centroids.Count; k++)
                for (int j = 0; j < centroids[k].Interests.Count; j++)
                    centroids[k].Interests[j].Weight /= centroids[k].ClustersCount;
            return true;
        }

        private int GetIndexOfMin(double[] data)
        {
            double min = double.MaxValue;
            int minId = -1;
            for (int i = 0; i < data.Length; i++)
            {
                if (min > data[i])
                {
                    min = data[i];
                    minId = i;
                }
            }
            return minId;
        }
    }
}
