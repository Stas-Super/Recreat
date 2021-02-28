using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recreat.Infrastructure.Business.Services;
using Recreat.Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recreat.Server.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Register(RegistrDTO registr)
        {
            UserService service = new UserService();
            if (registr == null)
                return new JsonResult("Error");
            var user = await service.Registr(registr);
            return new JsonResult(user);
        }

        /// <summary>
        /// Метод проверяет сущиствует ли переданный пользователь
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<IActionResult> Login(LoginDTO login)
        {
            UserService service = new UserService();
            var user = await service.Login(login);
            if (user is null)
                return null;
            return new JsonResult(user);
        }
    }
}
