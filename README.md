# _Dr. SillyStringz Factory_

#### By _**Sierra Rhodes**_

#### _A simple applicaation that allows a user to create engineers and machines and assign one to the other. _

## Technologies Used

* _ASP.Net_
* _c#_
* _HTML_
* _MySQL_

## Description

_This simple application allows users to create, edit, delete, and look at details of the engineers. You can assign an engineer to multiple machines. You can also create, delete, and look at the details of the machines as well as assign them to engineers._

## Setup/Installation Requirements

* _Install .NET 6_
* _clone the repository_
* _Navigate to 'Factory.Solution' directory in your terminal_
* _Open the project in any text editor/ VSCode preferably_
* _if you have not done so already create a .gitignore file_
* _Add bin, obj, and appsettings.json to the file_
* _Commit changes to your respository_
* _Create a new file called appsettings.json_
* _Add the following code to the appsettings.json file you created:
{ "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=[NAME-YOU-WANT-FOR-YOUR-DATABASE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];" } }
_
* _To add a migration naviate to Factory.Solution in your command line_
* _Navigate to Factory_
* _Run dotnet build_
* _Run the command "dotnet tool install --global dotnet-ef --version 6.0.0_
* _Run the command "dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0"_
* _Run the command "dotnet ef migrations add Initial"_
* _Run "dotnet ef database update" in your command line._
* _Lastly, run dotnet watch run_

## Known Bugs

* _None_


## License

Copyright 2023 Sierra Rhodes 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._
