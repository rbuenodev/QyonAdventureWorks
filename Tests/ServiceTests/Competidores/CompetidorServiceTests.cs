using Domain.Competidores.Entities;
using Domain.Competidores.Interfaces;
using Moq;
using NUnit.Framework;
using Service.Competidores;
using Service.Competidores.DTOs;
using System.Threading.Tasks;

namespace ServiceTests.Competidores
{
    public class CompetidorServiceTests
    {

        private readonly Competidor _competidor = new Competidor()
        {
            Id = 1,
            Nome = "Richard",
            Altura = (decimal)1.75,
            Peso = 80,
            Sexo = "M",
            TemperaturaMediaCorpo = 36
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ShouldCreateACompetidorSuccessfully()
        {
            //Mock
            var competidorRepository = new Mock<ICompetidorRepository>();
            competidorRepository.Setup(x => x.Save(_competidor)).Returns(Task.FromResult(_competidor));

            var competidorService = new CompetidorService(competidorRepository.Object);
            var dto = new CreateCompetidorDTO() { Altura = _competidor.Altura, Nome = _competidor.Nome, Peso = _competidor.Peso, Sexo = _competidor.Sexo, TemperaturaMediaCorpo = _competidor.TemperaturaMediaCorpo };
            var result = await competidorService.CreateCompetidor(dto);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.That(result.Data.Nome, Is.EqualTo(_competidor.Nome));
            Assert.That(result.Data.Peso, Is.EqualTo(_competidor.Peso));
        }

        [Test]
        public async Task ShouldNotFindACompetidor()
        {
            //Mock
            Competidor competidor = null;
            var competidorRepository = new Mock<ICompetidorRepository>();
            competidorRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(competidor));

            var competidorService = new CompetidorService(competidorRepository.Object);

            var result = await competidorService.GetCompetidorById(It.IsAny<int>());

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.That(result.Message, Is.EqualTo("Competidor não encontrado"));
        }
    }
}
