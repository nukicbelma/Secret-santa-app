using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Services
{
    public interface IGiftService
    {
        public List<Model.Models.Gift> Get(GiftSearchRequest request);
        void Insert(GiftInsertRequest request);
        public List<Model.Models.Users> GetNoSecretSanta(GiftSearchRequest request);
        public Task<bool> Delete();
    }
}
