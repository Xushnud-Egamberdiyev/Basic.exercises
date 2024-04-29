using EmailNotification.Interfaces;
using EmailNotification.Models;
using EmailNotification.Serveces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService) =>
            _emailService = emailService;
        

        [HttpPost]
        public async Task<IActionResult> SendMessageAsync(Message message)
        {
            await this._emailService.SendMessage(message);
            return Ok();
        }
    }
}
