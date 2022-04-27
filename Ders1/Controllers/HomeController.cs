using Ders1.Application;
using Ders1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ders1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            LoginDal login = new LoginDal();
            ModelData data = new ModelData
            {
                User = new User(),
                Users = login.GetAll()
            };
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            LoginDal login = new LoginDal();
            if(user.Password != user.ConfirmPassword || !ModelState.IsValid)
            {
                ModelData datas = new ModelData
                {
                    User = new User(),
                    Users = login.GetAll()
                };
                return View(datas);
            }

            login.Add(user);
            ModelData data = new ModelData
            {
                User = new User(),
                Users = login.GetAll()
            };
            return View(data);
        }
    }
}
