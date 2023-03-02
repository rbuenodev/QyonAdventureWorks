using Data;
using Data.Competidores;
using Data.HistoricosCorrida;
using Data.PistasCorrida;
using Domain.Competidores.Interfaces;
using Domain.HistoricosCorrida.Interfaces;
using Domain.PistasCorrida.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Competidores;
using Service.Competidores.Interface;
using Service.HistoricosCorrida;
using Service.HistoricosCorrida.Interface;
using Service.PistasCorrida;
using Service.PistasCorrida.Interface;

namespace API.DependenciesInjection
{
    public static class ServiceDependencyProvider
    {

        public static void RegisterDependencies(this IServiceCollection serviceCollection, string connectionString)
        {

            serviceCollection.AddScoped<ICompetidorRepository, CompetidorRepository>();
            serviceCollection.AddScoped<ICompetidorService, CompetidorService>();

            serviceCollection.AddScoped<IHistoricoCorridaRepository, HistoricoCorridaRepository>();
            serviceCollection.AddScoped<IHistoricoCorridaService, HistoricoCorridaService>();

            serviceCollection.AddScoped<IPistaCorridaRepository, PistaCorridaRepository>();
            serviceCollection.AddScoped<IPistaCorridaService, PistaCorridaService>();

            serviceCollection.AddDbContext<AdventureDBContext>(options => options.UseNpgsql(connectionString));
        }


    }
}
