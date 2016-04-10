using System;
using Ninject;
using NUnit.Framework;
using TicTacToe.Core;

namespace TicTacToe.IntegrationTests
{
    [TestFixture]
    public class BlamoIntegrationTests
    {
        private GameEngine _gameEngine;

        [SetUp]
        public void SetupFixture()
        {
            var kernel = new StandardKernel(new TicTacToeModule());
            _gameEngine = kernel.Get<GameEngine>();
        }

        [Test]
        public void ShouldBeAbleToLoginAndLogOut()
        {
            //arr
            var userName = "Moe";
            var password = "Bacon";

            //act
            var loginResult = _gameEngine.Login(userName, password);

            //assert
            Assert.IsNotNull(loginResult);
            Assert.AreNotEqual(Guid.Empty, loginResult);

            //act
            var logoutResult = _gameEngine.Logout(loginResult);

            //assert
            Assert.IsTrue(logoutResult);
        }
    }
}
