using ChatWPF.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public string Password { get; set; }

        public List<UserRelationship> Contactors { get; set; }
    }
}
