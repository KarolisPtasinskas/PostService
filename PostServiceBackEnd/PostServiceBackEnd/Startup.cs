using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PostServiceBackEnd.Data;
using PostServiceBackEnd.Entities;
using PostServiceBackEnd.Repositories;
using PostServiceBackEnd.Services;

namespace PostServiceBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // <<<<---- CORS Remove before publishing!!! ----->>>>>
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Database
            services.AddDbContext<DataContext>(d => d.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Repositories
            services.AddTransient<IParcelMachineRepository<ParcelMachine>, ParcelMachineRepository>();
            services.AddTransient<IParcelRepository<Parcel>, ParcelRepository>();

            //Services
            services.AddTransient<ParcelService>();
            services.AddTransient<ParcelMachineService>();

            //Validations
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
                fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PostServiceBackEnd", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy"); // <<<---- CORS Remove before publishing!!! ----->>>>

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PostServiceBackEnd v1"));
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
