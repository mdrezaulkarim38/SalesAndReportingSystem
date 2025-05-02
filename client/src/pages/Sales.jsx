import { useEffect, useState } from "react";
import { getProducts, makeSale } from "../services/api";
import { toast } from "react-toastify";

function Sales() {
  const [products, setProducts] = useState([]);
  const [selectedProductId, setSelectedProductId] = useState("");
  const [quantity, setQuantity] = useState("");
  const [availableStock, setAvailableStock] = useState(null);

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    try {
      const res = await getProducts();
      setProducts(res.data);
    } catch {
      toast.error("Failed to load products");
    }
  };

  const handleProductChange = (e) => {
    const id = e.target.value;
    setSelectedProductId(id);
    setAvailableStock(null);
    setQuantity("");

    const selected = products.find((p) => p.id === parseInt(id));
    if (selected) {
      // calculate current stock: initial - total sold
      fetch(`/api/Sale/stock/${id}`) // You can add this backend endpoint OR preload current stock in product list
        .then((res) => res.json())
        .then((data) => setAvailableStock(data.currentStock))
        .catch(() => setAvailableStock(selected.stockQty)); // fallback to initial
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!selectedProductId || !quantity) {
      toast.error("Please select a product and enter quantity.");
      return;
    }

    try {
      await makeSale(parseInt(selectedProductId), parseInt(quantity));
      toast.success("Sale recorded successfully!");
      setSelectedProductId("");
      setQuantity("");
      setAvailableStock(null);
      loadProducts(); // Refresh products
    } catch (err) {
      toast.error(err.response?.data?.error || "Sale failed.");
    }
  };

  return (
    <div className="container mt-4" style={{ maxWidth: "600px" }}>
      <h2 className="mb-4">Make a Sale</h2>

      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label>Product</label>
          <select
            className="form-select"
            value={selectedProductId}
            onChange={handleProductChange}
            required
          >
            <option value="">-- Select Product --</option>
            {products.map((product) => (
              <option key={product.id} value={product.id}>
                {product.name} (Stock: {product.stockQty})
              </option>
            ))}
          </select>
        </div>

        <div className="mb-3">
          <label>Quantity</label>
          <input
            type="number"
            className="form-control"
            value={quantity}
            onChange={(e) => setQuantity(e.target.value)}
            min="1"
            required
          />
        </div>

        {availableStock !== null && (
          <p className="text-muted">Available stock: {availableStock}</p>
        )}

        <button type="submit" className="btn btn-success w-100">
          Submit Sale
        </button>
      </form>
    </div>
  );
}

export default Sales;
