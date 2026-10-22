using System.ComponentModel.DataAnnotations;

namespace FerreteriaValdivia.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        public string Apellido { get; set; } = string.Empty;
        
        public string Telefono { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
    }
}