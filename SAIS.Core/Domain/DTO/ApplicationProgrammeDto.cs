using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class ApplicationProgrammeDto
{
    public int ApplicationProgrammeId { get; set; }
    public int ApplicantId { get; set; }

    public int ProgrammeId { get; set; }

}