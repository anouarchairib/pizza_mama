using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace pizza_mama.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public bool valide;
        IConfiguration configuration;
        public bool IsDevelopmentMode = false;
        public IndexModel(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.valide = true;
            this.configuration = configuration;
            if(env.IsDevelopment()){
            IsDevelopmentMode = true;
            }
        }
        public IActionResult OnGet()
        {

            if(HttpContext.User.Identity.IsAuthenticated)
            {
              return   Redirect("/Admin/Pizzas" );
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(string username, string password, string ReturnUrl)
        {
            //Recuperation  de l'authetifcation de notre fichier appseting
            var authSection = configuration.GetSection("Auth");
            string adminLogin = authSection["AdminLogin"];
            string adminPassword = authSection["AdminPassword"];
         
            if (username == adminLogin && password == adminPassword)
            {
                valide = true;
                var claims = new List<Claim>
{
new Claim(ClaimTypes.Name, username)
};
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new
                ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
            }
            else
            {
                valide = false;
                return Page();
            }
          
        }
        public async Task<IActionResult> OnGetLogout()
        {
           await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           return Redirect("/Admin");
        }
    }
    }

