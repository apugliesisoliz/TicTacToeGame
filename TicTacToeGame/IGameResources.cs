using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Board;
using TicTacToeGame.Player;
using TicTacToeGame.Referee;

namespace TicTacToeGame
{
    public interface IGameResources
    {
        IGameBoard Board { get; }
        IGameReferee GameReferee { get; }
        IGamePlayer GamePlayer { get; }
    }
}
