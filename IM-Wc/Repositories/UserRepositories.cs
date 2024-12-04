using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositories
{
    public class UserRepositories : DbSet<User>
    {
        public override IEntityType EntityType => throw new NotImplementedException();

        public User FindById(string id)
        {
            return default;
        }
    }
}
