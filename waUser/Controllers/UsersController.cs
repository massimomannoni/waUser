using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using waUser.Models;
using waUser.BLL;

namespace waUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ResponseGetUsers> GetAll()
        {
            ResponseGetUsers response;

            response = await Task.FromResult(BLLUser.GetAll()).Result;

            if (response == null)
            {
                // need to transport the exception
                response = new ResponseGetUsers(false, "error", response.Result);
            }

            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ResponseAddUser> Post([FromBody] User user)
        {
            ResponseAddUser response;

            if (user != null)
            {
                response = await Task.FromResult(BLLUser.Add(user)).Result;
            }
            else
            {
                // need to transport the exception
                response = new ResponseAddUser(false, "error", false);
            }

            return response;   
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
