using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class AppointmentService : Service, IService<Appointment, AppointmentModel>
    {
        public AppointmentService(Db db) : base(db)
        {
        }

        public Service Create(Appointment record)
        {
            if (_db.Appointments.Any(a => a.DoctorId==record.DoctorId && a.Hour == record.Hour))
                return Error("Appointment has already exist. Choose another day or time");
            //var doctor = _db.Doctors.Include(d => d.Branch).FirstOrDefault(d => d.DoctorId == record.DoctorId);
            //record.BranchId = doctor.BranchId;
            record.Hour = record.Hour;
            record.Price = record.Price;
            _db.Appointments.Add(record);
            _db.SaveChanges();
            return Success("Appointment is created successfully.");
        }

        public Service Delete(int id)
        {
            var entity = _db.Appointments.SingleOrDefault(t => t.AppointmentId == id);
            if (entity == null)
                return Error("Appointment not found!");
            _db.Appointments.Remove(entity);
            _db.SaveChanges();
            return Success("Appointment deleted successfully");
        }

        public IQueryable<AppointmentModel> Query()
        {
            return _db.Appointments.Include(t => t.Doctor).Include(t => t.Branch).Include(t => t.Patient).OrderBy(t => t.Hour).Select(t => new AppointmentModel()
            { Record = t });
        }

        public Service Update(Appointment record)
        {
            if (_db.Appointments.Any(a => a.DoctorId == record.DoctorId && a.Hour == record.Hour))
                return Error("Appointment has already exist. Choose another day or time");
            var entity = _db.Appointments.SingleOrDefault(t => t.AppointmentId == record.AppointmentId);
            if (entity == null)
                return Error("Appointment not found!");
            entity.Hour = record.Hour;
            entity.Price = record.Price;
            entity.DoctorId = record.DoctorId;
            entity.PatientId = record.PatientId;
            entity.BranchId = record.BranchId;
            _db.Appointments.Update(entity);
            _db.SaveChanges();
            return Success("Appointment updated successfully");
        }
    }
}
