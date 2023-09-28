using DoxaFinal.Models.Form;

namespace DoxaFinal.Models
{
    public class FormRepository
    {
        private readonly DatabaseContext _databaseContext;
        public FormRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public int GetReceiptId(string receiptName) 
        {

            try
            {
                Receipt receipt = _databaseContext.Receipts.FirstOrDefault(x => x.ReceiptName == receiptName);
                if (receipt != null)
                {
                    return receipt.Id;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return -1;
        }
        
        public void AddReceipt(Receipt receipt) 
        {
            _databaseContext.Receipts.Add(receipt);
            _databaseContext.SaveChanges();
        }

        public List<Receipt> GetReceipts()
        {
            return _databaseContext.Receipts.ToList();
        }

        public void AddMovement(Movement movement)
        {
            _databaseContext.Movements.Add(movement);
            _databaseContext.SaveChanges();
        }

        public List<Movement> GetMovements()
        {
            return _databaseContext.Movements.ToList();
        }
        public void AddDocument(Document document)
        {
            _databaseContext.Documents.Add(document);
            _databaseContext.SaveChanges();
        }
        public List <Document> GetDocuments() 
        {
            return _databaseContext.Documents.ToList();
        }

        public void AddProduct(Product product, out int productId)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();

            productId = product.ProductId;

        }
        public List <Product> GetProducts()
        {
            return _databaseContext.Products.ToList();
        }
        public void AddPart(Part part)
        {
            _databaseContext.Parts.Add(part);
            _databaseContext.SaveChanges();
        }
        public List<Part> GetParts()
        {
            return _databaseContext.Parts.ToList();
        }
    }
}
