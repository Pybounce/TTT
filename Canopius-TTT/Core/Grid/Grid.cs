using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Extensions;
using TTT.Core.Numerics;

namespace TTT.Core.Grid
{
    public class Grid<T, S> : IGrid<T, S> where T : class, IGridObject<S>, new()
    {
        #region Properties/Variables

        public num2<int> Size
        {
            get
            {
                return _size;
            }
            private set
            {
                _size.a = value.a <= 0 ? 1 : value.a;
                _size.b = value.b <= 0 ? 1 : value.b;
            }
        }
        private num2<int> _size;
        private T[,] values;

        #endregion

        #region Constructors
        public Grid(num2<int> size = default)
        {
            Size = size;
            values = InitialiseValues();
        }
        /// <summary>
        /// Sets the default values for the grid (not nulls)
        /// </summary>
        private T[,] InitialiseValues()
        {
            T[,] vals = new T[Size.a, Size.b];
            for (int x = 0; x < Size.a; x++)
            {
                for (int y = 0; y < Size.b; y++)
                {
                    vals[x, y] = new T();
                }
            }
            return vals;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// <br>Will place the grid object at the index and returns true if possibl</br>
        /// <br>Otherwise returns false with no change.</br>
        /// </summary>
        public virtual bool TryPlace(num2<int> point, T val)
        {
            if (CanPlace(point, val))
            {
                return Place(point, val);
            }
            return false;
        }
        /// <summary>
        /// Returns true if the object can be placed at this index, false otherwise.
        /// </summary>
        public virtual bool CanPlace(num2<int> point, T val)
        {
            if (values.InBounds(point) == false) { return false; }
            if (val == null) { return false; }
            return true;
        }
        /// <summary>
        /// Outputs true and the grid object if the index is in bounds
        /// <br>False with the default grid object otherwise.</br>
        /// </summary>
        public bool TryGetValueAt(num2<int> point, out T val)
        {
            val = default;
            if (values.InBounds(point) == false) { return false; }
            val = values[point.a, point.b];
            if (val.IsActive == false) { return false; }
            return true;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Places the object at the index so long as it's in bounds.
        /// <br>Ignores any additional checks.</br>
        /// </summary>
        private bool Place(num2<int> point, T val)
        {
            if (values.InBounds(point) == false) { return false; }
            values[point.a, point.b] = val;
            return true;
        }



        #endregion


    }
}
