using System.Net.Http.Json;
using BestPracticeInDotNet.Presentation.Api.Models.CustomerDto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace BestPracticeInDotNet.Presentation.Api.IntegrationTests;

// ClassName + Tests
public class CustomerControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public CustomerControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    // [method]_Should_[Action]_When_[Condition]
    [Fact]
    public async Task GetCustomers_Should_ReturnsListOfCustomers_When_Calls()
    {
        // Assign
        HttpClient client = _factory.CreateClient();
        
        // Act
        var response = await client.GetAsync("/api/v1/customer");
        var body = await response.Content.ReadAsStringAsync();
        var customer = JsonConvert.DeserializeObject<List<GetCustomerResponse>>(body);
        
        // Assert
        response.EnsureSuccessStatusCode();
        customer.Should().NotBeNull();
    }
    
    [Fact]
    public async Task Create_Should_CreateCustomer_When_GivenValidParameters()
    {
        // Assign
        HttpClient client = _factory.CreateClient();
        var newCustomer = new CreateCustomerDto(
            "Pooya",
            "Alamirpour",
            "2000-01-02",
            "+989910831364",
            "Pooya.Alamirpour@gmail.com",
            "6104000000001111");
        
        // Act
        var newCustomerCreatingResponse = await client.PostAsJsonAsync("/api/v1/customer", newCustomer);
        newCustomerCreatingResponse.EnsureSuccessStatusCode();

        var response = await client.GetAsync("/api/v1/customer?firstname=Pooya");
        var body = await response.Content.ReadAsStringAsync();
        var createdCustomer = JsonConvert.DeserializeObject<List<GetCustomerResponse>>(body);
        
        // Assert
        response.EnsureSuccessStatusCode();
        createdCustomer.Should().NotBeNull();
        createdCustomer?.Count.Should().BeGreaterOrEqualTo(1);
        createdCustomer?.FirstOrDefault()?.Firstname.Should().Be(newCustomer.Firstname);
    }
    
    [Fact]
    public async Task Delete_Should_DeleteCustomer_When_GivenCustomerId()
    {
        // Assign
        HttpClient client = _factory.CreateClient();
        var newCustomer = new CreateCustomerDto(
            "Pooya",
            "Alamirpour",
            "2000-01-02",
            "+989910831364",
            "Pooya.Alamirpour@gmail.com",
            "6104000000001111");
        
        // Act
        var newCustomerCreatingResponse = await client.PostAsJsonAsync($"/api/v1/customer", newCustomer);
        newCustomerCreatingResponse.EnsureSuccessStatusCode();

        var response = await client.GetAsync("/api/v1/customer?firstname=Pooya");
        var body = await response.Content.ReadAsStringAsync();
        var createdCustomer = JsonConvert.DeserializeObject<List<GetCustomerResponse>>(body);

        var customerId = createdCustomer?.FirstOrDefault()?.Id;
        var deleteResponse = await client.DeleteAsync($"/api/v1/customer/{customerId}");
        
        // Assert
        deleteResponse.EnsureSuccessStatusCode();
    }
    
    [Fact]
    public async Task Update_Should_UpdateCustomerPhoneNumber_When_GivenCustomerIdAndPhoneNumber()
    {
        // Assign
        HttpClient client = _factory.CreateClient();
        var newCustomer = new CreateCustomerDto(
            "Pooya",
            "Alamirpour",
            "2000-01-02",
            "+989910831364",
            "Pooya.Alamirpour@gmail.com",
            "6104000000001111");
        
        // Act
        var newCustomerCreatingResponse = await client.PostAsJsonAsync($"/api/v1/customer", newCustomer);
        newCustomerCreatingResponse.EnsureSuccessStatusCode();

        var response = await client.GetAsync("/api/v1/customer?firstname=Pooya");
        var body = await response.Content.ReadAsStringAsync();
        var createdCustomer = JsonConvert.DeserializeObject<List<GetCustomerResponse>>(body);

        var customerId = createdCustomer?.FirstOrDefault()?.Id;

        var updatedCustomer = new UpdateCustomerDto(
            Guid.Parse(customerId.ToString()!), "+989910831000", null);
        
        var updatedResponse = await client.PutAsJsonAsync($"/api/v1/customer/{customerId}", updatedCustomer);
        var updatedBody = await updatedResponse.Content.ReadAsStringAsync();
        
        // Assert
        updatedResponse.EnsureSuccessStatusCode();
    }
}