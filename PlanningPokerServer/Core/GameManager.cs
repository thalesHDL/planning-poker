using System.Collections.Generic;

namespace PlanningPokerServer.Core {
    public interface IGameManager {
        string NewGame(string ownerId);
        void JoinGame(string gameId, string playerId);
        bool TryIdentifyGame(string playerId, out string gameId);
        void LeaveGame(string gameId, string playerId);
    }

    public class GameManager : IGameManager {
        private IDictionary<string, Game> _games; // <GAME_ID, GAME>
        private IDictionary<string, string> _gameConnections; // <PLAYER_ID, GAME_ID> PLAYER_ID = CONNECTION_ID

        public GameManager() {
            this._games = new Dictionary<string, Game>();
            this._gameConnections =  new Dictionary<string, string>();
        }
        public string NewGame(string ownerId) {
            string gameId = GameIdGenerator.next();
            this._games.Add(gameId, new Game(gameId, ownerId));
            this._gameConnections.Add(ownerId, gameId);
            return gameId;
        }
        public void JoinGame(string gameId, string playerId) {
            Game game;
            if (this._games.TryGetValue(gameId, out game)) {
                game.AddPlayer(playerId);
            } else {
                // TODO: TRATAR EXCEPTION
            }
        }

        public bool TryIdentifyGame(string playerId, out string gameId) {
            return this._gameConnections.TryGetValue(playerId, out gameId);
        }

        public void LeaveGame(string gameId, string playerId) {
            Game game;
            if (this._games.TryGetValue(gameId, out game)) {
                game.RemovePlayer(playerId);
                this._gameConnections.Remove(playerId);
            }
        }
    }
}