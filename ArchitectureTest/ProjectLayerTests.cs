using System.Reflection;
using BestPracticeInDotNet.Application.Command;
using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Application.Queries;
using BestPracticeInDotNet.Application.Queries.Repositories;
using BestPracticeInDotNet.Domain.Core;
using FluentAssertions;
using BestPracticeInDotNet.Infrastructure.Persistence;
using BestPracticeInDotNet.Infrastructure.Write.Persistence;
using NetArchTest.Rules;

namespace BestPracticeInDotNet.Architecture.Tests;

public class ProjectLayerTests
{
    // application solution
    private const string CommandApplicationNamespace = "BestPracticeInDotNet.Application.Command";
    private const string QueryApplicationNamespace = "BestPracticeInDotNet.Application.Queries";

    // domain solution
    private const string DomainNamespace = "BestPracticeInDotNet.Domain.Core";

    // infrastructure solution
    private const string PersistenceNamespace = "BestPracticeInDotNet.Infrastructure.Read.Persistence";

    // presentation solution
    private const string PresentationNamespace = "BestPracticeInDotNet.Presentation.Api";

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