using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using secretsantaapp.Model.Models;
using secretsantaapp.Model.Requests;
using secretsantaapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secretsantaapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Authenticiraj/{username},{password}")]
        public Users Authenticiraj(string username, string password)
        {
            return _service.Authenticiraj(username, password);
        }

        [HttpGet]
        public List<Users> Get([FromQuery] UsersSearchRequest request)
        {
            return _service.Get(request);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public void Insert(UsersInsertRequest request)
        {
            _service.Insert(request);
        }

        [HttpGet("{id}")]
        public Model.Models.Users GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
