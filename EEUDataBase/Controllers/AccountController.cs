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
using System.Web.Security;

namespace EEUDataBase.Controllers
{

    [Authorize]
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
            var applicationUser = new ApplicationUser() { UserName = employee.UserName, Email = employee.Email };
            IdentityResult result = await UserManager.CreateAsync(applicationUser, employee.Password);
            await UserManager.AddToRoleAsync(applicationUser.Id, employee.EmployeeRole.ToString());
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok(employee.Id);
        }
        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        [Route("Remove")]
        public async Task<IHttpActionResult> Remove(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Employee employeeToDelete = employeeDB.ReadById(id);
            ApplicationUser user = await UserManager.FindByNameAsync(employeeToDelete.UserName);

            if (user == null)
            {
                return NotFound();
            }

            //var logins = user.Logins;

            //var rolesForUser = await UserManager.GetRolesAsync(id.ToString());

            //foreach(var login in logins)
            //{
            //    await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            //}
            //if(rolesForUser.Count > 0)
            //{
            //    foreach(var item in rolesForUser)
            //    {
            //        var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
            //    }
            //}
            await UserManager.DeleteAsync(user);

            return Ok(employeeToDelete.Id);
        }


        [Authorize]
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

        [AllowAnonymous]
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IHttpActionResult> ForgotPassword(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            string tempPassword = Membership.GeneratePassword(12, 1);
            user.PasswordHash = UserManager.PasswordHasher.HashPassword(tempPassword);
            var result = await UserManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            await UserManager.SendEmailAsync(user.Id, "Reset Password", $"Your new temporary password is: {tempPassword} - You will be prompted to change your password on your next logon.");
            return Ok();
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