using Assignment.Models.Forms;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Eventing.Reader;

namespace Assignment.Services
{
    public class AuthService
    {
        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var identityUser = new IdentityUser { UserName = form.Email, Email = form.Email };
            
            return false;
        }
    }
}
