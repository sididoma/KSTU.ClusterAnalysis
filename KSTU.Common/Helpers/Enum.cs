using System;
using System.Collections.Generic;
using System.Text;

namespace KSTU.Common.Helpers
{
    public enum EnumDistanceTypes
    {
        Euclidean = 1,
        EuclideanSquare = 2,
        Manhattan = 3,
        Chebyshev = 4
    }

    public enum EnumDataType
    {
        Text = 1,
        Excel = 2,
        DataBase = 3
    }

    public enum EnumClusterDistanceTypes
    {
        SingleConnection = 1,
        FullConnection = 2,
        PairWiseMean = 3,
        Centroid = 4
    }
}
