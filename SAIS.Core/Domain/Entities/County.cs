using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class County
{
    public int CountyId { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<SubCounty> SubCounties { get; set; } = [];
}