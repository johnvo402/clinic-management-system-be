# Clinic Management System Backend 🚀

The **Clinic Management System Backend** (CMS_BE) is a system built with **.NET 8** to streamline clinic operations, including user authentication, patient management, visit tracking, and drug inventory management. It integrates seamlessly with a frontend (e.g., Next.js) and supports features like secure authentication, patient records, and visit scheduling. The architecture is modular, leveraging **CQRS**, **MediatR**, and **Entity Framework Core** for robust data handling and scalability. 🛠️

## Table of Contents

- [Features](#features-✨)
- [Prerequisites](#prerequisites-📋)
- [Setup for Windows](#setup-for-windows-🪟)
- [Installation](#installation-🛠️)
- [Available Scripts (via Makefile)](#available-scripts-via-makefile-📜)
- [Project Structure](#project-structure-📂)
- [Technologies](#technologies-🛠️)
- [Deployment](#deployment-🚀)
- [Database Migrations](#database-migrations-🗄️)
- [Backup and Restore](#backup-and-restore-💾)
- [Testing](#testing-🧪)
- [Basic Usage](#basic-usage-🚀)
  - [Step-by-Step Run](#step-by-step-run)
  - [Filtering](#filtering-📊)
- [Contributing](#contributing-🤝)
- [License](#license-📜)

## Features ✨

- **Authentication** 🔒: Secure user authentication with JWT-based login, refresh tokens, and role-based authorization (`Role.cs`, `AuthorizeByAttribute.cs`).
- **Patient Management** 🩺: Create, update, delete, and query patient records with detailed contact information (`Patient.cs`, `Contact.cs`).
- **Visit Tracking** 📅: Manage patient visits, including prescriptions and visit details (`Visit.cs`, `Prescription.cs`).
- **Drug Inventory** 💊: Manage drug inventory with validation and mappings (`Drug.cs`, `CreateDrugCommand.cs`).
- **CQRS Architecture** 📨: Implements Command Query Responsibility Segregation using MediatR for commands and queries (e.g., `CreatePatientCommand.cs`, `ListPatientQuery.cs`).
- **Internationalization** 🌍: Supports multilingual error messages and responses.
- **Database Management** 🗄️: Uses **PostgreSQL** with migrations for schema management (`TheDbContext.cs`, `20250907100309_20250907170305_Migration.cs`).
- **API Response Handling** 📡: Standardized API responses with error handling (`ApiResponse.cs`, `ErrorDetails.cs`).
- **Query Filtering** 📊: Advanced query string processing with LHS Brackets for filtering, sorting, and pagination (`QueryParamRequest.cs`, `FilterExtension.cs`).
- **Background Jobs** ⏰: Supports background tasks for asynchronous processing.
- **Testing** 🧪: Includes unit and integration tests for robust validation (`CMS_BE.Application` tests).
- **Monitoring & Logging** 📜: Structured logging and performance tracking (`SerilogExtension.cs`, `PerformanceBehavior.cs`).

## Prerequisites 📋

Ensure the following are installed:

- **.NET 8 SDK** 🖥️: Required for building and running the application.
- **Docker** 🐳: For containerized deployment and services (PostgreSQL).
- **PostgreSQL** 🐘: Database for the application.
- **make** ⚙️: To run commands defined in the `Makefile` (see Windows setup below).
- **Git** 📚: For version control.

## Setup for Windows 🪟

To run `Makefile` commands on Windows, install **MSYS2** for a Unix-like environment.

1. **Download and Install MSYS2**:
   - Get the installer from [https://www.msys2.org/](https://www.msys2.org/).
   - Follow the installation instructions.
2. **Install Required Packages**:
   - Open the MSYS2 terminal (`MSYS2 MSYS` from the Start menu).
   - Install `make`:
     ```bash
     pacman -S --needed make
     ```
3. **Add MSYS2 to PATH**:
   - Add `C:\msys64\usr\bin` to the system `PATH` environment variable:
     - Go to **Control Panel** > **System and Security** > **System** > **Advanced system settings** > **Environment Variables**.
     - Edit the `PATH` variable under **System Variables**.
   - Verify installation:
     ```bash
     make --version
     ```

## Installation 🛠️

1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd clinic-management-system-be
   ```
2. **Set Up Environment Variables**:
   - Copy `.env.example` to `.env` and configure variables (e.g., database connections, JWT settings).
     ```bash
     cp .env.example .env
     ```
3. **Install Dependencies**:
   ```bash
   dotnet restore CMS_BE.sln
   ```
4. **Run Database Migrations**:
   ```bash
   make migration
   ```

## Available Scripts (via Makefile) 📜

The `Makefile` provides the following commands:

- **🔄 `make migration`**: Runs database migrations using the `run_migration.sh` script.
  ```bash
  make migration
  ```
- **🔄 `make update`**: Updates database migrations.
  ```bash
  make update
  ```
- **📊 `make status`**: Checks migration status.
  ```bash
  make status
  ```
- **🚀 `make dev`**: Starts Docker containers for development (PostgreSQL, application).
  ```bash
  make dev
  ```
- **🛠️ `make dev-build`**: Builds and starts Docker containers for development.
  ```bash
  make dev-build
  ```
- **🌐 `make staging`**: Builds and starts Docker containers for staging.
  ```bash
  make staging
  ```
- **🧹 `make clean`**: Stops Docker containers and removes volumes.
  ```bash
  make clean
  ```
- **🛑 `make down`**: Stops Docker containers without removing volumes.
  ```bash
  make down
  ```
- **⏹️ `make stop`**: Stops Docker containers.
  ```bash
  make stop
  ```
- **💾 `make backup`**: Backs up the database using `pgdump.sh`.
  ```bash
  make backup
  ```
- **🔄 `make restore`**: Restores the database from a backup.
  ```bash
  make restore
  ```
- **📦 `make publish`**: Publishes the application using `publish.sh`.
  ```bash
  make publish
  ```
- **📖 `make help`**: Displays available Makefile commands.
  ```bash
  make help
  ```
- **🧪 `make test [TYPE=<type>] [NAME=<test-name>]`**: Runs unit and integration tests. Optionally specify `TYPE` (e.g., `UnitTest`, `IntegrationTest`) and `NAME` (e.g., `LoginHandlerTest`).
  ```bash
  make test
  make test TYPE="IntegrationTest" NAME="LoginHandlerTest"
  ```

## Project Structure 📂

The backend is organized into a modular structure with separate layers for application logic, domain models, infrastructure, and presentation:

```
clinic-management-system-be/
├── 📁 scripts/ # Utility scripts for migrations, backups, and publishing
│   ├── 📁 docker-entrypoint-initdb.d/ # Database initialization scripts
│   │   └── 📜 000_createdb.sql
│   ├── 📜 pgdump.sh # Database backup script
│   ├── 📜 publish.sh # Application publishing script
│   └── 📜 run_migration.sh # Migration execution script
├── 📁 src/ # Source code for the application
│   ├── 📁 CMS_BE.Application/ # Application logic with CQRS and MediatR
│   │   ├── 📁 ApiWrapper/ # API response and error handling
│   │   ├── 📁 Common/ # Shared utilities, auth, and query processing
│   │   ├── 📁 Errors/ # Custom error classes (e.g., BadRequestError.cs)
│   │   ├── 📁 Features/ # Feature-specific commands and queries
│   │   │   ├── 📁 Auth/ # Authentication commands (e.g., LoginCommand.cs)
│   │   │   ├── 📁 Humans/ # Patient and visit management
│   │   │   └── 📁 Materials/ # Drug inventory management
│   │   ├── 📁 Guards/ # Expression validation utilities
│   │   ├── 📁 Routers/ # API routing logic
│   │   ├── 📜 CMS_BE.Application.csproj
│   │   └── 📜 DependencyInjection.cs
│   ├── 📁 CMS_BE.Domain/ # Domain models and specifications
│   │   ├── 📁 Aggregates/ # Entities and enums (e.g., Patient.cs, Role.cs)
│   │   ├── 📁 Common/ # Base entities and interfaces
│   │   ├── 📁 Specifications/ # Query specifications and builders
│   │   ├── 📜 CMS_BE.Domain.csproj
│   │   └── 📜 Extensions/
│   ├── 📁 CMS_BE.Infrastructure/ # Database and service implementations
│   │   ├── 📁 Common/ # Shared services (e.g., AuthService.cs)
│   │   ├── 📁 Data/ # Database context, migrations, and configurations
│   │   ├── 📜 CMS_BE.Infrastructure.csproj
│   │   └── 📜 DependencyInjection.cs
│   ├── 📁 CMS_BE.Presentation/ # API endpoints and middleware
│   │   ├── 📁 Converters/ # Date and time conversion utilities
│   │   ├── 📁 Endpoints/ # API endpoints (e.g., LoginEndpoint.cs)
│   │   ├── 📁 Extensions/ # Middleware and configuration extensions
│   │   ├── 📁 Middlewares/ # Custom middleware (e.g., AccountMiddleware.cs)
│   │   ├── 📁 Settings/ # OpenAPI settings
│   │   ├── 📜 appsettings.Development.json
│   │   ├── 📜 CMS_BE.Presentation.csproj
│   │   └── 📜 Program.cs
├── 📁 .github/ # CI/CD and documentation
│   └── 📁 instructions/
│       └── 📜 docs-requiment.instructions.md
├── 📁 .pgdump/ # Database backup dumps
├── 📜 CMS_BE.sln # Solution file
├── 📜 Directory.Packages.props # Package management
├── 📜 docker-compose.dev.yaml
├── 📜 docker-compose.staging.yaml
├── 📜 docker-compose.yaml
├── 📜 Dockerfile
├── 📜 Makefile
├── 📜 .env.example # Example environment variables
├── 📜 .dockerignore # Docker ignore file
├── 📜 .gitignore # Git ignore file
├── 📜 LICENSE # MIT License
└── 📜 README.md # Project documentation
```

## Technologies 🛠️

- **.NET 8** ⚙️: Core framework for the application.
- **Entity Framework Core** 🗃️: ORM for database operations with PostgreSQL (`TheDbContext.cs`).
- **MediatR** 📨: Implements CQRS pattern (`LoginHandler.cs`, `CreatePatientHandler.cs`).
- **JWT Authentication** 🔒: Secure token-based authentication (`JwtSettings.cs`, `TokenSecurityService.cs`).
- **Serilog** 📜: Structured logging (`SerilogExtension.cs`).
- **Docker** 🐳: Containerization for services (`docker-compose.yaml`).
- **PostgreSQL** 🐘: Primary database with migrations (`20250907100309_20250907170305_Migration.cs`).
- **OpenAPI/Swagger** 📊: API documentation (`SwaggerExtension.cs`).
- **LHS Brackets** 📊: Advanced query filtering (`StringExtension.LHSParser.cs`).

## Deployment 🚀

Deploy using **Docker Compose** for container orchestration:

1. Configure `.env` variables.
2. Build and start services:
   ```bash
   make dev-build
   ```
3. For staging:
   ```bash
   make staging
   ```
4. Publish the application:
   ```bash
   make publish
   ```
   CI/CD pipelines are defined in `.github/workflows/` for automated deployment.

## Database Migrations 🗄️

The application uses Entity Framework Core migrations for schema management:

- Run migrations:
  ```bash
  make migration
  ```
- Check status:
  ```bash
  make status
  ```
- Update migrations:
  ```bash
  make update
  ```

## Backup and Restore 💾

- Backup the database:
  ```bash
  make backup
  ```
- Restore from a backup:
  ```bash
  make restore
  ```

## Testing 🧪

Run unit and integration tests using the `make test` command. You can filter tests by `TYPE` (e.g., `UnitTest`, `IntegrationTest`) and `NAME` (e.g., `LoginHandlerTest`).

```bash
make test
make test TYPE="IntegrationTest" NAME="LoginHandlerTest"
```

The test suite includes:

- **Unit Tests**: Validation of individual components (e.g., `LoginValidator.cs`).
- **Integration Tests**: End-to-end testing of services (e.g., `PatientDetailHandler.cs`).

## Basic Usage 🚀

### Step-by-Step Run

1. Open a terminal in the project root.
2. Start PostgreSQL:
   ```bash
   make dev
   ```
3. Run the application:
   ```bash
   dotnet run --project src/CMS_BE.Presentation
   ```

### Filtering 📊

The system uses **LHS Brackets** for filtering queries, implemented in `StringExtension.LHSParser.cs`. Example:

```
GET /api/patients?filter[birthDate][$gt]=1990-01-01
```

Supported operators:
| Operator | Description |
|----------|-------------------------------------|
| `$eq` | Equal |
| `$eqi` | Equal (case-insensitive) |
| `$ne` | Not equal |
| `$nei` | Not equal (case-insensitive) |
| `$in` | Included in an array |
| `$notin` | Not included in an array |
| `$lt` | Less than |
| `$lte` | Less than or equal to |
| `$gt` | Greater than |
| `$gte` | Greater than or equal to |
| `$between` | Is between |
| `$contains` | Contains |
| `$containsi` | Contains (case-insensitive) |
| `$startswith` | Starts with |
| `$endswith` | Ends with |
Examples:

```
GET /api/patients?filter[gender][$in][0]=Male&filter[gender][$in][1]=Female
```

```
GET /api/patients?filter[name][$contains]=John
```

**$and** and **$or** operators:

```
GET /api/patients?filter[$and][0][name][$containsi]=Jo&filter[$and][1][email][$eq]=john.doe@gmail.com
```

```json
{
  "filter": {
    "$and": {
      "name": { "$containsi": "Jo" },
      "email": { "$eq": "john.doe@gmail.com" }
    }
  }
}
```

## Contributing 🤝

1. Fork the repository.
2. Create a feature branch:
   ```bash
   git checkout -b feature/YourFeature
   ```
3. Commit changes:
   ```bash
   git commit -m "Add YourFeature"
   ```
4. Push to the branch:
   ```bash
   git push origin feature/YourFeature
   ```
5. Open a Pull Request.

## License 📜

This project is licensed under the **MIT License** (see `LICENSE` file).
