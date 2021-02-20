using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using PlanningPokerServer.Model.Dtos;

namespace PlanningPokerServer.Core {
    public class GameHub : Hub {
        private IGameManager gameManager;
        private readonly ILogger logger;

        public GameHub(IGameManager gameManager, ILogger<GameHub> logger) {
            this.gameManager = gameManager;
            this.logger = logger;
        }

        public override async Task OnConnectedAsync() {
            this.logger.LogInformation("[" + Context.ConnectionId + "] Connected");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception) {
            this.logger.LogInformation("[" + Context.ConnectionId + "] Disconnected");
            string gameId;
            if (this.gameManager.TryIdentifyGame(Context.ConnectionId, out gameId)) {
                this.gameManager.LeaveGame(gameId, Context.ConnectionId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
                await Clients.OthersInGroup(gameId).SendAsync("PLAYER_LEAVE", Context.ConnectionId);
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(GameMessage message) {
            this.logger.LogInformation("[" + Context.ConnectionId + "] Received to SendMessage {type:" + message.eventType + "}");
            await  Clients.OthersInGroup(message.gameId).SendAsync(message.eventType, message.payload);
        }

        public async Task CreateGame() {
            this.logger.LogInformation("[" + Context.ConnectionId + "] Request to CreateGame");
            string gameId = this.gameManager.NewGame(Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            await Clients.Caller.SendAsync("GAME_NEW", gameId);
        }

        public async Task JoinGame(string gameId) {
            this.logger.LogInformation("[" + Context.ConnectionId + "] Request to JoinGame with id: " + gameId.ToString());
            this.gameManager.JoinGame(gameId, Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            await Clients.OthersInGroup(gameId).SendAsync("PLAYER_JOIN", Context.ConnectionId);
            await Clients.Caller.SendAsync("PLAYER_REGISTER", Context.ConnectionId);
        }
    }
}