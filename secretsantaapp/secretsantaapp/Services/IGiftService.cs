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
        void Insert(GiftInsertRequest request);
        public void Dodaj(GiftInsertRequest request);

        public Task<bool> Delete();
    }
}
