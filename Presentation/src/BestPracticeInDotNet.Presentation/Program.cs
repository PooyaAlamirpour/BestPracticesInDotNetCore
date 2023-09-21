using BestPracticeInDotNet.Application.Command;
using BestPracticeInDotNet.Application.Queries;
using BestPracticeInDotNet.Application.Services;
using BestPracticeInDotNet.Infrastructure.Authentication;
using BestPracticeInDotNet.Infrastructure.EventStore;
using BestPracticeInDotNet.Infrastructure.Persistence;
using BestPracticeInDotNet.Infrastructure.Write.Persistence;
using BestPracticeInDotNet.Presentation.Server.Middlewares;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BestPracticeInDotNet.Presentation.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services
                    .AddPresentation()
                    .AddCommandPipeline(CommandApplicationAssembly.Assembly)
                    .AddQueryPipeline(QueryApplicationAssembly.Assembly)
                    .AddReadInfrastructure(builder.Configuration)
                    .AddWriteInfrastructure(builder.Configuration)
                    .AddEventStore(builder.Configuration)
                    .AddAuthenticationService()
                    .AddJwtTokenGenerator(builder.Configuration);

                builder.Services.AddSwaggerGen();
            }
            
            var app = builder.Build();
            {
                // app.UseMiddleware<ExceptionHandlingMiddleware>();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    var apiVersionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    app.UseSwagger();
                    app.UseSwaggerUI(options =>
                    {
                        foreach (string groupName in apiVersionProvider.ApiVersionDescriptions.Select(x => x.GroupName))
                        {
                            options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
                        }
                    });
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseRouting();
                app.MapControllers();

                app.Run();
            }
            
        }
    }
}