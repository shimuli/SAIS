using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class SubCounty
{
    public int SubCountyId { get; set; }
    public string Name { get; set; } = null!;
    public int CountyId { get; set; }
    public County County { get; set; } = null!;
    public ICollection<Location> Locations { get; set; } = [];
}