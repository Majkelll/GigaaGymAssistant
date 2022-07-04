using GigaaGymAssistant.Infrastructure.EntityFramework.Entities;

namespace GigaaGymAssistant.Infrastructure.EntityFramework
{
    public class DbSeeder
    {
        private readonly GGADbContext _dbContext;

        public DbSeeder(GGADbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>
            {
                new()
                {
                    Name = "User"
                },
                new()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
    }
}
