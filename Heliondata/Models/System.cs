using System.ComponentModel.DataAnnotations;
namespace Heliondata.Models
{
    public class System
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
    }
}