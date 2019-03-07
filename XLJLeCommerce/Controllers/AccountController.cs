using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.Interfaces;
using XLJLeCommerce.Models.ViewModels;

namespace XLJLeCommerce.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ICart _cart;
        private IEmailSender _emailSender;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICart cart, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cart = cart;
            _emailSender = emailSender;

        }

        /// <summary>
        /// calls the register method to get the page
        /// </summary>
        /// <returns>the register view page</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        /// <summary>
        /// calls the post register method to create the registration
        /// </summary>
        /// <param name="rvm">the information from/about the user</param>
        /// <returns>the view after it has completed</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthdate = rvm.Birthdate,
                    Address = rvm.Address,
                    RegisteredDate = DateTime.Now
                };


                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    Cart cart = new Cart();
                    cart.UserID = user.Id;
                    await _cart.Create(cart);

                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim addressClaim = new Claim(ClaimTypes.StreetAddress,$"{ user.Address }");

                    Claim registerDateClaim = new Claim("RegisteredDate", $"{ user.RegisteredDate }");

                    List<Claim> claims = new List<Claim> { fullNameClaim, birthdayClaim, emailClaim,addressClaim, registerDateClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    if (user.Email == "amanda@codefellows.com" || user.Email == "nguyenv2@outlook.com" || user.Email == "just4youspam@yahoo.com" || user.Email == "xia.liu2@outlook.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                     

                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //send user email after successfully registered with us
                    await _emailSender.SendEmailAsync(rvm.Email, "Successfully registered with us!", "<p>Thank you for registering</p>");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(rvm);
        }

        /// <summary>
        /// gets the login page to send to screen
        /// </summary>
        /// <returns>page view</returns>
        [HttpGet]
        public IActionResult Login() => View();

        /// <summary>
        /// takes information from page to login a user
        /// </summary>
        /// <param name="lvm">log in user information</param>
        /// <returns>the page</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(lvm.Email);
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains(ApplicationRoles.Admin))
                    {
                        return RedirectToAction("Admin", "Admin");
                    }
                    return RedirectToAction("Index", "Product");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(lvm);
        }

        /// <summary>
        /// logs out a user
        /// </summary>
        /// <returns>to home page after completed task</returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// asking external service for access
        /// </summary>
        /// <param name="provider">which 3rd party api, like FB or Microsoft</param>
        /// <returns>The answer from the provider</returns>
        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            // Setting where we need to be redirected to once we have established our OAUTH
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        /// <summary>
        /// use external log in 
        /// </summary>
        /// <param name="error">set error because method requires</param>
        /// <returns>page</returns>
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string error = null)
        {

            if (error != null)
            {

                TempData["Error"] = "Error with Provider";
                return RedirectToAction("Login");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            // If the web app does not support the provider, make them login with a different technique.
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);


            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Product");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);


            return View("ExternalLogin", new ExternalLoginViewModel { Email = email });

        }

        /// <summary>
        /// verification log in worked then what happens, our case add a new user
        /// </summary>
        /// <param name="elvm">user information</param>
        /// <returns>the page</returns>
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loading information";
                }

                var user = new ApplicationUser
                {
                    UserName = elvm.Email,
                    Email = elvm.Email,
                    FirstName = elvm.FirstName,
                    LastName = elvm.LastName,
                    Address=elvm.Address,
                    RegisteredDate = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    Cart cart = new Cart();
                    cart.UserID = user.Id;
                    await _cart.Create(cart);

                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim addressClaim = new Claim(ClaimTypes.StreetAddress, user.Address);
                    Claim registerDateClaim = new Claim("RegisteredDate", $"{ user.RegisteredDate }");

                    List<Claim> claims = new List<Claim> { fullNameClaim, birthdayClaim, emailClaim, addressClaim, registerDateClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    if (user.Email == "amanda@codefellows.com" || user.Email == "nguyenv2@outlook.com" || user.Email == "just4youspam@yahoo.com" || user.Email == "xia.liu2@outlook.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);
                    }

                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Product");

                    }
                }


            }
            return View(elvm);
        }

        /// <summary>
        /// redirects pages when one doesn't have access to VIP area
        /// </summary>
        /// <returns>page </returns>
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Index", "Policy");
        }
    }
}
