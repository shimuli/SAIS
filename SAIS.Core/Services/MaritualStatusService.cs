using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Core.Exceptions;
using SAIS.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Services;

public class MaritualStatusService(IMaritualStatusRepo _repo) : IMaritualStatusServices
{
    public async Task AddM_StatusAsync(MaritalStatus status)
    {
        if (await _repo.ExistsByNameAsync(status.Value))
        {
            throw new BusinessException($"Status '{status.Value}' already exists.");
        }


        await _repo.AddAsync(status);
    }

    public async Task DeleteM_StatusAsync(int id)
    {
        MaritalStatus? status = await _repo.GetByIdAsync(id);
        if (status == null)
        {
            throw new NotFoundException($"Status was not found.");
        }


        await _repo.DeleteAsync(id);
    }

    public async Task<MaritalStatus?> GetM_StatusAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<MaritalStatus>> GetM_StatusAsync()
    {
        var genders = await _repo.GetAllAsync();
        return genders.ToList();
    }

    public async Task UpdateM_StatusAsync(MaritalStatus status)
    {
        var data = await _repo.GetByIdAsync(status.MaritalStatusId);
        if (data == null)
        {
            throw new NotFoundException($"Status was  not found.");
        }

        data.Value = status.Value;

        await _repo.UpdateAsync(data);
    }
}