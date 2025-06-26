using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class CreateApplicantVM
{
    public CreateApplicantDto CreateApplicant { get; set; } = null!;

    public string? PhoneNumbersRaw { get; set; }

    public List<int> SelectedProgrammeIds { get; set; } = new();

    public OfficialDto? OfficialApproval { get; set; }
}