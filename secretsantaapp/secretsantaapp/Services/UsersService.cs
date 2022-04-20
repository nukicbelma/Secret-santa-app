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

            //if (!string.IsNullOrWhiteSpace(search?.Id.ToString()))
            //{
            //    query = query.Where(x => x.UsersId==search.Id);
            //}
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

            foreach (var uloga in request.UsersRoles)
            {
                //secretsantaapp.Database.UsersRoles korisniciUloge = new secretsantaapp.Database.UsersRoles();
                //korisniciUloge.UsersId = entity.UsersId;
                //korisniciUloge.RolesId = uloga;
                //korisniciUloge.PublishedDate = DateTime.Now;
                //_context.UsersRoles.Add(korisniciUloge);
                //_context.SaveChanges();
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
            var entity = await _context.Users.Include("UsersRole.Uloge").FirstOrDefaultAsync(x => x.Username == username);
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
        //public Model.Models.Users Authenticiraj(string username, string pass)
        //{
        //    var user = _context.Users.FirstOrDefault(x => x.Username == username);

        //    if (user != null)
        //    {
        //        var hashedPass = GenerateHash(user.PaswordSalt, pass);

        //        if (hashedPass == user.PasswordHash)
        //        {
        //            var uloge = _context.UsersRoles.Include(x => x.Roles).Where(x => x.UsersId == user.UsersId);
        //            Model.Models.Users novikorisnik = new Model.Models.Users();

        //            foreach (var item in uloge)
        //            {

        //                novikorisnik.KorisniciUloge = new List<KorisniciUloge>();
        //                novikorisnik.KorisniciUloge.Add(new KorisniciUloge
        //                {
        //                    DatumIzmjene = item.DatumIzmjene,
        //                    KorisniciId = item.KorisniciId,
        //                    UlogeId = item.UlogeId,
        //                    KorisniciUlogeId = item.KorisniciUlogeId,
        //                    Uloge = new Uloge
        //                    {
        //                        Naziv = item.Uloge.Naziv,
        //                        OpisUloge = item.Uloge.OpisUloge,
        //                        UlogeId = item.Uloge.UlogeId
        //                    }
        //                });
        //            }
        //            novikorisnik.Ime = user.Ime;
        //            novikorisnik.Prezime = user.Prezime;
        //            novikorisnik.KorisnickoIme = user.KorisnickoIme;
        //            novikorisnik.Email = user.Email;
        //            novikorisnik.KorisniciId = user.KorisniciId;
        //            novikorisnik.Telefon = user.Telefon;

        //            return novikorisnik;
        //        }
        //    }
        //    return null;
        //}
    }
}
