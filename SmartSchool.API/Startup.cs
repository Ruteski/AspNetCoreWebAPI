using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartSchool.API.Data;
using System;
using System.IO;
using System.Reflection;

namespace SmartSchool.API
{
   /// <summary>
   /// 
   /// </summary>
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
         // context da aplicacao e qual a conexao com o banco vai usar
         services.AddDbContext<DataContext>(
             context => context.UseMySql(Configuration.GetConnectionString("MySqlConnection"))
         );

         services.AddControllers()
             .AddNewtonsoftJson(
                 opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );

         // dependece injection para o automapper
         services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

         //renova instancias somente em novas requisicoes, 
         services.AddScoped<IRepository, Repository>();

         services.AddVersionedApiExplorer(options =>
         {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
         })
         .AddApiVersioning(options =>
         {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
         });

         var apiProviderDescription = services.BuildServiceProvider()
             .GetService<IApiVersionDescriptionProvider>();

         services.AddSwaggerGen(options =>
         {
            foreach (var description in apiProviderDescription.ApiVersionDescriptions)
            {
               options.SwaggerDoc(
                      description.GroupName,
                      new Microsoft.OpenApi.Models.OpenApiInfo()
                     {
                        Title = "SmartSchool API",
                        Version = description.ApiVersion.ToString(),
                        TermsOfService = new Uri("http://MeuTermoDeUso.com"),
                        Description = "A descri��o da WebAPI do SmartSchool",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense
                        {
                           Name = "SmartSchool License",
                           Url = new Uri("http://mit.com")
                        },
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                           Name = "Lincoln Ruteski",
                           Email = "lruteski@gmail.com",
                           Url = new Uri("http://lruteski.com.br")
                        }
                     }
                  );
            }



            var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

            options.IncludeXmlComments(xmlCommentsFullPath);
         });
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiProviderDescription)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseRouting();

         app.UseSwagger()
             .UseSwaggerUI(options =>
             {
                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                   options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }

                options.RoutePrefix = "";
             });

         // app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
