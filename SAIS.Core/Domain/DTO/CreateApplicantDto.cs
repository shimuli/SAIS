using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class CreateApplicantDto
{
    public int ApplicantId { get; set; }
    public string FirstName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = null!;
    public string IDNumber { get; set; } = null!;
    public DateTime DateOfBirth { get; set; } = DateTime.Now.Date.AddYears(-18);
    public string? PostalAddress { get; set; }
    public string? PhysicalAddress { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.Now.Date;
    public DateTime SignedDate { get; set; }

    public int GenderId { get; set; }

    public int MaritalStatusId { get; set; }

    public int CountyId { get; set; }
    public int SubCountyId { get; set; }
    public int LocationId { get; set; }
    public int SubLocationId { get; set; }
    public int VillageId { get; set; }

    public string? FormStatus { get; set; }

    public bool DeclarationChecked { get; set; } = false;

    public string? DataEnteredBy { get; set; }

}