# LoggingHandler

A study repository focused on exploring strategies to log HTTP requests and responses between .NET-based APIs. The project captures, stores, and manages logs locally and asynchronously uploads them to AWS S3 using background processing.

---

## 📌 Overview

This project is composed of two main APIs:

- **IntegrationApi**: A mock API that provides generic responses.
- **MyTestingApi**: Sends HTTP requests to the IntegrationApi and generates logs for both the request and response.

These logs are first saved as local files, and then a background worker will upload them to Amazon S3. Metadata from each log is also persisted in a PostgreSQL database for search and traceability.

---

## 🧱 Project Structure

```graphql
├── APIs               # Contém os projetos de API (IntegrationApi, MyTestingApi)
│   ├── IntegrationApi
│   ├── MyTestingApi
├── Infra.Shared       # Serviços externos compartilhados entre os módulos
│   ├── HttpClients    # Clientes HTTP utilizados pelas APIs
│   └── Storage        # Integrações com armazenamento local e S3
├── Modules            # Serviços de domínio reutilizáveis (por exemplo, LogService)
├── Workers            # Serviços de segundo plano (ex: envio de arquivos para o S3)
└── docker-compose.yml # Orquestração dos serviços para execução local
```
---

## 🧪 Technologies

- .NET 9
- Docker
- PostgreSQL
- Amazon S3 (for file storage)
- Amazon SQS (planned for event queuing)
- Localstack (for developing with AWS tecnologies)

---

## 🚀 How to Run

To spin up the environment locally using Docker:

```bash
docker-compose up -d --build
```

This will create three containers:

1. PostgreSQL – stores metadata for log files.
2. IntegrationApi – provides mock responses.
3. MyTestingApi – makes HTTP requests and generates logs.
4. (planned) Worker - brackground service to send logs to s3
5. (planned) Localstack - simulate aws services

Future components like the Log Upload Worker, SQS queue, and S3 integration will be added later (marked as planned in the list above).

## Documentation

The documentation from the APIs can be found in the open api json (considering the docker-compose):

- IntegrationApi
```bash
http://localhost:5002/openapi/v1/openapi.json
```
- MyTestingApi
```bash
http://localhost:5000/openapi/v1/openapi.json
```

---

## 📂 Log Flow

1. MyTestingApi sends an HTTP request to IntegrationApi.
2. The request and response are intercepted and saved as a local log file.
3. (in development) An event is triggered for background processing (upload).
3. (in development) A Worker will consume the message, upload the log file to S3, and persist metadata in PostgreSQL.

---

## 📦 Module Highlights

- HttpClients: Generic HTTP clients used for inter-API communication.
- VolumeFileStorage: Handles local file operations for logs.
- S3FileStorage (in development): Responsible for uploading logs to AWS S3.
- LogUploadWorker (in development): Background service to consume SQS and manage file uploads.

---

## 📈 Project Status
- ✅ Basic API structure implemented
- ✅ Local logging working
- ✅ Docker & PostgreSQL environment ready
- 📄 OPEN API Documentation
- 🔧 Worker + S3 + SQS integration in progress
- 🧪 Automated testing
