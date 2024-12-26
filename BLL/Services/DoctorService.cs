using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DoctorService : Service, IService<Doctor, DoctorModel>
    {
        public DoctorService(Db db) : base(db)
        {
        }

        public Service Create(Doctor record)
        {
            if (_db.Doctors.Any(u => u.Name.ToUpper() == record.Name.ToUpper().Trim() && u.Surname.ToUpper() == record.Surname.ToUpper().Trim()))
                return Error("Doctor with the same name,surname and romm already exist");
            record.Name = record.Name?.Trim();
            record.Surname = record.Surname?.Trim();
            _db.Doctors.Add(record);
            _db.SaveChanges();
            return Success("Doctor created successfully");
        }

        public Service Delete(int id)
        {
            var entity = _db.Doctors.SingleOrDefault(u => u.DoctorId == id);
            if (entity == null)
                return Error("Doctor not found!");
            _db.Doctors.Remove(entity);
            _db.SaveChanges();
            return Success("Doctor deleted successfully");
        }

        public IQueryable<DoctorModel> Query()
        {
            return _db.Doctors.Include(u => u.Branch).Include(u=> u.Room).OrderByDescending(u => u.Name).ThenBy(u => u.Surname).Select(u => new DoctorModel()
            { Record = u });
        }

        public Service Update(Doctor record)
        {
            if (_db.Doctors.Any(u => u.DoctorId != record.DoctorId && u.Name.ToUpper() == record.Name.ToUpper().Trim() && u.Surname.ToUpper() == record.Surname.ToUpper().Trim()))
                return Error("Doctor with the same name, surname exist!");
            var entity = _db.Doctors.SingleOrDefault(u => u.DoctorId == record.DoctorId);
            if (entity == null)
                return Error("Doctor not found!");
            entity.Name = record.Name;
            entity.Surname = record.Surname;
            entity.BranchId = record.BranchId;
            entity.RoomId = record.RoomId;
            _db.Doctors.Update(entity);
            _db.SaveChanges();
            return Success("User updated successfully");
        }
    }
}
