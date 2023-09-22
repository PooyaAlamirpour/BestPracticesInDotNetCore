# CRUD Code Test 

In this repository, it is supposed to be implemented techniques and tools that would be 
categorized as `Best Preactice`. Feel free to add anything that you think would be helpful
for other dot net developer and send me pull request. I appreciate you for joining us
for this journey.

In the below sections, all architecture, tools, pattern and anything that were implemented are listed.
## Practices and patterns:

- [TDD](https://docs.microsoft.com/en-us/visualstudio/test/quick-start-test-driven-development-with-test-explorer?view=vs-2022)
- [DDD](https://en.wikipedia.org/wiki/Domain-driven_design)
- [BDD](https://en.wikipedia.org/wiki/Behavior-driven_development)
- [Clean architecture](https://github.com/jasontaylordev/CleanArchitecture)
- [Clean Code](https://en.wikipedia.org/wiki/SonarQube)
- [CQRS](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation#Command_query_responsibility_separation) pattern ([Event sourcing](https://en.wikipedia.org/wiki/Domain-driven_design#Event_sourcing)).
- Clean git commits that shows your work progress.

### Validations
It is used `FLuentValidation` for validating each request that comes from client.
- During Create; validate the phone number to be a valid *mobile* number only (It is used this library [Google LibPhoneNumber](https://github.com/google/libphonenumber) to validate number at the backend).
- A Valid email and a valid bank account number must be checked.
- Customers must be unique in database: By `Firstname`, `Lastname` and `DateOfBirth`.
- Email must be unique in the database.


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