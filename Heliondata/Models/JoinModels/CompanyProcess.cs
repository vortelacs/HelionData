using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heliondata.Models
{
    public class CompanyProcess : BaseModel
    {

        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("ProcessId")]
        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }
}