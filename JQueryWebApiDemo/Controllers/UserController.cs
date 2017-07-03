using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IRepositories;
using Models;

namespace JQueryWebApiDemo.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private readonly IUserRepository _usersRepo;


        public UserController(IUserRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }



        [HttpGet]
        [Route]
        public List<User> GetUsers()
        {
            return _usersRepo.GetAll();
        }
    }
}
