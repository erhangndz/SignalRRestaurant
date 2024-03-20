using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Text;
using ZXing;
using ZXing.Windows.Compatibility;

namespace SignalR.WebUI.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public QRCodeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

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
                    string webRootPath = _environment.WebRootPath;
                    image.Save(webRootPath + "\\QRimages\\QrCode.png" );
                    ViewBag.qrCodeImage = "\\QRimages\\QrCode.png";
                }
            }
                return View();
        }


        public IActionResult Decode(string code)
        {
            string webRootPath = _environment.WebRootPath;
            var path = webRootPath + "\\QRimages\\QrCode.png";
            var reader = new BarcodeReaderGeneric();
            Bitmap image = (Bitmap)Image.FromFile(path);
            using (image)
            {

                LuminanceSource source;
                source= new BitmapLuminanceSource(image);
                var result = reader.Decode(source);
                byte[] bytes = Encoding.Default.GetBytes(result.ToString());
                string myString = Encoding.UTF8.GetString(bytes);

                ViewBag.qrText = myString;
                TempData["qrTableNumber"] = myString;
            }
                return View("Index");
        }
    }
}
