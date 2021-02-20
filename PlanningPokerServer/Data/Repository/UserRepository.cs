using PlanningPokerServer.Data.Context;
using PlanningPokerServer.Data.Entity;

namespace PlanningPokerServer.Data.Repository {
    public interface IUserRepository : IAsyncRepository<User, int> {}
    public class UserRepository : AsyncRepository<User, int>, IUserRepository {
       public UserRepository(ApplicationDatabaseContext context): base (context) {}
    }
}