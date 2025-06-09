using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.IServices;

public interface IMaritualStatusServices
{
    Task<MaritalStatus?> GetM_StatusAsync(int id);
    Task<IEnumerable<MaritalStatus>> GetM_StatusAsync();
    Task AddM_StatusAsync(MaritalStatus status);
    Task UpdateM_StatusAsync(MaritalStatus status);
    Task DeleteM_StatusAsync(int id);
}
