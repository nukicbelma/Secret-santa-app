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

        public virtual Users FromUsers { get; set; }
        public virtual Users ToUsers { get; set; }
    }
}
