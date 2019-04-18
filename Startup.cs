using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using app_datumation.Infrastructure.Caching;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;


namespace app_datumation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    public CorsPolicy GenerateCorsPolicy()
        {
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin(); // For anyone access.            
            corsBuilder.AllowCredentials();
            return corsBuilder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {  services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<Infrastructure.Configuration.IAppConfiguration, Infrastructure.Configuration.AppConfiguration>();
            services.AddSingleton<ICacheProvider, MemoryCacheProvider>();
            services.AddScoped<Providers.Repo.IProviderRepo, Providers.Repo.ProviderRepo>();

                app_datumation.Infrastructure.Logging.LogFactory.Initialize(new app_datumation.Infrastructure.Logging.Logger());
            app_datumation.Infrastructure.Configuration.IAppConfiguration s = new app_datumation.Infrastructure.Configuration.AppConfiguration(Configuration);
            app_datumation.Infrastructure.Configuration.ConfigurationFactory.Initialize(s);
            services.AddSingleton<Infrastructure.Logging.ILogFactory, Infrastructure.Logging.Logger>();


                string rootUrl = Infrastructure.Configuration.ConfigurationFactory.Instance.Configuration().RootUrl;
            // services.AddDetection();


            services.AddMemoryCache();
            services.AddTransient<SmtpClient>((serviceProvider) =>
                              {
                                  var config = serviceProvider.GetRequiredService<IConfiguration>();
                                  return new SmtpClient()
                                  {
                                      Host = config.GetValue<string>("Email:Smtp:Host"),
                                      EnableSsl = true,
                                      Port = config.GetValue<int>("Email:Smtp:Port"),
                                      Credentials = new NetworkCredential(
                                              config.GetValue<string>("Email:Smtp:Username"),
                                              config.GetValue<string>("Email:Smtp:Password")
                                          )
                                  };
                              });
            GenerateCorsPolicy();


            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", domain)));
            });

            // register the scope authorization handler
            services.AddSingleton<Microsoft.AspNetCore.Authorization.IAuthorizationHandler, HasScopeHandler>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddLog4Net(Environment.CurrentDirectory + "/log4net.config");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
