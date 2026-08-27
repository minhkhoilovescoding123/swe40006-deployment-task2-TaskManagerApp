# SWE40006 Deployment Task 2: Web App Deployment to Azure

Student: Andy Truong (104977519)
Unit: SWE40006 Software Deployment and Evolution, Semester 2, 2026
Target level: Credit (Task 2.1 and Task 2.2)

This repository contains the source code for two ASP.NET Core web applications built and deployed to Microsoft Azure App Service as part of Deployment Task 2. Full setup, deployment steps, screenshots and troubleshooting notes are documented in the accompanying report, `Deployment_Task2_104977519_Credit.docx`.

## Contents

| Folder | Sub-task | Description |
|---|---|---|
| `WebApplication1_Task2/` | Task 2.1 (Pass) | Starter ASP.NET Core Web App (MVC) sample project, provided as the base template in the unit walkthrough. |
| `TaskManagerApp/` | Task 2.2 (Credit) | Custom built Task Manager web application. |

## Task 2.2: Task Manager

A simple task management application built with ASP.NET Core MVC, targeting .NET 8.

**Features**

- Add a task with a required title and an optional description
- Edit a task's description
- Delete a task regardless of its current status
- Change a task's status between four states, each shown with a colour coded badge:
  - Not Started (grey)
  - Ongoing (orange)
  - Complete (green)
  - Late (red)

**Tech stack**

- ASP.NET Core MVC, .NET 8.0 (LTS)
- In memory singleton service for task storage (no database required)
- Bootstrap for styling, via the default ASP.NET Core MVC template

**Project structure**

```
TaskManagerApp/
├── Controllers/
│   └── TasksController.cs
├── Models/
│   └── TaskItem.cs
├── Services/
│   └── TaskService.cs
├── Views/
│   └── Tasks/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       └── Edit.cshtml
└── Program.cs
```

## Getting started locally

Requirements: .NET 8.0 SDK or newer, Visual Studio 2022/2026 or VS Code with the C# extension.

```bash
git clone https://github.com/<your-username>/SWE40006-Deployment-Task2.git
cd SWE40006-Deployment-Task2/TaskManagerApp
dotnet run
```

Then open the URL shown in the console (typically `https://localhost:xxxx`) in a browser.

## Deployment

Both applications were published to separate Azure App Service instances using the Visual Studio Publish wizard:

| Application | Region | Pricing tier | Status |
|---|---|---|---|
| WebApplication1_Task2 (2.1) | Australia Southeast | Free (F1) | Deployed and verified |
| TaskManagerApp (2.2) | Australia Southeast | Free (F1) | Deployed, verified, then stopped |

The Task 2.2 App Service instance was intentionally **stopped** after verification to demonstrate responsible cloud resource lifecycle management, as required by the assignment brief. As a result, its public URL will return a "This web app is stopped" message rather than the live application. Screenshots of the application running live, taken before the instance was stopped, are included in the report.

## Notable issues resolved during deployment

Full details, including error messages, causes and resolutions, are documented in Section 5 of the report. In summary:

1. The ASP.NET Core Web App (MVC) template was missing until the ASP.NET and web development workload was installed via the Visual Studio Installer.
2. Publishing under a Swinburne student Azure account failed with an `AuthorizationFailed` error, as institutional policy restricts resource group creation. Resolved by switching to a personal Microsoft account with its own Azure Free subscription.
3. A newly created Azure Free subscription was not immediately visible in Visual Studio due to a cached account token. Resolved by signing out and back in.
4. App Service creation failed with a `SubscriptionIsOverQuotaForSku` error on the Standard (S1) tier due to zero default VM quota. Resolved by switching to the Free (F1) tier.
5. The same quota error persisted on Free (F1) in the Canada Central region specifically. Resolved by changing the Hosting Plan region to Australia Southeast, where quota was available.

## Report

The full report, including the assignment header details, declared target level, step by step workflow with annotated screenshots, and the self-troubleshooting table, is available at `Deployment_Task2_104977519_Credit.docx` in this repository or in the Canvas submission.

## License

This repository was created for academic assessment purposes as part of SWE40006 at Swinburne University of Technology and is not licensed for external reuse.
