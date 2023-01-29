using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Numerics;

namespace TTT.Core.Grid
{
    public interface IGridObject<T>
    {
        /// <summary>
        /// True if the object is avtually set and being used.
        /// <br>IGridObject could be implemented in a struct, where it would be impossible to tell since there is no nulls.</br>
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// Amount of cells taken up by the grid object.
        /// </summary>
        num2<int> Size { get; }
        /// <summary>
        /// The data the grid object holds
        /// </summary>
        T Data { get; }
    }
}
