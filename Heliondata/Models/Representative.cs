using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Representative
    {
        [Key]
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String email { get; set; }
        public String position { get; set; }

    }
}