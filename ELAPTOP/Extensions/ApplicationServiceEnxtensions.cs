using Core.Interfaces;
using ELAPTOP.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELAPTOP.Extensions
{
    public static class ApplicationServiceEnxtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration config) 
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options = options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    migration => migration.MigrationsAssembly("ELAPTOP"));
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContent =>
                {
                    var errors = actionContent.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });



            return services ;
        }
    }
}
