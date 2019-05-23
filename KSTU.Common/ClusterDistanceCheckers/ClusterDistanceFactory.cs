using KSTU.Common.Helpers;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.ClusterDistanceCheckers
{
    public class ClusterDistanceFactory
    {
        public static IClusterDistance GetClusterDistance(byte type)
        {
            switch (type)
            {
                case (byte)EnumClusterDistanceTypes.Centroid:
                    return new UnweightedCentroid();
                case (byte)EnumClusterDistanceTypes.PairWiseMean:
                    return new UnweightedPairwiseMean();
                case (byte)EnumClusterDistanceTypes.FullConnection:
                    return new FullConnection();
                default:
                    return new SingleConnection();
            }
        }
    }
}
