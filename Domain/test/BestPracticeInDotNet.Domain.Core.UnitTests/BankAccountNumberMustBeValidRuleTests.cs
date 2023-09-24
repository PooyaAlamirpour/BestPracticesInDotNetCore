using BestPracticeInDotNet.Domain.Core.DomainModels.Customer.Rules;
using BestPracticeInDotNet.framework.DDD.Abstracts;
using FluentAssertions;

namespace BestPracticeInDotNet.Domain.Core.Tests;

public class BankAccountNumberMustBeValidRuleTests
{
    private IBusinessRule _sut;
    
    // [MethodName]_Should_[Action]_When_[Condition]

    [Fact]
    public void HasValidRule_Should_ReturnsTrue_When_GivenValidBankAccountNumber()
    {
        // Assign
        var bankAccountNumber = "6104000000001111";
        _sut = new BankAccountNumberMustBeValidRule(bankAccountNumber);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("6104-0000-0000-1111")]
    [InlineData("61040000000011110")]
    [InlineData("123456")]
    public void HasValidRule_Should_ReturnsFalse_When_GivenInvalidBankAccountNumber(string bankAccountNumber)
    {
        // Assign
        _sut = new BankAccountNumberMustBeValidRule(bankAccountNumber);
        
        // Act
        var response = _sut.HasValidRule();

        // Assert
        response.Should().BeFalse();
    }
}