using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Numerics;

namespace TTT.Core.Grid
{
    public interface IGrid<T, S> where T : class, IGridObject<S>
    {
        public num2<int> Size { get; }

        public bool TryPlace(num2<int> point, T val);

        public bool CanPlace(num2<int> point, T val);
        public bool TryGetValueAt(num2<int> point, out T val);
    }
}
