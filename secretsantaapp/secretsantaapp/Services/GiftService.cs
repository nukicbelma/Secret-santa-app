using AutoMapper;
using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Services
{
    public class GiftService : IGiftService
    {

        private readonly IMapper _mapper;
        private readonly secretsantaapp.Database.SecretSantaContext _context;

        public GiftService(secretsantaapp.Database.SecretSantaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Models.Gift> Get()
        {
            var query = _context.Gift.AsQueryable();
            var list = query.ToList();
            return _mapper.Map<List<Model.Models.Gift>>(list);
        }
        public void Insert(GiftInsertRequest request)
        {
            secretsantaapp.Database.Gift entity = _mapper.Map<secretsantaapp.Database.Gift>(request);
            _context.SaveChanges();
        }
    }
}
