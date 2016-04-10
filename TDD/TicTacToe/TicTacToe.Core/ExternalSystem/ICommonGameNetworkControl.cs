using System;
using System.Collections.Generic;

namespace TicTacToe.Core.ExternalSystem
{
    public interface ICommonGameNetworkControl
    {
        Guid Login(string username, string password);
        bool Logout(Guid sessionToken);
        int PostScoreToLeaderboard(Guid sessionToken, Guid gameToken, int score);
        IEnumerable<LeaderBoardEntry> GetLeaderBoard(Guid sessionToken, Guid gameToken);
        IEnumerable<Player> GetFriends(Guid sessionToken);
        bool AddFriends(Guid sessionToken, Guid playerId);
        Guid InviteFriendToMatch(Guid sessionToken, Guid invitedPlayerId, Guid gameToken);
        Guid InviteFriendToMatch(Guid sessionToken, Guid invitedPlayerId, Guid gameToken, Guid matchToken);
        Guid StartMatch(Guid sessionToken, Guid matchToken);
    }

    public class LeaderBoardEntry
    {
        public int Place { get; set; }
        public int Score { get; set; }
        public string UserName { get; set; }
    }

    public class Player
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public IList<Guid> FriendIds { get; private set; }

        public Player()
        {
            FriendIds = new List<Guid>();
        }
    }
}
