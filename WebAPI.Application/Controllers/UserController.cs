using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces;
using WebAPI.Service.Validators;

namespace WebAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IService<User> _service { get; set; }

        public UserController(IService<User> service)
        {
            this._service = service;
        }

        // GET: api/User
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var _user = await _service.Get(id);
                return Ok(_user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var _users = await _service.GetAll();
                return Ok(_users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                var _userCreate = await _service.Post<UserValidator>(user);
                return Ok(_userCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            try
            {
                var _userUpdate = await _service.Put<UserValidator>(user);
                return Ok(_userUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
