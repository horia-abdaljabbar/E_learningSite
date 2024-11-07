using E_Learning.DAL.Models;
using E_Learning.PL.Helpers;
using E_Learning.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace E_Learning.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,

                };

              var result= await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign "User" role to the newly registered user
                    await userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction(nameof(Login));
                }

            }
            return View(model);

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user is not null)
                {
                    var check = await userManager.CheckPasswordAsync(user,model.Password);
                    if (check)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe,false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index","Home");
                        }
                    }
                }

            }
            return View(model);
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public async Task<IActionResult> SendResetPasswordURL(ForgetPasswordVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (ModelState.IsValid)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var resetPasswordURL = Url.Action("ResetPassword", "Account",new {email=model.Email, token=token},"https","localhost:7150");
                if (user is not null)
                {
                    var email = new Email()
                    {
                        Subject = "Reset Password",
                        Receivers = model.Email,
                        Body = resetPasswordURL,
                    };
                    EmailSettings.SendEmail(email);
                }
            }
           
                return View(model);

        }


        [HttpGet]
        public IActionResult ResetPassword(string email,string token)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if(user is not null)
            {
                var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }


}
