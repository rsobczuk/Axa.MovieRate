# Axa.MovieRate
Movie Rate Application for AXA

1. Application requires .NET Core 3.1
2. To use it properly there will be needed MSSQL database created and username/password for database
3. Set proper database connection string in appsettings.json
4. To create table please run update-database in console. Migration has been defined;
5. Please setup MovieApiUrl in appsettings.json file.
6. I have added 3 unit tests methods. One tests simple string formatting and another one tests database operations (counting etc);


TODO:
Use ActionFilter or whatever (even build in into .NET DataAnnotations) for validation that voting value is between 1 and 10.
