# Sales And Reporting System

## 📘 Project Setup & Run Instructions

This project consists of:

* **Backend**: ASP.NET Core 8 (C#, WebAPI)
* **Frontend**: React/Vite

---

### ⚙️ Prerequisites

Ensure the following are installed on your system:

| Tool                       | Required Version   |
| -------------------------- | ------------------ |
| .NET SDK                   | 8.0 or higher      |
| Node.js                    | 18 or higher       |
| NPM (Node Package Manager) | Comes with Node.js |

---

### 📁 Project Structure

```
/SalesAndReportingSystem
│
├── /Server     → ASP.NET Core 8 Backend
├── /client     → React Frontend (Node.js)
```

---

### 🛠️ Initial Backend Configuration

Before running the backend, complete the following steps:

1. Open the file:

   ```
   /Server/appsettings.json
   ```

2. Set your **database connection string** under the `DefaultConnection` key.

   Example:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;"
   }
   ```

3. Apply database migrations (migrations are already included in the project):

   ```bash
   cd Server
   dotnet ef database update
   ```

> ⚠️ Ensure `dotnet-ef` tool is installed. If not, install it via:
>
> ```bash
> dotnet tool install --global dotnet-ef
> ```

---

### 🚀 Running the Backend (ASP.NET Core)

#### Option 1: Using Command Line

```bash
cd Server
dotnet run
```

#### Option 2: Using Visual Studio Code

1. Open the project in **VS Code**.
2. Open the terminal (`Ctrl + ~`) and run:

   ```bash
   cd Server
   dotnet run
   ```

---

### 🌐 Running the Frontend (React JS)

1. Open a **new terminal** window.
2. Navigate to the `client` directory:

   ```bash
   cd client
   ```
3. Install dependencies:

   ```bash
   npm install
   ```
4. Start the frontend:

   ```bash
   npm run dev
   ```

By default, the frontend will run at:

```
http://localhost:5173
```

---

### 🔁 Important Note on CORS Configuration

If the frontend runs on a **different port**, update the backend’s CORS settings in:

> `Server/Program.cs`

```csharp
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173")
           .AllowAnyHeader()
           .AllowAnyMethod();
});
```

Change the URL in `.WithOrigins(...)` to match your actual frontend port.

---

### ✅ Testing the Project

1. Make sure the backend is running:

   ```bash
   dotnet run
   ```
2. Make sure the frontend is running:

   ```bash
   npm run dev
   ```
3. Visit:

   ```
   http://localhost:5173
   ```
4. Verify functionality:

   * Load products
   * Make a sale
   * Stock updates
   * Toast notifications (success/error)

---

### 📞 Support

If you face any issues or need help, feel free to contact:

**MD Rezaul Karim Shuvo**
📧 [mdrezaulkarim31295@gmail.com](mailto:mdrezaulkarim31295@gmail.com)
📞 +8801303316865
