using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Board;
using TicTacToeGame.Player;
using TicTacToeGame.Referee;

namespace TicTacToeGame
{
    public class TicTacToe
    {
        private static IGameResources resources;

        public TicTacToe() => InitializeVariables();

        private void InitializeVariables()
        {
            resources = new GameResources();
        }

        public PlayerToken[,] GetBoard() { return resources.Board.GetGameBoard(); }
        public PlayerToken GetCurrentPlayer() { return resources.GamePlayer.GetCurrentPlayer(); }
        public int GetMoveCount() { return resources.GameReferee.GetMoveCount(); }
        public GameStateEnum GetGameState() { return resources.GameReferee.GetGameState(); }
        public string GetGameMessage() { return resources.GameReferee.GetGameMessage(); }
        public string GetErrors() { return resources.GameReferee.GetErrors(); }
        public void Reset() { InitializeVariables(); }


        public void MakeMove(int row, int col)
        {
            resources.Board.MakeMove(row, col,resources.GamePlayer, resources.GameReferee);
        }

    }
}
