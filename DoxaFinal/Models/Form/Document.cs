using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoxaFinal.Models.Form
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        [ForeignKey("Receipt")]
        public int ReceiptId { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string DocumentName { get; set; }
        public byte[]? DocumentData { get; set; }
        [Column(TypeName ="date")]
        public DateTime DocUploadTime { get; set; } = DateTime.Now;
    }
}
