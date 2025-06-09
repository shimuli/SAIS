using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Infra.DbContexts;


namespace SAIS.Infra.Repository;

public class GenderRepo(AppDbContext _context) : IGenderRepo
{
    public async Task AddAsync(Gender entity)
    {
        await _context.Genders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var gender = await _context.Genders.FindAsync(id);
        if (gender != null)
        {
            _context.Remove(gender);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Genders.AnyAsync(u =>
           u.Value == name);
    }

    public async Task<IEnumerable<Gender>> GetAllAsync()
    {
        return await _context.Genders.ToListAsync();
    }

    public async Task<Gender?> GetByIdAsync(int id)
    {
        return await _context.Genders.FindAsync(id);
    }

    public async Task UpdateAsync(Gender entity)
    {
        _context.Genders.Update(entity);
        await _context.SaveChangesAsync();
    }
}