using CodeSense.Domain.Entities;
using CodeSense.Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSense.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainLayer(this IServiceCollection services)
    {
        services.AddTransient<IValidator<Employee>, EmployeeValidator>();
        services.AddTransient<IValidator<Project>, ProjectValidator>();

        return services;
    }
}