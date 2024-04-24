using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heliondata.Models.JoinModels
{
    public class EmployeeProcess : BaseModel
    {

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("ProcessId")]
        public int ProcessId { get; set; }
        public virtual Process Process { get; set; }

    }
}