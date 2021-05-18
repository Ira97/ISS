using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using BusinessLogicCore.Controllers;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MiddleWares;
using ScientificDatabase.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApiHandlers.Interfaces;
using WebApiHandlers.Providers;

namespace WebApiCore
{
    /// <summary>
    /// Конфигурация проекта
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Конфигурация проекта
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Конфигурация сервисов
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(cors =>
            {
                cors.AddPolicy("Policy1",
                    builder =>
                        builder.WithOrigins("https://tokyo-bar.ru/")
                            .WithHeaders("X-Header1", "X-Header1")
                            .WithMethods("GET", "POST", "PUT"));
            });

            // Configure Swagger
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fusion Rest Api",
                    Version = "v1",
                });
                c.SchemaFilter<EnumSchemaFilter>();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.EnableAnnotations();
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
#if DEBUG
                //XmlDocument apiDoc = new XmlDocument();
                //apiDoc.Load(xmlFile);
                //XmlDocument contractsDoc = new XmlDocument();
                //var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(xmlFile))))));
                //contractsDoc.Load(Path.Combine(path, "Databases", "FusionDatabase", "FusionDatabase.xml"));
                //if (contractsDoc.DocumentElement != null && apiDoc.DocumentElement != null)
                //{
                //    XmlNodeList nodes = contractsDoc.DocumentElement.ChildNodes;
                //    foreach (XmlNode node in nodes)
                //    {
                //        XmlNode copiedNode = apiDoc.ImportNode(node, true);
                //        apiDoc.DocumentElement?.AppendChild(copiedNode);
                //    }
                //    apiDoc.Save(xmlFile);
                //}
#endif
                //c.IncludeXmlComments(xmlFile);
            });
            services.AddSwaggerGenNewtonsoftSupport();
#if DEBUG
            //Работа с базой данных
            services.AddDbContext<ScientificContext>(options =>
            {
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
          
#else 
            //Работа с базой данных
            services.AddDbContext<FusionContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            
#endif

            //Кэш менеджер
            services.AddCacheManagerConfiguration(Configuration);
            services.AddCacheManager();



            //Провайдеры
           
            services.AddScoped<IMapperProvider, MapperProvider>();        
            services.AddScoped<IHashProvider, HashProvider>();
            services.AddScoped<IWebHttpClientProvider, WebHttpClientProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<ISectionService, SectionService>();

            //Репозитории 

            services.AddScoped<ScientificDatabase.Repositories.UserRepository.UserRepository>();
            services.AddScoped<ScientificDatabase.Repositories.UserRepository.RoleRepository>();
            services.AddScoped<ScientificDatabase.Repositories.HierarchyRepository.AreaRepository>();
            services.AddScoped<ScientificDatabase.Repositories.HierarchyRepository.SectionRepositopy>();
            services.AddScoped<ScientificDatabase.Repositories.TypeObjectRepository.TypeObjectRepository>();
            services.AddScoped<ScientificDatabase.Repositories.TypeObjectRepositopy.PropertiesRepository>();
            services.AddScoped<ScientificDatabase.Repositories.TypeObjectRepositopy.ValueRepository>();
            services.AddScoped<ScientificDatabase.Repositories.TypeObjectRepositopy.DataObjectRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            });
            services.AddControllers().AddNewtonsoftJson();
        }

        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        /// <param name="app"></param>
        /// <param name="logger"></param>
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/html";

                    await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                    await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature != null)
                    {
                        logger.LogError(exceptionHandlerPathFeature.Error, exceptionHandlerPathFeature.Error.StackTrace);
                        if (exceptionHandlerPathFeature.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                        }
                        await context.Response.WriteAsync(
                            $"<a href=\"/{exceptionHandlerPathFeature.Path}\">Exception for Path: {exceptionHandlerPathFeature.Path}</a><br>\r\n");
                        await context.Response.WriteAsync($"<p>Message:</p><br>\r\n");
                        await context.Response.WriteAsync(
                            $"<p>{exceptionHandlerPathFeature.Error.Message}</p><br>\r\n");
                        await context.Response.WriteAsync($"<p>Stack Trace:</p><br>\r\n");
                        await context.Response.WriteAsync(
                            $"<p>{exceptionHandlerPathFeature.Error.StackTrace}</p><br>\r\n");
                    }

                    await context.Response.WriteAsync("</body></html>\r\n");
                    await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                });
            });
            app.UseHsts();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fusion Rest Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseMvc();
        }

        /// <summary>
        /// Вывод значения enum в описании swagger
        /// </summary>
        private class EnumSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema model, SchemaFilterContext context)
            {
                if (context.Type.IsEnum)
                {
                    model.Enum.Clear();
                    Enum.GetNames(context.Type)
                        .ToList()
                        .ForEach(name => model.Enum.Add(new OpenApiString($"{Convert.ToInt64(Enum.Parse(context.Type, name))} - {name}")));
                }
            }
        }
    }

}
