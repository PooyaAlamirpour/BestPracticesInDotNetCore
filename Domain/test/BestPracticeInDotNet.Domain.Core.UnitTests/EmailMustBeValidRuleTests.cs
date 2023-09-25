using BestPracticeInDotNet.Domain.Core.Customer.Rules;
using FluentAssertions;
using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Tests;

// [ClassName]Tests
public class EmailMustBeValidRuleTests
{
    private IBusinessRule _sut;
    
    // [MethodName]_Should_[Action]_When_[Condition]

    [Fact]
    public void HasValidRule_Should_ReturnsTrue_When_GivenValidEmailAddress()
    {
        // Assign
        var email = "john@doe.com";
        _sut = new EmailMustBeValidRule(email);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("john@doecom")]
    [InlineData("john@doe.")]
    [InlineData("john@doe")]
    [InlineData("johndoe.")]
    [InlineData("johndoe.com")]
    [InlineData("johndoecom")]
    public void HasValidRule_Should_ReturnsFalse_When_GivenInValidEmailAddress(string email)
    {
        // Assign
        _sut = new EmailMustBeValidRule(email);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeFalse();
    }
}