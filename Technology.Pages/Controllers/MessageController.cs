using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Technology.Pages.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private IHubContext<MessageHub> _hubContext;

        public MessageController(
            IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;

        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine("Now send an message to all hubs");
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hello", "Hamm");
            return Ok();
        }
    }
}
