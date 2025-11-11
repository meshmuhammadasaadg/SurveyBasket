using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using SurveyBasket.Api.Services;
using System.Reflection;

namespace SurveyBasket.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();

        services
            .AddMapsterConfig()
            .AddFluentValidationConfig();

        //register services
        services.AddScoped<IPollService, PollService>();

        return services;
    }

    public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
    {
        //add mapster
        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMapper>(new Mapper(mappingConfig));

        return services;
    }



    public static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    {
        // Register FluentValidation 
        services.AddFluentValidationAutoValidation()
                            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
