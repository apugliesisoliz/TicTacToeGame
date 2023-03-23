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
        private string errors;
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
            errors = string.Empty;
        }
        public PlayerToken[,] GetGameBoard() { return board; }
        public string GetErrors() { return errors; }

        public void MakeMove(int row, int col, IGamePlayer player, IGameReferee referee)
        {

            if (!CheckInvalidMove(row, col) && !CheckIfGameIsFinished(player, referee))
            {
                board[row, col] = player.GetCurrentPlayer();
                referee.IncreaseMoveCount();
                if (!CheckIfGameIsFinished(player, referee))
                {
                    player.SwitchPlayer();
                }
            }
        }
        private bool CheckIfGameIsFinished(IGamePlayer player, IGameReferee referee)
        {
            var currentPlayer = player.GetCurrentPlayer();
            var check = board[0, 0] == currentPlayer && board[0, 1] == currentPlayer && board[0, 2] == currentPlayer ||
                    board[1, 0] == currentPlayer && board[1, 1] == currentPlayer && board[1, 2] == currentPlayer ||
                    board[2, 0] == currentPlayer && board[2, 1] == currentPlayer && board[2, 2] == currentPlayer ||
                    board[0, 0] == currentPlayer && board[1, 0] == currentPlayer && board[2, 0] == currentPlayer ||
                    board[0, 1] == currentPlayer && board[1, 1] == currentPlayer && board[2, 1] == currentPlayer ||
                    board[0, 2] == currentPlayer && board[1, 2] == currentPlayer && board[2, 2] == currentPlayer ||
                    board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer ||
                    board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer;
            referee.SetGameState( check ? $"Game finished, player {currentPlayer} wins" : referee.GetGameState());
            return check;
        }
        private bool CheckInvalidMove(int row, int col)
        {
            var checkOutOfBoundaries = row < 0 || row > 2 || col < 0 || col > 2;
            errors += checkOutOfBoundaries ? "Invalid move! row and column must be between 1 and 3. /n" : "";

            var checkSpaceOcupied = board[row, col] != PlayerToken.Empty;
            errors += checkSpaceOcupied ? "Invalid move! That space is already taken." : "";

            return checkOutOfBoundaries || checkSpaceOcupied;
        }
    }
}
