using KSTU.ClusterAnalysis.BLL.Interfaces;
using KSTU.ClusterAnalysis.BLL.Services;
using KSTU.Common.DistanceCheckers;
using KSTU.Common.DTOs;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace TestApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            IKMeans _kMeans = new KMeans();
            IDistance _distance = new EuclideanDistance();
            Random rnd = new Random(0);

            int objCount = 10;
            int intrstsCount = 2;
            int clusterCount = 2;

            List<ClusterEntityDTO> clusters = new List<ClusterEntityDTO>();

            for(int i = 0; i < objCount; i++)
            {
                ClusterEntityDTO dTO = new ClusterEntityDTO
                {
                    Name = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now),
                    Id = i
                };
                List<Interest> interests = new List<Interest>();
                Console.WriteLine("___" + dTO.Name + "___");
                for(int j = 0; j < intrstsCount; j++)
                {
                    double rand = Math.Round(rnd.NextDouble() * 200.0);
                    Interest intr = new Interest
                    {
                        Name = string.Format("intr{0:yyyyMMddHHmmss}", DateTime.Now),
                        Weight = rand,
                        Weight2 = rand
                    };
                    Console.WriteLine("--- " + intr.Weight + "---");
                    interests.Add(intr);
                }
                Console.WriteLine("-------------------------------");
                dTO.Interests = interests;
                clusters.Add(dTO);
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-----------------------------------");
            var result = _kMeans.Clustering(clusters, _distance, clusterCount);

            for(int i = 0; i < objCount; i++)
            {
                Console.WriteLine("___" + result[i].Name + "___");
                for (int j = 0; j < intrstsCount; j++)
                    Console.WriteLine("---" + result[i].Interests[j].Weight2 + "---");

                if (i < objCount - 1 && result[i].CentroidId != result[i + 1].CentroidId)
                    Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            }

            Console.ReadLine();
        }


    }
}
