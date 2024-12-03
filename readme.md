# GetInfra.Samples.Rest

Welcome to **MyProject**, a .NET-based API application that demonstrates handling HTTP requests and displaying information such as request headers and client IP addresses. This project is built with ASP.NET Core for simplicity and performance.

---

## Features

- **`/ping` Endpoint**: Prints the HTTP request headers and the client's IP address.
- Lightweight and designed for quick demonstration.
- Easily extendable for more complex scenarios.

---

## Table of Contents

1. [Installation](#installation)
2. [Usage](#usage)
3. [Endpoint Details](#endpoint-details)
4. [Examples](#examples)
5. [License](#license)

---

## Installation

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

### Steps

1. Clone this repository:

   ```bash
   git clone https://github.com/username/MyProject.git
   cd MyProject
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

---

## Usage

1. Run the application:

   ```bash
   dotnet run
   ```

2. The server will start on `http://localhost:5000`.

---

## Endpoint Details

### `/ping`

- **Method**: `GET`
- **Description**: Returns the HTTP request headers and the client's IP address.

#### Sample Response

```json
{
  "headers": {
    "Host": "localhost:5000",
    "User-Agent": "PostmanRuntime/7.28.4",
    "Accept": "*/*"
  },
  "clientIp": "127.0.0.1"
}
```

---

## Examples

### cURL

```bash
curl -X GET http://localhost:5000/ping
```

### Browser

Navigate to `http://localhost:5000/ping` in your web browser or API testing tool like Postman.

---

## License

This project is licensed under the [MIT License](LICENSE).

---

## How It Works

The `/ping` endpoint is implemented in ASP.NET Core to capture the HTTP headers and client IP from the incoming request. Below is the relevant code snippet:

```csharp
[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());
        var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();

        return Ok(new
        {
            headers,
            clientIp
        });
    }
}
```

Feel free to modify the code for your specific use case!