using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Workplace
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Zone { get; set; }
        public String City { get; set; }
        public String Address { get; set; }
    }
}