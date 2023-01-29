using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Numerics;

namespace TTT.Core.Grid
{
    public class NoOverlapGrid<T, S> : Grid<T, S> where T : class, IGridObject<S>, new()
    {
        public NoOverlapGrid(num2<int> size) : base(size) { }


        override public bool CanPlace(num2<int> point, T val)
        {
            if (base.CanPlace(point, val) == false) { return false; }
            if (IsPointTaken(point)) { return false; }
            return true;
        }

        /// <summary>
        /// Returns true if the value at the given point is not equal to the default value.
        /// <br>Does not account for non-nullables/boxed value types</br>
        /// </summary>
        private bool IsPointTaken(num2<int> point)
        {
            TryGetValueAt(point, out T val);
            if (val == null) { return false; }
            if (val.IsActive == false) { return false; }
            return true;
        }
    }
}
