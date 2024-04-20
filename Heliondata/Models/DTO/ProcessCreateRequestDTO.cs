namespace Heliondata.Models.DTO
{
    public class ProcessCreateRequestDTO
    {
        public DateTime SignDate { get; set; }
        public int CompanyId { get; set; }
        public int RepresentativeId { get; set; }
        public string ESignature { get; set; }
        public string GPSLocation { get; set; }
        public List<int> WorkplacesIds { get; set; }
        public List<int> EmployeeIds { get; set; }
        public List<int> ServiceIds { get; set; }
    }
}