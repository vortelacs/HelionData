using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Service
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
    }
}