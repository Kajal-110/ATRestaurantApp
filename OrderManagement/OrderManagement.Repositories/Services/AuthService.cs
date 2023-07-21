using OrderManagement.Models.CustomModels;
using OrderManagement.Models.DB;
using OrderManagement.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repositories.Services
{
    public class AuthService : IAuthService
    {
        public LoginModel Login(LoginModel loginModel)
        {
            AP351AteetMVCTestEntities db = new AP351AteetMVCTestEntities();
            LoginModel login = new LoginModel();
            int userIndex = db.USERs.ToList().FindIndex(x => x.Username == loginModel.Username && x.Password == loginModel.Password);
            if (userIndex > -1)
            {
                login.Username = db.USERs.ToList()[userIndex].Username;
                login.Password = db.USERs.ToList()[userIndex].Password;
                login.id = db.USERs.ToList()[userIndex].ID;
            }
            return login;
        }
    }
}
