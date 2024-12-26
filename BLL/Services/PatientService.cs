using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PatientService : Service, IService<Patient, PatientModel>
    {
        public PatientService(Db db) : base(db)
        {
        }

        public Service Create(Patient record)
        {
            if (_db.Patients.Any(u => u.Name.ToUpper() == record.Name.ToUpper().Trim() && u.Surname.ToUpper() == record.Surname.ToUpper().Trim()))
                return Error("Patient with the same name,surname exist");
            record.Name = record.Name?.Trim();
            record.Surname = record.Surname?.Trim();
            _db.Patients.Add(record);
            _db.SaveChanges();
            return Success("Patient created successfully");
        }

        public Service Delete(int id)
        {
            var entity = _db.Patients.SingleOrDefault(u => u.PatientId == id);
            if (entity == null)
                return Error("Patient not found!");
            _db.Patients.Remove(entity);
            _db.SaveChanges();
            return Success("Patient deleted successfully");
        }

        public IQueryable<PatientModel> Query()
        {
            return _db.Patients.OrderBy(u =>u.Name).Select(u => new PatientModel()
            { Record = u });
        }

        public Service Update(Patient record)
        {
            if (_db.Patients.Any(u => u.PatientId != record.PatientId && u.Name.ToUpper() == record.Name.ToUpper().Trim() && u.Surname.ToUpper() == record.Surname.ToUpper().Trim()))
                return Error("User with the same name, surname,gender and birthdate exist!");
            var entity = _db.Patients.SingleOrDefault(u => u.PatientId == record.PatientId);
            if (entity == null)
                return Error("User not found!");
            entity.Name = record.Name;
            entity.Surname = record.Surname;
            _db.Patients.Update(entity);
            _db.SaveChanges();
            return Success("User updated successfully");
        }
    }
}
