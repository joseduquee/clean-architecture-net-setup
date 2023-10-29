using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimyApp.Application.Contracts.Infrastructure;
using TimyApp.Application.Models.Mail;
using TimyApp.Infrastructure.Mail;

namespace TimyApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
