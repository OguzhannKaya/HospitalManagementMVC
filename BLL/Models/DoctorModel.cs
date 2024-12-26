using BLL.DAL;

namespace BLL.Models
{
    public class DoctorModel
    {
        public Doctor Record { get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;
        public string Branch => Record.Branch?.Name;
        public string Room => Record.Room?.Number.ToString();
    }
}
