using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int RoomId   { get; set; }
        public Room Room { get; set; }
    }
}
