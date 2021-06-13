using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolTaskApi.Authentication;
using SchoolTaskApi.Models;

namespace SchoolTaskApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationUser> roleManager;
        // private readonly IConfigration configuration;


        public AccountController(UserManager<ApplicationUser> userManager ,
            RoleManager<ApplicationUser> roleManager) {

            this.userManager = userManager;
            this.roleManager = roleManager;
            //config
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Register([FromBody] RegisterModel registerModel) {

            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerModel.userName,
                Email = registerModel.email,
            };

         //   var result = await userManager.CreateAsync(user, registerModel.password);

          //  var result = 

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] RegisterModel registerModel)
        {

            return Ok();
        }
    }
}