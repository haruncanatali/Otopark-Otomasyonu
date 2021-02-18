using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Otapark.Business.Abstract;
using Otapark.Business.Concrete;
using Otopark.API.Helper;
using Otopark.API.Model;
using Otopark.DataAccess.Abstract;
using Otopark.DataAccess.Concrete.EntityFrameworkCore;
using Otopark.Entities.Concrete;
using System;
using System.Text;

namespace Otopark.API
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
            services.AddControllers();
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings")); // yeni eklendi


            services.AddDbContext<OtoparkDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Otopark.DataAccess")));
            services.AddIdentity<Kullanici, IdentityRole>(options=> {

                options.User.RequireUniqueEmail = true; 
                options.Password.RequiredLength = 6; 
                options.Password.RequireLowercase = false; 
                options.Password.RequireUppercase = false; 
                options.Password.RequireNonAlphanumeric = false; 
                options.Password.RequireDigit = false; 


            }).AddEntityFrameworkStores<OtoparkDbContext>().AddDefaultTokenProviders();

            services.AddCors(); 

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x=> {  

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(c=> {
                c.RequireHttpsMetadata = false;
                c.SaveToken = false;
                c.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            }); 


            services.AddTransient<IAracService, AracManager>();
            services.AddTransient<IAracDal, AracDal>();

            services.AddTransient<IKonumService, KonumManager>();
            services.AddTransient<IKonumDal, KonumDal>();

            services.AddTransient<IFaturaService, FaturaManager>();
            services.AddTransient<IFaturaDal, FaturaDal>();

            services.AddTransient<IPasswordValidator<Kullanici>, CustomPasswordValidator>();
            services.AddTransient<IUserValidator<Kullanici>, CustomUserValidator>();

            services.AddMvc().AddNewtonsoftJson(options => // json objeleri arasýndaki döngüyü kýrmak için
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
