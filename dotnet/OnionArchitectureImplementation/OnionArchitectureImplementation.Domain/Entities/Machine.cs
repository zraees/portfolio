using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMv2.Domain.Entities
{
    public class Machine : ICommonEntity
    {
        public int MachineId { get; set; }

        public string ArMachineDescription { get; set; }

        public string EnMachineDescription { get; set; }

        public int MachineTypeID { get; set; }

        public MachineType MachineType { get; set; }

        public int FactoryID { get; set; }

        public Factory Factory { get; set; }

        public int FactorySectionID { get; set; }

        public FactorySection FactorySection { get; set; }

        public string MachineSerialNo { get; set; }

        public string MachineMaintenanceNo { get; set; }

        public string PurchasingNo { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
