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
    public class GameResources : IGameResources
    {
        private IGameBoard board;
        private IGameReferee referee;
        private IGamePlayer player;
        public IGameBoard Board
        {
            get
            {
                if (board == null)
                {
                    board = new GameBoard();
                }
                return board;
            }
        }
        public IGameReferee GameReferee
        {
            get
            {
                if (referee == null)
                {
                    referee = new GameReferee();
                }
                return referee;
            }
        }
        public IGamePlayer GamePlayer
        {
            get
            {
                if (player == null)
                {
                    player = new GamePlayer();
                }
                return player;
            }
        }
    }
}
