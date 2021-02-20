using Microsoft.EntityFrameworkCore;
using PlanningPokerServer.Data.Entity;

namespace PlanningPokerServer.Data.Context {
    public class ApplicationDatabaseContext : DbContext {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base (options) {}   

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>();
        }
    }
}