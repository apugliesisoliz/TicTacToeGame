﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Player
{
    public interface IGamePlayer
    {
        void SwitchPlayer();
        PlayerToken GetCurrentPlayer();
    }
}
