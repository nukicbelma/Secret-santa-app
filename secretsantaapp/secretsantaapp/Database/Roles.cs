using System;
using System.Collections.Generic;

namespace secretsantaapp.Database
{
    public partial class Roles
    {
        public Roles()
        {
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int RolesId { get; set; }
        public string RoleName { get; set; }
        public string RoleDuty { get; set; }

        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
