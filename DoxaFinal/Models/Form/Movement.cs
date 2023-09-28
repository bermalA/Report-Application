using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoxaFinal.Models.Form
{
    public class Movement
    {
        [Key]
        public int MovementId { get; set; }
        [ForeignKey("Receipt")]
        public int ReceiptId { get; set; }
        public string? PackageNo { get; set; }
        public int? PackageAmount { get; set; }
    }
}
