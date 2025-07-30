// using Xunit;
// using Moq;
// using System.Threading.Tasks;
// using System.Collections.Generic;
// using MyApi.Entities;
// using MyApi.Repositories;
// using MyApi.Services;
// using MyApi.Interfaces;

// public class MovimentServiceTests
// {
//     private readonly MovimentService _movimentService;
//     private readonly Mock<IMovimentRepository> _mockRepo;

//     public MovimentServiceTests()
//     {
//         _mockRepo = new Mock<IMovimentRepository>();
//         _movimentService = new MovimentService(_mockRepo.Object);
//     }

//     [Fact]
//     public async Task RegisterMoviment_ValidMoviment_Succeeds()
//     {
//         var moviment = new Moviment { PartId = 1, StationId = 2 };

//         _mockRepo.Setup(r => r.RegisterAsync(moviment)).Returns(Task.CompletedTask);

//         await _movimentService.RegisterMovimentAsync(moviment);

//         _mockRepo.Verify(r => r.RegisterAsync(moviment), Times.Once);
//     }

//     [Fact]
//     public async Task RegisterMoviment_InvalidStation_ThrowsException()
//     {
//         var moviment = new Moviment { PartId = 1, StationId = -1 }; // estação inválida

//         await Assert.ThrowsAsync<ArgumentException>(() => _movimentService.RegisterMovimentAsync(moviment));
//     }

//     [Fact]
//     public async Task UpdatePartStatus_ValidUpdate_Succeeds()
//     {
//         var partId = 1;
//         var newStatus = "Concluído";

//         _mockRepo.Setup(r => r.UpdatePartStatusAsync(partId, newStatus)).Returns(Task.CompletedTask);

//         await _movimentService.UpdatePartStatusAsync(partId, newStatus);

//         _mockRepo.Verify(r => r.UpdatePartStatusAsync(partId, newStatus), Times.Once);
//     }
// }