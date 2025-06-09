using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.IRepository;

public interface IGenderRepo : IRepos<Gender>
{
    Task<bool> ExistsByNameAsync(string name);
}