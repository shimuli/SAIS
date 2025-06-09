using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class Village
{
    public int VillageId { get; set; }
    public string Name { get; set; } = null!;
    public int SubLocationId { get; set; }
    public SubLocation SubLocation { get; set; } = null!;
    public ICollection<Applicant> Applicants { get; set; } = [];
}