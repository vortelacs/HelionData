namespace Heliondata.Models.DTO
{
    public class ProcessDTO
    {
        public int ID { get; set; }
        public DateTime SignDate { get; set; }
        public int CompanyId { get; set; }
        public int RepresentativeId { get; set; }
        public string ESignature { get; set; }
        public string GPSLocation { get; set; }
        public List<int> EmployeeProcessIds { get; set; }
        public List<int> ProcessServiceIds { get; set; }
    }
}