Feature: Customer Manager
	As a cline I wish to be able to Create, Update, Delete customer and list all customers
	
Scenario: Get customers
	Given I am a client
	And the repository has customer data
	When I make a GET request to 'customer'
	Then the response status code should be '200'
	And the response json should be 'customer.json'

Scenario: Get customer by email
	Given I am a client
	And the repository has customer data
	When I make a GET request with email 'Pooya.Alamirpour@gmail.com' to 'customer' api
	Then the response status code should be '200'
	And the response json should be 'customer.json'

Scenario: Add customer
	Given I am a client
	When I make a POST request with 'customer.json' to 'customer' api
	Then the response status code should be '201'
	And the customer should be created successfully from 'customer'

Scenario: Update customer phone number
	Given I am a client
	When I make a POST request with 'customer.json' to 'customer' api
	Then the response status code should be '201'
	When I make a PUT request for changing phone number to '+989910831000' to 'customer'
	Then the response status code should be '200'
	And the phone number should be updated into '+989910831000' by checking get 'customer' endpoint
	
Scenario: Remove customer
	Given I am a client
	When I make a POST request with 'customer.json' to 'customer' api
	Then the response status code should be '201'
	When I make a DELETE request for created customer to 'customer'
	Then the response status code should be '204'