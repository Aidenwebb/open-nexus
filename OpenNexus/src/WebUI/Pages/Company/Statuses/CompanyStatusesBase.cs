using System.Runtime.InteropServices;
using Arnkels.OpenNexus.Application.CompanyServices.Models.ClientDto;
using Arnkels.OpenNexus.WebUI.HttpRepositories;
using Microsoft.AspNetCore.Components;

namespace Arnkels.OpenNexus.WebUI.Pages;

public class CompanyStatusesBase : ComponentBase
{
    // Inject ClientCompanyStatusService
    [Inject] public ICompanyStatusHttpRepository CompanyStatusHttpRepository { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    // Expose to our razor page
    public ListResponseDto<CompanyStatusDto> CompanyStatuses { get; set; }

    // Run Fetch from API when razor component is first invoked
    protected override async Task OnInitializedAsync()
    {
        await LoadCompanyStatuses();
    }

    private async Task LoadCompanyStatuses()
    {
        CompanyStatuses = await CompanyStatusHttpRepository.GetCompanyStatuses();
    }


    protected async Task NewCompanyStatus_Click()
    {
        NavigationManager.NavigateTo("/company/statuses/new");
    }
}