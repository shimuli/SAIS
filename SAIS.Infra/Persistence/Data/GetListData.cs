using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.DTO;
using SAIS.Core.Domain.Entities;
using SAIS.Core.IServices;
using SAIS.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Infra.Persistence.Data;

public class GetListData
{
    public static IQueryable<SelectListItem> MaritalStatuses(AppDbContext _context)
    {
        return _context.MaritalStatuses.AsNoTracking()
            .OrderBy(c => c.Value).Select(i => new SelectListItem
            {
                Text = i.Value,
                Value = i.MaritalStatusId.ToString()
            });
    }


    public static IQueryable<SelectListItem> Genders(AppDbContext _context)
    {
        return _context.Genders.AsNoTracking()
            .OrderBy(c => c.Value).Select(i => new SelectListItem
            {
                Text = i.Value,
                Value = i.Id.ToString()
            });
    }

    public static IQueryable<SelectListItem> Counties(AppDbContext _context)
    {
        return _context.Counties.AsNoTracking()
            .OrderBy(c => c.Name).Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.CountyId.ToString()
            });
    }


    public static async Task<List<ProgrammeDto>> Programmes(IProgrammesService _programService, IMapper _mapper)
    {
        var gender = await _programService.GetProgrammesAsync();

        var programDto = _mapper.Map<List<ProgrammeDto>>(gender);

        return programDto;

    }


    public static async Task<List<SubCounty>> SubCounties(AppDbContext _context,int countyid)
    {
        return await _context.SubCounties.Where(c => c.CountyId == countyid)
            .AsNoTracking()
            .OrderBy(c => c.Name).ToListAsync();
    }

    public static async Task<List<Location>> Locations(AppDbContext _context, int subcountyid)
    {
        return await _context.Locations.Where(c => c.SubCountyId == subcountyid)
          .AsNoTracking()
          .OrderBy(c => c.Name).ToListAsync();

    }

    public static async Task<List<SubLocation>> SubLocation(AppDbContext _context, int location)
    {
        return await _context.SubLocations.Where(c => c.LocationId == location)
        .AsNoTracking()
        .OrderBy(c => c.Name).ToListAsync();

    }

    public static async Task<List<Village>> Village(AppDbContext _context, int sublocationid)
    {
        return await _context.Villages.Where(c => c.SubLocationId == sublocationid)
        .AsNoTracking()
        .OrderBy(c => c.Name).ToListAsync();

    }
}