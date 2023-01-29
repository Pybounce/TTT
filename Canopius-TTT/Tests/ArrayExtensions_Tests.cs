using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Extensions;
using TTT.Core.Numerics;

namespace TTT.Tests
{
    [TestFixture]
    public class ArrayExtensions_Tests
    {
        #region InBounds
        [Test]
        public void InBounds_ArrayNull_ReturnsFalse()
        {
            int[,] arr = null;
            num2<int> index = new num2<int>(0, 0);

            bool result = arr.InBounds(index);

            Assert.That(result, Is.False);
        }
        [Test]
        public void InBounds_NegativeIndex_ReturnsFalse()
        {
            int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            num2<int> index = new num2<int>(-2, -1);

            bool result = arr.InBounds(index);

            Assert.That(result, Is.False);
        }
        [Test]
        public void InBounds_IndexValueEqualToArrayLength_ReturnsFalse()
        {
            int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            num2<int> index = new num2<int>(3, 3);

            bool result = arr.InBounds(index);

            Assert.That(result, Is.False);
        }
        [Test]
        public void InBounds_IndexValueGreaterThanArrayLength_ReturnsFalse()
        {
            int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            num2<int> index = new num2<int>(4, 5);

            bool result = arr.InBounds(index);

            Assert.That(result, Is.False);
        }
        [Test]
        public void InBounds_IndexValueLessThanArrayLength_ReturnsTrue()
        {
            int[,] arr = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            num2<int> index = new num2<int>(2, 1);

            bool result = arr.InBounds(index);

            Assert.That(result, Is.True);
        }
        #endregion

        #region TryTo2DIndex
        [Test]
        public void TryTo2DIndex_NegativeIndex_ReturnsFalseWithZeroIndex()
        {
            num2<int> arrSize = new num2<int>(2, 3);
            int index1D = -5;
            num2<int> defaultIndex = new num2<int>();

            bool didConvert = index1D.TryTo2DIndex(arrSize, out num2<int> index2D);

            Assert.Multiple(() =>
            {
                Assert.That(didConvert, Is.False);
                Assert.That(index2D, Is.EqualTo(defaultIndex));
            });
        }
        [Test]
        public void TryTo2DIndex_IndexGreaterThanBounds_ReturnsFalseWithZeroIndex()
        {
            num2<int> arrSize = new num2<int>(2, 3);
            int index1D = 5000;
            num2<int> defaultIndex = new num2<int>();

            bool didConvert = index1D.TryTo2DIndex(arrSize, out num2<int> index2D);

            Assert.Multiple(() =>
            {
                Assert.That(didConvert, Is.False);
                Assert.That(index2D, Is.EqualTo(defaultIndex));
            });
        }
        [Test]
        public void TryTo2DIndex_ArraySizeZero_ReturnsFalseWithZeroIndex()
        {
            num2<int> arrSize = new num2<int>(0, 3);
            int index1D = 5;
            num2<int> defaultIndex = new num2<int>();

            bool didConvert = index1D.TryTo2DIndex(arrSize, out num2<int> index2D);

            Assert.Multiple(() =>
            {
                Assert.That(didConvert, Is.False);
                Assert.That(index2D, Is.EqualTo(defaultIndex));
            });
        }
        [Test]
        public void TryTo2DIndex_ArrayNegativeSize_ReturnsFalseWithZeroIndex()
        {
            num2<int> arrSize = new num2<int>(2, -3);
            int index1D = 5;
            num2<int> defaultIndex = new num2<int>();

            bool didConvert = index1D.TryTo2DIndex(arrSize, out num2<int> index2D);

            Assert.Multiple(() =>
            {
                Assert.That(didConvert, Is.False);
                Assert.That(index2D, Is.EqualTo(defaultIndex));
            });
        }
        [Test]
        public void TryTo2DIndex_ArrayEqualHeightAndWidth_ReturnsTrueWithCorrect2DIndex()
        {
            num2<int> arrSize = new num2<int>(3, 3);
            int index1D = 5;
            num2<int> true2DIndex = new num2<int>(1, 2);

            bool didConvert = index1D.TryTo2DIndex(arrSize, out num2<int> index2D);

            Assert.Multiple(() =>
            {
                Assert.That(didConvert, Is.True);
                Assert.That(index2D, Is.EqualTo(true2DIndex));
            });
        }
        [Test]
        public void TryTo2DIndex_ArrayNonEqualHeightAndWidth_ReturnsTrueWithCorrect2DIndex()
        {
            num2<int> arrSize = new num2<int>(3, 6);
            int index1D = 13;
            num2<int> true2DIndex = new num2<int>(2, 1);

            bool didConvert = index1D.TryTo2DIndex(arrSize, out num2<int> index2D);

            Assert.Multiple(() =>
            {
                Assert.That(didConvert, Is.True);
                Assert.That(index2D, Is.EqualTo(true2DIndex));
            });
        }
        #endregion
    }

}
