using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(15, ErrorMessage = "Este campo deve conter no máximo 15 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter ao menos 3 caracteres")]
        public string Room { get; set; }
        public string TeacherName { get; set; }

        public string Subject { get; set; }
        public int StudentsLimit { get; set; }
        public School School { get; set; }
    }
}
