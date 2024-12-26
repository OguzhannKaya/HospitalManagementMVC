using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoomService : Service, IService<Room, RoomModel>
    {
        public RoomService(Db db) : base(db)
        {
        }

        public Service Create(Room record)
        {
            if (_db.Rooms.Any(c => c.Number == record.Number))
                return Error("Room with the same number exist!");
            _db.Rooms.Add(record);
            _db.SaveChanges();
            return Success("Room is created successfully");
        }

        public Service Delete(int id)
        {
            Room room = _db.Rooms.SingleOrDefault(r => r.RoomID == id);
            if (room == null)
                return Error("Room is not found!");
            _db.Remove(room);
            _db.SaveChanges();
            return Success("Room is deleted successfully");
        }

        public IQueryable<RoomModel> Query()
        {
            return _db.Rooms.OrderBy(c => c.Number).Select(c => new RoomModel()
            {
                Record = c,
            });
        }

        public Service Update(Room record)
        {
            if (_db.Rooms.Any(r => r.RoomID != record.RoomID && r.Number == record.Number))
                return Error("Room with the same number exists!");
            var entity = _db.Rooms.SingleOrDefault(r => r.RoomID == record.RoomID);
            if (entity == null)
                return Error("Room not found!");
            entity.Number = record.Number;
            _db.Rooms.Update(entity);
            _db.SaveChanges();
            return Success("Room is updated successfully");
        }
    }
}
