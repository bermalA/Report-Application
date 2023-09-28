using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoxaFinal.Models.Form
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PartCode { get; set; }
        [Required]
        public int PartLogicalRef { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PartName { get; set; }
        public int? Thickness { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Color { get; set; }
        public int? NetAmount { get; set; }
        public int? NetHeight { get; set; }
        public int? NetWidth { get; set; }
        public int? RoughAmount { get; set; }
        public int? RoughHeight { get; set; }
        public int? RoughWidth { get; set; }
        public int? ProductAmount { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? PVCType { get; set; }
        public int? PVCHeight { get; set; }
        public int? PVCWidth { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Options { get; set; }
        public int? OptHeight { get; set; }
        public int? OptWidth { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? PartDescription { get; set; }
    }
}
