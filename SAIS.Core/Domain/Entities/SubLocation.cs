using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class SubLocation
{
    public int SubLocationId { get; set; }
    public string Name { get; set; } = null!;
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public ICollection<Village> Villages { get; set; } = [];
}