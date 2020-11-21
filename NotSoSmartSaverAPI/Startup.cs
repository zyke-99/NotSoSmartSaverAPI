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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotSoSmartSaverAPI.Interfaces;
using NotSoSmartSaverAPI.Processors;
using NotSoSmartSaverAPI.ModelsGenerated;
using NotSoSmartSaverAPI.DataVerification;
//using NotSoSmartSaverWFA.DataAccess;
//using NotSoSmartSaverWFA.DataAccess.DataValidation;

namespace NotSoSmartSaverAPI
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
            services.AddControllers();
            services.AddScoped<IIncomeProcessor, IncomeProcessor>();
            services.AddScoped<IGroupProcessor, GroupProcessor>();
            services.AddScoped<IExpensesProcessor, ExpenseProcessor>();
            services.AddScoped<IBudgetProcessor, BudgetProcessor>();
            services.AddScoped<IGoalProcessor, GoalProcessor>();
            services.AddScoped<IUserProcessor, UserProcessor>();
            services.AddScoped<IDataValidation, DataValidation>();
            services.AddScoped<IUserVerification, UserVerification>();
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<NSSSContext>()
                .BuildServiceProvider();


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
