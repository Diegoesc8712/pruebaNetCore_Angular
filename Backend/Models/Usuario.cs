

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Backend.Models
{
    public partial class Usuario
    {
       [Key]
       public int Id { get; set; }

       [Required(ErrorMessage = "El usuario no puede estar vacio.")]
       public string usuario { get; set; }

       [Required(ErrorMessage = "El password no puede estar vacia .")]
       public string password { get; set; }

       [Compare("password", ErrorMessage = "Las contraseñas no coinciden")]
       [NotMapped]
       public string confirmaPassword { get; set; }
       public int estado { get; set; }
       public string salt { get; set; }
    }
}
