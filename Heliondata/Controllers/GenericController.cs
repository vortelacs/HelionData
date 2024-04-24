
using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Heliondata.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Heliondata.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudControllerBase<T, TDto> : ControllerBase where T : BaseModel where TDto : class
    {
        private readonly IGenericRepository<T> _repository;
        protected readonly IMapper _mapper;

        public CrudControllerBase(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entities = await _repository.GetAll();
            var dtos = entities.Select(entity => _mapper.Map<TDto>(entity)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var entity = await _repository.GetByID(id);
            if (entity == null)
                return NotFound();
            var dto = _mapper.Map<TDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            int id = await _repository.Add(entity);
            return CreatedAtAction("Detail", new { id = id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TDto dto)
        {
            var existingEntity = await _repository.GetByID(id);
            if (existingEntity == null)
                return NotFound();

            _mapper.Map(dto, existingEntity);
            await _repository.Update(existingEntity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByID(id);
            if (entity == null)
                return NotFound();

            await _repository.Delete(id);
            return NoContent();
        }
    }
}