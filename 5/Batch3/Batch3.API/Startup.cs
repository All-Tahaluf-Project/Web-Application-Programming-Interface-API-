using Batch3.Core.Repository;
using Batch3.Core.Service;
using Batch3.Infra.Repository;
using Batch3.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.Task3OnionArchitectoure.Core.Connection;
using Tahaluf.Task3OnionArchitectoure.Core.Repository;
using Tahaluf.Task3OnionArchitectoure.Core.Service;
using Tahaluf.Task3OnionArchitectoure.Infra.Connection;
using Tahaluf.Task3OnionArchitectoure.Infra.Repository;
using Tahaluf.Task3OnionArchitectoure.Infra.Service;

namespace Batch3.API
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
            services.AddScoped<IConnection, Connection>();

            //Book
            services.AddScoped<IRepositoryBook, RepositoryBook>();
            services.AddScoped<IServiceBook, ServiceBook>();

            //Course
            services.AddScoped<IRepositoryCourse, RepositoryCourse>();
            services.AddScoped<IServiceCourse, ServiceCourse>();

            //Teacher
            services.AddScoped<IRepositoryTeacher, RepositoryTeacher>();
            services.AddScoped<IServiceTeacher, ServiceTeacher>();

            //TeacherCourse
            services.AddScoped<IRepositoryTeacherCourse, RepositoryTeacherCourse>();
            services.AddScoped<IServiceTeacherCourse, ServiceTeacherCourse>();

            //Mark
            services.AddScoped<IRepositoryMark, RepositoryMark>();
            services.AddScoped<IServiceMark, ServiceMark>();

            //JWTUserAuthUser
            services.AddScoped<IRepositoryJWTUserAuth, RepositoryJWTUserAuth>();
            services.AddScoped<IServiceJWTUserAuth, ServiceJWTUserAuth>();

            services.AddControllers();


services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(y =>
{
    y.RequireHttpsMetadata = false;
    y.SaveToken = true;
    y.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
