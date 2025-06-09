using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class Official
{
    public int OfficialId { get; set; }
    public string OfficerName { get; set; } = null!;
    public string Designation { get; set; } = null!;
    public string? Signature { get; set; }

    public DateTime InformationCollectedDate { get; set; }

    public int ApplicantId { get; set; }
    public Applicant Applicant { get; set; } = null!;
}