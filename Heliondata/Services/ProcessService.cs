using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Repositories;

namespace Heliondata.Services
{
    public class ProcessService
    {
        IGenericRepository<Process> _processRepository;
        IGenericRepository<Company> _companyRepository;
        IGenericRepository<Representative> _representativeRepository;
        IGenericRepository<Employee> _employeeRepository;
        IGenericRepository<Workplace> _workplaceRepository;
        IGenericRepository<Service> _serviceRepository;

        public ProcessService(
            IGenericRepository<Process> processRepository,
            IGenericRepository<Company> companyRepository,
            IGenericRepository<Employee> employeeRepository,
            IGenericRepository<Representative> representativeRepository,
            IGenericRepository<Workplace> workplaceRepository,
            IGenericRepository<Service> serviceRepository)
        {
            _processRepository = processRepository;
            _companyRepository = companyRepository;
            _representativeRepository = representativeRepository;
            _workplaceRepository = workplaceRepository;
            _employeeRepository = employeeRepository;
            _serviceRepository = serviceRepository;
        }

        public Process GetProcess(int ID)
        {
            return _processRepository.GetByID(ID);
        }

        public List<Process> GetAllProcess()
        {
            return (List<Process>)_processRepository.GetAll();
        }


        public async Task<Process> SaveProcess(ProcessDTO processDTO)
        {
            Process process = MapDTOToProcessAsync(processDTO);
            process = _processRepository.Add(process).Result;
            await CreateAndSaveJoinModelEntities(process, processDTO);
            return process;
        }


        public Process MapDTOToProcessAsync(ProcessDTO processDTO)
        {
            var process = new Process
            {
                SignDate = processDTO.SignDate,
                ESignature = processDTO.ESignature,
                GPSLocation = processDTO.GPSLocation
            };

            var company = _companyRepository.GetByID(processDTO.CompanyId);
            if (company == null)
            {
                throw new Exception($"Company with ID {processDTO.CompanyId} not found.");
            }
            process.Company = company;

            var representative = _representativeRepository.GetByID(processDTO.RepresentativeId);
            if (representative == null)
            {
                throw new Exception($"Representative with ID {processDTO.RepresentativeId} not found.");
            }
            process.Representative = representative;

            return process;
        }


        public async Task CreateAndSaveJoinModelEntities(Process process, ProcessDTO processDTO)
        {
            // if (processDTO.EmployeeProcessIds != null)
            // {
            //     List<Employee> employees = new List<Employee>();

            //     processDTO.EmployeeProcessIds.ForEach(employeeId =>
            //     employees.Add(_employeeRepository.GetByID(employeeId))
            //     );

            //     foreach (var employee in employees)
            //     {
            //         var employeeProcess = new Models.JoinModels.EmployeeProcess();
            //         employeeProcess.EmployeeId = employee.ID;
            //         employeeProcess.ProcessId = process.ID;
            //         if (employeeProcess == null)
            //         {
            //             throw new Exception($"EmployeeProcess with ID {employeeProcessId} not found.");
            //         }
            //         process.EmployeeProcesses.Add(employeeProcess);
            //     }
            //     process.EmployeeProcesses = new List<EmployeeProcess>();
            // }

            // if (processDTO.ProcessServiceIds != null)
            // {
            //     process.ProcessServices = new List<ProcessService>();
            //     foreach (var processServiceId in processDTO.ProcessServiceIds)
            //     {
            //         var processService = _processServiceRepository.GetByID(processServiceId);
            //         if (processService == null)
            //         {
            //             // Handle the case where ProcessService is not found
            //             throw new Exception($"ProcessService with ID {processServiceId} not found.");
            //         }
            //         process.ProcessServices.Add(processService);
            //     }
            // }

        }


    }
}