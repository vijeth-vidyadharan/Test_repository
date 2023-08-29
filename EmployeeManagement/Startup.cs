using EmployeeManagement.model;
using EmployeeManagement.model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<EmployeeContext>(
            options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            

            services.AddMvc(service => service.EnableEndpointRouting= false).AddXmlSerializerFormatters();
            //EnableEndpointRouting 
            services.AddScoped<IEmployeeRepository, SQLRepsitory>();
            //services.AddScoped<IEmployeeRepository,MockEmployeeRepository>();
            //services.AddTransient<IEmployeeRepository,MockEmployeeRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) //, ILogger<Startup> logger
        {
            if (env.IsDevelopment())
                
            {
                //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                //developerExceptionPageOptions.SourceCodeLineCount = 10; // to set set the no of error in developer exception page 
                app.UseDeveloperExceptionPage();
            }
            //----------------------------------------------------------------------------------------------------
            //FileServerOptions defaultFileserverOptions = new FileServerOptions();
            //defaultFileserverOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //defaultFileserverOptions.DefaultFilesOptions.DefaultFileNames.Add("htmlpage.html");
            //--------------------------------------------------------------------------------------------------
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();   //default
            app.UseMvc(Routes => Routes.MapRoute("default","{Controller}/{Action}/{id?}"));   // conventionel routing 
            //app.UseMvc();

            app.Run(async (context) =>
            {
                //logger.LogInformation("MySetting from mw1 ip3");
                //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                await context.Response.WriteAsync("MySetting from mw2");
                //logger.LogInformation("MySetting from mw1 0p3");
            });
        }
    }
}
