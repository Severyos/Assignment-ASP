﻿using Assignment.Contexts;
using Assignment.Models.Forms;
using Assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics.Eventing.Reader;

namespace Assignment.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IdentityContext _context;



        public AuthService(UserManager<IdentityUser> userManager, IdentityContext context, SignInManager<IdentityUser> signInManager = null)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }


        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var identityUser = new IdentityUser { 
                UserName = form.Email,
                Email = form.Email, 
                PhoneNumber = form.PhoneNumber
            };

            var identityProfile = new IdentityUserProfile
            {
                UserId = identityUser.Id,
                FirstName = form.FirstName,
                LastName = form.LastName,
                StreetName = form.StreetName,
                PostalCode = form.PostalCode,
                City= form.City,
                Company = form.Company,
            };

            var result = await _userManager.CreateAsync(identityUser, form.Password);
            if (result.Succeeded)
            {
                _context.UserProfiles.Add(identityProfile);
                await _context.SaveChangesAsync();
                return true;
            }
            
        

            return false;
        }

        public async Task<bool> LoginAsync(LoginForm form, bool keepMeLoggedIn = false)
        {
            var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, keepMeLoggedIn, false);
            return result.Succeeded;
        }
    }
}
