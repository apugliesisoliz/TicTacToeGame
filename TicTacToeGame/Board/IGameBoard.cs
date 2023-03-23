using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Player;
using TicTacToeGame.Referee;

namespace TicTacToeGame.Board
{
    public interface IGameBoard
    {
        void InitializeGameBoard();
        char[,] GetGameBoard();
        string GetErrors();
        void MakeMove(int row, int col, IGamePlayer player, IGameReferee referee);
    }
}
