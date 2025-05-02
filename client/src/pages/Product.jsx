import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import DataTable from "react-data-table-component";
import {
  getProducts,
  createProduct,
  updateProduct,
  deleteProduct,
} from "../services/api";

function Product() {
  const initialFormState = {
    id: null,
    name: "",
    sku: "",
    price: "",
    stockQty: "",
    description: "",
  };

  const [products, setProducts] = useState([]);
  const [form, setForm] = useState(initialFormState);
  const [isFormVisible, setIsFormVisible] = useState(false);
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    try {
      const response = await getProducts();
      setProducts(response.data);
    } catch {
      toast.error("Failed to load products");
    }
  };

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleAddNew = () => {
    setForm(initialFormState);
    setIsEditing(false);
    setIsFormVisible(true);
  };

  const handleEdit = (product) => {
    setForm(product);
    setIsEditing(true);
    setIsFormVisible(true);
  };

  const handleCancel = () => {
    setForm(initialFormState);
    setIsEditing(false);
    setIsFormVisible(false);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      if (isEditing) {
        await updateProduct(form.id, form);
        toast.success("Product updated!");
      } else {
        await createProduct(form);
        toast.success("Product created!");
      }

      fetchProducts();
      handleCancel();
    } catch {
      toast.error("Operation failed");
    }
  };

  const handleDelete = async (id) => {
    if (!window.confirm("Are you sure you want to delete this product?"))
      return;
    try {
      await deleteProduct(id);
      toast.success("Product deleted!");
      fetchProducts();
    } catch {
      toast.error("Delete failed");
    }
  };

  return (
    <div className="container mt-4">
      <div className="mb-3 text-end">
        <button className="btn btn-primary" onClick={handleAddNew}>
          Add New Product
        </button>
      </div>

      {isFormVisible && (
        <div className="card mb-4">
          <div className="card-header">
            {isEditing ? "Edit Product" : "Add New Product"}
          </div>
          <div className="card-body">
            <form onSubmit={handleSubmit}>
              <div className="row">
                <div className="col-md-6 mb-3">
                  <label>Name</label>
                  <input
                    type="text"
                    className="form-control"
                    name="name"
                    value={form.name}
                    onChange={handleChange}
                    required
                  />
                </div>
                <div className="col-md-6 mb-3">
                  <label>SKU</label>
                  <input
                    type="text"
                    className="form-control"
                    name="sku"
                    value={form.sku}
                    onChange={handleChange}
                  />
                </div>
                <div className="col-md-6 mb-3">
                  <label>Price</label>
                  <input
                    type="number"
                    className="form-control"
                    name="price"
                    value={form.price}
                    onChange={handleChange}
                    required
                  />
                </div>
                <div className="col-md-6 mb-3">
                  <label>Stock Quantity</label>
                  <input
                    type="number"
                    className="form-control"
                    name="stockQty"
                    value={form.stockQty}
                    onChange={handleChange}
                    required
                  />
                </div>
                <div className="mb-3">
                  <label>Description</label>
                  <input
                    type="text"
                    className="form-control"
                    name="description"
                    value={form.description}
                    onChange={handleChange}
                  />
                </div>
              </div>

              <div className="d-flex justify-content-end">
                <button
                  type="button"
                  className="btn btn-secondary me-2"
                  onClick={handleCancel}
                >
                  Cancel
                </button>
                <button type="submit" className="btn btn-primary">
                  {isEditing ? "Update Product" : "Create Product"}
                </button>
              </div>
            </form>
          </div>
        </div>
      )}

      <div className="mt-4">
        <DataTable
          title="Product List"
          columns={[
            { name: "Name", selector: (row) => row.name, sortable: true },
            { name: "SKU", selector: (row) => row.sku, sortable: true },
            { name: "Price", selector: (row) => row.price, sortable: true },
            {
              name: "Stock Qty",
              selector: (row) => row.stockQty,
              sortable: true,
            },
            { name: "Description", selector: (row) => row.description },
            {
              name: "Actions",
              cell: (row) => (
                <>
                  <button
                    className="btn btn-sm btn-warning me-2 p-1"
                    onClick={() => handleEdit(row)}
                  >
                    Edit
                  </button>
                  <button
                    className="btn btn-sm btn-danger p-1"
                    onClick={() => handleDelete(row.id)}
                  >
                    Delete
                  </button>
                </>
              ),
              ignoreRowClick: true,
              allowOverflow: true,
              button: true,
            },
          ]}
          data={products}
          pagination
          responsive
          highlightOnHover
          subHeader
          subHeaderComponent={
            <input
              type="text"
              className="form-control w-25"
              placeholder="Search by Name or SKU..."
              onChange={(e) => {
                const searchText = e.target.value.toLowerCase();
                const filtered = products.filter(
                  (p) =>
                    p.name.toLowerCase().includes(searchText) ||
                    p.sku.toLowerCase().includes(searchText)
                );
                setProducts(filtered.length ? filtered : []);
                if (!searchText) fetchProducts();
              }}
            />
          }
        />
      </div>
    </div>
  );
}

export default Product;
