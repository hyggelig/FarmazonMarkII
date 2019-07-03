using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farmazon.DAL;
using Farmazon.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace FarmazonMarkII.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IDataRepository<Users> _dataRepository;

        public UsersController(IDataRepository<Users> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Users> users = _dataRepository.GetAll();

                if(users.Count() == 0)
                    return BadRequest("User is null.");

                return Ok(users);
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing Users Get Method." + ex.Message);
                return NoContent();
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(long id)
        {
            try
            {
                Users user = _dataRepository.Get(id);

                if (user == null)
                    return NotFound("The User record couldn't be found.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                logger.Error("An Error Occured During Processing GetUser Method." + ex.Message);
                return new ObjectResult("Something Went Wrong During Processing Getting User Via Id"){StatusCode = 500};
            }
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            try
            {
                _dataRepository.Create(user);
                return CreatedAtRoute(
                      "Get",
                      new { Id = user.userId },
                      user);
            }
            catch(Exception ex)
            {
                logger.Error("An Error Occured During Processing Users Post Method." + ex.Message);
                return new ObjectResult("Something Went Wrong During Processing Users Post Method") { StatusCode = 500 };
            }
          
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            try
            {
                Users userToUpdate = _dataRepository.Get(id);
                if (userToUpdate == null)
                {
                    return NotFound("The User record couldn't be found.");
                }

                _dataRepository.Update(userToUpdate, user);
                return NoContent();
            }
            catch(Exception ex)
            {
                logger.Error("An Error Occured During Processing Users Put(ID) Method." + ex.Message);
                return NoContent();
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                Users user = _dataRepository.Get(id);
                if (user == null)
                {
                    return NotFound("The User record couldn't be found.");
                }

                _dataRepository.Delete(user);
                return NoContent();
            }
            catch(Exception ex)
            {
                logger.Error("An Error Occured During Processing Users Delete Method." + ex.Message);
                return NoContent();
            }
         
        }
    }
}