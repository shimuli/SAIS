using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class ApplicationProgramme
{
    public int ApplicationProgrammeId { get; set; }
    public int ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }

    public int ProgrammeId { get; set; }
    public Programme? Programme { get; set; }
}