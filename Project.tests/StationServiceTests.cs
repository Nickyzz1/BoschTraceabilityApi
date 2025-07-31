using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyApi.Entities;
using MyApi.Repositories;
using MyApi.Services;
using MyApi.Interfaces;
using MyApi.DTO;

public class StationServiceTests
{
// Validação da ordem das estações
    [Fact]
    public async Task ValidarECriarAsync_SortDuplicado_DeveRetornarErro() {
        // Arrange
        var mockRepo = new Mock<IStationRepository>();
        mockRepo.Setup(r => r.ExistsByTitleAsync(It.IsAny<string>())).ReturnsAsync(false);
        mockRepo.Setup(r => r.ExistsBySortAsync(2)).ReturnsAsync(true); // ordem já existe

        var service = new StationService(mockRepo.Object);

        var novaStation = new StationCreateDto
        {
            Title = "Estação Nova",
            Sort = 2
        };

        // Act
        var (ok, error) = await service.ValidarECriarAsync(novaStation);

        // Assert
        Assert.False(ok);
        Assert.Equal("Já existe uma estação com essa ordem.", error);
    }

    // Validação da ordem das estações
    [Fact]
    public async Task ValidarECriarAsync_DadosValidos_DeveRetornarSucesso()
    {
        // Arrange
        var mockRepo = new Mock<IStationRepository>();
        mockRepo.Setup(r => r.ExistsByTitleAsync("Estação A")).ReturnsAsync(false);
        mockRepo.Setup(r => r.ExistsBySortAsync(1)).ReturnsAsync(false);
        mockRepo.Setup(r => r.AddAsync(It.IsAny<Station>())).Returns(Task.CompletedTask);

        var service = new StationService(mockRepo.Object);

        var novaStation = new StationCreateDto
        {
            Title = "Estação A",
            Sort = 1
        };

        // Act
        var (ok, error) = await service.ValidarECriarAsync(novaStation);

        // Assert
        Assert.True(ok);
        Assert.Null(error);
        mockRepo.Verify(r => r.AddAsync(It.IsAny<Station>()), Times.Once);
    }
}