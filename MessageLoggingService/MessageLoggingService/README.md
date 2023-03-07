# message-logging-service

Its a message logging service where we can add messages to an interal log object.
A background job runs in the backend every 1 minute by default and deletes messages older than max size (60s is the default).

The definition of restful service API can be viewed in swagger after hosting the service locally at
https://localhost:7208/swagger/index.html

Steps to execute the service:

Preqequisites:  Need to have .Net 6.0 runtime installed in the computer.

Steps:

1. Have the project code ready at the location locally.
2. You can run it using visual studio . If not available, you can also execute using command line prompt.
3.Open the command prompt, and go the folder where the project file (.csproj) is located.
4.Type -dotnet build
5. Type -dotnet run <Time Interval Parameter>
5.The service is running locally at
https://localhost:7208/

Swagger link : https://localhost:7208/swagger/index.html