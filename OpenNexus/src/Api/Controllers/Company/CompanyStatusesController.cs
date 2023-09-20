using Arnkels.OpenNexus.Application.Companies.Models.Request;
using Arnkels.OpenNexus.Application.Companies.Models.Response;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.Company;

[Route("/company/statuses")]
[ApiController]
public class CompanyStatusesController : ControllerBase
{
    private readonly ICompanyStatusRepository _companyStatusRepository;
    private readonly ICompanyStatusService _companyStatusService;

    public CompanyStatusesController(ICompanyStatusRepository companyStatusRepository,
        ICompanyStatusService companyStatusService)
    {
        _companyStatusRepository = companyStatusRepository;
        _companyStatusService = companyStatusService;
    }

    // Get CompanyStatuses
    [HttpGet("")]
    public async Task<IActionResult> GetCompanyStatuses()
    {
        ICollection<Domain.Entities.CompanyStatus> companyStatuses = await _companyStatusRepository.GetManyAsync();

        if (companyStatuses == null)
        {
            return NoContent();
        }

        var responses = companyStatuses.Select(companyStatus => new CompanyStatusResponseModel(companyStatus));

        return Ok(new ListResponseModel<CompanyStatusResponseModel>(responses));
    }

    // Get CompanyStatusById
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCompanyStatusById(Guid id)
    {
        var companyStatus = await _companyStatusRepository.GetByIdAsync(id);

        if (companyStatus == null)
        {
            return NotFound();
        }

        var response = new CompanyStatusResponseModel(companyStatus);

        return Ok(response);
    }

    // Create CompanyStatus

    [HttpPost("")]
    public async Task<IActionResult> CreateCompanyStatus([FromBody] CompanyStatusRequestModel model)
    {
        var companyStatus = model.ToCompanyStatus();

        await _companyStatusService.SaveAsync(companyStatus);

        var companyStatusSaved = await _companyStatusRepository.GetByIdAsync(companyStatus.Id);

        var response = new CompanyStatusResponseModel(companyStatusSaved);

        return CreatedAtAction(nameof(GetCompanyStatusById), new { id = response.Id }, response);
    }

    // Delete CompanyStatus
    [ProducesResponseType(204)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCompanyStatusAsync(Guid id)
    {
        var companyStatus = await _companyStatusRepository.GetByIdAsync(id);
        if (companyStatus == null)
        {
            return NotFound();
        }

        await _companyStatusService.DeleteAsync(companyStatus);

        return NoContent();
    }

    // Put CompanyStatus
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> ReplaceCompanyStatusAsync(Guid id, [FromBody] CompanyStatusRequestModel model)
    {
        var existingCompanyStatus = await _companyStatusRepository.GetByIdAsync(id);
        if (existingCompanyStatus == null)
        {
            return NotFound();
        }

        var companyStatus = model.ToCompanyStatus();
        companyStatus.Id = existingCompanyStatus.Id;
        await _companyStatusService.SaveAsync(companyStatus);

        var response = new CompanyStatusResponseModel(await _companyStatusRepository.GetByIdAsync(id));

        return Ok(response);
    }
}