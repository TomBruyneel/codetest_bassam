# Code test Bassam Zahra

## Abstract

We want to create an application that keeps track of the modes of transport that a company's employees use to commute to work daily. The solution will include:

- Data project: defines the data structure
- Domain project: business logic implementations
- WebApplication project: includes the web API's

There are two possible approaches, either use a RESTFul API or use graphql, you are free to make this choice.

The application should have endpoints to add, update and fetch the employees and a method to add a new mode of transport to an employee with two parameters (Date and mode of transport). 
For each employee we want to be able to get a list of all the transport modes they used between two dates.
Lastly we want to be able to get a complete overview of all transport modes used by all employees ordered by the amount of times they were chosen.

## Data project

Use entity framework core to define two entities:

- Employee
- DailyCommute

The employee type has at least the following fields:
- Id
- FirstName
- LastName
- CreatedAt
- UpdatedAt
- Email
- Default commute type

There is 1-n relationship between the Employee type and the DailyCommute type with DailyCommute having following fields:
- Id
- DateOfCommute
- CreatedAt
- UpdatedAt
- Commute type

Commute type can be one of following (Bike, Car, CarpoolDriver, CarpoolPassenger, PublicTransport, Train, Walking).

Either use a real database or the in memory implementation of entity framework.

## Domain project

The domain project depends on the data project and forms a service layer between the data layer and the web application. Use Dependency injection to inject the datacontext into the domain.

## Validation

The employee has the following validation rules:

- Firstname and lastname are required and should contain a maximum of 64 characters
- Email should be a valid email of maximum 64 characters

It is only possible to add new transport modes for an employee if the date of the transport mode is maximum a week ago.

## Web application project

Implement an API as described above.

## Optional

- If using a RESTFul API, document it using the OpenAPI specification.
- Write some unit tests testing the domain layer
