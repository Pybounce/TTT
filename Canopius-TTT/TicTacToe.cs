using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Extensions;
using TTT.Core.Grid;
using TTT.Core.Numerics;

namespace TTT
{
    public class TicTacToe : IGame
    {

        private readonly IGrid<GridObject<string>, string> _grid;
        /// <summary>
        /// The amount of cells a player must get in a row to win
        /// </summary>
        private readonly int _countToWin;

        private bool _stalemateConditionMet = false;
        private bool _winConditionMet = false;
        private string _winner = "";

        private GridObject<string>[] _playerGridObjects;
        private int _currentPlayerIndex = 0;
        public string CurrentPlayer => _playerGridObjects[_currentPlayerIndex % _playerGridObjects.Length].Data;

        public TicTacToe(num2<int> size, int countToWin = 3)
        {

            _grid = new NoOverlapGrid<GridObject<string>, string>(size);
            _countToWin = countToWin <= 0 ? 1 : countToWin;
            _currentPlayerIndex = -1;
            _playerGridObjects = new GridObject<string>[2]
            {
                new GridObject<string>(new num2<int>(1, 1), true, "X"),
                new GridObject<string>(new num2<int>(1, 1), true, "O")
            };
        }
        /// <summary>
        /// Returns the rules necessary to win the game.
        /// </summary>
        public string GetRules()
        {
            return string.Format("Attain {0} in a row to win. Diagonals included.", _countToWin);
        }
        /// <summary>
        /// Returns false if the game is over (win condition met or stalemate)
        /// <br>Moves to the next players turn and returns true otherwise</br>
        /// </summary>
        public bool NextTurn()
        {
            CheckWinOrStalemate();
            if (_winConditionMet) { return false; }
            if (_stalemateConditionMet) { return false; }
            MoveToNextPlayer();
            return true;
        }
        /// <summary>
        /// Returns true if a winner has been found, false otherwise
        /// <br>Outputs a winner string regardless, but should only be used if true</br>
        /// </summary>
        public bool TryGetWinner(out string winner)
        {
            winner = _winner;
            return _winConditionMet;
        }
        /// <summary>
        /// Will make the player's turn if possible, if not it will return false with no changes made.
        /// </summary>
        /// <param name="reason">States why the player's turn failed.</param>
        /// <returns></returns>
        public bool TryMakeTurn(int index, out string reason)
        {
            reason = "";
            if (index.TryTo2DIndex(_grid.Size, out num2<int> index2D) == false) {
                reason = "Input out of grid bounds";
                return false; 
            }
            if (_grid.TryPlace(index2D, _playerGridObjects[_currentPlayerIndex]) == false) {
                reason = "Cannot place tile there!";
                return false; }
            return true;
        }

        private void MoveToNextPlayer()
        {
            _currentPlayerIndex += 1;
            _currentPlayerIndex %= _playerGridObjects.Length;
        }

        /// <summary>
        /// A genuine low point in my life.
        ///<br>View at your own risk.</br>
        ///<br>The only reason this is staying is because it's self contained to the one method and can be refactored later.</br>
        /// </summary>
        private void CheckWinOrStalemate()
        {
            int currentStreak = 0;
            string currentVal = "";
            for (int b = 1 - _grid.Size.a; b < _grid.Size.b; b++)
            {
                //Moving along the top row of the grid
                currentStreak = 0;
                currentVal = "";
                for (int da = 0; da < _grid.Size.a; da++)
                {
                    //Checking each diagonal down right
                    if (_grid.TryGetValueAt(new num2<int>(da, b + da), out GridObject<string> val))
                    {
                        if (val.Data == currentVal) { currentStreak += 1; }
                        else
                        {
                            currentStreak = 1;
                            currentVal = val.Data;
                        }
                        if (currentStreak >= _countToWin)
                        {
                            _winConditionMet = true;
                            _winner = CurrentPlayer;
                        }
                    }
                }
            }
            for (int b = 1 - _grid.Size.a; b < _grid.Size.b; b++)
            {
                //Moving along the top row of the grid
                currentStreak = 0;
                currentVal = "";
                for (int da = 0; da < _grid.Size.a; da++)
                {
                    //Checking each diagonal down left
                    if (_grid.TryGetValueAt(new num2<int>(da, b - da), out GridObject<string> val))
                    {
                        if (val.Data == currentVal) { currentStreak += 1; }
                        else
                        {
                            currentStreak = 1;
                            currentVal = val.Data;
                        }
                        if (currentStreak >= _countToWin)
                        {
                            _winConditionMet = true;
                            _winner = CurrentPlayer;
                        }
                    }
                }
            }
            for (int a = 0; a < _grid.Size.a; a++)
            {
                //horizontal checks
                currentStreak = 0;
                currentVal = "";
                for (int b = 0; b < _grid.Size.b; b++)
                {
                    //horizontal checks
                    if (_grid.TryGetValueAt(new num2<int>(a, b), out GridObject<string> val))
                    {
                        if (val.Data == currentVal) { currentStreak += 1; }
                        else
                        {
                            currentStreak = 1;
                            currentVal = val.Data;
                        }
                        if (currentStreak >= _countToWin)
                        {
                            _winConditionMet = true;
                            _winner = CurrentPlayer;
                        }
                    }
                }
            }
            int totalCellsUsed = 0;
            for (int b = 0; b < _grid.Size.b; b++)
            {
                //horizontal checks
                currentStreak = 0;
                currentVal = "";
                for (int a = 0; a < _grid.Size.a; a++)
                {
                    //horizontal checks
                    if (_grid.TryGetValueAt(new num2<int>(a, b), out GridObject<string> val))
                    {
                        totalCellsUsed += 1;
                        if (val.Data == currentVal) { currentStreak += 1; }
                        else
                        {
                            currentStreak = 1;
                            currentVal = val.Data;
                        }
                        if (currentStreak >= _countToWin)
                        {
                            _winConditionMet = true;
                            _winner = CurrentPlayer;
                        }
                    }
                }
            }
            if (totalCellsUsed >= _grid.Size.a * _grid.Size.b) { _stalemateConditionMet = true; }
        }

    }
}


//the tictactoe should keep track of who won
//cannot rely on the game controller to figure it out
//if it checks every 2 turns (for some reason), it would say the game was won, but there would be no way of knowing who won.