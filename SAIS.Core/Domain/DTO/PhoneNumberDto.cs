using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class PhoneNumberDto
{
    public int PhoneNumberId { get; set; }
    public string Number { get; set; } = null!;
    public int ApplicantId { get; set; }

}