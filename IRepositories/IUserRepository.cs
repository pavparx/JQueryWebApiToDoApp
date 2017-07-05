using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IRepositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
    }
}
