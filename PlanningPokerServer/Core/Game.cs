using System.Collections.Generic;

namespace PlanningPokerServer.Core {
    public class Game {
        public string id { get; set; }
        public string owner { get; set; }
        public ISet<string> players { get; set; }

        public Game(string id, string owner) {
            this.id = id;
            this.owner = owner;
            this.players = new HashSet<string>() {owner};
        }

        public void AddPlayer(string player) {
            this.players.Add(player);
        }

        public void RemovePlayer(string player) {
            this.players.Remove(player);
        }
    }
}