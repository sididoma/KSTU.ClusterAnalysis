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
                case (byte)EnumDistanceTypes.Chebyshev:
                    return new ChebyshevDistance();
                case (byte)EnumDistanceTypes.EuclideanSquare:
                    return new EuclideanDistance();
                case (byte)EnumDistanceTypes.Manhattan:
                    return new ManhattanDistance();
                default:
                    return new EuclideanDistance();
            }
        }
    }
}
