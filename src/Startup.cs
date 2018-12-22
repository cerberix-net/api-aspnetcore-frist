using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient((container) =>
            {
                return new Cerberix.HealthCheck.Core.HealthCheckService(
                    healthChecks: new Cerberix.HealthCheck.Core.IHealthCheck []
                    {
                        //
                        //  TODO: inject your health checks here
                        //

                        ////  PM> Install-Package Cerberix.HealthCheck.HttpEndpoint -Version 1.0.0
                        //new Cerberix.HealthCheck.HttpEndpoint.HttpGetEndpointHealthCheck(
                        //    description: "http endpoint health check (postman-echo)",
                        //    endpoint: "https://postman-echo.com/delay/2",
                        //    connectTimeout: 5
                        //    ),

                        ////  PM> Install-Package Cerberix.HealthCheck.RedisConnection -Version 1.0.0
                        //new Cerberix.HealthCheck.RedisConnection.RedisConnectionHealthCheck(
                        //    description: "redis connection health check (localhost:6379)",
                        //    connectionString: "localhost:6379",
                        //    connectTimeout: 5,
                        //    connectRetry: 3
                        //    ),

                        ////  PM> Install-Package Cerberix.HealthCheck.SqlConnection -Version 1.0.0
                        //new Cerberix.HealthCheck.SqlConnection.SqlConnectionHealthCheck(
                        //    description: "dockerized sql server connection (localhost:1433)",
                        //    connectionString: "Data Source=tcp:localhost,1433;Integrated Security=False;User Id=sa;Password=pw;",
                        //    connectTimeout: 10
                        //    ),

                        //  PM> Install-Package Cerberix.HealthCheck.MySqlConnection -Version 1.0.0
                        //new Cerberix.HealthCheck.MySqlConnection.MySqlConnectionHealthCheck(
                        //    description: "dockerized mysql server connection (localhost:3306)",
                        //    connectionString: "server=127.0.0.1;port=3306;uid=root;pwd=my-secret-pw;",
                        //    connectTimeout: 10
                        //    ),
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
