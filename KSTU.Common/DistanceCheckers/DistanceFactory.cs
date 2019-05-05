using KSTU.Common.Helpers;
using KSTU.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.DistanceCheckers
{
    public static  class DistanceFactory
    {
        public static IDistance GetDistance(byte type)
        {
            switch (type)
            {
                case (byte)DistanceTypes.Chebyshev:
                    return new ChebyshevDistance();
                case (byte)DistanceTypes.EuclideanSquare:
                    return new EuclideanDistance();
                case (byte)DistanceTypes.Manhattan:
                    return new ManhattanDistance();
                default:
                    return new EuclideanDistance();
            }
        }
    }
}
