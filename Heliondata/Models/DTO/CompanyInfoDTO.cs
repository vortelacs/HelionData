namespace Heliondata.Models.DTO
{
    public class CompanyInfoDTO : BaseModel
    {
        public int CUI { get; set; }
        public String Name { get; set; }

        public int? CNP { get; set; }
        public string? Activity { get; set; }
        public int? RegistrationCode { get; set; }
    }
}