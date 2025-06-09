using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Core.Exceptions;
using SAIS.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Services;

public class GenderService(IGenderRepo _genderRepo) : IGenderService
{
    public async Task AddGenderAsync(Gender gender)
    {
        if (await _genderRepo.ExistsByNameAsync(gender.Value))
        {
            throw new BusinessException($"Gender '{gender.Value}' already exists.");
        }
            
        await _genderRepo.AddAsync(gender);
    }

    public async Task DeleteGenderAsync(int id)
    {
        var gender = await _genderRepo.GetByIdAsync(id);
        if (gender == null)
        {
            throw new NotFoundException($"Gender was not found.");
        }
            

        await _genderRepo.DeleteAsync(id);
    }

    public async Task<Gender?> GetGenderAsync(int id)
    {
        return await _genderRepo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Gender>> GetGendersAsync()
    {
        var genders = await _genderRepo.GetAllAsync();
        return genders.ToList();
    }

    public async Task UpdateGenderrAsync(Gender gender)
    {
        var exsitingender = await _genderRepo.GetByIdAsync(gender.Id);
        if (exsitingender == null)
        {
            throw new NotFoundException($"Gender was  not found.");
        }
           
            
        exsitingender.Value = gender.Value;

        await _genderRepo.UpdateAsync(exsitingender);
    }
}