using Microsoft.AspNetCore.Mvc.Rendering;
using SAIS.Core.Domain.DTO;
using SAIS.Core.Domain.Entities;


namespace SAIS.Core.ViewModel;

public class CreateApplicantViewModel
{
    public ApplicantsDto CreateApplicant { get; set; } = null!;
    public PhoneNumberDto CreatePhoneNumber{ get; set; } = null!;

    public Applicant? ApplicantDetails { get; set; }
    public List<ApplicationProgrammeDto> CreateApplicationProgramme { get; set; } = null!;

    public OfficialDto? OfficialApproval { get; set; }


    public string? PhoneNumbersRaw { get; set; }

    public List<ProgrammeDto>? ProgrammeList { get; set; }

    public List<int> SelectedProgrammeIds { get; set; } = new();
    public IEnumerable<SelectListItem>? GenderList { get; set; }
    public IEnumerable<SelectListItem>? MaritualStatusList { get; set; }
    public IEnumerable<SelectListItem>? CountyList { get; set; }

}