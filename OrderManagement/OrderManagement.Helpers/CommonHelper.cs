using Newtonsoft.Json;
using OrderManagement.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace OrderManagement.Helpers
{
    public class CommonHelper
    {
        public static LoginModel getCurrentUser(HttpRequestBase Request)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                FormsAuthenticationTicket ticket1 = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                var user = JsonConvert.DeserializeObject<LoginModel>(ticket1.UserData);
                return user;
            }
            else { return new LoginModel(); }

        }
    }
}
