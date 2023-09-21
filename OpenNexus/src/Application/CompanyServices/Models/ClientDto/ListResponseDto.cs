namespace Arnkels.OpenNexus.Application.CompanyServices.Models.ClientDto;

public class ListResponseDto<T>
{
    public IEnumerable<T>? Data { get; set; }
    public string ContinuationToken { get; set; }
}