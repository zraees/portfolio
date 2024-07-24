using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMv2.Domain.Entities
{
    public class MachineType
    {
        public int MachineTypeID { get; set; }

        public int MachineCategoryID { get; set; }

        public MachineCategory MachineCategory { get; set; }

        public string MachineTypeNo { get; set; }

        public string MachineTypeName { get; set; }

        public string ArMachineTypeDescription { get; set; }

        public string EnMachineTypeDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
