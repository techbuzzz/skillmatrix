using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SkillMatrix.Service
{
    public interface IAuthenticationService
    {
    }

    public class AuthenticationService: IAuthenticationService
    {
        private HttpContextBase _httpContext;

        public AuthenticationService(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }
    }

    
}
