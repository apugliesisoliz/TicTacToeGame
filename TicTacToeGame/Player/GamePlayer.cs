using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Player
{
    public class GamePlayer : IGamePlayer
    {
        private char currentPlayer;
        public GamePlayer()
        {
            currentPlayer = 'X';
        }
        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        }
        public char GetCurrentPlayer() { return currentPlayer; }
    }
}
