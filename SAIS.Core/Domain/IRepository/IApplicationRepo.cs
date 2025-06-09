using SAIS.Core.Domain.Entities;
using SAIS.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.IRepository;

public interface IApplicationRepo
{
    Task<Applicant?> GetApplicationAsync(int id);
    Task<IEnumerable<Applicant>> GetApplicationsAsync();
    Task AddApplicationsAsync(CreateApplicantViewModel data);
    Task UpdateApplicationsAsync(CreateApplicantViewModel data);
    Task DeleteApplicationsAsync(int id);
}
