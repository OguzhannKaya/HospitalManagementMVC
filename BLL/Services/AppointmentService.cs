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
