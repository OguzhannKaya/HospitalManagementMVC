using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class PatientModel
    {
        public Patient Record { get; set; }
        public string Name => Record.Name;
        public string Surname => Record.Surname;
    }
}
