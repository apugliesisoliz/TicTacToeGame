using System.Numerics;

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
                    verification =  board[i, j] == ' ';
                }
            }
            Assert.IsTrue(verification);
        }

        [Test]
        public void WhenInitializeTheGameTheCurrentPlayerShouldBeX()
        {
            var newGame = new TicTacToe();
            Assert.That(newGame.GetCurrentPlayer(), Is.EqualTo('X'));
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
            Assert.That(newGame.GetGameState(), Is.EqualTo("In Progress"));
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
                    verification = board[i, j] == ' ';
                }
            }
            Assert.IsTrue(verification);
            Assert.That(newGame.GetCurrentPlayer(), Is.EqualTo('X'));
            Assert.That(newGame.GetMoveCount(), Is.EqualTo(0));
            Assert.That(newGame.GetGameState(), Is.EqualTo("In Progress"));
            Assert.That(newGame.GetErrors(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void WhenMakingAMoveTheGameMustSwitchBetweenThePlayers()
        {
            var newGame = new TicTacToe();
            var firstPlayer = newGame.GetCurrentPlayer();
            newGame.MakeMove(0, 0);

            Assert.That(firstPlayer, Is.EqualTo('X'));
            Assert.That(newGame.GetCurrentPlayer, Is.EqualTo('O'));
        }

        [Test]
        public void WhenAPlayerMakeAMoveTheBoardShouldReflectThatAction()
        {
            var newGame = new TicTacToe();
            var currentPlayer = newGame.GetCurrentPlayer();
            newGame.MakeMove(0,0);

            Assert.That(currentPlayer, Is.EqualTo(newGame.GetBoard()[0,0]));
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

            Assert.That(newGame.GetGameState(), Is.EqualTo("Game finished, player X wins"));
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

            Assert.That(newGame.GetBoard()[0,2], Is.EqualTo(' '));
        }

    }
}