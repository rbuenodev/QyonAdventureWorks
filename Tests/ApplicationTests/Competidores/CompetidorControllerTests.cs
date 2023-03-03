using API.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Service.Competidores.DTOs;
using Service.Competidores.Interface;
using Service.Competidores.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationTests.Competidores
{
    public class CompetidorControllerTests
    {
       
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ShouldGetAllCompetidoresWithStatus200()
        {           
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            //Mock
            var fakeResult = new CompetidorResponse<List<ResultCompetidorDTO>>() { Success = true, Data = new List<ResultCompetidorDTO>() { new ResultCompetidorDTO() { Id = 1, Nome = "Richard", Altura = (decimal)1.75, Peso = 80, Sexo = "M", TemperaturaMediaCorpo = 36 } } };
            var competidorService = new Mock<ICompetidorService>();
            competidorService.Setup(x => x.GetAllCompetidores()).Returns(Task.FromResult(fakeResult));
            var logger = new Mock<ILogger<CompetidoresController>>();            

            var controller = new CompetidoresController(logger.Object, competidorService.Object, memoryCache);

            var res = await controller.GetAllCompetidores();
            var result = res.Result as OkObjectResult;
            var resultObject = GetObjectResultContent<CompetidorResponse<List<ResultCompetidorDTO>>>(result);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(resultObject.Success);
            Assert.IsNotNull(resultObject.Data.ElementAt(0));
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}
