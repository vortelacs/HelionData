using System.ComponentModel.DataAnnotations;

namespace Heliondata.Models
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }
    }
}