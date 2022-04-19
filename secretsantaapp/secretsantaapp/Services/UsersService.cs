using AutoMapper;
using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
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

            //if (!string.IsNullOrWhiteSpace(search?.Ime))
            //{
            //    query = query.Where(x => x.Ime.ToLower().StartsWith(search.Ime.ToLower()));
            //}
            var list = query.ToList();

            return _mapper.Map<List<Model.Models.Users>>(list);
        }
        //public Korisnici GetById(int id)
        //{
        //    var entity = _context.Korisnici.Find(id);

        //    return _mapper.Map<Korisnici>(entity);

        //}
        //public void Insert(KorisniciInsertRequest request)
        //{
        //    FashionNova.WebAPI.Database.Korisnici entity = _mapper.Map<FashionNova.WebAPI.Database.Korisnici>(request);



        //    if (request.Password != request.PasswordPotvrda)
        //    {
        //        throw new Exception("Passwordi se ne slažu");
        //    }

        //    entity.LozinkaSalt = GenerateSalt();
        //    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

        //    _context.Korisnici.Add(entity);
        //    _context.SaveChanges();

        //    foreach (var uloga in request.Uloge)
        //    {
        //        FashionNova.WebAPI.Database.KorisniciUloge korisniciUloge = new FashionNova.WebAPI.Database.KorisniciUloge();
        //        korisniciUloge.KorisniciId = entity.KorisniciId;
        //        korisniciUloge.UlogeId = uloga;
        //        korisniciUloge.DatumIzmjene = DateTime.Now;
        //        _context.KorisniciUloge.Add(korisniciUloge);
        //        _context.SaveChanges();
        //    }
        //    _context.SaveChanges();
        //}

        //public void Update(int id, KorisniciUpdateRequest request)
        //{
        //    var entity = _context.Korisnici.Where(x => x.KorisniciId == id).FirstOrDefault();
        //    if (!string.IsNullOrWhiteSpace(request.Password))
        //    {
        //        if (request.Password != request.PasswordPotvrda)
        //        {
        //            throw new Exception("Passwordi se ne slažu");
        //        }
        //        entity.LozinkaSalt = GenerateSalt();
        //        entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
        //    }

        //    var ulogeKorisnik = _context.KorisniciUloge.Where(x => x.KorisniciId == id).ToList();

        //    foreach (int item in request.Uloge)
        //    {
        //        var uloga = _context.Uloge.Where(x => x.UlogeId == item).FirstOrDefault();

        //        var imaUlogu = ulogeKorisnik.Where(x => x.KorisniciUlogeId == uloga.UlogeId).FirstOrDefault();

        //        if (imaUlogu == null)
        //        {
        //            var korisnikUloga = new FashionNova.WebAPI.Database.KorisniciUloge() { KorisniciId = entity.KorisniciId, UlogeId = uloga.UlogeId, DatumIzmjene = DateTime.Now };

        //            entity.KorisniciUloge.Add(korisnikUloga);
        //        }
        //    }

        //    _context.Korisnici.Attach(entity);
        //    _context.Korisnici.Update(entity);
        //    _mapper.Map(request, entity);

        //    _context.SaveChanges();

        //}
        //public static string GenerateSalt()
        //{
        //    var buf = new byte[16];
        //    (new RNGCryptoServiceProvider()).GetBytes(buf);
        //    return Convert.ToBase64String(buf);
        //}

        //public static string GenerateHash(string salt, string password)
        //{
        //    byte[] src = Convert.FromBase64String(salt);
        //    byte[] bytes = Encoding.Unicode.GetBytes(password);
        //    byte[] dst = new byte[src.Length + bytes.Length];

        //    System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        //    System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

        //    HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        //    byte[] inArray = algorithm.ComputeHash(dst);
        //    return Convert.ToBase64String(inArray);
        //}
        //public async Task<FashionNova.Model.Models.Korisnici> Login(string username, string password)
        //{
        //    var entity = await _context.Korisnici.Include("KorisniciUloge.Uloge").FirstOrDefaultAsync(x => x.KorisnickoIme == username);

        //    if (entity == null)
        //    {
        //        throw new UserException("Pogresan username ili password");
        //    }

        //    var hash = GenerateHash(entity.LozinkaSalt, password);

        //    if (hash != entity.LozinkaHash)
        //    {
        //        throw new UserException("Pogresan username ili password");
        //    }
        //    return _mapper.Map<FashionNova.Model.Models.Korisnici>(entity);
        //}
        //public Korisnici Authenticiraj(string username, string pass)
        //{
        //    var user = _context.Korisnici.FirstOrDefault(x => x.KorisnickoIme == username);

        //    if (user != null)
        //    {
        //        var hashedPass = GenerateHash(user.LozinkaSalt, pass);

        //        if (hashedPass == user.LozinkaHash)
        //        {
        //            var uloge = _context.KorisniciUloge.Include(x => x.Uloge).Where(x => x.KorisniciId == user.KorisniciId);
        //            Korisnici novikorisnik = new Korisnici();

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
