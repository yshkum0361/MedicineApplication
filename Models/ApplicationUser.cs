using Microsoft.AspNetCore.Identity;

namespace MedicineApplication.Models
{
    // Identity already handles Name (via username/claims), Email, and Provider (via external login)
    // We mainly use this to link our DbContext with Identity
    public class ApplicationUser : IdentityUser
    {
        // Add any custom fields here if needed. 
        // For this assignment, the base IdentityUser provides what is required.
    }
}
