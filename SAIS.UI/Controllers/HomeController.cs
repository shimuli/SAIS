using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAIS.Core.Domain.DTO;
using SAIS.Core.Domain.Entities;
using SAIS.Core.Domain.IRepository;
using SAIS.Core.IServices;
using SAIS.Core.Services;
using SAIS.Core.ViewModel;
using SAIS.Infra.DbContexts;
using SAIS.Infra.Persistence.Data;
using SAIS.Infra.Repository;
using SAIS.UI.Models;

namespace SAIS.UI.Controllers;

public class HomeController(AppDbContext _context, IProgrammesService _programService, 
    IMapper _mapper, INotyfService _notifyService, IApplicationRepo _repo) : Controller
{

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> Index()
    {
        IEnumerable<Applicant>? applicants = await _repo.GetApplicationsAsync();
        return View(applicants);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> Create(int id = 0)
    {
        if(id == 0)
        {
            CreateApplicantViewModel model = new()
            {
                CreateApplicant = new(),
                CreatePhoneNumber = new(),
                CreateApplicationProgramme = [],
                OfficialApproval = new(),
                ProgrammeList = await GetListData.Programmes(_programService, _mapper),
                GenderList = GetListData.Genders(_context),
                MaritualStatusList = GetListData.MaritalStatuses(_context),
                CountyList = GetListData.Counties(_context)
            };

            return View(model);
        }

        else
        {
            var data = await _repo.GetApplicationAsync(id);
            if(data == null)
            {
                _notifyService.Warning("Information was not found");
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            var dto = _mapper.Map<ApplicantsDto>(data);

            CreateApplicantViewModel model = new()
            {
                CreateApplicant = dto,
                ApplicantDetails = data,
                CreatePhoneNumber = new(),
                CreateApplicationProgramme = [],
                OfficialApproval = new(),
                ProgrammeList = await GetListData.Programmes(_programService, _mapper),
                GenderList = GetListData.Genders(_context),
                MaritualStatusList = GetListData.MaritalStatuses(_context),
                CountyList = GetListData.Counties(_context)
            };

            return View(model);
        }

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateApplicantViewModel viewModel)
    {
        try
        {
            if (viewModel.CreateApplicant.DeclarationChecked != true)
            {
                _notifyService.Warning("Please declare that the information provided in this application is true");

                viewModel.ProgrammeList = await GetListData.Programmes(_programService, _mapper);
                viewModel.GenderList = GetListData.Genders(_context);
                viewModel.MaritualStatusList = GetListData.MaritalStatuses(_context);
                viewModel.CountyList = GetListData.Counties(_context);

                return View(viewModel);
            }

            await _repo.AddApplicationsAsync(viewModel);
            _notifyService.Success("Application was submited");

            return RedirectToAction("Index", "Home", new { area = "" });
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    [HttpGet]
    public async Task<IActionResult> getsubcounties(int id)
    {

        var list = await GetListData.SubCounties(_context, id);
        return Ok(list);
    }

    [HttpGet]
    public async Task<IActionResult> getlocations(int id)
    {
        var list = await GetListData.Locations(_context, id);
        return Ok(list);
    }

    [HttpGet]
    public async Task<IActionResult> getsublocations(int id)
    {
        var list = await GetListData.SubLocation(_context, id);
        return Ok(list);
    }


    [HttpGet]
    public async Task<IActionResult> getvillages(int id)
    {
        var list = await GetListData.Village(_context, id);
        return Ok(list);
    }
}
