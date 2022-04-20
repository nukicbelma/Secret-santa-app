using System;
using System.Collections.Generic;
using System.Text;

namespace secretsantaapp.WinUI
{
    public class LoggedInUser
    {
        public static secretsantaapp.Model.Models.Users LoggedUser { get; set; }

        public static bool Admin { get; set; }
    }
}
