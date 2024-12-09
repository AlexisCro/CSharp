# .NET 
## Commands
- create a new project
`dotnet new <pattern> -n <project name> -o <directory name>`
  - `-o` for output, create a directory where all files will be put

- Launch a .NET program
`dotnet run`

## Files
**mvc.csproj** is the project ID, equal to package.json

**program.cs** is the entry point. 

## Namespace
To ease the reusse of code, we create as many files as we need of class. 

Namespace permit to create virtual container to ease the import and export the source code.

Inside of it, we'll store classes. 

### Naming
`namespace <project name>.<repertory class name>`

## Fields or properties
Properties are fields with getter and setter. 

By convention we prefer to use field for private data. 

## Methods
```cs
public IActionResult Index()
{
  return View();
}
```

- public : define the portabilty
- type of method return `IActionResult` (Interface)
- name of method, in controller it's named an action. 


## Interface
Permit to create 