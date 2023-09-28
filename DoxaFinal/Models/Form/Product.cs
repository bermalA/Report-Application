using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoxaFinal.Models.Form
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("Receipt")]
        public int ReceiptId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ProductDescription { get; set; }
    }
}
