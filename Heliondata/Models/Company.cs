using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public int CUI { get; set; }
        public String Name { get; set; }

        public List<Representative> Representatives { get; set; }

        public List<Workplace> Workplaces { get; set; }
    }
}