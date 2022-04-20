using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Services
{
    public class RolesService : IRolesService
    {
        private readonly secretsantaapp.Database.SecretSantaContext _context;
        private readonly IMapper _mapper;

        public RolesService(secretsantaapp.Database.SecretSantaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Models.Roles> Get()
        {
            List<Model.Models.Roles> result = new List<Model.Models.Roles>();
            var lista = _context.Roles.ToList();

            foreach (var item in lista)
            {
                Model.Models.Roles uloga = new Model.Models.Roles();
                uloga.RoleName = item.RoleName;
                uloga.RoleDuty = item.RoleDuty;
                uloga.RolesId = item.RolesId;

                result.Add(uloga);
            }
            return result;
        }

        public Model.Models.Roles ProvjeriAdmin(int UlogaId)
        {
            var lista = _context.Roles.ToList();
            Model.Models.Roles result = new Model.Models.Roles();

            foreach (var item in lista)
            {
                if (item.RolesId == UlogaId)
                {
                    if (item.RoleName.Contains("Admin"))
                    {
                        result.RoleName = item.RoleName;
                        result.RoleDuty = item.RoleDuty;
                        result.RolesId = item.RolesId;

                        return result;
                    }
                }
            }
            return null;
        }
    }
}
