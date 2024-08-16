using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDev.Extensions
{
    public static class BoolExtensions
    {
        public static int SwapBoolAndInt(this bool value)
        {
            return value ? 1 : 0;
        }
        public static bool SwapBoolAndInt(this int value)
        {
            return value == 1 ? true : false;
        }
    }

}