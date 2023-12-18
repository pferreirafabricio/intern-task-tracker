<h1 align="right">
  <img alt="Project's logo" src="https://github.com/pferreirafabricio/intern-task-tracker/assets/42717522/fc06f417-9dd0-45de-9b7b-bf0fdf4ee723" width="140px" align="left" />
  Intern Task Tracker
</h1>

<p align="right">
  ✅ Tracking your activities as an intern
  <br />
</p>
<br/>

## 👀 Overview

<div>
  <img src="https://github.com/pferreirafabricio/intern-task-tracker/assets/42717522/679b5809-5a2c-4237-be5d-9489f5e2be9e" />
  <img src="https://github.com/pferreirafabricio/intern-task-tracker/assets/42717522/472b4c94-f0d3-43d2-80ae-cdfd5cf1e003" />
</div>

## 📖 About

Intern Task Tracker is an application designed to enhance the tracking of intern activities within an organization. Leveraging .NET 6, SQLite, and Entity Framework Core, the project provides a platform for efficient management and monitoring of intern tasks.

## 🧱 This project was built with:

- [.NET 6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)
- [SQLite](https://www.sqlite.org/index.html)
- [Entity Framework Core](https://github.com/dotnet/efcore)

## 🚶‍♂️ Installing and Running

1.  Clone this repository `git clone https://github.com/pferreirafabricio/intern-task-tracker.git`
2.  Enter in the project's folder: `cd intern-task-tracker`
3.  Run `dotnet restore`
> If you haven't downloaded .NET yet you can follow this tutorial [Install .NET on Windows, Linux, and macOS](https://learn.microsoft.com/en-us/dotnet/core/install/)
4.  Guarantee that you have Entity Framework Core installed globally `dotnet tool install --global dotnet-ef`
> If you are using Linux, maybe you will need to add the dotnet-ef to your path.
> Like this:
> ```bash
> sudo nano .bashrc # or sudo nano .zshrc
> # Append this to the bottom of the file
> export PATH="$PATH:$HOME/.dotnet/tools/"
> ```
6.  If this is your first time running the project execute `./migration-helper.ps1` and select the option `3. Update Database`
> If you are using Linux, you can run the script using the PowerShell Core. [Install PowerShell on Linux](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-linux?view=powershell-7.4)
7.  Run the API with
```bash
cd InternTaskTracker.Api
dotnet run
```
8.  Run the console app with
```bash
cd InternTaskTracker.Console
dotnet run
```

## ♻ Contribute

1.  Fork this repository
2.  Create a branch with your feature: `git checkout -b my-feature`
3.  Commit your changes: `git commit -m 'feat: My new feature'`
4.  Push your branch: `git push origin my-feature`

## :page_with_curl: License

This project is under the MIT license. Take a look at the [LICENSE](LICENSE) file for more details.

## 📚 Learn more

- [Build a minimal API with .NET 6](https://microsoft.github.io/workshop-library/full/intro-minapi/)
- [Tutorial: Create a minimal API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio)
