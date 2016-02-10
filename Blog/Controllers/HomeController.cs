using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog_ChristonBurns.com_.Models;

namespace MyBlog_ChristonBurns.com_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new BlogDBContext())
            {
                return View(db.Blogs.OrderByDescending(b => b.CreatedDate).ToList());
            }
        }
    }
}