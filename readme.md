# Sample API application

Welcome to **getinfra.samples.rest**, a .NET-based API application that demonstrates handling HTTP requests and displaying information such as request headers and client IP addresses. This project is built with ASP.NET Core for simplicity and performance.

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
   git clone https://github.com/getinfra/sample-api.git
   cd sample-api
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

2. The server will start on `http://localhost:5085`.

---

## Endpoint Details

### `/ping`

- **Method**: `GET`
- **Description**: Returns the HTTP request headers and the client's IP address.

#### Sample Response

```json
[
  {
    "name": "Accept",
    "value": "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7"
  },
  {
    "name": "Host",
    "value": "localhost:5085"
  },
  {
    "name": "Accept-Encoding",
    "value": "gzip, deflate, br, zstd"
  },
  {
    "name": "Accept-Language",
    "value": "en-GB,en-DE;q=0.9,en;q=0.8,de-DE;q=0.7,de;q=0.6,en-US;q=0.5,ru;q=0.4"
  },
  {
    "name": "Cache-Control",
    "value": "max-age=0"
  }
]
```

---

## Examples

### cURL

```bash
curl -X GET http://localhost:5085/ping
```

### Browser

Navigate to `http://localhost:5085/ping` in your web browser or API testing tool like Postman.

---

## License

This project is licensed under the [MIT License](LICENSE).

---


Feel free to modify the code for your specific use case!
