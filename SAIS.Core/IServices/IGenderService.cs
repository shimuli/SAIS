using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.IServices;

public interface IGenderService
{
    Task<Gender?> GetGenderAsync(int id);
    Task<IEnumerable<Gender>> GetGendersAsync();
    Task AddGenderAsync(Gender gender);
    Task UpdateGenderrAsync(Gender gender);
    Task DeleteGenderAsync(int id);
}