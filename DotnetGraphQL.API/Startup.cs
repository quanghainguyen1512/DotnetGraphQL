using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphQL;
using GraphiQl;
using DotnetGraphQL.Data;
using Microsoft.EntityFrameworkCore;
using DotnetGraphQL.Core.Interfaces;
using DotnetGraphQL.Data.Repositories;
using GraphQL.Types;
using DotnetGraphQL.API.ObjectTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using GraphQL.Http;
using DotnetGraphQL.API.Schemas;
using DotnetGraphQL.API.Inputs;
// using DotnetGraphQL.API.Models;

namespace DotnetGraphQL.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:Demo"]));
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddHttpContextAccessor();
            // services.AddSingleton<ContextServiceLocator>();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<ITaskRepository, TaskRepository>();

            services.AddSingleton<GraphQuery>();
            services.AddSingleton<GraphMutation>();

            services.AddTransient<DepartmentType>();
            services.AddTransient<EmployeeType>();
            services.AddTransient<TaskType>();

            services.AddTransient<DepartmentInputType>();
            services.AddTransient<EmployeeInputType>();
            services.AddTransient<TaskInputType>();

            var sp =services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            // services.AddSingleton<ISchema>(_ => new GraphSchema(type => ()))
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Context db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphiQl("/graphiql", "/demo");
            app.UseMvc();
            db.EnsureSeedData();
        }
    }
}
