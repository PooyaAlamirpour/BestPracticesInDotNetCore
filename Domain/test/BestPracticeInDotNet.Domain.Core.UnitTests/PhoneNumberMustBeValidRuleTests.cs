using BestPracticeInDotNet.Domain.Core.Customer.Rules;
using FluentAssertions;
using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Tests;

public class PhoneNumberMustBeValidRuleTests
{
    private IBusinessRule _sut;
    
    // [MethodName]_Should_[Action]_When_[Condition]

    [Fact]
    public void HasValidRule_Should_ReturnsTrue_When_GivenValidPhoneNumber()
    {
        // Assign
        var phoneNumber = "+989910831364";
        _sut = new PhoneNumberMustBeValidRule(phoneNumber);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("09900831364")]
    [InlineData("9900831364")]
    [InlineData("989900831364")]
    public void HasValidRule_Should_ReturnsFalse_When_GivenInValidPhoneNumber(string phoneNumber)
    {
        // Assign
        _sut = new PhoneNumberMustBeValidRule(phoneNumber);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeFalse();
    }
}