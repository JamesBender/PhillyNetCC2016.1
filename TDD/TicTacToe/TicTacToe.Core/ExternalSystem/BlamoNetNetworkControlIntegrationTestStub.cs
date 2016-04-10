using System;
using System.Collections.Generic;

namespace TicTacToe.Core.ExternalSystem
{
    public class BlamoNetNetworkControlIntegrationTestStub : ICommonGameNetworkControl
    {
        public Guid Login(string username, string password)
        {
            System.Threading.Thread.Sleep(2000);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Bad username or password.");
            }
            var pairOne = username == "Manny" && password == "1234";
            var pairTwo = username == "Moe" && password == "Bacon";
            var pairThree = username == "Jack" && password == "dj3n#gh73klg&hd-hgDh4";

            if (pairOne || pairTwo || pairThree)
            {
                return Guid.NewGuid();
            }

            return Guid.Empty;
        }

        public bool Logout(Guid sessionToken)
        {
            System.Threading.Thread.Sleep(1000);
            return sessionToken != Guid.Empty;
        }

        public int PostScoreToLeaderboard(Guid sessionToken, Guid gameToken, int score)
        {
            System.Threading.Thread.Sleep(1000);
            if (sessionToken == Guid.Empty)
            {
                throw new ArgumentException("bad session token");
            }

            if (gameToken == Guid.Empty)
            {
                throw new ArgumentException("bad game token");
            }

            return score >= 100 ? 5 : 10;
        }

        public IEnumerable<LeaderBoardEntry> GetLeaderBoard(Guid sessionToken, Guid gameToken)
        {
            System.Threading.Thread.Sleep(5000);
            if (sessionToken == Guid.Empty)
            {
                throw new ArgumentException("bad session token");
            }

            if (gameToken == Guid.Empty)
            {
                throw new ArgumentException("bad game token");
            }

            return new List<LeaderBoardEntry>
            {
                new LeaderBoardEntry {Place = 1, Score = 100, UserName = "James"},
                new LeaderBoardEntry {Place = 2, Score = 99, UserName = "Manny"},
                new LeaderBoardEntry {Place = 3, Score = 87, UserName = "Moe"},
                new LeaderBoardEntry {Place = 4, Score = 72, UserName = "Jack"},
                new LeaderBoardEntry {Place = 5, Score = 65, UserName = "Kylo"}
            };
        }

        public IEnumerable<Player> GetFriends(Guid sessionToken)
        {
            throw new NotImplementedException();
        }

        public bool AddFriends(Guid sessionToken, Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Guid InviteFriendToMatch(Guid sessionToken, Guid invitedPlayerId, Guid gameToken)
        {
            throw new NotImplementedException();
        }

        public Guid InviteFriendToMatch(Guid sessionToken, Guid invitedPlayerId, Guid gameToken, Guid matchToken)
        {
            throw new NotImplementedException();
        }

        public Guid StartMatch(Guid sessionToken, Guid matchToken)
        {
            throw new NotImplementedException();
        }
    }
}