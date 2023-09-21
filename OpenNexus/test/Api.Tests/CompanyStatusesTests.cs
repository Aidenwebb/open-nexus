using System.Collections.ObjectModel;
using Arnkels.OpenNexus.Api.Controllers.Company;
using Arnkels.OpenNexus.Application.CompanyServices.Models.Response;
using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Tests;

public class CompanyStatusesTests : IDisposable
{
    private Collection<CompanyStatus> _companyStatusCollection;
    private CompanyStatusesController _companyStatusesController;
    private Mock<ICompanyStatusRepository> _companyStatusRepositoryMock;

    private Mock<ICompanyStatusService> _companyStatusServiceMock;

    public CompanyStatusesTests()
    {
        // Setup
        _companyStatusServiceMock = new Mock<ICompanyStatusService>();
        _companyStatusRepositoryMock = new Mock<ICompanyStatusRepository>();
        _companyStatusesController =
            new CompanyStatusesController(_companyStatusRepositoryMock.Object, _companyStatusServiceMock.Object);

        // Arrange

        var companyStatuses = new Collection<CompanyStatus>
        {
            new CompanyStatus
            {
                Id = Guid.Parse("018aae64-d601-4c5a-a26a-cc75c4a97e83"),
                Name = "Active",
                Description = "Company is Active",
                InactiveFlag = false
            },
            new CompanyStatus
            {
                Id = Guid.Parse("018aae68-5c7a-49fb-867f-c9ed9a932494"),
                Name = "Inactive",
                Description = "Company is Inactive",
                InactiveFlag = false
            },
            new CompanyStatus
            {
                Id = Guid.Parse("018aae66-25b7-4c9d-ad3b-81729c58b2d5"),
                Name = "On Hold",
                Description = "Company is On Hold",
                InactiveFlag = false
            }
        };

        _companyStatusRepositoryMock
            .Setup(x => x.GetManyAsync())
            .ReturnsAsync(companyStatuses);

        _companyStatusRepositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(companyStatuses.FirstOrDefault());

        _companyStatusCollection = companyStatuses;
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }

    [Fact]
    public async void GetCompanyStatuses_Should_Return_OKObjectResult()
    {
        // Act
        var result = await _companyStatusesController.GetCompanyStatuses();

        // Assert

        // result Statuscode is OK/200
        Assert.IsAssignableFrom<IActionResult>(result);
        Assert.IsType<OkObjectResult>(result);

        _companyStatusRepositoryMock.Verify(x => x.GetManyAsync(), Times.Once());
    }

    [Fact]
    public async void GetCompanyStatuses_Value_Should_Return_ListResponseModel()
    {
        // Act
        var result = (OkObjectResult)await _companyStatusesController.GetCompanyStatuses();

        // Assert

        // result Model is ListResponseModel<CompanyStatusResponseModel>
        Assert.IsType<ListResponseModel<CompanyStatusResponseModel>>(result.Value);
    }

    [Fact]
    public async void GetCompanyStatuses_Should_Return_SameCount()
    {
        // Act
        var result = (OkObjectResult)await _companyStatusesController.GetCompanyStatuses();
        ListResponseModel<CompanyStatusResponseModel> listResponseModel =
            (ListResponseModel<CompanyStatusResponseModel>)result.Value;

        // Assert
        Assert.Equal(listResponseModel.Data.Count(), _companyStatusCollection.Count());
    }
}