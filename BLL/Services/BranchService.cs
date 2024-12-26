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
    public class BranchService : Service, IService<Branch, BranchModel>
    {
        public BranchService(Db db) : base(db)
        {
        }

        public Service Create(Branch record)
        {
            if (_db.Branches.Any(c => c.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Branch with the same name exist!");
            record.Name = record.Name?.Trim();
            _db.Branches.Add(record);
            _db.SaveChanges();
            return Success("Branch is created succesfully");
        }

        public Service Delete(int id)
        {
            Branch branch = _db.Branches.Include(c => c.Doctors).SingleOrDefault(c => c.BranchId == id);
            if (branch == null)
                return Error("Branch is not found!");
            if (branch.Doctors.Any())
                return Error("Branch has relational products!");
            _db.Remove(branch);
            _db.SaveChanges();
            return Success("Branch is deleted successfully");
        }

        public IQueryable<BranchModel> Query()
        {
            return _db.Branches.OrderBy(c => c.Name).Select(c => new BranchModel()
            {
                Record = c,
            });
        }

        public Service Update(Branch record)
        {
            if (_db.Branches.Any(c => c.BranchId != record.BranchId && c.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Branch with the same name exist!");

            var entity = _db.Branches.SingleOrDefault(c => c.BranchId == record.BranchId);
            if (entity is null)
                return Error("Branch not found!");
            entity.Name = record.Name?.Trim();
            _db.Branches.Update(entity);
            _db.SaveChanges();
            return Success("Branch is updated successfully.");
        }
    }
}
