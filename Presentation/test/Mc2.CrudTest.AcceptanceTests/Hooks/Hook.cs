using BoDi;
using Mc2.CrudTest.AcceptanceTests.Repositories;
using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;
using Mc2.CrudTest.Presentation.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.AcceptanceTests.Hooks
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
            var repository = scope.ServiceProvider.GetRequiredService<ICustomerRepository>();
            _objectContainer.RegisterInstanceAs(repository);
        }

        private WebApplicationFactory<Program> GetWebApplicationFactory() =>
            new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var connectionString = "Server=localhost;User ID=root;Password=root;Database=ApplicationDb";
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
                });
            });

        private async Task ClearData(WebApplicationFactory<Program> factory)
        {
            using var scope = factory.Services.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ICustomerRepository>();
            var entities = await repository.GetListAsync();
            foreach (var entity in entities)
            {
                repository.Delete(entity);
            }

            await repository.CommitAsync();
        }
    }
}