using DoxaFinal.Models;
using DoxaFinal.Models.Form;
using DoxaFinal.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoxaFinal.Controllers
{
    public class ReportController : Controller
    {
        private readonly IFormatService _formatService;

        public ReportController (IFormatService formatService)
        {
            _formatService = formatService;

        }

        //HTML Sayfa Görüntüleri
        public IActionResult Receipt()
        {
            return View();
        }
        public IActionResult Movement()
        {
            return View();
        }
        public IActionResult Document()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Part()
        {
            return View();
        }


        //Formlardan alınan datanın işlenmesi


        [HttpPost]
        public IActionResult ReceiveData
            (Receipt receipt, Product product, Document document,
            [FromForm] List<string> PackageNo,[FromForm] List<string> PackageAmount, 
            [FromForm] List<string> FileName, [FromForm] List<string> PartName,
            [FromForm] List<string> PartCode, [FromForm] List<string> Thickness,
            [FromForm] List<string> Color, [FromForm] List<string> NetAmount,
            [FromForm] List<string> NetHeight, [FromForm] List<string> NetWidth,
            [FromForm] List<string> RoughAmount, [FromForm] List<string> RoughHeight,
            [FromForm] List<string> RoughWidth, [FromForm] List<string> ProductAmount,
            [FromForm] List<string> PVCType, [FromForm] List<string> PVCHeight,
            [FromForm] List<string> PVCWidth, [FromForm] List<string> Options,
            [FromForm] List<string> OptHeight, [FromForm] List<string> OptWidth,
            [FromForm] List<string> PartDescription)
        {
            int moveMax = (PackageAmount.Count >= PackageNo.Count) ? PackageAmount.Count : PackageNo.Count;

            Console.WriteLine(moveMax);
            if(ModelState.IsValid)
            {
                _formatService.FormatReceipt(receipt);
                for(int i = 0;i< moveMax; i++)
                {
                    Console.WriteLine("adding movement"); 
                    _formatService.FormatMovement(PackageNo[i], PackageAmount[i], receipt.Id);
                }

                string DocName = document.DocumentName;
             
                for(int i = 0; i< FileName.Count; i++)
                {
                    Console.WriteLine("adding document");
                    _formatService.FormatDocument(DocName, FileName[i], receipt.Id);
                }
                int productId;
                _formatService.FormatProduct(product, out productId);
                
                for (int i = 0; i < PartCode.Count; i++)
                {
                    Console.WriteLine("adding part");
                    _formatService.FormatPart(productId, PartCode[i],PartName[i], Thickness[i], Color[i], NetAmount[i],NetHeight[i],NetWidth[i], RoughAmount[i], RoughHeight[i],RoughWidth[i],ProductAmount[i],PVCType[i], PVCHeight[i],PVCWidth[i],Options[i],OptHeight[i],OptWidth[i],PartDescription[i]);
                }
            }
            else { Console.WriteLine("modl state error"); }


            return StatusCode(200);
        }
    }
}
