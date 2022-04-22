using AutoMapper;
using Microsoft.EntityFrameworkCore;
using secretsantaapp.Exceptions;
using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace secretsantaapp.Services
{
    public class UsersService : IUsersService

    {
        private readonly IMapper _mapper;
        private readonly secretsantaapp.Database.SecretSantaContext _context;

        public UsersService(secretsantaapp.Database.SecretSantaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Models.Users> Get(UsersSearchRequest search)
        {
            var query = _context.Users.AsQueryable();
            var list = query.ToList();
            return _mapper.Map<List<Model.Models.Users>>(list);
        }
        public Model.Models.Users GetById(int id)
        {
            var entity = _context.Users.Find(id);

            return _mapper.Map<Model.Models.Users>(entity);

        }

        public void Insert(UsersInsertRequest request)
        {
            secretsantaapp.Database.Users entity = _mapper.Map<secretsantaapp.Database.Users>(request);
            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.PaswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PaswordSalt, request.Password);

            _context.Users.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Roles)
            {
                secretsantaapp.Database.UsersRoles korisniciUloge = new secretsantaapp.Database.UsersRoles();
                korisniciUloge.UsersId = entity.UsersId;
                korisniciUloge.RolesId = uloga;
                korisniciUloge.PublishedDate = DateTime.Now;
                _context.UsersRoles.Add(korisniciUloge);
                _context.SaveChanges();
            }
            _context.SaveChanges();
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public async Task<secretsantaapp.Model.Models.Users> Login(string username, string password)
        {
            var entity = await _context.Users.Include("UsersRoles.Roles").FirstOrDefaultAsync(x => x.Username == username);
            if (entity == null)
            {
                throw new UserException("Pogresan username ili password");
            }
            var hash = GenerateHash(entity.PaswordSalt, password);
            if (hash != entity.PasswordHash)
            {
                throw new UserException("Pogresan username ili password");
            }
            return _mapper.Map<secretsantaapp.Model.Models.Users>(entity);
        }
        public Model.Models.Users Authenticiraj(string username, string pass)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                var hashedPass = GenerateHash(user.PaswordSalt, pass);

                if (hashedPass == user.PasswordHash)
                {
                    var uloge = _context.UsersRoles.Include(x => x.Roles).Where(x => x.UsersId == user.UsersId);
                    Model.Models.Users novikorisnik = new Model.Models.Users();

                    foreach (var item in uloge)
                    {

                        novikorisnik.UsersRoles = new List<Model.Models.UsersRoles>();
                        novikorisnik.UsersRoles.Add(new Model.Models.UsersRoles
                        {
                            PublishedDate = item.PublishedDate,
                            UsersId = item.UsersId,
                            RolesId = item.RolesId,
                            UsersRolesId = item.UsersRolesId,
                            Roles = new Model.Models.Roles
                            {
                                RoleName = item.Roles.RoleName,
                                RoleDuty = item.Roles.RoleDuty,
                                RolesId = item.Roles.RolesId
                            }
                        });
                    }
                    novikorisnik.FirstName = user.FirstName;
                    novikorisnik.LastName = user.LastName;
                    novikorisnik.Username = user.Username;
                    novikorisnik.Email = user.Email;
                    novikorisnik.UsersId = user.UsersId;
                    novikorisnik.Phone = user.Phone;

                    return novikorisnik;
                }
            }
            return null;
        }
    }
}
