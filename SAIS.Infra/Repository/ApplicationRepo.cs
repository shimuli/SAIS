using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.DTO;
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


    public async Task RegisterApplicationsAsync(CreateApplicantVM data)
    {
        if (data?.CreateApplicant == null)
        {
            throw new BusinessException(nameof(data.CreateApplicant));
        }

        if(await _context.Applicants.AnyAsync(c=>c.IDNumber == data.CreateApplicant.IDNumber))
        {
            throw new BusinessException("The ID Number is already in the system");
        }
        var applicant = _mapper.Map<Applicant>(data.CreateApplicant);
        applicant.FormStatus = "Pending";
        _context.Applicants.Add(applicant);
        await _context.SaveChangesAsync();

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
            .Include(c => c.ApplicationProgrammes)
            .ThenInclude(c => c.Programme)
            .Include(c => c.PhoneNumbers)
            .Include(c => c.OfficialUse)
            .Include(c => c.Gender)
            .Include(c => c.MaritalStatus)
            .Include(c => c.Village)
            .ThenInclude(c => c.SubLocation)
            .ThenInclude(c => c.Location)
            .ThenInclude(c => c.SubCounty)
            .ThenInclude(c => c.County)
            .FirstOrDefaultAsync(c => c.ApplicantId == id);

        return data;

    }

    public async Task<IEnumerable<Applicant>> GetApplicationsAsync()
    {
        var data = await _context.Applicants
            .Include(c => c.Gender)
            .Include(c => c.MaritalStatus)
            .Include(c => c.PhoneNumbers)
            .ToListAsync();
        return data;
    }

    public Task UpdateApplicationsAsync(CreateApplicantViewModel data)
    {
        throw new NotImplementedException();
    }



    public async Task<ApplicantsDto?> GetApplicantByIdAsync(int id)
    {
        var data = await _context.Applicants.Where(c=>c.ApplicantId == id)
            .Include(a => a.Gender)
            .Include(a => a.MaritalStatus)
            .Include(a => a.PhoneNumbers)
            .Select(a => new ApplicantsDto
            {
                ApplicantId = a.ApplicantId,
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                LastName = a.LastName,
                IDNumber = a.IDNumber,
                DateOfBirth = a.DateOfBirth,
                PostalAddress = a.PostalAddress,
                PhysicalAddress = a.PhysicalAddress,
                ApplicationDate = a.ApplicationDate,
                FormStatus = a.FormStatus,
                DataEnteredBy = a.DataEnteredBy,
                DeclarationChecked = a.DeclarationChecked ?? false,
                SignedDate = a.SignedDate,
                ApplicantGender = new ApplicantGenderDto
                {
                    Id = a.Gender.Id,
                    GenderName = a.Gender.Value
                },
                MaritalStatus = new ApplicantMaritalStatusDto
                {
                    Id = a.MaritalStatus.MaritalStatusId,
                    Name = a.MaritalStatus.Value
                },
                PhoneNumbers = a.PhoneNumbers.Select(p => new ApplicantPhoneNumberDto
                {
                    Id =p.PhoneNumberId,
                    Number = p.Number
                }).ToList(),
                Village = new VillageDto
                {
                    VillageId = a.Village.VillageId,
                    Name = a.Village.Name
                },

                SubLocation = new SubLocationDto
                {
                    SubLocationId = a.Village.SubLocation.SubLocationId,
                    Name = a.Village.SubLocation.Name,
                },

                Location = new LocationDto
                {
                    LocationId = a.Village.SubLocation.Location.LocationId,
                    Name = a.Village.SubLocation.Location.Name,
                },

                SubCounty = new SubCountyDto
                {
                    SubCountyId = a.Village.SubLocation.Location.SubCounty.SubCountyId,
                    Name = a.Village.SubLocation.Location.SubCounty.Name,
                },

                 County = new CountyDto
                 {
                     CountyId = a.Village.SubLocation.Location.SubCounty.County.CountyId,
                     Name = a.Village.SubLocation.Location.SubCounty.County.Name,
                 }
            }).FirstOrDefaultAsync();

        return data;

    }

    public async Task<IEnumerable<ApplicantsDto>> GetApplicantsAsync()
    {
        var data = await _context.Applicants
            .Include(a => a.Gender)
            .Include(a => a.MaritalStatus)
            .Include(a => a.PhoneNumbers)
            .Include(c => c.Village)
            .ThenInclude(c => c.SubLocation)
            .ThenInclude(c => c.Location)
            .ThenInclude(c => c.SubCounty)
            .ThenInclude(c => c.County)
            .Select(a => new ApplicantsDto
            {
                ApplicantId = a.ApplicantId,
                FirstName = a.FirstName,
                MiddleName = a.MiddleName,
                LastName = a.LastName,
                IDNumber = a.IDNumber,
                DateOfBirth = a.DateOfBirth,
                PostalAddress = a.PostalAddress,
                PhysicalAddress = a.PhysicalAddress,
                ApplicationDate = a.ApplicationDate,
                FormStatus = a.FormStatus,
                DataEnteredBy = a.DataEnteredBy,
                DeclarationChecked = a.DeclarationChecked ?? false,
                SignedDate = a.SignedDate,
                GenderId = a.GenderId,
                VillageId = a.VillageId,
                MaritalStatusId = a.MaritalStatusId,

                ApplicantGender = new ApplicantGenderDto
                {
                    Id = a.Gender.Id,
                    GenderName = a.Gender.Value
                },
                MaritalStatus = new ApplicantMaritalStatusDto
                {
                    Id = a.MaritalStatus.MaritalStatusId,
                    Name = a.MaritalStatus.Value
                },
                PhoneNumbers = a.PhoneNumbers.Select(p => new ApplicantPhoneNumberDto
                {
                    Id = p.PhoneNumberId,
                    Number = p.Number
                }).ToList(),
            }).ToListAsync();

        return data;

    }
}