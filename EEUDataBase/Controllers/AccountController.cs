using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using EEUDataBase_DLL.Models;
using EEUDataBase_DLL.Entities;
using EEUDataBase_DLL.Interfaces;
using EEUDataBase_DLL.Facade;
using EEUDataBase.Providers;

namespace EEUDataBase.Controllers
{

    //[Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IRepository<Employee, int> employeeDB = new DLLFacade().GetEmployeeRepository(new ApplicationDbContext());

        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        // POST api/Account/Register
        [Authorize(Roles = "Administrator")]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var applicationUser = new ApplicationUser() { UserName = employee.UserName, Email = employee.Email};
            IdentityResult result = await UserManager.CreateAsync(applicationUser, employee.Password);
            await UserManager.AddToRoleAsync(applicationUser.Id, employee.EmployeeRole.ToString());
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok(employee.Id);
        }

        //[Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IHttpActionResult> Update(Employee employeeToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser user = await UserManager.FindByNameAsync(employeeToUpdate.UserName);
            if (user == null)
            {
                return NotFound();
            }
            user.PasswordHash = UserManager.PasswordHasher.HashPassword(employeeToUpdate.Password);
            var result = await UserManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok(employeeToUpdate);
        }


        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}