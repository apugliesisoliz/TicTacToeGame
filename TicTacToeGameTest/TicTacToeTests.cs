using System.Numerics;
using TicTacToeGame.Player;
using TicTacToeGame.Referee;

namespace TicTacToeGameTest
{
    public class Tests
    {
        private TicTacToe _ticTacToe;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenInitializeTheGameShouldHaveAnEmptyBoard()
        {
            var newGame = new TicTacToe();
            var board = newGame.GetBoard();
            var verification = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    verification =  board[i, j] == PlayerToken.Empty;
                }
            }
            Assert.IsTrue(verification);
        }

        [Test]
        public void WhenInitializeTheGameTheCurrentPlayerShouldBeX()
        {
            var newGame = new TicTacToe();
            Assert.That(newGame.GetCurrentPlayer(), Is.EqualTo(PlayerToken.X));
        }

        [Test]
        public void WhenInitializeTheGameTeMoveCountShouldBe0()
        {
            var newGame = new TicTacToe();
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(0));
        }

        [Test]
        public void WhenInitializeTheGameTheStateShouldBeInProgres()
        {
            var newGame = new TicTacToe();
            Assert.That(newGame.GetGameState(), Is.EqualTo(GameStateEnum.InProgress));
            Assert.That(newGame.GetGameMessage(), Is.EqualTo("In Progress"));
        }

        [Test]
        public void WhenInitializeTheGameTheErrorsShouldBeInBlank()
        {
            var newGame = new TicTacToe();
            Assert.That(newGame.GetErrors(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void WhenResetingTheGameShouldBeLikeItIsANewGame()
        {
            var newGame = new TicTacToe();
            newGame.Reset();
            var board = newGame.GetBoard();
            var verification = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    verification = board[i, j] == PlayerToken.Empty;
                }
            }
            Assert.IsTrue(verification);
            Assert.That(newGame.GetCurrentPlayer(), Is.EqualTo(PlayerToken.X));
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(0));
            Assert.That(newGame.GetGameState(), Is.EqualTo(GameStateEnum.InProgress));
            Assert.That(newGame.GetGameMessage(), Is.EqualTo("In Progress"));
            Assert.That(newGame.GetErrors(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void WhenMakingAMoveTheGameMustSwitchBetweenThePlayers()
        {
            var newGame = new TicTacToe();
            var firstPlayer = newGame.GetCurrentPlayer();
            newGame.MakeMove(0, 0);

            Assert.That(firstPlayer, Is.EqualTo(PlayerToken.X));
            Assert.That(newGame.GetCurrentPlayer, Is.EqualTo(PlayerToken.O));
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(1));
        }

        [Test]
        public void WhenAPlayerMakeAMoveTheBoardShouldReflectThatAction()
        {
            var newGame = new TicTacToe();
            var currentPlayer = newGame.GetCurrentPlayer();
            newGame.MakeMove(0,0);

            Assert.That(currentPlayer, Is.EqualTo(newGame.GetBoard()[0,0]));
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(1));
        }

        [Test]
        public void WhenAPlayerWinsTheStateOfTheGameShouldReflectThat()
        {
            var newGame = new TicTacToe();
            newGame.MakeMove(0, 0);
            newGame.MakeMove(1, 0);
            newGame.MakeMove(1, 1);
            newGame.MakeMove(2, 0);
            newGame.MakeMove(2, 2);

            Assert.That(newGame.GetGameMessage(), Is.EqualTo("Game finished, player X wins"));
            Assert.That(newGame.GetGameState(), Is.EqualTo(GameStateEnum.Win));
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(5));
        }

        [Test]
        public void WhenAPlayerWinsTheBoardShouldStopTrackingPlayerMoves()
        {
            var newGame = new TicTacToe();
            newGame.MakeMove(0, 0);
            newGame.MakeMove(1, 0);
            newGame.MakeMove(1, 1);
            newGame.MakeMove(2, 0);
            newGame.MakeMove(2, 2);
            newGame.MakeMove(0, 2);

            Assert.That(newGame.GetBoard()[0,2], Is.EqualTo(PlayerToken.Empty));
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(5));
        }

        [Test]
        public void WhenThereIsNoMoreBlankSpacesTheRefereeShouldDeclareATie()
        {
            var newGame = new TicTacToe();
            newGame.MakeMove(0, 0);
            newGame.MakeMove(1, 1);
            newGame.MakeMove(0, 2);
            newGame.MakeMove(0, 1);
            newGame.MakeMove(2, 1);
            newGame.MakeMove(1, 2);
            newGame.MakeMove(1, 0);
            newGame.MakeMove(2, 0);
            newGame.MakeMove(2, 2);

            Assert.That(newGame.GetGameMessage(), Is.EqualTo("Game finished, Tie"));
            Assert.That(newGame.GetGameState(), Is.EqualTo(GameStateEnum.Tie));
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(9));
        }

    }
}