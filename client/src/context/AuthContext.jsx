import { createContext, useContext, useState } from "react";
import {
  login as loginUser,
  register as registerUser,
  logout as logoutUser,
} from "../services/api";

const AuthContext = createContext();

// AuthProvider component
export const AuthProvider = ({ children }) => {
  const [token, setToken] = useState(localStorage.getItem("token"));

  const login = async (userName, password) => {
    try {
      const response = await loginUser(userName, password);
      const token = response.data.token;
      localStorage.setItem("token", token);
      setToken(token);
    } catch (err) {
      throw new Error(err.response?.data?.message || "Login failed");
    }
  };

  const register = async (name, userName, password) => {
    try {
      const response = await registerUser(name, userName, password);
      const token = response.data.token;
      localStorage.setItem("token", token);
      setToken(token);
    } catch (err) {
      throw new Error(err.response?.data?.message || "Registration failed");
    }
  };

  const logout = () => {
    logoutUser();
    localStorage.removeItem("token");
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ token, login, register, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};
