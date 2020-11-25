using Exercise.Interface.Repositroy;
using Exercise.Interface.Service;
using Exercise.Model;
using Exercise.Repository;
using Exercise.Repository.DBContext;
using Exercise.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Exercise.Payment
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

            #region DBContext Setup

            services.AddDbContext<PaymentDBContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("PaymentDBContext")));
 
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<PaymentDBContext>();

            #endregion


            //Start: IOC

            #region Repository

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            
            #endregion

            #region Service

            services.AddScoped<IPaymentService, PaymentService>();

            #endregion

            //End: IOC



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exercise.Payment", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exercise.Payment v1"));
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
