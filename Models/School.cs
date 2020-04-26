using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80, ErrorMessage = "Este campo deve conter no máximo 80 caracteres")]
        [MinLength(6, ErrorMessage = "Este campo deve conter ao menos 6 caracteres")]
        public string Name { get; set; }
    }
}
