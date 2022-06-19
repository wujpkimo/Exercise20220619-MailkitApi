using MailKit.Net.Smtp;
using MailkitApi.Models;
using MailkitApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace MailkitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public ActionResult SendMail(MailDto request)
        {
            _mailService.SendMail(request);
            return Ok();
        }
    }
}