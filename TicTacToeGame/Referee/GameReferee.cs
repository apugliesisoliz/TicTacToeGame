using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Referee
{
    public class GameReferee: IGameReferee
    {
        private string gameState;
        private int moveCount;
        public GameReferee()
        {
            gameState = "In Progress";
            moveCount = 0;
        }
        public string GetGameState() { return gameState; }
        public void SetGameState(string state) { gameState = state; }
        public void IncreaseMoveCount() { moveCount++; }
        public int GetMoveCount() { return moveCount; }
    }
}
