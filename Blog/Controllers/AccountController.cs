using MyBlog_ChristonBurns.com_.Models;
using System.Linq;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AttributeRouting.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Data.Entity.SqlServer;

namespace MyBlog_ChristonBurns.com_.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        [GET("login")]
        public ActionResult Login()
        {
            return View();
        }
        [POST("login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User input)
        {
            if (ModelState.IsValid)
            {
                using (BlogDBContext db = new BlogDBContext()) 
                {
                    var authUser = db.Members.Any(u => u.Username == input.Username && u.Password == input.Password);
                    if(authUser)
                    {
                        var identity = new ClaimsIdentity(new[]
                            {
                            new Claim(ClaimTypes.Name, input.Username),
                            },
                        DefaultAuthenticationTypes.ApplicationCookie,
                        ClaimTypes.Name, ClaimTypes.Role);

                        identity.AddClaim(new Claim(ClaimTypes.Role, "guest"));

                        Authentication.SignIn(identity);
                        return RedirectToAction("index", "blogs");
                    }
                }
            }

            return View("Login", input);
        }

        [GET("logout")]
        public ActionResult Logout()
        {
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("index", "home");
        }
    }
}