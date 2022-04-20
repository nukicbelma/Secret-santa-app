using System;
using System.Collections.Generic;
using System.Text;

namespace secretsantaapp.Model.Models
{
    public class Roles
    {
        public int RolesId { get; set; }
        public string RoleName { get; set; }
        public string RoleDuty { get; set; }
        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
