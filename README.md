# BlazorSozluk

BlazorSozluk is an open-source project by [TechBuddyTR](https://github.com/TechBuddyTR) inspired by Ekşi Sözlük, implemented using .NET technologies and modern web frameworks. The project aims to provide a functional, scalable, and modular dictionary/forum-like platform with interactive user-generated entries, voting, favorites, and user management features.

## Table of Contents

- [Features](#features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Dictionary/Forum Platform**: Users can create entries, comment, vote, and favorite content.
- **Blazor WebAssembly Client**: Rich, responsive web UI built with Blazor.
- **.NET API Backend**: RESTful API with ASP.NET Core.
- **Authentication & Authorization**: Token-based authentication, login/logout, and user management.
- **Microservices Projections**: Background services for handling votes, favorites, and user events.
- **Search & Navigation**: Entry search, main page refresh, and topic navigation.
- **Modular Architecture**: Separation of concerns via API, client, and projections.

---

## Project Structure

```
src/
├── Api/
│   └── WebApi/              # ASP.NET Core Web API
│   └── Core/                # Application logic, queries, commands
├── Clients/
│   └── BlazorWeb/           # Blazor WebAssembly client
├── Projections/
│   └── VoteService/         # Background worker for votes
│   └── User/                # Background worker for user events
│   └── FavoriteService/     # Background worker for favorites
```

---

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (for client-side assets)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or compatible database)

### Running the Application

1. **Clone the repository:**

   ```bash
   git clone https://github.com/TechBuddyTR/youtube_BlazorSozluk.git
   cd youtube_BlazorSozluk
   ```

2. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

3. **Build and run the API:**

   ```bash
   cd src/Api/WebApi/BlazorSozluk.Api.WebApi
   dotnet run
   ```

4. **Build and run the Blazor client:**

   ```bash
   cd src/Clients/BlazorWeb/BlazorSozluk.WebApp
   dotnet run
   ```

5. **Background Services (optional, for vote/favorite/user projections):**

   Run each projection as a background worker via:

   ```bash
   cd src/Projections/BlazorSozluk.Projections.VoteService
   dotnet run
   ```

---

## Technologies Used

- **C# / .NET 7**: Backend and microservices
- **Blazor WebAssembly**: Rich client-side UI
- **ASP.NET Core**: Web API
- **Entity Framework Core**: Data access
- **MediatR**: CQRS pattern for queries and commands
- **FluentValidation**: API input validation
- **RabbitMQ**: Event-driven projections (background services)
- **Swagger**: API documentation (see `/swagger` endpoint)
- **Blazored.LocalStorage**: Local storage in Blazor client

---

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

---

## License

This repository currently does not specify a license. Please contact the repository owner for usage terms.

---

## Acknowledgements

- Inspired by Ekşi Sözlük and similar dictionary/forum platforms.
- Uses [Open Iconic v1.1.1](http://useiconic.com/open) for UI icons.

---

## Contact

For more information, visit [TechBuddyTR](https://github.com/TechBuddyTR).
