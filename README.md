<h1 align="right">
  <img alt="Project's logo" src="" width="200px" align="left" />
  Intern Task Tracker
</h1>

<p align="right">
  ✅ Tracking your activities as an intern
  <br /><br />
</p>

## 👀 Overview

<div>
  <img alt="" src="" width="" />
</div>
<br/>

## 📖 About

## 🧱 This project was built with:

- [.NET 6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)
- [SQLite](https://www.sqlite.org/index.html)
- [Entity Framework Core](https://github.com/dotnet/efcore)

## 🚶‍♂️ Installing and Running

1.  Clone this repository `git clone https://github.com/pferreirafabricio/intern-task-tracker.git`
2.  Enter in the project's folder: `cd intern-task-tracker`
3.  Run `dotnet restore`
4.  Guarantee that you have ef core installed globally `dotnet tool install --global dotnet-ef`
> If you are using Linux, maybe you will need to add the dotnet-ef to your path.
> Something like this:
> ```bash
> sudo nano .bashrc # or .zshrc
> # Append this to the bottom of the file
> export PATH="$PATH:$HOME/.dotnet/tools/"
> ```
6.  If this is your first time running the project execute `./migration-helper.ps1` and select the option "3. Update Database"
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

## :recycle: Contribute

1.  Fork this repository
2.  Create a branch with your feature: `git checkout -b my-feature`
3.  Commit your changes: `git commit -m 'feat: My new feature'`
4.  Push your branch: `git push origin my-feature`

## :page_with_curl: License

This project is under the MIT license. Take a look at the [LICENSE](LICENSE) file for more details.

## 📚 Learn more

- [Build a minimal API with .NET 6](https://microsoft.github.io/workshop-library/full/intro-minapi/)
- [Tutorial: Create a minimal API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio)
