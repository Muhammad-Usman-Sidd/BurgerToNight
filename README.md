# Food Ordering Web Application

This repository contains a feature-rich food ordering web application developed using .NET and React.js. The application incorporates modern technologies and best practices to deliver a secure, efficient, and user-friendly experience.

## Technologies Used

- **Data Management:**
  - Utilized LINQ for high-performance data retrieval, ensuring efficient and seamless data access.

- **Design Patterns:**
  - Implemented the repository pattern for clean, maintainable, and scalable code architecture.

- **Exception Handling:**
  - Integrated robust exception handling mechanisms to improve system resilience and reliability.

- **Authentication & Authorization:**
  - Employed JWT (JSON Web Tokens) for secure multi-role access, ensuring appropriate permissions for users.

- **API Development:**
  - Designed and optimized Web API and RESTful APIs for smooth frontend-backend communication.

- **Secure CRUD Operations:**
  - Managed secure CRUD operations, incorporating Base64 image encoding to safeguard sensitive data.

- **DTOs (Data Transfer Objects):**
  - Created DTOs to enhance data transfer efficiency and overall system performance.

- **Frontend Development:**
  - Built a responsive and intuitive user interface using React.js and TypeScript.
  - Employed Redux for effective state management.
  - Developed an admin panel for streamlined order management.

## Features

- Role-based user authentication and authorization.
- Responsive and visually appealing user interface.
- Efficient admin panel for managing orders and products.
- Secure and optimized API endpoints for robust backend operations.
- Comprehensive error handling and data management strategies.

## Website Overview

### Note:
The following GIFs may appear laggy due to compression, but the actual website runs smoothly.

#### Home Page
![Home Page Dark](https://github.com/user-attachments/assets/9e76ab73-1d3d-47b9-aafc-55e3a0a47b86)

##### Home in Light Mode
![image](https://github.com/user-attachments/assets/bb18c1a2-4fb3-4e63-98f2-3cf98e6b8828)

#### About Us Page
![About-Us Page](https://github.com/user-attachments/assets/16c7a773-1bd2-4b91-8650-03fab287abdd)

##### About Us in Light Mode
![image](https://github.com/user-attachments/assets/12d76012-908c-4181-8209-9a14c10fb046)

#### Deals Page
![Deals Page](https://github.com/user-attachments/assets/779d2c89-0a85-4343-a921-6193545a8586)

##### Deals in Light Mode
![image](https://github.com/user-attachments/assets/553f8ef4-7407-4db9-b643-06f52b53152a)

#### Menu Page
![Menu Overview](https://github.com/user-attachments/assets/a465f53e-f96f-417f-860a-67594fb224f3)

#### Contact Page
![Contact Page 1](https://github.com/user-attachments/assets/cf036963-5a90-4ee0-a3df-3bb5104e8915)
![Contact Page 2](https://github.com/user-attachments/assets/9585fc70-b5db-4ed6-88d2-aa2998c7ef89)

#### Placing an Order
##### Details Page
![Details Page](https://github.com/user-attachments/assets/a7a419b8-6e37-44d7-9b08-1d1901b3d8d4)

##### Checkout Page
![Checkout Page](https://github.com/user-attachments/assets/f4a9862a-88b6-40fe-b234-8441d7d02427)

### Admin Dashboard
![Admin Dashboard](https://github.com/user-attachments/assets/bc732c1b-3a80-4080-ae23-95a2ee31f1af)

#### Admin Product Page Overview
![Admin Product Page](https://github.com/user-attachments/assets/732aa731-24e2-416c-94cf-83a19be21da1)

## Getting Started

To set up this project locally, you will need to configure several components, including:

1. Setting up the `local.settings.json` file in the Functions assembly.
2. Configuring the database in SSMS (SQL Server Management Studio).
3. Adjusting the IP address or using `localhost`.
4. Connecting with Azure Storage Explorer (after downloading it).
5. Accessing the admin account (refer to the code for the secret key, which is `"usman is admin"`).
6. Azurite if not using VS (Visual Studio).

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) and npm
- [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/) or an Azure account
