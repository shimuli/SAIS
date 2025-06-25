using Microsoft.AspNetCore.Mvc;
using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Infra.DbContexts;

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
        IEnumerable<Applicant>? applicants = await _repo.GetApplicationsAsync();
        return Ok(applicants);
    }


    /// <summary>
    /// Get Applicant Details by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Applicant Details</returns>
    [HttpGet("GetApplicantDetails")]
    public async Task<IActionResult> GetApplicantDetails(int id)
    {
        var data = await _repo.GetApplicationAsync(id);
        if (data == null)
        {
            return NotFound(new { message = "Applicant was not found" });
        }

        return Ok(data);
    }
}