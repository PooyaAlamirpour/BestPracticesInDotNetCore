using FluentAssertions;
using Mc2.CrudTest.Domain.Core.Customer.Rules;
using Mc2.CrudTest.framework.DDD.Abstracts;

namespace Mc2.CrudTest.Domain.Core.Tests;

public class DateOfBirthMustBeValidRuleTests
{
    private IBusinessRule _sut;
    
    // [MethodName]_Should_[Action]_When_[Condition]

    [Fact]
    public void HasValidRule_Should_ReturnsTrue_When_GivenBirthdate()
    {
        // Assign
        var birthdate = "2000-02-01";
        _sut = new DateOfBirthMustBeValidRule(birthdate);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("2000-02-01-14:20:30")]
    [InlineData("birthdate")]
    [InlineData("123456")]
    public void HasValidRule_Should_ReturnsFalse_When_GivenGivenBirthdate(string birthdate)
    {
        // Assign
        _sut = new DateOfBirthMustBeValidRule(birthdate);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeFalse();
    }
}