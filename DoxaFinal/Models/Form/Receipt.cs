using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoxaFinal.Models.Form
{
    public class Receipt
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int RevisionId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string ReceiptName { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime ReceiptDate { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string ReceiptCode { get; set; }
    }
}
