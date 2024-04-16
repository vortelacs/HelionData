using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Position { get; set; }
    }
}