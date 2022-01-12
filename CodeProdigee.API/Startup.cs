using CodeProdigee.API.Core;
using CodeProdigee.API.Data;
using CodeProdigee.API.GraphQL.MutationTypes;
using CodeProdigee.API.GraphQL.QueryTypes;
using HotChocolate.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CodeProdigee.API
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
            services.AddPooledDbContextFactory<CodeProdigeeContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging();
            });
            services.AddGraphQLServer()
              .AddQueryType<Query>()
              .AddMutationType<Mutation>()
              .AddProjections()
              .AddFiltering()
              .AddSorting()
              .RegisterDbContext<CodeProdigeeContext>(kind: DbContextKind.Pooled);

            //services.AddMediatR(typeof(Startup));
            //services.AddTransient<IAuthenticationService, AuthenticationService>();
            //services.AddTransient<IContentFilter, ContentFilter>();
            //services.AddIdentityCore<ApplicationUser>()
            //    .AddEntityFrameworkStores<CodeProdigeeContext>();
            services.AddHttpContextAccessor();
            services.AddControllers();

            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);
            var jwtBytes = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeProdigee.API", Version = "v1", Description = "Backend API for CodeProdigee" });
            //    var securityScheme = new OpenApiSecurityScheme
            //    {
            //        Description = "JWT Auth Header with bearer scheme",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer",
            //        Reference = new OpenApiReference
            //        {
            //            Id = "Bearer",
            //            Type = ReferenceType.SecurityScheme
            //        }
            //    };

            //    var security = new OpenApiSecurityRequirement
            //    {
            //        { securityScheme, new string[] {} }
            //    };

            //    c.AddSecurityDefinition("Bearer", securityScheme);
            //    c.AddSecurityRequirement(security);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeProdigee.API v1"));
            }

            //app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeProdigee.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}
