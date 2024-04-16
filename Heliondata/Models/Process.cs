using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Process
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Company Company { get; set; }
        public List<Workplace> Workplaces { get; set; }
        public List<Representative> Representative { get; set; }
        public List<Employee> Employees { get; set; }
        public List<System> Systems { get; set; }

        public String ESignature { get; set; }
        public String GPSLocation { get; set; }

    }
}