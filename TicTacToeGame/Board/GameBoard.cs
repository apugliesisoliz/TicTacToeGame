using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Player;
using TicTacToeGame.Referee;

namespace TicTacToeGame.Board
{
    public class GameBoard : IGameBoard
    {
        private PlayerToken[,] board;
        public GameBoard() 
        {
            InitializeGameBoard();
        }
        public void InitializeGameBoard()
        {
            board = new PlayerToken[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = PlayerToken.Empty;
                }
            }
        }
        public PlayerToken[,] GetGameBoard() { return board; }

        public void MakeMove(int row, int col, IGamePlayer player, IGameReferee referee)
        {

            if (!referee.CheckInvalidMove(row, col, this) && referee.GetGameState() == GameStateEnum.InProgress )
            {
                board[row, col] = player.GetCurrentPlayer();
                referee.IncreaseMoveCount();
                if (!referee.CheckIfGameIsFinished(player, this))
                {
                    player.SwitchPlayer();
                }
            }
        }
    }
}
