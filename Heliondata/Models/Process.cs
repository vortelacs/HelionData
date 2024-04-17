using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Heliondata.Models.JoinModels;

namespace Heliondata.Models
{
    public class Process
    {
        [Key]
        public int ID { get; set; }
        public DateTime SignDate { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<ProcessWorkplace> ProcessWorkplaces { get; set; }

        [ForeignKey("RepresentativeId")]
        public int RepresentativeId { get; set; }
        public virtual Representative Representative { get; set; }
        public virtual List<EmployeeProcess> EmployeeProcesses { get; set; }
        public virtual List<ProcessService> ProcessServices { get; set; }

        public String ESignature { get; set; }
        public String GPSLocation { get; set; }

    }
}