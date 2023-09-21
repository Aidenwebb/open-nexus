using Arnkels.OpenNexus.Application.CompanyServices.Models.ClientDto;
using Arnkels.OpenNexus.Application.CompanyServices.Models.Request;
using Arnkels.OpenNexus.WebUI.HttpRepositories;
using Microsoft.AspNetCore.Components;

namespace Arnkels.OpenNexus.WebUI.Pages;

public class CompanyStatusDetailsBase : ComponentBase
{
    [Parameter] public Guid Id { get; set; }

    // Inject ClientCompanyStatusService
    [Inject] public ICompanyStatusHttpRepository CompanyStatusHttpRepository { get; set; }

    // Expose to our razor page
    public CompanyStatusDto CompanyStatus { get; set; }

    // Run Fetch from API when razor component is first invoked
    protected override async Task OnInitializedAsync()
    {
        await LoadCompanyStatus();
    }

    private async Task LoadCompanyStatus()
    {
        CompanyStatus = await CompanyStatusHttpRepository.GetCompanyStatusById(Id);
    }

    protected async Task DeleteCompanyStatus_Click()
    {
        await CompanyStatusHttpRepository.DeleteCompanyStatusById(Id);
    }

    protected async Task SaveCompanyStatus_Click()
    {
        var model = new CompanyStatusRequestModel
        {
            Name = CompanyStatus.Name,
            Description = CompanyStatus.Description
        };

        await CompanyStatusHttpRepository.SaveCompanyStatus(Id, model);
        await LoadCompanyStatus();
    }
}