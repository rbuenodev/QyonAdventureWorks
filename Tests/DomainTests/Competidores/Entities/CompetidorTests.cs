using Domain.Competidores.Entities;
using NUnit.Framework;
using System;

namespace DomainTests.Competidores.Entities
{
    public class CompetidorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldCreateACompetidorSuccessfully()
        {
            var competidor = new Competidor() { Altura = 10, Id = 1, Nome = "Richard", Peso = 80, Sexo = "M", TemperaturaMediaCorpo = 36 };

            Assert.IsNotNull(competidor);
            Assert.IsTrue(competidor.IsValid());
        }

        [Test]
        public void ShouldCreateACompetidorWithHighTemperature()
        {
            var competidor = new Competidor() { Altura = 10, Id = 1, Nome = "Richard", Peso = 80, Sexo = "M", TemperaturaMediaCorpo = 39 };

            var ex = Assert.Throws<Exception>(() => competidor.IsValid());
            Assert.That(ex, Is.Not.Null);
            StringAssert.Contains("Verifique a temperatura; ", ex.Message);            
        }
    }
}
