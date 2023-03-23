using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Board;
using TicTacToeGame.Player;

namespace TicTacToeGame.Referee
{
    public interface IGameReferee
    {
        GameStateEnum GetGameState();
        string GetGameMessage();
        string GetErrors();
        void IncreaseMoveCount();
        int GetMoveCount();
        bool CheckInvalidMove(int row, int col, IGameBoard gameBoard);
        bool CheckIfGameIsFinished(IGamePlayer player, IGameBoard gameBoard);
    }
}
