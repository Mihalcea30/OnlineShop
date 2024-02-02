using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
  public class ApplicationUser : IdentityUser
  {
    public bool IsClient { get; set; }
    public bool IsSeller { get; set; }
  }
}
