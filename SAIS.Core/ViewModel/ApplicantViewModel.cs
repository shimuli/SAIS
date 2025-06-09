using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.ViewModel;

public class ApplicantViewModel
{
    public string? FullName { get; set; }
    public string? Gender { get; set; }
    public string? Office { get; set; }
    public int? Age { get; set; }
    public string? MaritalStatus { get; set; }
    public string? IdNumber { get; set; }
    public string? County { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? Date { get; set; }
    public string? Status { get; set; }
}