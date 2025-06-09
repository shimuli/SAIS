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

public class ProgrammesRepo(AppDbContext _context) : IProgrammesRepo
{
    public async Task AddAsync(Programme entity)
    {
        await _context.Programmes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var program = await _context.Programmes.FindAsync(id);
        if (program != null)
        {
            _context.Remove(program);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Programmes.AnyAsync(u =>
           u.Name == name);
    }

    public async Task<IEnumerable<Programme>> GetAllAsync()
    {
        return await _context.Programmes.ToListAsync();
    }

    public async Task<Programme?> GetByIdAsync(int id)
    {
        return await _context.Programmes.FindAsync(id);
    }

    public async Task UpdateAsync(Programme entity)
    {
        _context.Programmes.Update(entity);
        await _context.SaveChangesAsync();
    }
}