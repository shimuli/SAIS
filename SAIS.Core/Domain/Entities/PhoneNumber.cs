using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class PhoneNumber
{
    public int PhoneNumberId { get; set; }
    public string? Number { get; set; }
    public int ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }
}