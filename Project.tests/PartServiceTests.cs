using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyApi.Services;
using MyApi.Entities;
using MyApi.Interfaces;
using MyApi.DTO;

public class PartServiceTests
{
    private readonly Mock<IPartRepository> _partRepoMock;
    private readonly Mock<IStationRepository> _stationRepoMock;
    private readonly PartService _partService;

    public PartServiceTests()
    {
        _partRepoMock = new Mock<IPartRepository>();
        _stationRepoMock = new Mock<IStationRepository>();
        _partService = new PartService(_partRepoMock.Object, _stationRepoMock.Object);
    }

    [Fact]
    public async Task ValidarECriarAsync_ReturnsError_WhenPartCodeExists()
    {
        // Arrange
        var dto = new PartCreateDto { Code = "ABC123", Status = "Nova", CurStationId = 1 };
        _partRepoMock.Setup(r => r.GetByCode(dto.Code)).ReturnsAsync(new Part { Code = dto.Code , Status = dto.Status, CurStationId = dto.CurStationId});

        // Act
        var result = await _partService.ValidarECriarAsync(dto);

        // Assert
        Assert.False(result.ok);
        Assert.Equal("Já existe uma peça com esse código.", result.error);
        Assert.Null(result.part);
    }

    [Fact]
    public async Task ValidarECriarAsync_ReturnsError_WhenStationNotFound()
    {
        // Arrange
        var dto = new PartCreateDto { Code = "XYZ987", Status = "Nova", CurStationId = 1 };
        _partRepoMock.Setup(r => r.GetByCode(dto.Code)).ReturnsAsync((Part?)null);
        _stationRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Station { Id = 1, Title = "Estação 1", Sort = 1 });

        // Act
        var result = await _partService.ValidarECriarAsync(dto);

        // Assert
        Assert.False(result.ok);
        Assert.Equal("Peça não encontrada.", result.error);
        Assert.Null(result.part);
    }

    [Fact]
    public async Task ValidarECriarAsync_Success()
    {
        // Arrange
        var dto = new PartCreateDto { Code = "NEW001", Status = "Nova", CurStationId = 1 };
        _partRepoMock.Setup(r => r.GetByCode(dto.Code)).ReturnsAsync((Part?)null);
        _stationRepoMock.Setup(s => s.GetByIdAsync(dto.CurStationId)).ReturnsAsync(new Station { Id = 1, Title = "Estação 1", Sort = 1 });


        // Act
        var result = await _partService.ValidarECriarAsync(dto);

        // Assert
        Assert.True(result.ok);
        Assert.Null(result.error);
        Assert.NotNull(result.part);
        Assert.Equal(dto.Code, result.part.Code);
        _partRepoMock.Verify(r => r.AddAsync(It.IsAny<Part>()), Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsList()
    {
        // Arrange
        var parts = new List<Part> {
            new Part { Code = "P1", Status = "Nova" },
            new Part { Code = "P2", Status = "Em Processo" }
        };
        _partRepoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(parts);

        // Act
        var result = await _partService.GetAllAsync();

        // Assert
        Assert.Equal(parts.Count, ((List<Part>)result).Count);
    }

    [Fact]
    public async Task AtualizarAsync_ReturnsError_WhenPartNotFound()
    {
        // Arrange
        int id = 1;
        var dto = new PartUpdateDto { Code = "Atualizado" };
        _partRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Part?)null);

        // Act
        var result = await _partService.AtualizarAsync(id, dto);

        // Assert
        Assert.False(result.ok);
        Assert.Equal("Peça não encontrada.", result.error);
    }

    [Fact]
    public async Task AtualizarAsync_Success()
    {
        // Arrange
        int id = 1;
        var dto = new PartUpdateDto { Code = "Atualizado" };
        var part = new Part { Code = "OldCode", Status = "Nova" };
        _partRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(part);

        // Act
        var result = await _partService.AtualizarAsync(id, dto);

        // Assert
        Assert.True(result.ok);
        Assert.Null(result.error);
        Assert.Equal(dto.Code, part.Code);
        _partRepoMock.Verify(r => r.UpdateAsync(part), Times.Once);
    }

    [Fact]
    public async Task DeletarAsync_ReturnsError_WhenPartNotFound()
    {
        // Arrange
        int id = 1;
        _partRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Part?)null);

        // Act
        var result = await _partService.DeletarAsync(id);

        // Assert
        Assert.False(result.ok);
        Assert.Equal("Peça não encontrada.", result.error);
    }

    [Fact]
    public async Task DeletarAsync_Success()
    {
        // Arrange
        int id = 1;
        var part = new Part { Code = "P1", Status = "Nova" };
        _partRepoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(part);

        // Act
        var result = await _partService.DeletarAsync(id);

        // Assert
        Assert.True(result.ok);
        Assert.Null(result.error);
        _partRepoMock.Verify(r => r.DeleteAsync(id), Times.Once);
    }
}
