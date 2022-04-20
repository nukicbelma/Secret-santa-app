using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using secretsantaapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _service;

        public RolesController(IRolesService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Models.Roles> Get()
        {
            return _service.Get();
        }

        [HttpGet]
        [Route("ProvjeriAdmin/{UlogaId}")]
        public Model.Models.Roles ProvjeriAdmin(int UlogaId)
        {
            return _service.ProvjeriAdmin(UlogaId);
        }
    }
}
