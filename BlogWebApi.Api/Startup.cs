using BlogWebApi.Application.Authors.Commands.CreateAuthor;
using BlogWebApi.Infrastructure.AutoMapper;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using BlogWebApi.Infrastructure.Data.Data.Context;
using BlogWebApi.Infrastructure.Data.Middleware;
using BlogWebApi.Infrastructure.Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BlogWebApi.Api
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
            services.AddAutoMapperServices();
            services.AddCors();

            services.AddMediatR(cfg => {
                cfg.Lifetime = ServiceLifetime.Scoped;
                cfg.RegisterServicesFromAssemblies(typeof(CreateAuthorCommand).Assembly);
            });

            services.AddScoped<IDBContext, ApplicationDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddValidatorsFromAssemblyContaining<CreateAuthorCommandValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "BlogWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogWebApi");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
