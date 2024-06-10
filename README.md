# Incident Management API

This project is an ASP.NET Core Web API for managing incidents, accounts, and contacts. It uses Entity Framework Core for database operations and follows a code-first approach. The relationships between the entities are:
- A many-to-many relationship between contacts and accounts.
- A one-to-many relationship between accounts and incidents.

## Features
- Create contacts, accounts, and incidents.
- Validate account existence before creating incidents.
- Validate contact existence by email before linking to an account.
- Update contact information if the contact already exists.
- Link a new contact to an account and create an incident.

## Requirements
- .NET 6.0 or later
- SQL Server

## Setup

### 1. Clone the repository
```bash
git clone https://github.com/Josorod/IncidentReport.git
cd incident-management-api
