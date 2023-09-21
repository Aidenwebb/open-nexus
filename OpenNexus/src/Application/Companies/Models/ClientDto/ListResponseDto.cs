namespace Arnkels.OpenNexus.Application.Companies.Models.ClientDto;

public class ListResponseDto<T>
{
    public IEnumerable<T>? Data { get; set; }
    public string ContinuationToken { get; set; }
}