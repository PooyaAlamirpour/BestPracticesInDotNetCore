# CRUD Code Test 

Please read each note very carefully!
Feel free to add/change project structure to a clean architecture to your view.
and if you are not able to work on FrontEnd project, you can add a Swagger UI
in a new Front project.

Create a simple CRUD application with ASP NET that implements the below model:
```
Customer {
	Firstname
	Lastname
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
## Practices and patterns (Must):

- [TDD](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2022)
- [DDD](https://en.wikipedia.org/wiki/Domain-driven_design)
- [BDD](https://en.wikipedia.org/wiki/Behavior-driven_development)
- [Clean architecture](https://github.com/jasontaylordev/CleanArchitecture)
- [Clean Code](https://en.wikipedia.org/wiki/SonarQube)
- [CQRS](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_query_responsibility_separation) pattern ([Event sourcing](https://en.wikipedia.org/wiki/Domain-driven_design#Event_sourcing)).
- Clean git commits that shows your work progress.

### Validations (Must)

- During Create; validate the phone number to be a valid *mobile* number only (Please use this library [Google LibPhoneNumber](https://github.com/google/libphonenumber) to validate number at the backend).

- A Valid email and a valid bank account number must be checked before submitting the form.

- Customers must be unique in database: By `Firstname`, `Lastname` and `DateOfBirth`.

- Email must be unique in the database.

### Storage (Must)

- Store the phone number in a database with minimized space storage (choose `varchar`/`string`, or `ulong` whichever store less space).

### Generating UserSecretId for JWT
By using the below code, it is possible to be generated a suer secret id which is used
for signing credential by using `HmacSha256` algorithm. So, the first step is initialing
user secret by built-in dot net command:
```
dotnet user-secrets init --project .\Presentation\src\BestPracticesInDotNet.Presentation\
```
Now, assign a value like `super-secret-key-from-user-secrets` as the below:
```
dotnet user-secrets set --project .\Presentation\src\Mc2.CrudTest.Presentation\ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
```
If it is needed to list all generated secrets, use the below command:
```
dotnet user-secrets list --project .\Presentation\src\Mc2.CrudTest.Presentation\
```

### Error Handling
This part is one of essential scenario for preventing to show all occured exceptions.
In the dot net core, there are 3 ways for doing it. 
- Middleware
- Filter attribute
- Global exception handling

In this project, it is used `filter attribute` technique and `problem detail` class.
Also, there are an amazing nuget package that are called `OneOf` and `ErrorOr` that have lovely ways
for handling errors.