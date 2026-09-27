# Request & Response Timing Demo

A simple full-stack application demonstrating cross-cutting concerns using an **Angular HTTP Interceptor** and **ASP.NET Core Middleware**.

The project measures HTTP request duration on the Angular client and response processing duration on the ASP.NET Core server.

## Task Objective

The objective of this task is to implement and register at least one of the following:

- Angular HTTP Interceptor
- EF Core Interceptor
- ASP.NET Core Middleware

This project implements **two** of them:

1. **Angular Request Timing Interceptor**
2. **ASP.NET Core Response Timing Middleware**

---

## Technologies

### Backend
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

### Frontend
- Angular 22
- TypeScript
- RxJS
- Bootstrap

---

## Architecture Overview

The request flows through the application as follows:

```text
Angular Component
        |
        v
HttpClient
        |
        v
Request Timing Interceptor
        |
        | HTTP Request
        v
ASP.NET Core
        |
        v
Response Timing Middleware
        |
        v
Controller
        |
        v
Service
        |
        v
Entity Framework Core
        |
        v
SQL Server
```

The response then travels back through the same pipeline.

---

## ASP.NET Core Response Timing Middleware

The backend contains a custom `ResponseTimingMiddleware`.

The middleware:

- Starts a `Stopwatch` when a request enters the ASP.NET Core pipeline.
- Calls the next middleware using `RequestDelegate`.
- Measures the server-side request duration.
- Logs the HTTP method, path, status code, and elapsed time.
- Logs slow requests as warnings.
- Adds the server timing to the response using the custom header:

```text
X-Response-Time-ms
```

The slow-request threshold is configurable in `appsettings.json`:

```json
"Performance": {
  "SlowRequestThresholdMs": 1000
}
```

The middleware is registered in the ASP.NET Core request pipeline in `Program.cs`.

---

## Angular Request Timing Interceptor

The frontend contains a functional Angular HTTP interceptor.

The interceptor:

- Intercepts requests made through Angular `HttpClient`.
- Starts timing using `performance.now()`.
- Passes the request to the next handler.
- Uses RxJS `tap` to inspect the HTTP response.
- Reads the server timing from the `X-Response-Time-ms` response header.
- Uses RxJS `finalize` to calculate the total client-side duration.
- Logs normal requests using `console.log`.
- Logs slow requests using `console.warn`.

Example:

```text
HTTP GET https://localhost:7056/api/Products?pageNumber=1&pageSize=10
completed in 15.30 ms | Server: 3 ms
```

The Angular timing represents the total duration observed by the client, while the server timing represents the duration measured inside the ASP.NET Core request pipeline.

---

## HTTP Performance Monitor

The Angular UI also displays the latest HTTP requests in a small performance monitor.

For each request it displays:

- HTTP method
- Request URL
- Client-side duration
- Server-side duration
- Fast / Slow status

The monitor keeps the latest **three requests**, making it possible to observe multiple requests such as:

```text
POST /api/Products
GET  /api/Products?pageNumber=1&pageSize=10
```

This makes it easier to demonstrate that the interceptor applies globally to requests made through Angular `HttpClient`.

---

## Demo Features

The application includes a small Products and Categories API/UI to generate real HTTP traffic for testing the timing implementation.

Supported operations include:

- List products with pagination
- Filter products by category
- View product details
- Create products
- Create categories

---

## Running the Project

### Backend

Navigate to the backend project:

```bash
cd TimingDemo.Api
```

Configure the SQL Server connection string in `appsettings.json`.

Then run:

```bash
dotnet run
```

The API is configured to run locally over HTTPS.

### Frontend

Navigate to the Angular project:

```bash
cd timing-demo-client
```

Install dependencies:

```bash
npm install
```

Run the application:

```bash
ng serve
```

Then open:

```text
http://localhost:4200
```

---

## Build Verification

Backend:

```bash
dotnet build TimingDemo.Api/TimingDemo.Api.csproj
```

Frontend:

```bash
cd timing-demo-client
npm run build
```

Both projects build successfully.

---

## Author

**Mohammad Malkawi**
