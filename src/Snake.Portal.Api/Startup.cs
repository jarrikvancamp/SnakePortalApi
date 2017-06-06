using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BL.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Snake.Portal.Api.Middleware;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.Swagger;
using Entities.User;
using Snake.Portal.Api.Filters;
using Snake.Portal.Api.Contracts;
using Snake.Portal.Api.Services;

namespace Snake.Portal.Api
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
				.AddEnvironmentVariables();

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Warning()
				.Enrich.FromLogContext()
				.WriteTo.LiterateConsole()
				.WriteTo.RollingFile(@"C:\PortalLogs\snake-portal-api-{Date}.txt")
				.CreateLogger();

			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddApplicationInsightsTelemetry(Configuration);
			services.AddMvc();

			//Swagger
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "Snake.Portal.Api", Version = "v1" });

			});

			services.ConfigureSwaggerGen(options =>
			{
				options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
			});

			services.AddSingleton<IIdentityService, IdentityService>();

			//AutoFac implementation
			var builder = new ContainerBuilder();

			builder.RegisterModule<BlAutoFacModule>();

			//check for other registered dependencies
			builder.Populate(services);

			var container = builder.Build();
			return container.Resolve<IServiceProvider>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
		{
			loggerFactory.AddSerilog();

			//global application of CORS policy
			app.UseCors("CorsPolicy");

			// Configure a rewrite rule to auto-lookup for standard default files such as index.html.
			app.UseDefaultFiles();
			//avoid caching errors
			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = context =>
				{
					context.Context.Response.Headers["Cache-Control"] =
						Configuration["StaticFiles:Headers:Cache-Control"];
					context.Context.Response.Headers["Pragma"] = Configuration["StaticFiles:Headers:Pragma"];
					context.Context.Response.Headers["Headers"] = Configuration["StaticFiles:Headers:Expires"];
				}
			});

			var options = new JwtBearerOptions
			{
				Audience = Configuration["Auth0:ApiIdentifier"],
				Authority = $"https://{Configuration["Auth0:Domain"]}/",
				AutomaticAuthenticate = true,
			};
			app.UseJwtBearerAuthentication(options);

			app.UseMiddleware(typeof(ErrorHandlingMiddleware));
			app.UseMvc();

			//Swagger
			app.UseMvcWithDefaultRoute();
			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			// Ensure any buffered events are sent at shutdown
			appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
		}
	}
}