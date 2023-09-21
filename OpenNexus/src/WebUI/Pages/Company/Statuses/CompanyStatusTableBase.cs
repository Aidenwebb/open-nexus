using Arnkels.OpenNexus.Application.CompanyServices.Models.ClientDto;
using Arnkels.OpenNexus.WebUI.HttpRepositories;
using Microsoft.AspNetCore.Components;

namespace Arnkels.OpenNexus.WebUI.Pages;

public class CompanyStatusTableBase : ComponentBase
{
    [Parameter] public ListResponseDto<CompanyStatusDto> CompanyStatuses { get; set; }
    [Inject] public ICompanyStatusHttpRepository CompanyStatusHttpRepository { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    protected async Task DeleteCompanyStatus_Click(Guid id)
    {
        await CompanyStatusHttpRepository.DeleteCompanyStatusById(id);
        await LoadCompanyStatuses();
    }

    private async Task LoadCompanyStatuses()
    {
        CompanyStatuses = await CompanyStatusHttpRepository.GetCompanyStatuses();
    }

    protected async Task EditCompanyStatus_Click(Guid id)
    {
        NavigationManager.NavigateTo($"/company/statuses/{id}");
    }
}