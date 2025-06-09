using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Azure;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using SAIS.Core.Domain.DTO;
using SAIS.Core.Domain.Entities;
using SAIS.Core.IServices;
using System.Threading.Tasks;

namespace SAIS.UI.Controllers;

public class LooksUpController(IGenderService _genderService,IProgrammesService _programService, IMaritualStatusServices _statusRepo,
    IMapper _mapper, INotyfService _notifyService) : Controller
{

    #region Gender
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> GenderList()
    {
        try
        {
            var gender = await _genderService.GetGendersAsync();

            var genderDto = _mapper.Map<List<GenderDto>>(gender);

            return View(genderDto);
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
     
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet]
    public async Task<IActionResult> CreateGender(int id)
    {
        try
        {
            var entity = await _genderService.GetGenderAsync(id);

            var genderDto = _mapper.Map<GenderDto>(entity);
            if (genderDto == null)
            {
                return PartialView("_CreateGender");
            }

            genderDto.IsEditing = true;
            return PartialView("_CreateGender", genderDto);
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("GenderList", "LooksUp", new { area = "" });
        }
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateGender(GenderDto dto)
    {
        try
        {
            if (dto.IsEditing == false)
            {
                var entity = _mapper.Map<Gender>(dto);
                await _genderService.AddGenderAsync(entity);

                _notifyService.Success("Gender was added");
            }
            else
            {
                var entity = _mapper.Map<Gender>(dto);
                await _genderService.UpdateGenderrAsync(entity);

                _notifyService.Success("Gender was updated");
            }

            return RedirectToAction("GenderList", "LooksUp", new { area = "" });
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("GenderList", "LooksUp", new { area = "" });
        }
     
    }


    public async Task<IActionResult> DeleteGender(int id)
    {
        try
        {
            await _genderService.DeleteGenderAsync(id);

            _notifyService.Success("Gender was deleted");
            return RedirectToAction("GenderList", "LooksUp", new { area = "" });
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("GenderList", "LooksUp", new { area = "" });
        }

    }

    #endregion


    #region Programs
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> ProgramList()
    {
        try
        {
            var gender = await _programService.GetProgrammesAsync();

            var programDto = _mapper.Map<List<ProgrammeDto>>(gender);

            return View(programDto);
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet]
    public async Task<IActionResult> CreateProgram(int id)
    {
        try
        {
            var entity = await _programService.GetProgrammeAsync(id);

            var programDto = _mapper.Map<ProgrammeDto>(entity);
            if (programDto == null)
            {
                return PartialView("_CreateProgram");
            }

            programDto.IsEditing = true;
            return PartialView("_CreateProgram", programDto);
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("ProgramList", "LooksUp", new { area = "" });
        }

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProgram(ProgrammeDto dto)
    {
        try
        {
            if (dto.IsEditing == false)
            {
                var entity = _mapper.Map<Programme>(dto);
                await _programService.AddProgrammeAsync(entity);

                _notifyService.Success("Program was added");
            }
            else
            {
                var entity = _mapper.Map<Programme>(dto);
                await _programService.UpdateProgrammeAsync(entity);

                _notifyService.Success("Program was updated");
            }

            return RedirectToAction("ProgramList", "LooksUp", new { area = "" });
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("ProgramList", "LooksUp", new { area = "" });
        }

    }


    public async Task<IActionResult> DeleteProgram(int id)
    {
        try
        {
            await _programService.DeleteProgrammeAsync(id);

            _notifyService.Success("Program was deleted");
            return RedirectToAction("ProgramList", "LooksUp", new { area = "" });
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("ProgramList", "LooksUp", new { area = "" });
        }

    }

    #endregion


    #region Maritual Status
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> MaritualStatusList()
    {
        try
        {
            var data = await _statusRepo.GetM_StatusAsync();

            var StatusDto = _mapper.Map<List<MaritualStatusDto>>(data);

            return View(StatusDto);
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet]
    public async Task<IActionResult> CreateMaritualStatus(int id)
    {
        try
        {
            var entity = await _statusRepo.GetM_StatusAsync(id);

            var StatusDto = _mapper.Map<MaritualStatusDto>(entity);
            if (StatusDto == null)
            {
                return PartialView("_CreateMaritualStatus");
            }

            StatusDto.IsEditing = true;
            return PartialView("_CreateMaritualStatus", StatusDto);
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("MaritualStatusList", "LooksUp", new { area = "" });
        }

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateMaritualStatus(MaritualStatusDto dto)
    {
        try
        {
            if (dto.IsEditing == false)
            {
                var entity = _mapper.Map<MaritalStatus>(dto);
                await _statusRepo.AddM_StatusAsync(entity);

                _notifyService.Success("Status was added");
            }
            else
            {
                var entity = _mapper.Map<MaritalStatus>(dto);
                await _statusRepo.UpdateM_StatusAsync(entity);

                _notifyService.Success("Status was updated");
            }

            return RedirectToAction("MaritualStatusList", "LooksUp", new { area = "" });
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("MaritualStatusList", "LooksUp", new { area = "" });
        }

    }


    public async Task<IActionResult> DeleteMaritualStatus(int id)
    {
        try
        {
            await _statusRepo.DeleteM_StatusAsync(id);

            _notifyService.Success("Status was deleted");
            return RedirectToAction("MaritualStatusList", "LooksUp", new { area = "" });
        }
        catch (Exception ex)
        {
            _notifyService.Error(ex.Message);
            return RedirectToAction("MaritualStatusList", "LooksUp", new { area = "" });
        }

    }

    #endregion
}

