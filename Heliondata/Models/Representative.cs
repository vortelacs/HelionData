using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Representative
    {
        [Key]
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Position { get; set; }

        public List<Process> Processes { get; set; }
    }
}