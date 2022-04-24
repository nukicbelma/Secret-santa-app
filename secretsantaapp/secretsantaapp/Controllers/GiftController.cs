using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _service;

        public GiftController(IGiftService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Models.Gift> Get()
        {
            return _service.Get();
        }

        [HttpPost]
        public void Insert([FromBody] GiftInsertRequest request)
        {
             _service.Insert(request);
        }
        //[HttpPost]
        //public void Dodaj([FromBody] GiftInsertRequest request)
        //{
        //    _service.Dodaj(request);
        //}

        [HttpDelete("{id}")]
        public async Task<bool> Delete()
        {
            return await _service.Delete();
        }
    }
}
