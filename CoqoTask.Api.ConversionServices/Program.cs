using CoqoTask.Application.Interfaces;
using CoqoTask.Application.Queries;

namespace CoqoTask.Api.ConversionServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddScoped<IConvertRomanNumberToDecimalQuery, ConvertRomanNumberToDecimalQuery>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}