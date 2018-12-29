The server-side is targetting __.NET Core v2.2__ and the client - __Angular v7__.
"ECommerce.Api" is the server-side startup project which is compatible with .NET Core 2.2 only.
In order to start the client-side application, you need NodeJS and NPM (I used the LTS versions as of current date - v10.15 and v6.5, respectively).
I've developed and tested it on Windows 10 machine, only, so I am not sure if the application will misbehave on macOS or Linux.

There are several environments, please use the default (development) ones.

_Brief overview:_
* I've used Swagger in order to document the web API
* I am using in-memory Entity framework for storage
* Clean architecture based approach. Business logic and contracts are located in the Core project.
* Database, external system's logic and implementations are located in the Infrastructure project.


_What I didn't do but wish I did:_
* Write tests
* Error handling
* ode documentation
* Fancy UI
