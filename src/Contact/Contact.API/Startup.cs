using consumerAPI.Business;
using Contact.API.Data;
using Contact.API.Data.Interfaces;
using Contact.API.Repositories;
using Contact.API.Repositories.Interfaces;
using Contact.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.API
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

            services.AddDbContext<DAPContext>(options => options.UseSqlServer(@"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog =MicroserviceExampleDB;Trusted_Connection=True;MultipleActiveResultSets = true"));
            services.AddCap(options =>
            {
                options.UseEntityFramework<DAPContext>();
                options.UseSqlServer(@"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog =MicroserviceExampleDB;Trusted_Connection=True;MultipleActiveResultSets = true");

                options.UseRabbitMQ(options =>
                {
                   
                    options.ConnectionFactoryOptions = options =>
                    {
                        options.Ssl.Enabled = false;
                        options.HostName = "localhost";
                        options.UserName = "guest";
                        options.Password = "guest";
                        options.Port = 5672;
                    };
                });
            });

            services.Configure<ContactDatabaseSettings>(Configuration.GetSection(nameof(ContactDatabaseSettings)));

            services.AddSingleton<IContactDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ContactDatabaseSettings>>().Value);

            services.AddTransient<IContactContext, ContactContext>();
            services.AddTransient<IContactRepository, ContactRepository>();



            // services.AddSingleton<EventBusRabbitMQConsumer>();
            services.AddTransient<ConsumerService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Contact API", Version = "v1" });
            });

            services.AddControllers();
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact API V1");
            });
        }
    }
}
