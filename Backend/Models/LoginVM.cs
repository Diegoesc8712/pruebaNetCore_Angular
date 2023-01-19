using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Password { get; set; }
    }
}
