using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalR.WebUI.Dtos.MailDtos;

namespace SignalR.WebUI.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            var mimeMessage = new MimeMessage();

            var mailBoxAddressFrom = new MailboxAddress("Gündüz Restoran Rezervasyon", "gunduzrestoran@gmail.com");
            mimeMessage.From.Add(mailBoxAddressFrom);

            var mailBoxAddressTo = new MailboxAddress("Sayın Kullanıcı", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailBoxAddressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject= createMailDto.Subject;
            var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("gunduzrestoran@gmail.com", "irxmszakvfekhaxl");

            client.Send(mimeMessage);
            client.Disconnect(true);
            return NoContent();
        }
    }
}
