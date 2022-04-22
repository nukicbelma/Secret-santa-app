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
        public async Task<bool> PostojiLi(int id)
        {
            return !await _context.Gift.AnyAsync(i => i.ToUsersId == id);
        }
        public async Task<Model.Models.Gift> Insert(GiftInsertRequest request)
        {
            var randomGiver = _context.Users.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            while (!await PostojiLi(randomGiver.UsersId))
            {
                randomGiver = _context.Users.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            }
            var model = new Model.Requests.GiftInsertRequest
            {
                FromUsersId = request.FromUsersId,
                ToUsersId = randomGiver.UsersId,
                DatePublished = DateTime.Now

            };
            Database.Gift entity = _mapper.Map<Database.Gift>(model);
            await _context.Gift.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Model.Models.Gift>(entity);
        }
    }
}


