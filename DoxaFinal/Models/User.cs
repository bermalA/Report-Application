using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DoxaFinal.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen bir email adresi giriniz")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir email adresi giriniz")]
        [Column(TypeName ="nvarchar(30)")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Lütfen bir şifre giriniz")]
        [Column(TypeName ="nvarchar(20)")]
        public string Password { get; set; }
        [Column(TypeName ="bit")]
        public bool ActiveUser { get; set; }
    }
}
