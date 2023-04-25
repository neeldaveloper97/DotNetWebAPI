using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Exaltedsoft_Model;
using Microsoft.EntityFrameworkCore;
using Exaltedsoft_Services.Interface;
using Exaltedsoft_Repository.Interface;
using Exaltedsoft_Repository.Implementation;
using Exaltedsoft_Services.Implementation;

namespace Exaltedsoft_Backend
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
            services.AddControllersWithViews();

            // Add Database Crendentials for MSSQL Server 2019 DB
            //services.AddDbContext<AppDbContext>
            //    (options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            // Add Database Crendentials for PostgreSQL Server DB
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<AppDbContext>(option =>
                option.UseNpgsql(Configuration.GetConnectionString("DatabaseConnection")));

            // Add All Interface, Services and Repository file.
            services.AddTransient<IFontStyleRepository, FontStyleRepository>();
            services.AddTransient<IFontStyleService, FontStyleService>();

            services.AddMvc()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            // Session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(365);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //Add CORS configuration.
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("Token-Expired")
                    .Build();
                });
            });

            services.AddSwaggerGen();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exaltedsoft App V1");
            });
        }
    }
}
