
using AutoMapper;
using Heliondata.Data;
using Heliondata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Heliondata.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudControllerBase<TEntity, TDto> : ControllerBase where TEntity : BaseModel where TDto : class
    {
        protected readonly HelionDBContext _context;
        protected readonly IMapper _mapper;

        public CrudControllerBase(HelionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> List()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            var dtos = entities.Select(entity => _mapper.Map<TDto>(entity)).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Detail(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return NotFound();
            var dto = _mapper.Map<TDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Detail", new { id = entity.ID }, dto);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(int id, TDto dto)
        {
            if (!await EntityExists(id))
                return NotFound();

            var entity = _mapper.Map<TEntity>(dto);
            entity.ID = id; // Ensure the ID is set correctly
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private Task<bool> EntityExists(int id)
        {
            return _context.Set<TEntity>().AnyAsync(e => e.ID == id);
        }
    }
}