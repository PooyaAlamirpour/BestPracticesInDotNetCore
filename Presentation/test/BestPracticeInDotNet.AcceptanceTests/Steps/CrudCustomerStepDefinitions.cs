using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using BestPracticeInDotNet.AcceptanceTests.Convertors;
using BestPracticeInDotNet.AcceptanceTests.Extensions;
using BestPracticeInDotNet.AcceptanceTests.Repositories;
using BestPracticeInDotNet.Application.Command.Repositories;
using BestPracticeInDotNet.Domain.Core.Customer;
using BestPracticeInDotNet.Domain.Core.Events;
using BestPracticeInDotNet.Presentation.Server;
using BestPracticeInDotNet.Presentation.Server.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BestPracticeInDotNet.AcceptanceTests.Steps;

[Binding]
public sealed class CrudCustomerStepDefinitions
{
    private const string BaseAddress = "http://localhost:8080/api/v1/";

    private readonly ScenarioContext _scenarioContext;
    private ICustomerWriteRepository CustomerWriteRepository { get; }
    private WebApplicationFactory<Program> Factory { get; }
    private JsonFilesRepository JsonFilesRepository { get; }
    private HttpResponseMessage Response { get; set; } = null!;

    JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        Converters = { new DateOnlyJsonConverter() },
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
    };
    
    public HttpClient Client { get; set; } = null!;

    public CrudCustomerStepDefinitions(ScenarioContext scenarioContext, WebApplicationFactory<Program> factory, 
        JsonFilesRepository jsonFilesRepository, ICustomerWriteRepository customerWriteRepository)
    {
        _scenarioContext = scenarioContext;
        Factory = factory;
        JsonFilesRepository = jsonFilesRepository;
        CustomerWriteRepository = customerWriteRepository;
    }


    [Given(@"I am a client")]
    public void GivenIAmAClient()
    {
        Client = Factory.CreateDefaultClient(new Uri(BaseAddress));
    }

    [Given(@"the repository has customer data")]
    public async Task GivenTheRepositoryHasCustomersData()
    {
        var customersJson = JsonFilesRepository.Files["customer.json"];
        var customers = JsonSerializer.Deserialize<IList<CustomerCreatedDomainEvent>>(customersJson, JsonSerializerOptions);
        if (customers != null)
        {
            foreach (var customer in customers)
            {
                CustomerWriteRepository.Add(CustomerAggregateRoot.Create(customer.Firstname, customer.Lastname, 
                    customer.DateOfBirth.ToString(), customer.PhoneNumber, customer.Email, customer.BankAccountNumber));
            }

            await CustomerWriteRepository.CommitAsync();
        }
    }

    [When(@"I make a GET request to '(.*)'")]
    public async Task WhenIMakeAgetRequestTo(string endpoint)
    {
        Response = await Client.GetAsync(endpoint);
    }

    [Then(@"the response status code should be '(.*)'")]
    public void ThenTheResponseStatusCodeIs(int statusCode)
    {
        var expected = (HttpStatusCode)statusCode;
        Response.StatusCode.Should().Be(expected);
    }

    [Then(@"the response json should be '(.*)'")]
    public async Task ThenTheResponseJsonShouldBe(string file)
    {
        var expected = JsonFilesRepository.Files[file];
        var response = await Response.Content.ReadAsStringAsync();
        var actual = response.ParseJson();
        
        var actualCustomer = JsonSerializer.Deserialize<IList<CustomerCreatedDomainEvent>>(actual, JsonSerializerOptions);
        var expectedCustomer = JsonSerializer.Deserialize<IList<CustomerCreatedDomainEvent>>(expected, JsonSerializerOptions);

        var singleActualCustomer = actualCustomer?.FirstOrDefault();
        var singleExpectedCustomer = expectedCustomer?.FirstOrDefault();
        
        singleActualCustomer?.Firstname.Should().Be(singleExpectedCustomer?.Firstname);
        singleActualCustomer?.Lastname.Should().Be(singleExpectedCustomer?.Lastname);
        singleActualCustomer?.Email.Should().Be(singleExpectedCustomer?.Email);
        singleActualCustomer?.PhoneNumber.Should().Be(singleExpectedCustomer?.PhoneNumber);
        singleActualCustomer?.BankAccountNumber.Should().Be(singleExpectedCustomer?.BankAccountNumber);
    }

    [When(@"I make a GET request with email '(.*)' to '(.*)' api")]
    public async Task WhenIMakeAgetRequestWithEmailToApi(string email, string endpoint)
    {
        Response = await Client.GetAsync($"{endpoint}?email={email}");
    }

    [When(@"I make a POST request with '(.*)' to '(.*)' api")]
    public async Task WhenIMakeApostRequestWithToApi(string file, string endpoint)
    {
        var jsonList = JsonFilesRepository.Files[file];
        JArray jArray = JArray.Parse(jsonList);

        if (jArray.Count == 1)
        {
            JObject singleObject = (JObject)jArray[0];
            string singleJson = singleObject.ToString();
            var content = new StringContent(singleJson, Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = await Client.PostAsync(endpoint, content);
        }
    }

    [Then(@"the customer should be created successfully from '(.*)'")]
    public async Task ThenTheCustomerShouldBeCreatedSuccessfully(string endpoint)
    {
        Response = await Client.GetAsync(endpoint);
        var response = await Response.Content.ReadAsStringAsync();
        var actual = response.ParseJson();
        
        var actualCustomer = JsonSerializer.Deserialize<IList<CustomerCreatedDomainEvent>>(actual, JsonSerializerOptions);
        actualCustomer?.Count.Should().Be(1);
    }

    [When(@"I make a PUT request for changing phone number to '(.*)' to '(.*)'")]
    public async Task WhenIMakeAputRequestWithTo(string phoneNumber, string endpoint)
    {
        Response = await Client.GetAsync(endpoint);
        var response = await Response.Content.ReadAsStringAsync();
        JArray jsonArray = JArray.Parse(response);
        string id = jsonArray[0]["id"]?.ToString()!;

        UpdateCustomerDto updatedPhoneNumber = new(Guid.Parse(id), phoneNumber, null);
        var updatedJson = JsonConvert.SerializeObject(updatedPhoneNumber);
        
        var content = new StringContent(updatedJson, Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = await Client.PutAsync($"{endpoint}/{id}", content);
    }

    [Then(@"the phone number should be updated into '(.*)' by checking get '(.*)' endpoint")]
    public async Task ThenThePhoneNumberShouldBeUpdated(string phoneNumber, string endpoint)
    {
        Thread.Sleep(5000);
        Response = await Client.GetAsync(endpoint);
        var response = await Response.Content.ReadAsStringAsync();
        var customer = JsonSerializer.Deserialize<IList<CustomerCreatedDomainEvent>>(response, JsonSerializerOptions);
        customer?.Count.Should().Be(1);
        customer?.FirstOrDefault()?.PhoneNumber.Should().Be(phoneNumber);
    }

    [When(@"I make a DELETE request for created customer to '(.*)'")]
    public async Task WhenIMakeAdeleteRequestForCreatedCustomerTo(string endpoint)
    {
        Response = await Client.GetAsync(endpoint);
        var response = await Response.Content.ReadAsStringAsync();
        JArray jsonArray = JArray.Parse(response);
        string id = jsonArray[0]["id"]?.ToString()!;
        Response = await Client.DeleteAsync($"{endpoint}/{id}");
    }
}