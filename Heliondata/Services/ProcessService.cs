using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Models.JoinModels;
using Heliondata.Models.Mappers;
using Heliondata.Repositories;
using Microsoft.IdentityModel.Tokens;
using ProcessServiceModel = Heliondata.Models.JoinModels.ProcessService;

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
        IGenericRepository<EmployeeProcess> _employeeProcessRepository;
        IGenericRepository<ProcessServiceModel> _processServiceRepository;
        IGenericRepository<ProcessWorkplace> _processWorkplaceRepository;

        public ProcessService(
            IGenericRepository<Process> processRepository,
            IGenericRepository<Company> companyRepository,
            IGenericRepository<Employee> employeeRepository,
            IGenericRepository<Representative> representativeRepository,
            IGenericRepository<Workplace> workplaceRepository,
            IGenericRepository<Service> serviceRepository,
            IGenericRepository<EmployeeProcess> employeeProcessRepository,
            IGenericRepository<ProcessServiceModel> processServiceRepository,
            IGenericRepository<ProcessWorkplace> processWorkplaceRepository)
        {
            _processRepository = processRepository;
            _companyRepository = companyRepository;
            _representativeRepository = representativeRepository;
            _workplaceRepository = workplaceRepository;
            _employeeRepository = employeeRepository;
            _serviceRepository = serviceRepository;
            _employeeProcessRepository = employeeProcessRepository;
            _processServiceRepository = processServiceRepository;
            _processWorkplaceRepository = processWorkplaceRepository;
        }

        public Process GetProcess(int ID)
        {
            return _processRepository.GetByID(ID);
        }

        public List<ProcessInfoDTO> GetAllProcess()
        {
            var processes = _processRepository.GetAll();
            var processInfoDTOs = processes.Select(ProcessMapper.MapProcessToProcessInfoDTO).ToList();
            return processInfoDTOs;
        }


        public async Task<Process> SaveProcess(ProcessCreateRequestDTO processDTO)
        {
            Process process = MapDTOToProcess(processDTO);
            process = _processRepository.Add(process).Result;
            await CreateAndSaveJoinModelEntities(process, processDTO);
            return process;
        }


        public Process MapDTOToProcess(ProcessCreateRequestDTO processDTO)
        {


            string dataUrl = processDTO.ESignature;
            string base64Data = dataUrl.Split(',')[1];
            byte[] imageData = Convert.FromBase64String(base64Data);

            var process = new Process
            {
                SignDate = processDTO.SignDate,
                ESignature = imageData,
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


        public async Task CreateAndSaveJoinModelEntities(Process process, ProcessCreateRequestDTO processDTO)
        {
            if (!processDTO.EmployeeIds.IsNullOrEmpty() && process != null)
            {
                List<Employee> employees = new List<Employee>();

                processDTO.EmployeeIds.ForEach(employeeId =>
                employees.Add(_employeeRepository.GetByID(employeeId))
                );

                foreach (var employee in employees)
                {
                    var employeeProcess = new EmployeeProcess
                    {
                        EmployeeId = employee.ID,
                        ProcessId = process.ID
                    };
                    await _employeeProcessRepository.Add(employeeProcess);
                }
            }
            if (!processDTO.ServiceIds.IsNullOrEmpty())
            {
                List<Service> services = new List<Service>();

                processDTO.ServiceIds.ForEach(serviceId =>
                    services.Add(_serviceRepository.GetByID(serviceId))
                );

                foreach (var service in services)
                {
                    var processService = new ProcessServiceModel
                    {
                        ServiceId = service.ID,
                        ProcessId = process.ID
                    };
                    await _processServiceRepository.Add(processService);
                }
            }

            if (!processDTO.WorkplacesIds.IsNullOrEmpty())
            {
                List<Workplace> workplaces = new List<Workplace>();

                processDTO.ServiceIds.ForEach(workplaceId =>
                    workplaces.Add(_workplaceRepository.GetByID(workplaceId))
                );

                foreach (var workplace in workplaces)
                {
                    var processWorkplace = new ProcessWorkplace
                    {
                        WorkplaceId = workplace.ID,
                        ProcessId = process.ID
                    };
                    await _processWorkplaceRepository.Add(processWorkplace);
                }
            }

        }


    }


}