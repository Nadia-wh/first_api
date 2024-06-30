using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace first_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private static List <User> users = new List<User>();


        // GET: api/<UserController>
        [HttpGet]
        //getting all users so is an array
        public IEnumerable <User> Get()
        {
            return users;
        }
        //get a single user 
        // GET api/<UserController>/5

        [HttpGet("{id}")]
        public User Get(int id)
        {

            var user = users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        // POST api/<UserController>  create a user form body means the data will be in request's body
        [HttpPost]
        public void Post([FromBody] User request)
        {
            //adding an user
            users.Add(request);
        }

        //UDDATING THE USER 
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User request)
        {
            var user =users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                return
                    BadRequest();
            }
            else
            {
              
                //user.Id = id;
                user.Email = request.Email;
                user.Name = request.Name;
                return Ok(user);

            }
            //var user = users[id];

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // var user = users.FirstOrDefault(x => x.Id == id);
            // users.Remove(user);
            users.Remove(Get(id));
        }
    }
}
