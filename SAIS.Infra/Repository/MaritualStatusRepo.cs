using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Infra.Repository;

public class MaritualStatusRepo(AppDbContext _context) : IMaritualStatusRepo
{
    public async Task AddAsync(MaritalStatus entity)
    {
        await _context.MaritalStatuses.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        MaritalStatus? data = await _context.MaritalStatuses.FindAsync(id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.MaritalStatuses.AnyAsync(u =>
           u.Value == name);
    }

    public async Task<IEnumerable<MaritalStatus>> GetAllAsync()
    {
        return await _context.MaritalStatuses.ToListAsync();
    }

    public async Task<MaritalStatus?> GetByIdAsync(int id)
    {
        return await _context.MaritalStatuses.FindAsync(id);
    }

    public async Task UpdateAsync(MaritalStatus entity)
    {
        _context.MaritalStatuses.Update(entity);
        await _context.SaveChangesAsync();
    }
}