// API Controller Layer
// CRUD ENDPOINTS for Sternritter resource
// Uses ISternritterRepository to perform data operations

using Microsoft.AspNetCore.Mvc;
using Wandenreich.Api.DTOs;
using Wandenreich.Api.Models;
using Wandenreich.Api.Repositories;

namespace Wandenreich.Api.Controllers;

[ApiController]
[Route("api/[controller]")]


public class SternritterController : ControllerBase
{
    private readonly ISternritterRepository _repository;

    public SternritterController(ISternritterRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SternritterReadDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SternritterReadDto>>> GetAll()
    {
        var sternritters = await _repository.GetAllAsync();
        var dtos = sternritters.Select(MapToReadDto);
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SternritterReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SternritterReadDto>> GetById(int id)
    {
        var sternritter = await _repository.GetByIdAsync(id);
        if (sternritter is null)
        {
            return NotFound();
        }
        return Ok(MapToReadDto(sternritter));
    }

    [HttpPost]
    [ProducesResponseType(typeof(SternritterReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SternritterReadDto>> Create(SternritterCreateDto createDto)
    {
        var sternritter = new Sternritter
        {
            Name = createDto.Name,
            Designation = createDto.Designation,
            Epithet = createDto.Epithet,
            Rank = createDto.Rank,
            IsAlive = createDto.IsAlive,
            Description = createDto.Description
        };

        var created = await _repository.CreateAsync(sternritter);
        var readDto = MapToReadDto(created);

        return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, SternritterCreateDto updateDto)
    {
        var sternritter = await _repository.GetByIdAsync(id);
        if (sternritter is null)
        {
            return NotFound();
        }

        sternritter.Name = updateDto.Name;
        sternritter.Designation = updateDto.Designation;
        sternritter.Epithet = updateDto.Epithet;
        sternritter.Rank = updateDto.Rank;
        sternritter.IsAlive = updateDto.IsAlive;
        sternritter.Description = updateDto.Description;

        await _repository.UpdateAsync(sternritter);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var sternritter = await _repository.GetByIdAsync(id);
        if (sternritter is null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(sternritter);
        return NoContent();
    }

    private static SternritterReadDto MapToReadDto(Sternritter s) => new()
    {
        Id = s.Id,
        Name = s.Name,
        Designation = s.Designation,
        Epithet = s.Epithet,
        Rank = s.Rank,
        IsAlive = s.IsAlive,
        Description = s.Description
    };
}