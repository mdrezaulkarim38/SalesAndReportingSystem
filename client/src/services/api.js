import axios from "axios";

const API_URL = "http://localhost:5174/api";

const api = axios.create({
  baseURL: API_URL,
  headers: { "Content-Type": "application/json" },
});

export const register = async (name, userName, password) => {
  return await api.post("/Auth/register", { name, userName, password });
};

export const login = async (userName, password) => {
  return await api.post("/Auth/login", { userName, password });
};

export const logout = () => {
  localStorage.removeItem("token");
};

export const getToken = () => {
  localStorage.getItem("token");
};

export default api;
