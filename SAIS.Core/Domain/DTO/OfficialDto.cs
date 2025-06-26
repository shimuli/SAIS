using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class OfficialDto
{
    public string OfficerName { get; set; } = null!;
    public string Designation { get; set; } = null!;
    public string? Signature { get; set; }

    public DateTime InformationCollectedDate { get; set; } = DateTime.Now.Date;

    public int ApplicantId { get; set; }
}
