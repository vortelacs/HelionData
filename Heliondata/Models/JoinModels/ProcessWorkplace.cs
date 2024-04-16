using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heliondata.Models.JoinModels
{
    public class ProcessWorkplace
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("WorkplaceId")]
        public int WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }

        [ForeignKey("ProcessId")]
        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }
}