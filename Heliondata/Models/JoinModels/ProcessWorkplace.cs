using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heliondata.Models.JoinModels
{
    public class ProcessWorkplace : BaseModel
    {

        [ForeignKey("WorkplaceId")]
        public int WorkplaceId { get; set; }
        public virtual Workplace Workplace { get; set; }

        [ForeignKey("ProcessId")]
        public int ProcessId { get; set; }
        public virtual Process Process { get; set; }
    }
}