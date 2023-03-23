using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Board;
using TicTacToeGame.Player;

namespace TicTacToeGame.Referee
{
    public class GameReferee: IGameReferee
    {
        private GameStateEnum gameState;
        private string gameMessage;
        private string errors;
        private int moveCount;
        public GameReferee()
        {
            gameState = GameStateEnum.InProgress;
            gameMessage = "In Progress";
            moveCount = 0;
            errors= string.Empty;
        }
        public GameStateEnum GetGameState() { return gameState; }
        public string GetGameMessage() { return gameMessage; }
        public string GetErrors() { return errors; }
        public void IncreaseMoveCount() { moveCount++; }
        public int GetMoveCount() { return moveCount; }

        public bool CheckInvalidMove(int row, int col, IGameBoard gameBoard)
        {
            var board = gameBoard.GetGameBoard();
            var checkOutOfBoundaries = row < 0 || row > 2 || col < 0 || col > 2;
            errors += checkOutOfBoundaries ? "Invalid move! row and column must be between 1 and 3. /n" : "";

            var checkSpaceOcupied = board[row, col] != PlayerToken.Empty;
            errors += checkSpaceOcupied ? "Invalid move! That space is already taken." : "";

            return checkOutOfBoundaries || checkSpaceOcupied;
        }

        public bool CheckIfGameIsFinished(IGamePlayer player, IGameBoard gameBoard)
        {
            var board = gameBoard.GetGameBoard();
            var currentPlayer = player.GetCurrentPlayer();
            var currentPlayerWins = CheckIfCurrentPlayerWins(currentPlayer, board);
            var nextPlayerCanMakeAMove = !CheckIfNextPlayerCanMakeAMove(board);
            if (currentPlayerWins)
            {
                gameState = GameStateEnum.Win;
                gameMessage = $"Game finished, player {currentPlayer} wins";
            }
            if (nextPlayerCanMakeAMove)
            {
                gameState = GameStateEnum.Tie;
                gameMessage = "Game finished, Tie";
            }
            return currentPlayerWins || nextPlayerCanMakeAMove;
        }

        private bool CheckIfNextPlayerCanMakeAMove(PlayerToken[,] board)
        {
            var check = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == PlayerToken.Empty)
                    {
                        check= true;
                    }
                }
            }
            return check;
        }

        private bool CheckIfCurrentPlayerWins(PlayerToken currentPlayer, PlayerToken[,] board )
        {
            var checkIfPlayerWins = board[0, 0] == currentPlayer && board[0, 1] == currentPlayer && board[0, 2] == currentPlayer ||
                    board[1, 0] == currentPlayer && board[1, 1] == currentPlayer && board[1, 2] == currentPlayer ||
                    board[2, 0] == currentPlayer && board[2, 1] == currentPlayer && board[2, 2] == currentPlayer ||
                    board[0, 0] == currentPlayer && board[1, 0] == currentPlayer && board[2, 0] == currentPlayer ||
                    board[0, 1] == currentPlayer && board[1, 1] == currentPlayer && board[2, 1] == currentPlayer ||
                    board[0, 2] == currentPlayer && board[1, 2] == currentPlayer && board[2, 2] == currentPlayer ||
                    board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer ||
                    board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer;

            return checkIfPlayerWins;
        }
    }
}
