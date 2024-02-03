using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{

  [ApiController]
  public class ValuesController : ControllerBase
  {
    [Route("api/isSeller")]
    [Authorize(Roles = "Seller")]
    [HttpGet]
    public int isSeller()
    {
      return 1;
    }

    [Route("api/isClient")]
    [Authorize(Roles = "Client")]
    [HttpGet]
    public int isClient()
    {
      return 2;
    }
  }
}
