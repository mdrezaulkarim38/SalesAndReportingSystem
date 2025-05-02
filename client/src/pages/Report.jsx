import { useEffect, useState } from "react";
import { getCurrentStockReport } from "../services/api";
import { toast } from "react-toastify";

function Report() {
  const [report, setReport] = useState([]);

  useEffect(() => {
    fetchReport();
  }, []);

  const fetchReport = async () => {
    try {
      const res = await getCurrentStockReport();
      setReport(res.data);
    } catch {
      toast.error("Failed to fetch stock report.");
    }
  };

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Current Stock Report</h2>

      <table className="table table-bordered table-striped">
        <thead className="table-dark">
          <tr>
            <th>Product Name</th>
            <th>SKU</th>
            <th>Price</th>
            <th>Current Stock Qty</th>
          </tr>
        </thead>
        <tbody>
          {report.length === 0 ? (
            <tr>
              <td colSpan="4" className="text-center">
                No products to show
              </td>
            </tr>
          ) : (
            report.map((item, index) => (
              <tr key={index}>
                <td>{item.productName}</td>
                <td>{item.sku}</td>
                <td>{item.price}</td>
                <td>{item.currentStock}</td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}

export default Report;
