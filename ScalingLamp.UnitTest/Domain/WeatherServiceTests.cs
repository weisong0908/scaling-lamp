using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using ScalingLamp.Domain.Models.DAOs;
using ScalingLamp.Domain.Models.DomainModels;
using ScalingLamp.Domain.Persistence;
using ScalingLamp.Domain.Services;
using Xunit;

namespace ScalingLamp.UnitTest.Domain
{
    public class WeatherServiceTests
    {
        private readonly ICityRepository _cityRepository;
        private readonly IVariableRepository _variableRepository;

        private readonly List<VariableDao> _variables;
        private readonly HottestCityDao _hottestCityDao;
        private readonly MoistestCityDao _moistestCityDao;

        public WeatherServiceTests()
        {
            _cityRepository = A.Fake<ICityRepository>();
            _variableRepository = A.Fake<IVariableRepository>();

            _variables = new List<VariableDao>
            {
                new VariableDao(new Variable{
                    Name = "Temperature",
                    Unit = "C",
                    Value = "100",
                    City = new City
                    {
                        CityName = "My City"
                    }
                })
            };

            A.CallTo(() => _variableRepository.GetVariablesAsync(
                "Temperature",
                A<DateTimeOffset>.Ignored,
                A<DateTimeOffset>.Ignored,
                "My City"))
                .Returns(_variables);
            
            _hottestCityDao = new HottestCityDao
            {
                CityName = "My Hottest City",
                Count = 10
            };
            A.CallTo(() => _cityRepository.GetHottestCityAsync())
                .Returns(_hottestCityDao);

            _moistestCityDao = new MoistestCityDao
            {
                CityName = "My Hottest City",
                Average = 10.6
            };
            A.CallTo(() => _cityRepository.GetMoistestCityAsync())
                .Returns(_moistestCityDao);
        }

        [Theory]
        [InlineData("Temperature", "My City", 1)]
        [InlineData("Temperature", "Not My City", 0)]
        public async Task GetVariablesAsync_GivenInput_CompletesSuccessfully(string variableName, string cityName, int expectedCount)
        {
            var startDate = DateTimeOffset.Parse("2023-01-01");
            var endDate = DateTimeOffset.Parse("2023-01-31");

            var service = new WeatherService(_cityRepository, _variableRepository);
            var result = service.GetVariablesAsync(variableName, startDate, endDate, cityName);

            Assert.True(result.IsCompletedSuccessfully);
            Assert.Equal(expectedCount, (await result).Count);
        }

        [Fact]
        public async Task GetHottestCityAsync_CompletesSuccessfully()
        {
            var service = new WeatherService(_cityRepository, _variableRepository);
            var result = service.GetHottestCityAsync();

            Assert.True(result.IsCompletedSuccessfully);
            Assert.Equal(_hottestCityDao, await result);
        }

        [Fact]
        public async Task GetMoistestCityAsync_CompletesSuccessfully()
        {
            var service = new WeatherService(_cityRepository, _variableRepository);
            var result = service.GetMoistestCityAsync();

            Assert.True(result.IsCompletedSuccessfully);
            Assert.Equal(_moistestCityDao, await result);
        }
    }
}