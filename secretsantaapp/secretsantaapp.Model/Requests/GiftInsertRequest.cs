using secretsantaapp.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace secretsantaapp.Model.Requests
{
    public class GiftInsertRequest
    {
        public int FromUsersId { get; set; }
        public int ToUsersId { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
