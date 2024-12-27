using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class AppointmentModel
    {
        public Appointment Record { get; set; }
        [DisplayName("Time and Day")]
        public string Hour => Record.Hour.HasValue ? Record.Hour.Value.ToString("MM/dd/yyyy HH:mm"): string.Empty;
        public string Price => Record.Price.ToString();
        public string Doctor => Record.Doctor?.Name;
        public string Branch => Record.Branch?.Name;
        public string Patient =>Record.Patient?.Name;
    }
}
