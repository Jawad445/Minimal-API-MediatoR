using API.Abstractions;
using Application.Abstraction;
using Application.Commands;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServicesExtension
    {
        public static void servicesRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("sqlLite");
            services.AddDbContext<SocialDbContext>(x => x.UseSqlite(cs));

            services.AddScoped<IPostRepo, PostRepo>();
            //builder.Services.AddMediatR(c => c.MediatorImplementationType.);
            services.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(typeof(CreatePost).Assembly));


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //return services;
        }

        public static void EndpointRegistration(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            var endpointDefinations = typeof(Program).Assembly
                                            .GetTypes()
                                            .Where(t => t.IsAssignableTo(typeof(IEndpointDefination))
                                                    && !t.IsAbstract && !t.IsInterface)
                                            .Select(Activator.CreateInstance)
                                            .Cast<IEndpointDefination>();

            foreach (var endpointDef in endpointDefinations)
            {
                endpointDef.registerEndpoints(app);
            }
        }
    }

}
