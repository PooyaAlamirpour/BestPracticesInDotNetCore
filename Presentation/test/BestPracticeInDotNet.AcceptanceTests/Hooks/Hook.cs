using BestPracticeInDotNet.AcceptanceTests.Repositories;
using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Presentation.Server;
using BoDi;
using BestPracticeInDotNet.Infrastructure.Persistence.DbContexts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BestPracticeInDotNet.AcceptanceTests.Hooks
{
    [Binding]
    public class CustomerHooks
    {
        private readonly IObjectContainer _objectContainer;
        private const string AppSettingsFile = "appsettings.json";

        public CustomerHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task RegisterServices()
        {
            var factory = GetWebApplicationFactory();
            await ClearData(factory);
            _objectContainer.RegisterInstanceAs(factory);
            _objectContainer.RegisterInstanceAs(new JsonFilesRepository());
            
            var scope = factory.Services.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ICustomerWriteRepository>();
            _objectContainer.RegisterInstanceAs(repository);
        }

        private WebApplicationFactory<Program> GetWebApplicationFactory() =>
            new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var connectionStringRead = "Server=localhost;User ID=root;Password=root;Database=ReadDb";
                    var connectionStringWrite = "Server=localhost;User ID=root;Password=root;Database=WriteDb";
                    services.AddDbContext<ApplicationReadDbContext>(options =>
                        options.UseMySql(connectionStringRead, ServerVersion.AutoDetect(connectionStringRead)));
                    
                    services.AddDbContext<ApplicationReadDbContext>(options =>
                        options.UseMySql(connectionStringWrite, ServerVersion.AutoDetect(connectionStringWrite)));
                });
            });

        private async Task ClearData(WebApplicationFactory<Program> factory)
        {
            using var scope = factory.Services.CreateScope();
            var readRepository = scope.ServiceProvider.GetRequiredService<ICustomerReadRepository>();
            var writeRepository = scope.ServiceProvider.GetRequiredService<ICustomerWriteRepository>();
            var entities = await readRepository.GetListAsync();
            foreach (var entity in entities)
            {
                writeRepository.Delete(entity);
            }

            await writeRepository.CommitAsync();
        }
    }
}