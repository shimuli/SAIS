using AutoMapper;
using SAIS.Core.Domain.DTO;
using SAIS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIS.Core.Domain.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Gender, GenderDto>().ReverseMap();
        CreateMap<Programme, ProgrammeDto>().ReverseMap();
        CreateMap<MaritalStatus, MaritualStatusDto>().ReverseMap();

        CreateMap<Applicant, ApplicantsDto>().ReverseMap();

        CreateMap<Official, OfficialDto>().ReverseMap();

        CreateMap<Applicant, CreateApplicantDto>().ReverseMap();
    }
}