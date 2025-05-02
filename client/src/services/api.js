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

export const getProducts = async () => {
  const token = localStorage.getItem("token");
  return await api.get("/Product", {
    headers: { Authorization: `Bearer ${token}` }
  });
};

export const createProduct = async (data) => {
  const token = localStorage.getItem("token");
  return await api.post("/Product", data, {
    headers: { Authorization: `Bearer ${token}` }
  });
};

export const updateProduct = async (id, data) => {
  const token = localStorage.getItem("token");
  return await api.put(`/Product/${id}`, data, {
    headers: { Authorization: `Bearer ${token}` }
  });
};

export const deleteProduct = async (id) => {
  const token = localStorage.getItem("token");
  return await api.delete(`/Product/${id}`, {
    headers: { Authorization: `Bearer ${token}` }
  });
};

export const makeSale = async (productId, quantity) => {
  const token = localStorage.getItem("token");
  return await api.post(
    "/Sales",
    { productId, quantity },
    { headers: { Authorization: `Bearer ${token}` } }
  );
};

export const getCurrentStockReport = async () => {
  const token = localStorage.getItem("token");
  return await api.get("/report/current-stock", {
    headers: { Authorization: `Bearer ${token}` }
  });
};

export const getDateWiseStockReport = async (fromDate, toDate) => {
  const token = localStorage.getItem("token");
  return await api.get(`/report/date-wise-stock?fromDate=${fromDate}&toDate=${toDate}`, {
    headers: { Authorization: `Bearer ${token}` }
  });
};

export default api;
