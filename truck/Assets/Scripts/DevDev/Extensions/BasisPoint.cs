using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDev.Extensions
{
    public static class BasisPointExtensions
    {
        public static long ToInt(this BasisPoint basisPoint)
        {
            double result = basisPoint.value * 0.0001f;
            return (int)result;
        }
        public static long ToLong(this BasisPoint basisPoint)
        {
            double result = basisPoint.value * 0.0001f;
            return (long)result;
        }
        public static float ToFloat(this BasisPoint basisPoint)
        {
            float result = basisPoint.value * 0.0001f;
            return result;
        }
        public static double ToDouble(this BasisPoint basisPoint)
        {
            double result = basisPoint.value * 0.0001;
            return result;
        }
        public static BasisPoint ToBasisPoint(this long value)
        {
            return new BasisPoint(value * 10000);
        }
        public static BasisPoint ToBasisPoint(this double value)
        {
            return new BasisPoint((long)(value * 10000));
        }

    }
    //만분율
    // BasisPoint value new BasisPoint(10000) == 1
    public struct BasisPoint
    {
        public static BasisPoint operator+(BasisPoint a, BasisPoint b) => new BasisPoint(a.value + b.value);
        public static BasisPoint operator-(BasisPoint a, BasisPoint b) => new BasisPoint(a.value - b.value);
        public static BasisPoint operator*(BasisPoint a, BasisPoint b)
        {
            double result = a.value * b.value;
            return new BasisPoint((long)(result * 0.0001));
        }
        public static BasisPoint operator/(BasisPoint a, BasisPoint b)
        {
            long value = a.value * 10000;
            double result = value / b.value;
            return new BasisPoint((long)(result));
        }
        public static BasisPoint operator*(BasisPoint a, double b) => new BasisPoint((long)(a.value * b));
        public static BasisPoint operator/(BasisPoint a, double b) => new BasisPoint((long)(a.value / b));
        public static BasisPoint operator+(BasisPoint a, long b) => new BasisPoint(a.value + (b*10000));
        public static BasisPoint operator-(BasisPoint a, long b) => new BasisPoint(a.value - (b*10000));
        public static BasisPoint operator+(BasisPoint a, double b) => new BasisPoint(a.value + (long)(b*10000));
        public static BasisPoint operator-(BasisPoint a, double b) => new BasisPoint(a.value - (long)(b*10000));


        public long value;

        public BasisPoint(long value)
        {
            this.value = value;
        }
    }
}
