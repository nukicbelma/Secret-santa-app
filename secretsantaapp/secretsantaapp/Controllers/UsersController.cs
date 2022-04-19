﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using secretsantaapp.Model.Models;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        //[HttpGet]
        //[AllowAnonymous]
        //[Route("Authenticiraj/{username},{password}")]
        //public Users Authenticiraj(string username, string password)
        //{
        //    return _service.Authenticiraj(username, password);
        //}

        //[HttpGet]
        //public List<Users> Get([FromQuery] UsersSearchRequest request)
        //{
        //    return _service.Get(request);
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpPut("{id}")]
        //public void Update(int id, [FromBody] KorisniciUpdateRequest request)
        //{
        //    _service.Update(id, request);
        //}

        //[HttpGet("{id}")]
        //public Korisnici GetById(int id)
        //{
        //    return _service.GetById(id);
        //}
    }
}