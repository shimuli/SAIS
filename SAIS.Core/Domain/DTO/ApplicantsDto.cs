using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.DTO;

public class ApplicantsDto
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
    public Gender Gender { get; set; } = null!;

    public int MaritalStatusId { get; set; }

    public int CountyId { get; set; }
    public int SubCountyId { get; set; }
    public int LocationId { get; set; }
    public int SubLocationId { get; set; }
    public int VillageId { get; set; }

    public string? FormStatus { get; set; }

    public bool DeclarationChecked { get; set; } = false;

    public string? DataEnteredBy { get; set; }

    public ApplicantGenderDto? ApplicantGender { get; set; }
    public ApplicantMaritalStatusDto? MaritalStatus { get; set; }
    public List<ApplicantPhoneNumberDto>? PhoneNumbers { get; set; } = new();

    public VillageDto? Village { get; set; }
    public SubLocationDto? SubLocation { get; set; }

    public LocationDto? Location { get; set; }

    public SubCountyDto? SubCounty { get; set; } 

    public CountyDto? County { get; set; } 
}


public class ApplicantGenderDto
{
    public int Id { get; set; }
    public string? GenderName { get; set; } = string.Empty;
}

public class ApplicantMaritalStatusDto
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}

public class ApplicantPhoneNumberDto
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
}


public class VillageDto
{
    public int VillageId { get; set; }
    public string Name { get; set; } = null!;
    
}


public class SubLocationDto
{
    public int SubLocationId { get; set; }
    public string Name { get; set; } = null!;
}


public class LocationDto
{
    public int LocationId { get; set; }
    public string Name { get; set; } = null!;
    public int SubCountyId { get; set; }
}

public class SubCountyDto
{
    public int SubCountyId { get; set; }
    public string Name { get; set; } = null!;
}


public class CountyDto
{
    public int CountyId { get; set; }
    public string Name { get; set; } = null!;
}