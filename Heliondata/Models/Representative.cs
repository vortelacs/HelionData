using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Representative
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public int CompanyID { get; set; }

        public virtual Company Company { get; set; }
        public virtual List<Process> Processes { get; set; }
    }
}