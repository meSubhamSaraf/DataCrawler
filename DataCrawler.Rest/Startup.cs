using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataCrawler.Core.Engine;
using DataCrawler.Core.Service;
using DataCrawler.Model.Entity;
using DataCrawler.Model.InterFace;
using DataCrawler.Producer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataCrawler.Rest
{
    public class Startup
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        public Startup(/*IHostingEnvironment environment*/)
        {
            var config = new ConfigurationBuilder()
                            //.SetBasePath(environment.ContentRootPath)
                            .AddJsonFile("appsettings.json")
                            //.AddJsonFile($"appsettings{environment.EnvironmentName}.json")
                            //.AddEnvironmentVariables()
                            .Build();
            Configuration = config;
        }

     

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IDataDumpService,DataDumpService>();
            services.AddTransient<IDataDumpValidator, DataDumpValidator>();
            services.AddTransient<IDataDumpEngine, DataDumpEngine>();
            services.AddTransient<ISender, Sender>();
            services.AddTransient<IProducerFactory, ProducerFactory>();
            services.AddTransient<Model.InterFace.IConfigurationBuilder, AppSettingConfigurationBuilder>();
            services.Configure<AppSetting>(Configuration);//.getsection
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
