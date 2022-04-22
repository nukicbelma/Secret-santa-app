using AutoMapper;
using Microsoft.EntityFrameworkCore;
using secretsantaapp.Exceptions;
using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<bool> PostojiLi(GiftInsertRequest request)
        {
            return !await _context.Gift.AnyAsync(i => i.ToUsersId == request.ToUsersId);
        }
        public bool imali(GiftInsertRequest request)
        {
            bool ima = false;
            if(_context.Gift.Any(i=>i.ToUsersId==request.ToUsersId))
            {
                ima = true;
            }
            return ima;
        }
        public async void Insert(GiftInsertRequest request)
        {
            var randomGiver = _context.Users.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            var model = new Model.Requests.GiftInsertRequest
            {
                FromUsersId = request.FromUsersId, 
                DatePublished=DateTime.Now,
                ToUsersId=randomGiver.UsersId
            };
             Database.Gift entity =  _mapper.Map<Database.Gift>(model);
             _context.Gift.Add(entity);
             _context.SaveChanges();
        }
    }
}
