using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.IRepository;

public interface IProgrammesRepo : IRepos<Programme>
{
    Task<bool> ExistsByNameAsync(string name);
}