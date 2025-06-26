using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.DTO;
using SAIS.Core.Domain.IRepository;
using SAIS.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LooksUpController(AppDbContext _context) : ControllerBase
{


    [HttpGet("GetProgrammes")]
    public async Task<IActionResult> GetProgrammes()
    {
        var data = await _context.Programmes.ToListAsync();
        return Ok(data);
    }

    [HttpGet("GetGenders")]
    public async Task<IActionResult> GetGenders()
    {
        var data = await _context.Genders.ToListAsync();
        return Ok(data);
    }

    [HttpGet("GetMaritalStatuses")]
    public async Task<IActionResult> GetMaritalStatuses()
    {
        var data = await _context.MaritalStatuses.ToListAsync();
        return Ok(data);
    }

    [HttpGet("GetCounties")]
    public async Task<IActionResult> GetCounties()
    {
        var data = await _context.Counties.ToListAsync();
        return Ok(data);
    }

    [HttpGet("GetSubCounties")]
    public async Task<IActionResult> GetSubCounties(int countyid)
    {
        var data = await _context.SubCounties.Where(c=>c.CountyId == countyid).ToListAsync();
        return Ok(data);
    }

    [HttpGet("GetLocations")]
    public async Task<IActionResult> GetLocations(int subcountyId)
    {
        var data = await _context.Locations.Where(c => c.SubCountyId == subcountyId).ToListAsync();
        return Ok(data);
    }

    [HttpGet("GetSubLocations")]
    public async Task<IActionResult> GetSubLocations(int locationId)
    {
        var data = await _context.SubLocations.Where(c => c.LocationId == locationId).ToListAsync();
        return Ok(data);
    }

    [HttpGet("GetVillages")]
    public async Task<IActionResult> GetVillages(int sublocationId)
    {
        var data = await _context.Villages.Where(c => c.SubLocationId == sublocationId).ToListAsync();
        return Ok(data);
    }
}