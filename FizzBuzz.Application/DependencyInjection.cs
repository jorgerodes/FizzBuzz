using FizzBuzz.Application.Abstractions.Behaviors;
using FizzBuzz.Application.Abstractions.Behaviours;
using FizzBuzz.Application.Abstractions.Clock;
using FizzBuzz.Domain.FizzBuzzs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient<FizzBuzzService>();
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
