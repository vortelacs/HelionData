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
        public Company Company { get; set; }
        public List<ProcessWorkplace> ProcessWorkplaces { get; set; }

        [ForeignKey("CompanyId")]
        public int RepresentativeId { get; set; }
        public Representative Representative { get; set; }
        public List<EmployeeProcess> EmployeeProcesses { get; set; }
        public List<ProcessService> ProcessServices { get; set; }

        public String ESignature { get; set; }
        public String GPSLocation { get; set; }

    }
}