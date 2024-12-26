using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RoomModel
    {
        public Room Record { get; set; }
        public int Number => Record.Number;
    }
}
