using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using XLJLeCommerce.Models;
using XLJLeCommerce.Models.ViewModels;

namespace XLJLeCommerce.Controllers
{
    public class AccountController: Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                    RegisteredDate = DateTime.Now
                };


                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    Cart cart = new Cart();
                    cart.UserID = user.Id;

                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim registerDateClaim = new Claim("RegisteredDate", $"{ user.RegisteredDate }");

                    List<Claim> claims = new List<Claim> { fullNameClaim, birthdayClaim, emailClaim, registerDateClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    await _signInManager.SignInAsync(user, isPersistent: false);
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
                    return RedirectToAction("Index", "Product");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(lvm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        public IActionResult ExternalLogin(string provider)
        {
            // Setting where we need to be redirected to once we have established our OAUTH
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
            // the information for our OAUTH providers
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            // Start the process
            return Challenge(properties, provider);
        }

        [HttpGet]

        public async Task<IActionResult> ExternalLoginCallback(string error = null)
        {
            // If there is an error message, send them away
            if (error != null)
            {
                // logging of the error coming in
                TempData["Error"] = "Error with Provider";
                return RedirectToAction("Login");
            }

            // see if our web app supports the login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();

            // If the web app does not support the provider, make them login with a different technique.
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // login with the external provider given the info from our sign in manager
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            // redirect them home if the login was a success
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Product");
            }

  

            //redirect to the external login page for the user to 
            return View("ExternalLogin");

        }


        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    TempData["Error"] = "Error loading information";
                }

                //Create the user.
                //TODO: Could potentially force the user to add a password here....
                //
                var user = new ApplicationUser
                {
                    UserName = elvm.Email,
                    Email = elvm.Email,
                    FirstName = elvm.FirstName,
                    LastName = elvm.LastName
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    //TODO: Potentially add Claims here.....

                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    await _userManager.AddClaimAsync(user, fullNameClaim);

                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                        // sign the user in with the information they gave us
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "Product");

                    }
                }


            }
            return View(elvm);
        }

    }
}
