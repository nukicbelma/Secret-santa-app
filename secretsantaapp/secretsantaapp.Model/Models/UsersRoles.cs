using System;
using System.Collections.Generic;
using System.Text;

namespace secretsantaapp.Model.Models
{
    public class UsersRoles
    {
        public int UsersRolesId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int UsersId { get; set; }
        public int RolesId { get; set; }

        public virtual Roles Roles { get; set; }
        public virtual Users Users { get; set; }
    }
}
