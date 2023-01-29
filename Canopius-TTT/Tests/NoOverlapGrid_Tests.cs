using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Grid;
using TTT.Core.Numerics;

namespace TTT.Tests
{
    [TestFixture]
    public class NoOverlapGrid_Tests
    {
        #region CanPlace
        [Test]
        public void CanPlace_IndexNotInBounds_ReturnsFalse()
        {
            NoOverlapGrid<GridObject<int>, int> grid = new NoOverlapGrid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(100, 100);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.False);

        }
        [Test]
        public void CanPlace_GridObjIsNull_ReturnsFalse()
        {
            NoOverlapGrid<GridObject<int>, int> grid = new NoOverlapGrid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = null;

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.False);
        }
        [Test]
        public void CanPlace_IndexInBounds_ReturnsTrue()
        {
            NoOverlapGrid<GridObject<int>, int> grid = new NoOverlapGrid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void CanPlace_IndexUpperLeft_ReturnsTrue()
        {
            NoOverlapGrid<GridObject<int>, int> grid = new NoOverlapGrid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(0, 0);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void CanPlace_IndexLowerRight_ReturnsTrue()
        {
            NoOverlapGrid<GridObject<int>, int> grid = new NoOverlapGrid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(2, 2);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void CanPlace_CellAtIndexAlreadyTakenByActiveGridObject_ReturnsFalse()
        {
            NoOverlapGrid<GridObject<int>, int> grid = new NoOverlapGrid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> initialGridObj = new GridObject<int>();
            initialGridObj.IsActive = true;
            bool initialCellTaken = grid.TryPlace(index, initialGridObj);

            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.Multiple(() =>
            {
                Assert.That(initialCellTaken, Is.True);
                Assert.That(returnVal, Is.False);

            });
        }
        [Test]
        public void CanPlace_CellAtIndexAlreadyTakenByNonActiveGridObject_ReturnsTrue()
        {
            NoOverlapGrid<GridObject<int>, int> grid = new NoOverlapGrid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> initialGridObj = new GridObject<int>();

            bool initialCellTaken = grid.TryPlace(index, initialGridObj);

            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.Multiple(() =>
            {
                Assert.That(initialCellTaken, Is.True);
                Assert.That(returnVal, Is.True);

            });
        }
        #endregion
    }
}
