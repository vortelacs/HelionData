using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Models.DTO;
using Heliondata.Models.JoinModels;
using Heliondata.Models.Mappers;
using Heliondata.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProcessServiceModel = Heliondata.Models.JoinModels.ProcessService;

namespace Heliondata.Services
{
    public class ProcessService
    {
        private readonly ILogger<ProcessService> _logger;
        private readonly HelionDBContext _helionDBContext;
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
            IGenericRepository<ProcessWorkplace> processWorkplaceRepository,
            ILogger<ProcessService> logger,
            HelionDBContext helionDBContext
            )
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
            _logger = logger;
            _helionDBContext = helionDBContext;
        }

        public Task<Process> GetProcess(int ID)
        {
            return _processRepository.GetByID(ID);
        }

        public List<ProcessInfoDTO> GetAllProcess()
        {
            var processes = _processRepository.GetAll();
            var processInfoDTOs = processes.Result.Select(ProcessMapper.MapProcessToProcessInfoDTO).ToList();
            return processInfoDTOs;
        }


        public async Task<int> SaveProcess(ProcessCreateRequestDTO processDTO)
        {
            try
            {
                Process process = MapDTOToProcess(processDTO);
                int savedID = await _processRepository.Add(process);
                await CreateAndSaveJoinModelEntities(process, processDTO);
                return savedID;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while saving the process.", ex);
            }
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
                GPSLocation = processDTO.GPSLocation,
                CompanyId = processDTO.CompanyId,
                RepresentativeId = processDTO.RepresentativeId
            };

            // if (!_companyRepository.Exists(processDTO.CompanyId))
            // {
            //     throw new Exception($"Company with ID {processDTO.CompanyId} not found.");
            // }
            // if (!_representativeRepository.Exists(processDTO.RepresentativeId))
            // {
            //     throw new Exception($"Representative with ID {processDTO.RepresentativeId} not found.");
            // }

            return process;
        }

        public async Task CreateAndSaveJoinModelEntities(Process process, ProcessCreateRequestDTO processDTO)
        {
            if (!processDTO.EmployeeIds.IsNullOrEmpty() && process != null)
            {
                foreach (var employeeId in processDTO.EmployeeIds)
                {
                    var employeeProcess = new EmployeeProcess
                    {
                        EmployeeId = employeeId,
                        ProcessId = process.ID
                    };
                    await _employeeProcessRepository.Add(employeeProcess);
                }
            }


            if (!processDTO.ServiceIds.IsNullOrEmpty())
            {
                foreach (var serviceId in processDTO.ServiceIds)
                {
                    var processService = new ProcessServiceModel
                    {
                        ServiceId = serviceId,
                        ProcessId = process.ID
                    };
                    await _processServiceRepository.Add(processService);
                }
            }

            if (!processDTO.WorkplacesIds.IsNullOrEmpty())
            {
                foreach (var workplaceId in processDTO.WorkplacesIds)
                {
                    var processWorkplace = new ProcessWorkplace
                    {
                        WorkplaceId = workplaceId,
                        ProcessId = process.ID
                    };
                    await _processWorkplaceRepository.Add(processWorkplace);
                }
            }
        }


        public async Task<bool> DeleteProcess(int processId)
        {
            using (var transaction = _helionDBContext.Database.BeginTransaction())
            {
                try
                {
                    var process = await _helionDBContext.Processes
                        .Include(p => p.ProcessServices)
                        .Include(p => p.ProcessWorkplaces)
                        .Include(p => p.EmployeeProcesses)
                        .SingleOrDefaultAsync(p => p.ID == processId);

                    if (process == null)
                        return false;

                    _helionDBContext.ProcessServices.RemoveRange(process.ProcessServices);
                    _helionDBContext.ProcessWorkplaces.RemoveRange(process.ProcessWorkplaces);
                    _helionDBContext.EmployeeProcesses.RemoveRange(process.EmployeeProcesses);

                    _helionDBContext.Processes.Remove(process);
                    await _helionDBContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception ex)
                {

                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }


    }


}