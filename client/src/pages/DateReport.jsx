import { useState } from "react";
import { getDateWiseStockReport } from "../services/api";
import { toast } from "react-toastify";

function DateReport() {
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [report, setReport] = useState([]);
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!fromDate || !toDate) {
      toast.error("Please select both dates.");
      return;
    }

    setLoading(true);
    try {
      const res = await getDateWiseStockReport(fromDate, toDate);
      setReport(res.data);
    } catch {
      toast.error("Failed to fetch date-wise report.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Date-wise Stock Report</h2>

      <form onSubmit={handleSubmit} className="row mb-4">
        <div className="col-md-4 mb-2">
          <label>From Date</label>
          <input
            type="date"
            className="form-control"
            value={fromDate}
            onChange={(e) => setFromDate(e.target.value)}
            required
          />
        </div>
        <div className="col-md-4 mb-2">
          <label>To Date</label>
          <input
            type="date"
            className="form-control"
            value={toDate}
            onChange={(e) => setToDate(e.target.value)}
            required
          />
        </div>
        <div className="col-md-4 mb-2 d-flex align-items-end">
          <button type="submit" className="btn btn-primary w-100">
            {loading ? "Loading..." : "Get Report"}
          </button>
        </div>
      </form>

      <table className="table table-bordered table-striped">
        <thead className="table-dark">
          <tr>
            <th>Product Name</th>
            <th>Opening Stock</th>
            <th>Sold Quantity</th>
            <th>Closing Stock</th>
          </tr>
        </thead>
        <tbody>
          {report.length === 0 ? (
            <tr>
              <td colSpan="4" className="text-center">
                No data to display.
              </td>
            </tr>
          ) : (
            report.map((item, idx) => (
              <tr key={idx}>
                <td>{item.productName}</td>
                <td>{item.openingStock}</td>
                <td>{item.soldQuantity}</td>
                <td>{item.closingStock}</td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
}

export default DateReport;
