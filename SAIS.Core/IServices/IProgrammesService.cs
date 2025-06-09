using SAIS.Core.Domain.Entities;

namespace SAIS.Core.IServices;

public interface IProgrammesService
{
    Task<Programme?> GetProgrammeAsync(int id);
    Task<IEnumerable<Programme>> GetProgrammesAsync();
    Task AddProgrammeAsync(Programme program);
    Task UpdateProgrammeAsync(Programme program);
    Task DeleteProgrammeAsync(int id);
}
