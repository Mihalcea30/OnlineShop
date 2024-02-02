using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;

namespace ServerApp.Controllers
{
  [Route("regiter")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(User model)
    {
      if (ModelState.IsValid)
      {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

        // Set additional properties based on the ViewMode

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          if (model.Role == "Seller")
            _userManager.AddToRoleAsync(user, "Seller");
          else _userManager.AddToRoleAsync(user, "Client");
          return Ok(model);
        }
      }


      return Ok(model);
      // Handle errors if registration fails
      // If ModelState is not valid, return to registration view with errors
    }
      
  }
}
