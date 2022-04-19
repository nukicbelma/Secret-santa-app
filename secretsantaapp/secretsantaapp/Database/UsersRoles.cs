using System;
using System.Collections.Generic;

namespace secretsantaapp.Database
{
    public partial class UsersRoles
    {
        public int UsersRolesId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int UsersId { get; set; }
        public int RolesId { get; set; }

        public virtual Roles Roles { get; set; }
        public virtual Users Users { get; set; }
    }
}
