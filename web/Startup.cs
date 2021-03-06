﻿using DNX_Admin.Web.ViewComponents;
using DNX_Admin.Web.Modules.Users.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DNX_Admin.Web {

	public class Startup {

		public IConfigurationRoot Configuration { get; set; }

		public Startup(IHostingEnvironment env) {

			// Set up configuration sources.
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();

		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddIdentity<User, IdentityRole>()
				//.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddMvc();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {

			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment()) {

				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();

			} else {

				app.UseExceptionHandler("/Home/Error");

				//// For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
				//try {
				//	using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
				//		.CreateScope()) {
				//		serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
				//			 .Database.Migrate();
				//	}
				//} catch { }

			}

			app.UseIISPlatformHandler(options => options.AuthenticationDescriptions.Clear());
			app.UseStaticFiles();
			app.UseIdentity();
			// To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

			app.UseMvc(routes => {

				//routes.MapRoute(RouteNames.Home, "", new { controller = "Home", action = "Index" });
				//routes.MapRoute(RouteNames.Sandbox, "sandbox", new { controller = "Sandbox", action = "Index" });

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");

			});

			//app.Run(async (context) => {
			//	await context.Response.WriteAsync("Hello World!");
			//});

		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);

	}

}
