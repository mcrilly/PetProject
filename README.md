# PetProjectWeb

This project was generated with Visual Studio 2017 & [Angular CLI](https://github.com/angular/angular-cli) version 6.1.5.

I could have addressed the requirements in a number of ways - a console app or mvc application. I decided in the end to create a solution using web api and Angular - this seems like a similar solution would more closely match to the needs of the business for the migration of an existing .net application to azure.

My approach with this project was to use c# .net core 2.1 for the web api backend, and using Angular 6 for the front end.

This solution could also be adapted to a microservices architecture by splitting the backend and frontend code into separate applications.

As this is only a prototype, I have not included logging or error handling - though this would obviously be included in a production solution.

## Build

Run `ng build` in the ~\src folder to build the angular project. The build artifacts will be stored in the `wwwroot` directory. Use the `--prod` flag for a production build.
Run `dotnet run`in the ~\PetProject folder to launch the hosting environment.
You should then be able to browse to: https://localhost:5001 or  http://localhost:5000 to view the site.


## Other information

mcrilly_gmail.com
