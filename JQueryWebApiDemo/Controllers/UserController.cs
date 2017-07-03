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
        private readonly IUserRepository _IRepoVar;


        public UserController(IUserRepository IRepovar)
        {
            _IRepoVar = IRepovar;
        }



        [HttpGet]
        [Route]
        public List<User> GetUsers()
        {

            return _IRepoVar.GetAll();
        }
    }
}
