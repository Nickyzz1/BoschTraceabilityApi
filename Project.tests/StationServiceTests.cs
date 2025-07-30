// using Xunit;
// using Moq;
// using System.Threading.Tasks;
// using System.Collections.Generic;
// using MyApi.Entities;
// using MyApi.Repositories;
// using MyApi.Services;
// using MyApi.Interfaces;

// public class StationServiceTests
// {
//     private readonly StationService _stationService;
//     private readonly Mock<IStationRepository> _mockRepo;

//     public StationServiceTests()
//     {
//         _mockRepo = new Mock<IStationRepository>();
//         _stationService = new StationService(_mockRepo.Object);
//     }

//     [Fact]
//     public async Task ValidateStationOrder_ValidOrder_ReturnsTrue()
//     {
//         var station1 = new Station {Id = 1,
//         Title = "Estação 1",
//         Sort = 1};
//         var station2 = new Station { Id = 2,
//         Title = "Estação 2",
//         Sort = 2};
//         var stations = new List<Station> { station1, station2 };

//         _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(stations);

//         var result = await _stationService.ValidateStationOrderAsync();

//         Assert.True(result);
//     }

//     [Fact]
//     public async Task ValidateStationOrder_InvalidOrder_ReturnsFalse()
//     {
//         var station1 = new Station { id = 1, Sort = 2, Title = "Estação 1", };
//         var station2 = new Station { id = 2, Sort = 1, Title = "Estação 2", };
//         var stations = new List<Station> { station1, station2 };

//         _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(stations);

//         var result = await _stationService.ValidateStationOrderAsync();

//         Assert.False(result);
//     }
// }