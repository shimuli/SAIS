using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Core.Exceptions;
using SAIS.Core.IServices;


namespace SAIS.Core.Services;

public class ProgrammesService(IProgrammesRepo programRepo) : IProgrammesService
{
    public async Task AddProgrammeAsync(Programme gender)
    {
        if (await programRepo.ExistsByNameAsync(gender.Name))
        {
            throw new BusinessException($"Program '{gender.Name}' already exists.");
        }

        await programRepo.AddAsync(gender);
    }

    public async Task DeleteProgrammeAsync(int id)
    {
        var program = await programRepo.GetByIdAsync(id);
        if (program == null)
        {
            throw new NotFoundException($"Program was not found.");
        }


        await programRepo.DeleteAsync(id);
    }

    public async Task<Programme?> GetProgrammeAsync(int id)
    {
        return await programRepo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Programme>> GetProgrammesAsync()
    {
        var genders = await programRepo.GetAllAsync();
        return genders.ToList();
    }

    public async Task UpdateProgrammeAsync(Programme program)
    {
        var exsitingprogram = await programRepo.GetByIdAsync(program.ProgrammeId);
        if (exsitingprogram == null)
        {
            throw new NotFoundException($"Program was  not found.");
        }

        exsitingprogram.Name = program.Name;

        await programRepo.UpdateAsync(exsitingprogram);
    }
}