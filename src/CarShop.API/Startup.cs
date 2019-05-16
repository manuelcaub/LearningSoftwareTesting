using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            CarShopApiConfiguration.ConfigureServices(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            CarShopApiConfiguration.Configure(app, host =>
            {
                if (env.IsDevelopment())
                {
                    host.UseDeveloperExceptionPage();
                }
                else
                {
                    host.UseHsts();
                }

                host.UseHttpsRedirection();
                return host;
            });
        }
    }
}
