using Mc2.CrudTest.Application.Command;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Infrastructure.EventStore;
using Mc2.CrudTest.Infrastructure.Persistence;
using Mc2.CrudTest.Infrastructure.Write.Persistence;
using Mc2.CrudTest.Presentation.Server.Middlewares;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services.AddPresentation();
                builder.Services.AddCommandPipeline(CommandApplicationAssembly.Assembly);
                builder.Services.AddQueryPipeline(QueryApplicationAssembly.Assembly);
                builder.Services.AddReadInfrastructure(builder.Configuration);
                builder.Services.AddWriteInfrastructure(builder.Configuration);
                builder.Services.AddEventStore(builder.Configuration);

                builder.Services.AddSwaggerGen();
            }
            
            var app = builder.Build();
            {
                app.UseMiddleware<ExceptionHandlingMiddleware>();

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