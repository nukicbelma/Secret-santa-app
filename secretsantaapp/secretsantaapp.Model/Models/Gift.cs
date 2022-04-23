using System;
using System.Collections.Generic;
using System.Text;

namespace secretsantaapp.Model.Models
{
    public class Gift
    {
        public int GiftId { get; set; }
        public int FromUsersId { get; set; }
        public int ToUsersId { get; set; }
        public DateTime DatePublished { get; set; }

        public string FromUsers { get; set; }
        public string ToUsers { get; set; }

    }
}
