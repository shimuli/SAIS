using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Core.Exceptions;
using SAIS.Core.ViewModel;
using SAIS.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Infra.Repository;

public class ApplicationRepo(AppDbContext _context, IMapper _mapper) : IApplicationRepo
{
    public async Task AddApplicationsAsync(CreateApplicantViewModel data)
    {
        if (data?.CreateApplicant == null)
        {
            throw new BusinessException(nameof(data.CreateApplicant));
        }


        var applicant = _mapper.Map<Applicant>(data.CreateApplicant);
        applicant.FormStatus = "Pending";
        _context.Applicants.Add(applicant);
        await _context.SaveChangesAsync(); // Save early to get ApplicantId (if it's database generated)

        var phoneNumbers = new List<PhoneNumber>();
        var applicationProgrammes = new List<ApplicationProgramme>();


        if (!string.IsNullOrWhiteSpace(data.PhoneNumbersRaw))
        {
            var numbers = data.PhoneNumbersRaw
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .Where(p => !string.IsNullOrWhiteSpace(p));

            foreach (var num in numbers)
            {
                phoneNumbers.Add(new PhoneNumber
                {
                    Number = num,
                    ApplicantId = applicant.ApplicantId
                });
            }
        }


        if (data.SelectedProgrammeIds != null && data.SelectedProgrammeIds.Any())
        {
            foreach (var ProgrammeId in data.SelectedProgrammeIds)
            {
                applicationProgrammes.Add(new ApplicationProgramme
                {
                    ApplicantId = applicant.ApplicantId,
                    ProgrammeId = ProgrammeId
                });
            }
        }


        if (phoneNumbers.Any()) _context.PhoneNumbers.AddRange(phoneNumbers);
        if (applicationProgrammes.Any()) _context.ApplicationProgrammes.AddRange(applicationProgrammes);


        if (data.OfficialApproval != null)
        {
            var official = _mapper.Map<Official>(data.OfficialApproval);
            official.ApplicantId = applicant.ApplicantId;
            _context.OfficialUses.Add(official);
        }

        await _context.SaveChangesAsync();
    }


    public Task DeleteApplicationsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Applicant?> GetApplicationAsync(int id)
    {
        var data = await _context.Applicants
            .Include(c=>c.ApplicationProgrammes)
            .ThenInclude(c=>c.Programme)
            .Include(c=>c.PhoneNumbers)
            .Include(c=>c.OfficialUse)
            .Include(c=>c.Gender)
            .Include(c => c.MaritalStatus)
            .Include(c=>c.Village)
            .ThenInclude(c=> c.SubLocation)
            .ThenInclude(c=>c.Location)
            .ThenInclude(c=>c.SubCounty)
            .ThenInclude(c=>c.County)
            .FirstOrDefaultAsync(c => c.ApplicantId == id);

        return data;

    }

    public async Task<IEnumerable<Applicant>> GetApplicationsAsync()
    {
        var data = await _context.Applicants
            .Include(c=>c.Gender)
            .Include(c => c.MaritalStatus)
            .Include(c => c.PhoneNumbers)
            .ToListAsync();
        return data;
    }

    public Task UpdateApplicationsAsync(CreateApplicantViewModel data)
    {
        throw new NotImplementedException();
    }
}