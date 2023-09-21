using System.Runtime.Serialization;
using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Application.Companies.CompanyStatuses.Queries;
using Arnkels.OpenNexus.Domain.Entities;
using AutoMapper;

namespace Arnkels.OpenNexus.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void Should_Have_ValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(CompanyStatus), typeof(CompanyStatusDto))]
    public void Should_Support_MappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without paramaterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}