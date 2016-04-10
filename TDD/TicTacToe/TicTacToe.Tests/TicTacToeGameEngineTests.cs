using System;
using Moq;
using NUnit.Framework;
using TicTacToe.Core;
using TicTacToe.Core.ExternalSystem;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class TicTacToeGameEngineTests
    {
        private GameEngine _gameEngine;
        private string[,] _board;
        private Mock<ICommonGameNetworkControl> _networkInterfaceMock;

        [SetUp]
        public void SetupTest()
        {
            _networkInterfaceMock = new Mock<ICommonGameNetworkControl>();
            _gameEngine = new GameEngine(_networkInterfaceMock.Object);
            _board = new[,] { { "", "", "" }, { "", "", "" }, { "", "", "" } };

        }

        [Test]
        public void IfBoardIsEmptyThenThereIsNoWinner()
        {
            //Arrainge
            var expectedResult = "";

            //Act
            var result = _gameEngine.GetWinner(_board);

            //Assert       
            Assert.AreEqual(expectedResult, result);  
        }

        [Test]
        public void WhenAllTheTopRowCellsHaveAnXThenXWins()
        {
            //Arrainge
            _board[0, 0] = "X";
            _board[0, 1] = "X";
            _board[0, 2] = "X";
            var expectedResult = "X";

            //Act
            var result = _gameEngine.GetWinner(_board);

            //Assert       
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldBeAbleToLogonWithCorrectUserNameAndPassword()
        {
            //arr
            var userName = "James";
            var password = "ILoveBacon";
            var expectedResult = Guid.NewGuid();

            _networkInterfaceMock.Setup(x => x.Login(userName, password))
                .Returns(expectedResult);

            //act
            var result = _gameEngine.Login(userName, password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void LoginShouldFailWhenTheUserNameIsEmptyButPasswordIsNot()
        {
            //arr
            var userName = "";
            var password = "ILoveBacon";
            var invalidSessionId = Guid.Empty;

            _networkInterfaceMock.Setup(x => x.Login(userName, password))
                .Returns(invalidSessionId);

            //act
            var result = _gameEngine.Login(userName, password);

            //assert
            Assert.AreNotEqual(invalidSessionId, result);
        }
    }
}
