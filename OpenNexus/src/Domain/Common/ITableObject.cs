namespace Arnkels.OpenNexus.Domain.Common;

public interface ITableObject<T> where T : IEquatable<T>
{
    T Id { get; set; }
    void SetNewId();
}