using System.Reflection;
using FluentAssertions;
using Mc2.CrudTest.Application.Command;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Domain.Core;
using Mc2.CrudTest.Infrastructure.Persistence;
using NetArchTest.Rules;

namespace Mc2.CrudTest.Architecture.Tests;

public class ProjectLayerTests
{
    // application solution
    private const string ApplicationCommandNamespace = "Mc2.CrudTest.Application.Command";
    private const string ApplicationQueryNamespace = "Mc2.CrudTest.Application.Queries";

    // domain solution
    private const string DomainNamespace = "Mc2.CrudTest.Domain.Core";

    // infrastructure solution
    private const string PersistenceNamespace = "Mc2.CrudTest.Infrastructure.Persistence";

    // presentation solution
    private const string PresentationNamespace = "Mc2.CrudTest.Presentation.Api";

    private void CheckProjectDependencies(Assembly projectAssembly, string[] forbiddenProjects)
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
        CheckProjectDependencies(
            typeof(DomainAssembly).Assembly,
            new[]
            {
                PersistenceNamespace,
                ApplicationCommandNamespace,
                ApplicationQueryNamespace,
                PresentationNamespace
            }
        );
        
        CheckProjectDependencies(
            typeof(PersistenceAssembly).Assembly,
            new[]
            {
                ApplicationCommandNamespace,
                ApplicationQueryNamespace,
                PresentationNamespace
            }
        );
        
        CheckProjectDependencies(
            typeof(CommandApplicationAssembly).Assembly,
            new[]
            {
                PresentationNamespace,
            }
        );
        
        CheckProjectDependencies(
            typeof(QueryApplicationAssembly).Assembly,
            new[]
            {
                PresentationNamespace,
            }
        );
    }
}