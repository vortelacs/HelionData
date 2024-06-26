using System.ComponentModel.DataAnnotations;
using Heliondata.Models.JoinModels;

namespace Heliondata.Models
{
    public class Employee : BaseModel
    {
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Position { get; set; }

        public virtual List<EmployeeProcess> EmployeeProcesses { get; set; }
    }
}