using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.Components
{
    public class MenuLogin : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var context = HttpContext;
            return View(context);
        }
    }
}
