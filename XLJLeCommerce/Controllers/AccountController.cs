using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController: Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ICart _cart;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, ICart cart)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cart = cart;
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
                    await _cart.Create(cart);

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

    }
}
