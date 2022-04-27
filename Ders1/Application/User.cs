using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ders1.Application
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [StringLength(11, ErrorMessage ="Telefon 11 karakter olmalıdır", MinimumLength = 11)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Şifreler aynı olması gerek")]
        public string ConfirmPassword { get; set; }
    }
}
