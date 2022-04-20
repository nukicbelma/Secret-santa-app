using System;
using System.Collections.Generic;
using System.Text;

namespace secretsantaapp.Model.Requests
{
    public class UsersInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public List<int> Roles { get; set; } = new List<int>();
    }
}
