using System.Reflection;
using FluentAssertions;
using Mc2.CrudTest.Application.Command;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Domain.Core;
using Mc2.CrudTest.Infrastructure.Persistence;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.Abstracts;
using Mc2.CrudTest.Infrastructure.Write.Persistence;
using Mc2.CrudTest.Infrastructure.Write.Persistence.Repository.Abstracts;
using NetArchTest.Rules;

namespace Mc2.CrudTest.Architecture.Tests;

public class ProjectLayerTests
{
    // application solution
    private const string CommandApplicationNamespace = "Mc2.CrudTest.Application.Command";
    private const string QueryApplicationNamespace = "Mc2.CrudTest.Application.Queries";

    // domain solution
    private const string DomainNamespace = "Mc2.CrudTest.Domain.Core";

    // infrastructure solution
    private const string PersistenceNamespace = "Mc2.CrudTest.Infrastructure.Read.Persistence";

    // presentation solution
    private const string PresentationNamespace = "Mc2.CrudTest.Presentation.Api";

    private void ShouldNotHaveDependenciesOn(Assembly projectAssembly, string[] forbiddenProjects)
    {
        // Act
        var result = Types.InAssembly(projectAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(forbiddenProjects)
            .GetResult();

        // Asset
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void CheckLayersDependencies()
    {
        ShouldNotHaveDependenciesOn(
            typeof(DomainAssembly).Assembly,
            new[]
            {
                PersistenceNamespace,
                CommandApplicationNamespace,
                QueryApplicationNamespace,
                PresentationNamespace
            }
        );
        
        ShouldNotHaveDependenciesOn(
            typeof(ReadPersistenceAssembly).Assembly,
            new[]
            {
                CommandApplicationNamespace,
                QueryApplicationNamespace,
                PresentationNamespace
            }
        );
        
        ShouldNotHaveDependenciesOn(
            typeof(WritePersistenceAssembly).Assembly,
            new[]
            {
                CommandApplicationNamespace,
                QueryApplicationNamespace,
                PresentationNamespace
            }
        );
        
        ShouldNotHaveDependenciesOn(
            typeof(CommandApplicationAssembly).Assembly,
            new[]
            {
                PresentationNamespace,
            }
        );
        
        ShouldNotHaveDependenciesOn(
            typeof(QueryApplicationAssembly).Assembly,
            new[]
            {
                PresentationNamespace,
            }
        );
    }

    [Fact]
    public void CommandApplicationAssembly_Should_Not_HaveDependencyOn_ICustomerReadRepository()
    {
        Types.InAssembly(CommandApplicationAssembly.Assembly)
            .That().HaveNameEndingWith("Handler")
            .ShouldNot()
            .HaveDependencyOn($"{typeof(ICustomerReadRepository).Namespace}.{nameof(ICustomerReadRepository)}")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void QueryApplicationAssembly_Should_Not_HaveDependencyOn_ICustomerWriteRepository()
    {
        Types.InAssembly(QueryApplicationAssembly.Assembly)
            .That().HaveNameEndingWith("Handler")
            .ShouldNot()
            .HaveDependencyOn($"{typeof(ICustomerWriteRepository).Namespace}.{nameof(ICustomerWriteRepository)}")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
}