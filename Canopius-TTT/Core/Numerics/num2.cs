using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TTT.Core.Numerics
{
    public struct num2<T> where T : INumber<T>
    {
        public T a { get; set; }
        public T b { get; set; }

        public num2(T a, T b)
        {
            this.a = a;
            this.b = b;
        }

    }
}
