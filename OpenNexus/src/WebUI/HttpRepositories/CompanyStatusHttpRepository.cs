using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Arnkels.OpenNexus.Application.Companies.Models.ClientDto;
using Arnkels.OpenNexus.Application.Companies.Models.Request;
using Arnkels.OpenNexus.Application.Companies.Models.Response;
using AutoMapper;

namespace Arnkels.OpenNexus.WebUI.HttpRepositories;

public class CompanyStatusHttpRepository : ICompanyStatusHttpRepository
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;

    public CompanyStatusHttpRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<ListResponseDto<CompanyStatusDto>> GetCompanyStatuses()
    {
        var response = await _httpClient.GetAsync("company/statuses");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        var companyStatuses = JsonSerializer.Deserialize<ListResponseDto<CompanyStatusDto>>(content, _options);

        return companyStatuses;
    }

    public async Task<CompanyStatusDto> GetCompanyStatusById(Guid id)
    {
        var response = await _httpClient.GetAsync($"company/statuses/{id}");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        var companyStatus = JsonSerializer.Deserialize<CompanyStatusDto>(content, _options);

        return companyStatus;
    }

    public async Task DeleteCompanyStatusById(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"company/statuses/{id}");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }

    public async Task<CompanyStatusDto> CreateCompanyStatus(CompanyStatusRequestModel model)
    {
        var response = await _httpClient.PostAsJsonAsync($"company/statuses", model);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }

        return JsonSerializer.Deserialize<CompanyStatusDto>(content, _options);
    }

    public async Task SaveCompanyStatus(Guid id, CompanyStatusRequestModel model)
    {
        var response = await _httpClient.PutAsJsonAsync($"company/statuses/{id}", model);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
    }
}