using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Numerics;

namespace TTT.Core.Grid
{
    public class GridObject<T> : IGridObject<T>
    {
        public T Data { get; set; }
        public bool IsActive { get; set; }
        public num2<int> Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size.a = value.a <= 0 ? 1 : value.a;
                _size.b = value.b <= 0 ? 1 : value.b;
            }
        }
        private num2<int> _size;
        public GridObject()
        {
            Size = default;
            IsActive = default;
            Data = default;
        }
        public GridObject(num2<int> size, bool isActive, T data)
        {
            Size = size;
            IsActive = isActive;
            Data = data;
        }
    }
}
