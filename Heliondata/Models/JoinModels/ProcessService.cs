using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heliondata.Models.JoinModels
{
    public class ProcessService : BaseModel
    {

        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        [ForeignKey("ProcessId")]
        public int ProcessId { get; set; }
        public virtual Process Process { get; set; }
    }
}