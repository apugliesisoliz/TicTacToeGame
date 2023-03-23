using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Referee
{
    public interface IGameReferee
    {
        string GetGameState();
        void SetGameState(string state);
        void IncreaseMoveCount();
        int GetMoveCount();
    }
}
