using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoBro.Web.Infrastructure
{
    public interface IUserProvider
    {
        string Username { get; }
    }
    public class HttpContextUserProvider : IUserProvider
    {
        public string Username
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
    }
}