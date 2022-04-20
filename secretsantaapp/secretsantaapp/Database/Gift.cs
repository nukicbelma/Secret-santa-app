using System;
using System.Collections.Generic;

namespace secretsantaapp.Database
{
    public partial class Gift
    {
        public int GiftId { get; set; }
        public int FromUsersId { get; set; }
        public int ToUsersId { get; set; }
        public DateTime DatePublished { get; set; }

        public virtual Users FromUsers { get; set; }
        public virtual Users ToUsers { get; set; }
    }
}
