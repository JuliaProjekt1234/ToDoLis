using Microsoft.EntityFrameworkCore;
using ToDoList.Db;
using ToDoList.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Mappers;
using Newtonsoft.Json.Serialization;

namespace ToDoList;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });

        services.AddControllers().AddNewtonsoftJson();

        services.AddSwaggerGen();
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();

        services.AddDbContext<ToDoListDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            options.UseLazyLoadingProxies();
        });

        services.AddScoped<IToDoListDbContext, ToDoListDbContext>();
        services.AddScoped<ITablesRepository, TablesRepository>();
        services.AddSingleton(mapper);



    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("AllowSpecificOrigin");
        app.UseHttpsRedirection();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}