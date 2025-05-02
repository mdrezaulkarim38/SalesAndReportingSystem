import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainLayout from "./Layout/MainLayout";
import Home from "./pages/Home";
import Register from "./pages/Register";
import Login from "./pages/Login";
import { AuthProvider } from "./context/AuthContext";
import PrivateRoute from "./routes/PrivateRoute";

function App() {
  return (
    <Router>
      <AuthProvider>
        <Routes>
          <Route path="/" element={<PrivateRoute><MainLayout component={<Home />} /> </PrivateRoute>} />
          <Route path="/register" element={<MainLayout component={<Register />} />} />
          <Route path="/login" element={<MainLayout component={<Login />} />} />
        </Routes>
      </AuthProvider>
    </Router>
  );
}

export default App;
