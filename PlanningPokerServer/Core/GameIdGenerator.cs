namespace PlanningPokerServer.Core {
    public static class GameIdGenerator {
        private static int _id = 0;

        public static string next() {
            _id = _id + 1;
            return _id.ToString();
        }
    }
}