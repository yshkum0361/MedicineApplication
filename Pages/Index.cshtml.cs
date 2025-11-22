using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MedicineApplication.Models;


namespace MedicineApplication.Pages
{
    [Authorize] // Only logged-in users can see this
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string Provider { get; set; }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                UserName = user.UserName;
                UserEmail = user.Email;

                // Try to find the external login provider
                var logins = await _userManager.GetLoginsAsync(user);
                Provider = logins.FirstOrDefault()?.ProviderDisplayName ?? "Local Login";
            }
        }
    }
}
