namespace Heliondata.Models.DTO
{
    public class CompanyInfoDTO : BaseModel
    {
        public int CUI { get; set; }
        public String Name { get; set; }

        public virtual List<int> Representatives { get; set; }
    }
}