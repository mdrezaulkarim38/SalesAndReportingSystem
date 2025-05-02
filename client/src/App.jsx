import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainLayout from "./Layout/MainLayout";
import Home from "./pages/Home";
import Register from "./pages/Register";
import Login from "./pages/Login";
import Report from "./pages/Report";
import DateReport from "./pages/DateReport";
import { AuthProvider } from "./context/AuthContext";
import PrivateRoute from "./routes/PrivateRoute";
import Product from "./pages/Product";
import Sales from "./pages/Sales";

function App() {
  return (
    <Router>
      <AuthProvider>
        <Routes>
          <Route path="/" element={<PrivateRoute><MainLayout component={<Home />} /> </PrivateRoute>} />
          <Route path="/products" element={<PrivateRoute><MainLayout component={<Product />}/></PrivateRoute>} />
          <Route path="/sales" element={<PrivateRoute><MainLayout component={<Sales />}/></PrivateRoute>} />
          <Route path="/reports/sales" element={<PrivateRoute><MainLayout component={<Report />} /></PrivateRoute>} />
          <Route path="/reports/stock" element={<PrivateRoute><MainLayout component={<DateReport />} /></PrivateRoute>} />
          <Route path="/register" element={<MainLayout component={<Register />} />} />
          <Route path="/login" element={<MainLayout component={<Login />} />} />
        </Routes>
      </AuthProvider>
    </Router>
  );
}

export default App;
