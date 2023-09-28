using DoxaFinal.Models;
using DoxaFinal.Models.Form;
using System.Text;

namespace DoxaFinal.Services
{
    public interface IFormatService
    {
        bool FormatReceipt(Receipt receipt);
        bool FormatMovement(string packageNo, string packageAmount, int receiptId);
        bool FormatDocument(string documentName, string FileName, int receiptId);
        bool FormatProduct(Product product, out int productId);
        bool FormatPart(int ProductId, string PartCode, string PartName, string Thickness,
            string Color, string NetAmount, string NetHeight, string NetWidth, string RoughAmount,
            string RoughHeight, string RoughWidth, string ProductAmount, string PVCType, string PVCHeight,
            string PVCWidth, string Options, string OptHeight, string OptWidth, string PartDescription);
    }
    public class FormatService : IFormatService
    {
        private readonly FormRepository _formRepository;
        public FormatService(FormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public bool FormatReceipt(Receipt receipt)
        {
            Receipt last = _formRepository.GetReceipts().OrderByDescending(p => p.Id).FirstOrDefault();
            receipt.RevisionId = last.Id;
            _formRepository.AddReceipt(receipt);

            return true;
        }
        public bool FormatMovement(string packageNo, string packageAmount, int receiptId)
        {
            Movement movement = new Movement();
            if (int.TryParse(packageAmount, out int parsedPackageAmount))
            {
                movement.PackageAmount = parsedPackageAmount;
            }
            else { movement.PackageAmount = 0; }
            movement.ReceiptId = receiptId;
            movement.PackageNo = packageNo;
            _formRepository.AddMovement(movement);
            return true;
        }
        public bool FormatDocument(string documentName, string FileName, int receiptId)
        {
            Document document = new Document();
            document.DocumentName = documentName;
            byte[] documentData = Encoding.UTF8.GetBytes(FileName);
            document.DocumentData = documentData;
            document.ReceiptId = receiptId;
            _formRepository.AddDocument(document);
            return true;
        }
        public bool FormatProduct(Product product, out int productId)
        {

            _formRepository.AddProduct(product, out productId);
            return true;
        }
        public bool FormatPart(int ProductId,string PartCode, string PartName, string Thickness,
            string Color, string NetAmount, string NetHeight, string NetWidth, string RoughAmount,
            string RoughHeight, string RoughWidth, string ProductAmount, string PVCType, string PVCHeight,
            string PVCWidth, string Options, string OptHeight, string OptWidth, string PartDescription)
        {
            Part part = new Part();
            if (int.TryParse(Thickness, out int thickness))
                part.Thickness = thickness;
            else thickness = 0;
            if (int.TryParse(NetAmount, out int netamount))
                part.NetAmount = netamount;
            else netamount= 0;
            if(int.TryParse(NetHeight, out int netheight))
                part.NetHeight = netheight;
            else netheight= 0;
            if(int.TryParse(NetWidth, out int netwidth))
                part.NetWidth = netwidth;
            else netwidth= 0;
            if(int.TryParse(RoughAmount, out int roughamount))
                part.RoughAmount = roughamount;
            else roughamount= 0;
            if(int.TryParse(RoughWidth,out int roughwidth))
                part.RoughWidth = roughwidth;
            else roughwidth= 0;
            if(int.TryParse(RoughHeight,out int roughheight))
                part.RoughHeight = roughheight;
            else roughheight= 0;
            if(int.TryParse(ProductAmount,out int productamount))
                part.ProductAmount = productamount;
            else part.ProductAmount = 0;
            if(int.TryParse(PVCHeight,out int pvcheight))
                part.PVCHeight = pvcheight;
            else part.PVCHeight = 0;
            if(int.TryParse(PVCWidth,out int pvcwidth))
                part.PVCWidth = pvcwidth;
            else part.PVCWidth = 0;
            if(int.TryParse(OptHeight,out int optheight))
                part.OptHeight = optheight;
            else part.OptHeight = 0;
            if(int.TryParse(OptWidth, out int opthwidth))
                part.OptWidth = opthwidth;
            else part.OptWidth = 0;
            
            part.ProductId = ProductId;
            part.PartCode = PartCode;
            part.PartName = PartName;
            part.Color = Color;
            part.PVCType = PVCType;
            part.Options = Options;
            part.PartDescription = PartDescription;
            _formRepository.AddPart(part);
            return true;
        }
    }
}
