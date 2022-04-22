using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Services
{
    public interface IGiftService
    {
        public List<Model.Models.Gift> Get();
        //public void Insert(GiftInsertRequest request);
        Task<Model.Models.Gift> Insert(GiftInsertRequest request);
    }
}
