using Arnkels.OpenNexus.Application.CompanyServices.Models.ClientDto;
using Arnkels.OpenNexus.Application.CompanyServices.Models.Request;
using Arnkels.OpenNexus.WebUI.HttpRepositories;
using Microsoft.AspNetCore.Components;

namespace Arnkels.OpenNexus.WebUI.Pages;

public class CompanyStatusNewBase : ComponentBase
{
    // Inject ClientCompanyStatusService
    [Inject] public ICompanyStatusHttpRepository CompanyStatusHttpRepository { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    // Expose to our razor page
    public CompanyStatusDto CompanyStatus { get; set; }

    public string ErrorMessage { get; set; }

    protected async override Task OnInitializedAsync()
    {
        CompanyStatus = new CompanyStatusDto();
    }

    protected async Task CreateCompanyStatus_Click()
    {
        var model = new CompanyStatusRequestModel
        {
            Name = CompanyStatus.Name,
            Description = CompanyStatus.Description
        };

        var savedModel = await CompanyStatusHttpRepository.CreateCompanyStatus(model);

        NavigationManager.NavigateTo($"/company/statuses/{savedModel.Id}");
    }
}