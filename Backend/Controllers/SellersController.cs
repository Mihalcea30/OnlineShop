using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Services.SellerService;
using Microsoft.AspNetCore.Identity;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
    private readonly UserManager<ApplicationUser> _userManager;
    private ISellerService _sellerService;
    public SellersController(ISellerService sellerService, UserManager<ApplicationUser> userManager)
    {
      _sellerService = sellerService;
      _userManager = userManager;
    }

    // GET: api/Sellers
    [HttpGet]
    public IActionResult GetSellers()
    {
      var sellers = _sellerService.GetSellers();
      if (sellers == null)
      {
        return NotFound();

      }
      return Ok(sellers);
    }

    // GET: api/Sellers/5
    [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetSeller(int id)
        {
            var seller = _sellerService.GetSeller(id);

            if (seller == null)
            {
                return NotFound();
            }

            return seller;
        }

        // PUT: api/Sellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutSeller(int id, Seller seller)
        {
            var sellerr = _sellerService.PutSeller(id, seller);
            if(seller == null)
             {
                return BadRequest();

             }
      return Ok(sellerr);

        }

        // POST: api/Sellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seller>> PostSeller(Seller seller)
        {
            var sellers = _sellerService.PostSeller(seller);
            if (sellers == null)
              return BadRequest();
            var user = new ApplicationUser { UserName = seller.Email, Email = seller.Email };


            var result = await _userManager.CreateAsync(user, seller.Password);
            if (result.Succeeded)
              await _userManager.AddToRoleAsync(user, "Seller");
      return Ok(seller);

    }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
      var seller = _sellerService.DeleteSeller(id);
            if (seller == null)
            {
                return NotFound();
            }


      return Ok(seller);
        }

    }
}
