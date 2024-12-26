namespace BLL.DAL
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? Hour {  get; set; }
        public int Price { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int BranchId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Branch Branch { get; set; }
    }
}
