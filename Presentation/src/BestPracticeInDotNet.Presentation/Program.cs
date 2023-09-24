using BestPracticeInDotNet.Application.Command;
using BestPracticeInDotNet.Application.Queries;
using BestPracticeInDotNet.Infrastructure.Authentication;
using BestPracticeInDotNet.Infrastructure.EventStore;
using BestPracticeInDotNet.Infrastructure.Persistence;
using BestPracticeInDotNet.Infrastructure.Write.Persistence;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace BestPracticeInDotNet.Presentation.Api
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
                    .AddJwtTokenGenerator(builder.Configuration);

                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo()
                    {
                        Title = "Best Practices in DotNet Core",
                        Version = "v1"
                    });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme. " +
                                      "Just paste below the token that you have taken from the login api.",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT"
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme()
                            {
                                Reference = new OpenApiReference()
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
                });
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
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseAuthentication();
                app.UseRouting();
                app.MapControllers();
                app.UseAuthorization();
                app.Run();
            }
            
        }
    }
}