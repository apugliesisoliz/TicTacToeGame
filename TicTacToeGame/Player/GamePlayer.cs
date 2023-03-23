using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Player
{
    public class GamePlayer : IGamePlayer
    {
        private PlayerToken currentPlayer;
        public GamePlayer()
        {
            currentPlayer = PlayerToken.X;
        }
        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == PlayerToken.X ? PlayerToken.O : PlayerToken.X;
        }
        public PlayerToken GetCurrentPlayer() { return currentPlayer; }
    }
}
