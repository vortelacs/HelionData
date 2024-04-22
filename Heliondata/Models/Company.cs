using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class Company : BaseModel
    {
        public int CUI { get; set; }
        public String Name { get; set; }

        public virtual List<Representative> Representatives { get; set; }
    }

    public class PFA : Company
    {
        public int CNP { get; set; }
        public string Activity { get; set; }
    }

    public class SRL : Company
    {
        public int RegistrationCode { get; set; }
    }
}