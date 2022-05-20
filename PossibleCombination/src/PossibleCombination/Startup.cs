using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PossibleCombination.Domain.IRepositories;
using PossibleCombination.Domain.Services;
using PossibleCombination.Domain.Services.Interfaces;
using PossibleCombination.Infra.Repositories;

namespace PossibleCombination
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PossibleCombination", Version = "v1" });
            });
            this.DependencyInjection(services);
        }

        private void DependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<ICombinationService, CombinationService>();
            services.AddScoped<ICombinationRepository, CombinationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PossibleCombination v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
