namespace PlanningPokerServer.Model.Dtos {
    public class GameMessage {
        public string gameId{ get; set; }
        public string eventType{ get; set; }
        public object payload { get; set; }
    }
}