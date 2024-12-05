using ChatWPF.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWPF.Repositories
{
    public class UserRelationshipConfig : IEntityTypeConfiguration<UserRelationship>
    {
        public void Configure(EntityTypeBuilder<UserRelationship> builder)
        {
            builder.HasOne<User>(u=>u.User).WithMany(u=>u.Contactors).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<User>(u=>u.Contactor).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
