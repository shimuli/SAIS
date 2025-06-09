using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class MaritalStatus
{
    public int MaritalStatusId { get; set; }
    public string? Value { get; set; }
    public ICollection<Applicant> Applicants { get; set; } = [];
}