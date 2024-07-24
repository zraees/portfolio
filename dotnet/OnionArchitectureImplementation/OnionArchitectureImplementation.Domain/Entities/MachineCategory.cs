using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMv2.Domain.Entities
{
    public class MachineCategory
    {
        public int MachineCategoryID { get; set; }
        public string MachineCategoryNo { get; set; }
        public string ArMachineCategoryName { get; set; }
        public string EnMachineCategoryName { get; set; }
        public string ArMachineCategoryDescription { get; set; }
        public string EnMachineCategoryDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
