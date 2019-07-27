using ControlPanel.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlPanel.Model.Domain
{
    //[Table("Planning.ExceptionSource")]
    public partial class ExceptionSource : TimeStamp
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
