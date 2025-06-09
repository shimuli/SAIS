using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Entities;

public class Applicant
{
    public int ApplicantId { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public string IDNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public DateTime ApplicationDate { get; set; }
    public DateTime SignedDate { get; set; }

    public int GenderId { get; set; }
    public Gender? Gender { get; set; }

    public int MaritalStatusId { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }

    public int VillageId { get; set; }
    public Village? Village { get; set; }

    public string? FormStatus { get; set; }

    public string? DataEnteredBy { get; set; }


    public bool? DeclarationChecked { get; set; }
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = [];
    public ICollection<ApplicationProgramme> ApplicationProgrammes { get; set; } = [];
    public Official? OfficialUse { get; set; }
}
