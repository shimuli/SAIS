using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.DTO;
using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Core.ViewModel;
using SAIS.Infra.DbContexts;
using SAIS.Infra.Persistence.Data;

namespace SAIS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController(IApplicationRepo _repo) : ControllerBase
{
    /// <summary>
    /// Get Applications
    /// </summary>
    /// <returns>List of applicants</returns>
    [HttpGet("GetApplications")]
    public async Task<IActionResult> GetApplications()
    {
        IEnumerable<ApplicantsDto>? applicants = await _repo.GetApplicantsAsync();
        return Ok(applicants);
    }


    /// <summary>
    /// Get Applicant Details by ID
    /// </summary>
    /// <param name="id">ApplicantId</param>
    /// <returns>Applicant Details</returns>
    [HttpGet("GetApplicantDetails")]
    public async Task<IActionResult> GetApplicantDetails(int id)
    {
        var data = await _repo.GetApplicantByIdAsync(id);
        if (data == null)
        {
            return NotFound(new { message = "Applicant was not found" });
        }

        return Ok(data);
    }



    [HttpPost("RegisterApplicant")]
    public async Task<IActionResult> RegisterApplicant(CreateApplicantVM model)
    {
        try
        {
            await _repo.RegisterApplicationsAsync(model);
            return Ok(new { message = "Application submitted successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }
}