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
        public List<Model.Models.Gift> Get(GiftSearchRequest request)
        {
            var query= _context.Gift.AsQueryable();
            if ((!string.IsNullOrWhiteSpace((request?.FromUsersId).ToString())) && request?.FromUsersId != 0)
            {
                query = query.Where(x => x.FromUsersId == request.FromUsersId);
            }

            var giftList = query.ToList();
            var usersList = _context.Users.AsQueryable().ToList();
            List<Model.Models.Gift> result = new List<Model.Models.Gift>();

            foreach (var item in giftList)
            {

                Model.Models.Gift newGift = new Model.Models.Gift();

                newGift.GiftId = item.GiftId;
                newGift.FromUsersId = item.FromUsersId;
                newGift.ToUsersId = item.ToUsersId;
                newGift.DatePublished = item.DatePublished;

                foreach (var user in usersList)
                {
                    if (user.UsersId == item.ToUsersId)
                        newGift.ToUsers = user.FirstName + " " + user.LastName;
                }
                foreach (var user in usersList)
                {
                    if (user.UsersId == item.FromUsersId)
                        newGift.FromUsers = user.FirstName + " " + user.LastName;
                }
                result.Add(newGift);
            }
            return result;
        }
        public async Task<bool> PostojiLi(int id)
        {
            return !await _context.Gift.AnyAsync(i => i.ToUsersId == id);
        }

        public void Insert(GiftInsertRequest request)
        {
            var gifts = _context.Gift.AsQueryable().ToList();
            var query = _context.Users.AsQueryable().ToList();
            var giversLista = new List<Model.Models.Users>();
            int kolicina = query.Count();
            var recieversLista = new List<Model.Models.Users>();
            foreach (var item in query)
            {
                Model.Models.Users user = new Model.Models.Users();
                user.FirstName = item.FirstName;
                user.LastName = item.LastName;
                user.Address = item.Address;
                user.Email = item.Email;
                user.Username = item.Username;
                user.UsersId = item.UsersId;
                user.PasswordHash = item.PasswordHash;
                user.PaswordSalt = item.PaswordSalt;
                user.Status = item.Status;

                giversLista.Add(user);
                recieversLista.Add(user);
            }

            for (int i = 0; i < kolicina; i++)
            {
                var randomGiver = giversLista.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                var randomReciever = recieversLista.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                if (randomGiver.UsersId != randomReciever.UsersId)
                {
                    giversLista.Remove(randomGiver);
                    recieversLista.Remove(randomReciever);
                    var model = new GiftInsertRequest
                    {
                        FromUsersId = randomGiver.UsersId,
                        ToUsersId = randomReciever.UsersId,
                        DatePublished = DateTime.Now
                    };
                    Database.Gift entity = _mapper.Map<Database.Gift>(model);
                    _context.Gift.Add(entity);
                    _context.SaveChanges();
                }

            }
        }
        public virtual async Task<bool> Delete()
        {
            var query = await _context.Gift.AsQueryable().ToListAsync();
            try
            {
                _context.Gift.RemoveRange(_context.Gift.Where(x => x.GiftId>0));
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}


