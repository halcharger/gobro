using GoBro.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoBro.Web.Controllers
{
    public class UserController : Controller
    {
        [Route("user/{username}")]
        public ActionResult Profile(string username)
        {
            return View(new UserProfileViewModel { Username = username });
        }
    }
}