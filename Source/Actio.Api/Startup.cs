using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.API.Handlers;
using Actio.Common.Events;
using Actio.Common.IEvents;
using Actio.Common.Authentication;
using Actio.Common.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Actio.Api.Handlers;
using Actio.Common.Mongo;
using Actio.Api.IRepositories;
using Actio.Api.Repositories;

namespace Actio.API
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
            services.AddMvc();
            services.AddLogging();
            services.AddJwt(Configuration);
            services.AddMongoDB(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<IEventHandler<ActivityCreated>, ActivityCreatedHandler>();
            services.AddScoped<IEventHandler<UserCreated>, UserCreatedHandler>();
            services.AddScoped<IEventHandler<UserAuthenticated>, UserAuthenticatedHandler>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
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
