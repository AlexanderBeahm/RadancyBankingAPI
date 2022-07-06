# RandancyBanking


## How-To Run

First, clone or download this repository.

In the root directory of the repository, run the following command:
```
docker-compose up -d
```

The `-d` is an optional flag to detach from the console when the containers start running, can leave it out if you want to view console output.

After containers are confirmed running, the root API will be hosted at the following URL:

https://localhost:8081/api

To test this is running correctly, you can hit the following health check endpoint.

https://localhost:8081/health

The SwaggerUI page can be accessed at the following URL:

https://localhost:8081/swagger/index.html

Similarly, the swagger.json file can be accessed at the following URL:

https://localhost:8081/swagger/v1/swagger.json

---

## Future Work

Given the small timeframe of this assignment, I made some judgment calls on usual features, standards, and design decisions in order to prove out the concept of this API.

- In most cases, I would have used custom IDBConnector implementation logic. This would be generated at request time and then some form of factory would be injected into the repositories in order to 
obtain it. This allows for better agnostic database design and helps implement session based requests. With time I would implement that DBConnector and move the dictionary logic inside it so that the repository could look more standard.
- The unit tests are currently missing for base service implementations, with more time I would implement unit testing more thouroughly here. For example, for the requests themselves, I would be able to test the basic validation logic being used correctly as well as inject a Mocked repository interface (via Moq) to manipulate the test data. This could simiarly apply to the controller layer as well.
- More documentation always helps, adding discrete examples to the xml documentation on the models and routes makes the user more apparent of functionality when viewing the SwaggerUI.
- Given the current state of API, it can be hit by everyone and of course is in need of some token mechanism, would be easy to add Oauth2 to this given the valid mechanism for generating/validating.
- Currently this is operating under the assumption of a single API version. To solve this, I would implement API versioning using decorators and older-versioned namespaces in order to keep code seperated when functionality changes between code.
- The current check-in process to main currently runs a simple Github Action to build and test the project. While this is a good first step, packaging the containers into a container registry and running them would be the next step.
- My error handling is currently leaves a lot to be desired, better logging and error messaging for various failure points could be vastly improved.
- Domain/Data models could easily be fleshed out with standard ToString, Equals, and Clone implementations.
- As seen in the services layer, I am manually creating objects to map between. In this small scenario, this works out, however it would be better to either use an object mapper like Automapper on that services layer or a layer in-between services and repositories.
- Adding configuration store and settings in the appSettings.json/docker-file to control environment variables more closely. For example, the particulars of business logic validations (90% withdrawal limit) could be a number defined in such configuration.
- In particular to the validation strategy I went down, I think I could enhance it more with some form of builder pattern or more subclasses to handle multiple validation steps.
- Ran into some issues with setting up Swashbuckle that could have been resolved by tinkering with the app building on routes I believe, but for interest of time I have decided to include base routes as part of action definitions.