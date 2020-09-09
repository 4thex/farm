# Farm

The Farm is a solution that enable you to farm out a task to several other computers and therefore achieving better performance.

## Communication

### Task
The agent will make a request to the main service asking for something to do. This request will remain unanswered until the main service has a task for the agent or a response is sent indicating that there is nothing to do at this time and to check back later.

The agent will ask for a task by sending a GET request to the endpoint:
```
/api/v1/tasks
```
The response to indicate a task will look like this for instance:
```
{
    "id": "f0f6c15d-71ba-4e91-9b38-f6ac7738d28a",
    "response": "Perform",
    "action": {
        "type": "Farm.Api.Tasks.Addition, Farm.Api.Tasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7f709c5b713576e1",
        "method": "Execute",
        "arguments": [
            1, 2
        ]
    } 
}
```
This response tells the agent from the "response" property to perform the indicated action. The agent will in this case call the public static "Execute" method of the "Addition" call with the arguments 1, and 2.  
The result of executing the method will be sent to the main service in a new POST request to the endpoint:
```
/api/v1/tasks/{id}/perform
```
The {id} path argument is the "id" property from the previous response.  
The request body will contain the result like this:
```
{
    "result": 3
}
```
If the main service did not have a task for the agent, it will send the following response:
```
{
    "id": "65685b87-d13a-4899-bef7-668ce21b1b56",
    "response": "Desist"
}
```
The agent will then immediately send a new GET request to the tasks endpoint.

### Type resolution
So the agent does not necessarily have the type that it is asked to perform. If that is the case, the agent will ask for the type from the main service. We will utilize the [AppDomain.TypeResolve](https://docs.microsoft.com/en-us/dotnet/api/system.appdomain.typeresolve?view=netcore-3.1) event. 