using ECommerce.Application.Exceptions;
using ECommerce.Application.Validations;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

            services.AddTransient<ExceptionMiddleware>();

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr-Tr");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationConfiguration<,>));

        }
    }
}
