using MaterialConstructionAPI.DAL;
using MaterialConstructionAPI.DAO;
using System.Collections.Generic;
using System.Web.Http;

namespace MaterialConstructionAPI.Controllers
{
    public class UserController : ApiController
    {
        UserManager um = new UserManager();

        // GET: api/User
        public List<User> Get()
        {
            return um.User();
        }

        // GET: api/User/5
        public User Get(int id)
        {
            return um.User(id);
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
