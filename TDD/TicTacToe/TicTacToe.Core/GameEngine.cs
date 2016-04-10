using System;
using TicTacToe.Core.ExternalSystem;

namespace TicTacToe.Core
{
    public class GameEngine
    {
        private ICommonGameNetworkControl _networkInterface;

        public GameEngine(ICommonGameNetworkControl networkInterface)
        {
            _networkInterface = networkInterface;
        }

        public string GetWinner(string[,] board)
        {
            if (board[0, 0] == "X" && board[0, 1] == "X" && board[0, 2] == "X")
            {
                return "X";
            }

            return "";
        }

        public Guid Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException();
            }

            return _networkInterface.Login(userName, password);
        }

        public bool Logout(Guid sessionId)
        {
            return _networkInterface.Logout(sessionId);
        }
    }
}
