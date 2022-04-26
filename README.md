# Secret-santa-app
Mini MVC app for random choosing who will be receiving your next gift. (Secret Santa)

### Software development II project - SecretSantaApp

### ASP .NET Core, REST API, Windows forms

Primarily a desktop application where the user can view who his secret santa is. In this case 'user' can be the admin or an employee. Only the admin can generate a secret santa list (random generated list from all of the users), and every employee can log into their account to reviel who their secret santa is. 
The admin can add as many users(employees) per individual request, view all employees, view everyone's secret santa, delete secret santa list(pairs) and generate it again.

Passwords for users are generated with a function GenerateSalt and Hash(); Swagger does not display passwords. 
Application has authentification and authorization implemented, only admin can insert properties. 

This app has basic data enough for testing methods and functions. After running the app in VS, the migration will create the database and the seeder will import data in tables. Make sure to check your connectionstring for sql before starting the app.





#### Desktop application credentials for ADMIN/ADMINISTRATOR:
	Username: admin
	Password: admin

#### Desktop application credentials for UPOSLENIK/WORKER:
	Username: uposlenik 
	Password: uposlenik

#### Desktop application credentials for UPOSLENIK/WORKER:
	Username: belma
	Password: belma
________________________________________________________________________

This project contains 2 interconnected applications:

1.  REST API C# ASP.NET Core application,
2.  Windows forms application

