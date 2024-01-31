using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.Services.ClientService;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
    private IClientService _clientService;
    public ClientsController(IClientService clientService) {
      _clientService = clientService;

    }
        // GET: api/Clients
        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _clientService.GetClients();
            if (clients == null)
          {
              return NotFound();

          }
            return Ok(clients);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client =  _clientService.GetClient(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  IActionResult PutClient(int id, Client client)
        {
      var clientt = _clientService.PutClient(id, client);
            if (clientt == null)
            {
                return BadRequest();
            }
            return Ok(clientt);

        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            var clients = _clientService.PostClient(client);
            if(clients == null)
                return BadRequest();
            return Ok(clients);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var clients = _clientService.DeleteClient(id);
            if (clients == null)
            {
                return NotFound();
            }
      return Ok(clients);
        }

       
    }
}
