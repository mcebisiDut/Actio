using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Authentication;
using Actio.Common.Commands;
using Actio.Common.ICommands;
using Actio.Common.Mongo;
using Actio.Common.RabbitMq;
using Authentication.Encryption;
using Authentication.Handlers;
using Authentication.IEncryption;
using Authentication.IRepositories;
using Authentication.IServices;
using Authentication.Repositories;
using Authentication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Authentication
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
            services.AddScoped<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
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
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
