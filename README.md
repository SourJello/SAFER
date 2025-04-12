# SAFER: Situational Awareness Framework for Extended Resilience

**SAFER** is a real-time Space Domain Awareness (SDA) dashboard designed to maintain orbital awareness capabilities in degraded operational environments—particularly when commercial data feeds are unavailable.

It ingests and visualizes observational data from open and free sources like:
- 🛰️ [OurSky](https://www.oursky.com/)
- 🛰️ [Space-Track](https://www.space-track.org/)
- 🛰️ [SatNOGS](https://network.satnogs.org/)
- 🛰️ [Celestrak](https://celestrak.org/)
- 🛰️ [ESA Space Debris](https://www.esa.int/Safety_Security/Space_Debris)

> This project is built using **.NET 9**, **ASP.NET Core**, and designed to be fully containerized using **Docker**. Observational insights will later be enhanced via **AWS Bedrock**.

---

## Development Environment Setup

> These instructions are for macOS (tested on macOS 14.6.1), but should work on any Unix-based system.

### Prerequisites

- [.NET 9 SDK (preview)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [VS Code](https://code.visualstudio.com/) + the following extensions:
  - **C# Dev Kit**
  - **.NET Install Tool for Extension Authors**
- [Homebrew](https://brew.sh/) (for package installation)
- [GnuPG](https://gnupg.org/) for signed Git commits
  ```bash
  brew install gnupg pinentry-mac
  ```

> Make sure you've set up Git to use your GPG key and that it's associated with your GitHub account.

---

## Clone and Build

```bash
git clone git@github.com:your-username/SAFER.git
cd SAFER
code .
```

### First-time setup:

```bash
git config user.signingkey YOUR_FINGERPRINT
git config commit.gpgsign true
```

---

## Running with Docker

### Local development with hot-reload (via Docker Compose):

Run this to start the app in development mode with debug settings:
This will:

Build the app in Debug mode using Dockerfile.dev
Expose the API on http://localhost:5050
Open port 5005 for debugger attachment
Mount your code into the container (optional enhancement)

```bash
docker compose up --build --force-recreate
```
### Production
To build and run the production configuration (e.g., Release mode only):

```bash
docker compose -f docker-compose.yml up --build
```
This uses:

The Release configuration
The official ASP.NET runtime image (no SDK/debugger)
The pre-published output from the multi-stage Dockerfile


This will:
- Build the SAFER API (targeting .NET 9)
- Map API to `http://localhost:5050`

## Running Tests (Dockerized)

SAFER includes a containerized test runner using xUnit, enabling you to execute unit tests in a consistent, isolated environment.

To run the full test suite:

docker compose -f docker-compose.test.yml up --build
This will:

- Build the test environment from Dockerfile.test
- Restore dependencies and compile tests
- Run all unit tests defined in SAFER.Tests/
- Test results will stream directly to your terminal.
- Requires only Docker — no local .NET SDK setup needed.

---

## Available Endpoints

| Endpoint                   | Description                               |
|----------------------------|-------------------------------------------|
| `/weatherforecast`         | Sample endpoint scaffolded by .NET        |
| `/data/status`             | Verifies the DataController is online     |
| `/data/oursky`             | Hardcoded test call to OurSky             |
| `/data/satnogs`            | (Coming soon) Pulls SatNOGS data          |
| `/data/spacetrack`         | (Coming soon) Pulls TLEs from Space-Track |

---

## Workspace Setup

This repo includes a `.code-workspace` file:
```bash
SAFER.code-workspace
```

You can open it directly with VS Code for pre-configured folder and project settings:

```bash
code SAFER.code-workspace
```

---

## Project Philosophy

This project is designed to ensure **mission resilience** in low-data or disconnected environments. By ingesting and analyzing open-source orbital data, SAFER helps maintain orbital situational awareness when commercial feeds are disrupted or unavailable.

---

## To Do / Coming Soon

- [ ] Integration with live OurSky, SatNOGS, and Space-Track feeds
- [ ] Real-time telemetry ingestion pipeline via Kafka/NiFi
- [ ] AI-powered analytics using AWS Bedrock
- [ ] Solar exclusion detection
- [ ] Pattern-of-life anomaly detection
- [ ] Deployment pipeline via GitHub Actions
- [ ] Visual dashboard (React + Recharts or Blazor?)

---

## License

This project is licensed under the **Apache 2.0 License**.

---

### Developed by

> Patrick Kitchens
