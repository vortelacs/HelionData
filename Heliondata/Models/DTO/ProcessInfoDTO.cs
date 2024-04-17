namespace Heliondata.Models.DTO
{
    public class ProcessInfoDTO
    {
        public int ID { get; set; }
        public DateTime SignDate { get; set; }
        public string CompanyName { get; set; }
        public int RepresentativeId { get; set; }
        public string ESignature { get; set; }
        public string GPSLocation { get; set; }
        public List<string> EmployeeNames { get; set; }
        public List<string> ServiceNames { get; set; }
        public Dictionary<string, string> Workplace { get; set; }
    }
}