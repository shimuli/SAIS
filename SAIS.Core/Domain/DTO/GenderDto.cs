using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class GenderDto
{
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    public bool? IsEditing { get; set; }
}