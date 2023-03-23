﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Board;

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

        public char[,] GetBoard() { return resources.Board.GetGameBoard(); }
        public char GetCurrentPlayer() { return resources.GamePlayer.GetCurrentPlayer(); }
        public int GetMoveCount() { return resources.GameReferee.GetMoveCount(); }
        public string GetGameState() { return resources.GameReferee.GetGameState(); }
        public string GetErrors() { return resources.Board.GetErrors(); }
        public void Reset() { InitializeVariables(); }


        public void MakeMove(int row, int col)
        {
            resources.Board.MakeMove(row, col,resources.GamePlayer, resources.GameReferee);
        }

    }
}