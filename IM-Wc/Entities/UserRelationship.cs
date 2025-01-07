using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWPF.Entities
{
    public class UserRelationship
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public User  User { get; set; }

        public User Contactor { get; set; }

        public int Level { get; set; }
    }
}
