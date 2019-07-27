using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPanel.Model.Shared
{
    public class TimeStamp
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
