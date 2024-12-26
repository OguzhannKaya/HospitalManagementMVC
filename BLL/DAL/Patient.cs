using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Patient
    {
        public int PatientId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
