using System;
using System.Collections.Generic;

namespace secretsantaapp.Database
{
    public partial class Users
    {
        public Users()
        {
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int UsersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PaswordSalt { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
