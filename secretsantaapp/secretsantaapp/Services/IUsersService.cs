using secretsantaapp.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Services
{
    public interface IUsersService
    {
        //Task<secretsantaapp.Model.Models.Korisnici> Login(string username, string password);
        List<secretsantaapp.Model.Models.Users> Get(UsersSearchRequest search);
        //Korisnici GetById(int id);
        //void Insert(KorisniciInsertRequest request);
        //void Update(int id, KorisniciUpdateRequest request);
        //Korisnici Authenticiraj(string username, string pass);
    }
}
