using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalR.WebUI.Controllers
{
    public class QRCodeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string value)
        {
            using (var memoryStream = new MemoryStream())
            {
                var codeGenerator = new QRCodeGenerator();

                QRCodeGenerator.QRCode squareCode = codeGenerator.CreateQrCode(value,QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.qrCodeImage = "data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                }
            }
                return View();
        }


        public IActionResult Decode(string code)
        {
            return View();
        }
    }
}
