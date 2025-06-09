using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class Programme
{
    public int ProgrammeId { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<ApplicationProgramme> ApplicationProgrammes { get; set; } = [];
}