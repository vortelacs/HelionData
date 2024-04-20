using Heliondata.Models.DTO;

namespace Heliondata.Models.Mappers
{
    public class ProcessMapper
    {
        public static ProcessInfoDTO MapProcessToProcessInfoDTO(Process process)
        {
            var processInfoDTO = new ProcessInfoDTO
            {
                ID = process.ID,
                SignDate = process.SignDate,
                CompanyName = process.Company?.Name,
                RepresentativeId = process.RepresentativeId,
                GPSLocation = process.GPSLocation,
                EmployeeNames = process.EmployeeProcesses?.Select(ep => ep.Employee?.FirstName + " " + ep.Employee?.LastName).ToList(),
                ServiceNames = process.ProcessServices?.Select(ps => ps.Service?.Name).ToList(),
                Workplace = process.ProcessWorkplaces?
                        .ToDictionary(pw => pw.Workplace?.Name, pw => pw.Workplace?.Zone + " " + pw.Workplace?.City + " " + pw.Workplace?.Address)
            };

            return processInfoDTO;
        }

    }
}