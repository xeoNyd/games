using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using cybersport.Models;

namespace cybersport.Controllers
{
    public class IdentityUserController : Controller
    {
        private readonly Database2Context _secContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityUserController(Database2Context secContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _secContext = secContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            bool isExist = await _roleManager.RoleExistsAsync("admin");
            if (!isExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                IdentityUser user = _secContext.Users.Find(currentUserID);
                await _userManager.AddToRoleAsync(user, "admin");
                await _signInManager.RefreshSignInAsync(user);
            }

            return View();
        }
    }
}