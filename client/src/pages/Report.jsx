import { useEffect, useState } from "react";
import { getCurrentStockReport } from "../services/api";
import { toast } from "react-toastify";
import DataTable from "react-data-table-component";

function Report() {
  const [report, setReport] = useState([]);
  const [filtered, setFiltered] = useState([]);

  useEffect(() => {
    fetchReport();
  }, []);

  const fetchReport = async () => {
    try {
      const res = await getCurrentStockReport();
      setReport(res.data);
      setFiltered(res.data);
    } catch {
      toast.error("Failed to fetch stock report.");
    }
  };

  const columns = [
    { name: "Product Name", selector: (row) => row.productName, sortable: true },
    { name: "SKU", selector: (row) => row.sku, sortable: true },
    { name: "Price", selector: (row) => row.price, sortable: true },
    { name: "Stock Qty", selector: (row) => row.currentStock, sortable: true },
  ];

  return (
    <div className="container mt-4">
      <DataTable
        title="Current Stock Report"
        columns={columns}
        data={filtered}
        pagination
        highlightOnHover
        subHeader
        subHeaderComponent={
          <input
            type="text"
            className="form-control w-25"
            placeholder="Search by name or SKU..."
            onChange={(e) => {
              const text = e.target.value.toLowerCase();
              const result = report.filter(
                (item) =>
                  item.productName.toLowerCase().includes(text) ||
                  item.sku.toLowerCase().includes(text)
              );
              setFiltered(text ? result : report);
            }}
          />
        }
      />
    </div>
  );
}

export default Report;
