using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Numerics;

namespace TTT.Core.Extensions
{
    public static class ArrayExtensions
    {

        public static bool InBounds<T>(this T[,] arr, num2<int> point)
        {
            if (arr == null) { return false; }
            if (point.a < 0 || point.a >= arr.GetLength(0)) { return false; }
            if (point.b < 0 || point.b >= arr.GetLength(1)) { return false; }
            return true;
        }

        public static bool TryTo2DIndex(this int i, num2<int> size, out num2<int> return2DIndex)
        {
            return2DIndex = new num2<int>();
            if (i < 0) { return false; }
            if (size.a <= 0) { return false; }
            if (size.b <= 0) { return false; }
            return2DIndex = new num2<int>(i / size.b, i % size.b);
            if (return2DIndex.a >= size.a || return2DIndex.b >= size.b)
            {
                return2DIndex = new num2<int>();
                return false;
            }
            return true;
        }
    }
}
