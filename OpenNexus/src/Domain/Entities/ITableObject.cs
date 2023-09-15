namespace Arnkels.OpenNexus.Domain.Entities;

public interface ITableObject<T> where T : IEquatable<T>
{
    T Id { get; set; }
    void SetNewId();
}