using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Services
{
    public interface IRolesService
    {
        public List<Model.Models.Roles> Get();
        public Model.Models.Roles ProvjeriAdmin(int UlogaId);
    }
}
