using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MyApi.DTO;
using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.Services;
using System;

public class MovimentServiceTests
{
    //Registro de movimentações válidas e rejeição de inválidas.

    // Validação da ordem das estações com movimento
    [Fact]
    public async Task CriarMovimentacaoAsync_ValidMoviment_RegistersSuccessfully()
    {
        // Arrange
        var part = new Part { Id = 1, CurStationId = 1, Status = "Em processamento" };
        var atualStation = new Station { Id = 1, Sort = 1, Title = "Estação A" };
        var nextStation = new Station { Id = 2, Sort = 2, Title = "Estação B" };

        var partRepo = new Mock<IPartRepository>();
        var stationRepo = new Mock<IStationRepository>();
        var movimentRepo = new Mock<IMovimentRepository>();

        partRepo.Setup(r => r.GetByIdAsync(part.Id)).ReturnsAsync(part);
        stationRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(atualStation);
        stationRepo.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(nextStation);
        stationRepo.Setup(r => r.GetMaxSortAsync()).ReturnsAsync(5);

        var service = new MovimentService(partRepo.Object, stationRepo.Object, movimentRepo.Object);

        var dto = new MovimentCreateDto
        {
            PartId = 1,
            DestinationStationId = 2,
            Responsable = "Ni"
        };

        // Act
        var result = await service.CriarMovimentacaoAsync(dto);

        // Assert
        Assert.True(result.ok);
        movimentRepo.Verify(m => m.AddAsync(It.IsAny<Moviment>()), Times.Once);
    }
    //Registro de movimentações válidas e rejeição de inválidas.

    // Validação da ordem das estações com movimento
    [Fact]
    public async Task CriarMovimentacaoAsync_InvalidDestinationSort_ReturnsError()
    {
        // Arrange
        var part = new Part { Id = 1, CurStationId = 1, Status = "Em processamento" };
        var atualStation = new Station { Id = 1, Sort = 1, Title = "Estação A" };
        var wrongStation = new Station { Id = 3, Sort = 4, Title = "Estação B" }; 
       


        var partRepo = new Mock<IPartRepository>();
        var stationRepo = new Mock<IStationRepository>();
        var movimentRepo = new Mock<IMovimentRepository>();

        partRepo.Setup(r => r.GetByIdAsync(part.Id)).ReturnsAsync(part);
        stationRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(atualStation);
        stationRepo.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(wrongStation);

        var service = new MovimentService(partRepo.Object, stationRepo.Object, movimentRepo.Object);

        var dto = new MovimentCreateDto
        {
            PartId = 1,
            DestinationStationId = 3,
            Responsable = "Ni"
        };

        // Act
        var result = await service.CriarMovimentacaoAsync(dto);

        // Assert
        Assert.False(result.ok);
        Assert.Contains("pular ou retrocede", result.error);

    }
}
