using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heliondata.Models.JoinModels
{
    public class ProcessService
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ServiceId")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        [ForeignKey("ProcessId")]
        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }
}