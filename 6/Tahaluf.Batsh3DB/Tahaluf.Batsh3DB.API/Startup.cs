using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.Batsh3DB.Core.Common;
using Tahaluf.Batsh3DB.Core.Repository;
using Tahaluf.Batsh3DB.Core.Service;
using Tahaluf.Batsh3DB.Infra.Common;
using Tahaluf.Batsh3DB.Infra.Repository;
using Tahaluf.Batsh3DB.Infra.Service;

namespace Tahaluf.Batsh3DB.API
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
            services.AddScoped<IDBContext, DBContext>();

            //Repository
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IBookReository, BookRepository>();


            //Service
            services.AddScoped<ICourseService, CourseSerivce>();
            services.AddScoped<IBookService, BookService>();
            services.AddControllers();
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
        }
    }
}
