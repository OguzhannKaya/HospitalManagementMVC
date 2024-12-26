using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Branch
    {
        public int BranchId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
