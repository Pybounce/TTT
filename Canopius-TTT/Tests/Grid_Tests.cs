using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TTT.Core.Grid;
using TTT.Core.Numerics;

namespace TTT.Tests
{
    [TestFixture]
    public class Grid_Tests
    {
        #region Helpers

        #endregion

        #region TryPlace
        [Test]
        public void TryPlace_IndexNotInBounds_ReturnsFalse()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(100, 100);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.TryPlace(index, gridObj);

            Assert.That(returnVal, Is.False);

        }
        [Test]
        public void TryPlace_GridObjIsNull_ReturnsFalse()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = null;

            bool returnVal = grid.TryPlace(index, gridObj);

            Assert.That(returnVal, Is.False);
        }
        [Test]
        public void TryPlace_IndexInBounds_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.TryPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void TryPlace_IndexUpperLeft_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(0, 0);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.TryPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void TryPlace_IndexLowerRight_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(2, 2);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.TryPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void TryPlace_CellAtIndexAlreadyTaken_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> initialGridObj = new GridObject<int>();

            bool initialCellTaken = grid.TryPlace(index, initialGridObj);

            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.TryPlace(index, gridObj);

            Assert.Multiple(() =>
            {
                Assert.That(initialCellTaken, Is.True);
                Assert.That(returnVal, Is.True);

            });
        }
        #endregion

        #region CanPlace
        [Test]
        public void CanPlace_IndexNotInBounds_ReturnsFalse()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(100, 100);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.False);

        }
        [Test]
        public void CanPlace_GridObjIsNull_ReturnsFalse()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = null;

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.False);
        }
        [Test]
        public void CanPlace_IndexInBounds_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void CanPlace_IndexUpperLeft_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(0, 0);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void CanPlace_IndexLowerRight_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(2, 2);
            GridObject<int> gridObj = new GridObject<int>();

            bool returnVal = grid.CanPlace(index, gridObj);

            Assert.That(returnVal, Is.True);

        }
        [Test]
        public void CanPlace_CellAtIndexAlreadyTakenByNonActiveGridObject_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
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
        [Test]
        public void CanPlace_CellAtIndexAlreadyTakenByActiveGridObject_ReturnsTrue()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> initialGridObj = new GridObject<int>();
            initialGridObj.IsActive = true;
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

        #region TryGetValueAt
        [Test]
        public void TryGetValueAt_IndexNotInBounds_ReturnsFalseAndDefaultVal()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(100, 100);

            bool didGetValue = grid.TryGetValueAt(index, out GridObject<int> val);

            Assert.Multiple(() =>
            {
                Assert.That(didGetValue, Is.False);
                Assert.That(val == (default(GridObject<int>)));

            });
        }
        [Test]
        public void TryGetValueAt_GetsInactiveValue_ReturnsFalseAndActualVal()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = new GridObject<int>();
            bool didPlace = grid.TryPlace(index, gridObj);


            bool didGetValue = grid.TryGetValueAt(index, out GridObject<int> val);

            Assert.Multiple(() =>
            {
                Assert.That(didPlace, Is.True);
                Assert.That(didGetValue, Is.False);
                Assert.That(val == gridObj);

            });
        }
        [Test]
        public void TryGetValueAt_GetsActiveValue_ReturnsTrueAndActualVal()
        {
            Grid<GridObject<int>, int> grid = new Grid<GridObject<int>, int>(new num2<int>(3, 3));
            num2<int> index = new num2<int>(1, 1);
            GridObject<int> gridObj = new GridObject<int>();
            gridObj.IsActive = true;
            bool didPlace = grid.TryPlace(index, gridObj);


            bool didGetValue = grid.TryGetValueAt(index, out GridObject<int> val);

            Assert.Multiple(() =>
            {
                Assert.That(didPlace, Is.True);
                Assert.That(didGetValue, Is.True);
                Assert.That(val == gridObj);

            });
        }
        #endregion

        #region Size_PROPERTY

        #endregion
    }
}
