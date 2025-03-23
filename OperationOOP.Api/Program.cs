
using Microsoft.Extensions.Options;
using OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;
using OperationOOP.Api.Endpoints.Bonsai;


namespace OperationOOP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            builder.Services.AddSingleton<IDatabase, Database>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            { 
                app.UseSwagger(); 
                app.UseSwaggerUI(); 
            }

            //app.UseHttpsRedirection();
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapEndpoints<Program>();

            app.Run();
        }
    }
}
