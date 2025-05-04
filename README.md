
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

### 🚀 Running the Backend (ASP.NET Core)

#### Option 1: Using Command Line

1. Open a terminal/command prompt.
2. Navigate to the `Server` directory:

   ```bash
   cd Server
   ```
3. Run the backend server:

   ```bash
   dotnet run
   ```

> Make sure `.NET SDK 8` is properly installed and added to the system path.

#### Option 2: Using Visual Studio Code

1. Open the project in **VS Code**.
2. Open the integrated terminal (`Ctrl + ~`).
3. Navigate to the `Server` folder:

   ```bash
   cd Server
   ```
4. Run the backend:

   ```bash
   dotnet run
   ```

---

### 🌐 Running the Frontend (React JS)

1. Open a **new terminal** window.
2. Navigate to the `client` directory:

   ```bash
   cd client
   ```
3. Install project dependencies:

   ```bash
   npm install
   ```
4. Start the frontend development server:

   ```bash
   npm run dev
   ```

By default, the frontend will run at:

```
http://localhost:5173
```

---

### 🔁 Important Note on CORS Configuration

If the frontend runs on a **different port**, you must **update the backend's CORS settings** in:

> `Server/Program.cs`

Locate the CORS section:

```csharp
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173")
           .AllowAnyHeader()
           .AllowAnyMethod();
});
```

👉 Change the URL in `.WithOrigins(...)` to match the actual frontend port if it differs from `5173`.

---

### ✅ Testing the Project

1. Ensure the backend is running via:

   ```bash
   dotnet run
   ```

2. Ensure the frontend is running via:

   ```bash
   npm run dev
   ```

3. Open your browser and navigate to:

   ```
   http://localhost:5173
   ```

4. Test the features:

   * Load products
   * Make a sale
   * Observe available stock updates
   * Ensure success/error notifications are shown properly

---

### 📞 Support

If you face any issues or need help, feel free to contact:

**MD Rezaul Karim Shuvo**
📧 [mdrezaulkarim31295@gmail.com](mailto:mdrezaulkarim31295@gmail.com)
📞 +8801303316865
