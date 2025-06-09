using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class ProgrammeDto
{
    public int ProgrammeId { get; set; }
    public string Name { get; set; } = null!;

    public bool? IsEditing { get; set; }
}