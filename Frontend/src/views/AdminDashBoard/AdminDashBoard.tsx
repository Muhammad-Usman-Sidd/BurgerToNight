import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { Bar } from "react-chartjs-2";
import { FaUsers, FaShoppingCart } from "react-icons/fa";
import { FiTrendingUp } from "react-icons/fi";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
  ChartOptions,
} from "chart.js";
import { fetchProducts, fetchTopProducts } from "../../app/Stores/ProductSlice";
import { fetchOrders } from "../../app/Stores/OrderSlice";
import { fetchTopCustomers } from "../../app/Stores/AuthSlice";
import { RootState, AppDispatch } from "../../app/store";
import TableWrapper from "../../components/Generics/TableWrapper";
import { TableColumn } from "../../components/Generics/MainTable";
import Loader from "../../components/Loading/Loader";

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);

const AdminDashboard: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { product, order, auth } = useSelector((state: RootState) => state);
  const { topProducts, loading } = product;
  const { orders, orderLoading } = order;
  const { topCustomers } = auth;

  useEffect(() => {
    dispatch(fetchProducts({}));
    dispatch(fetchTopCustomers());
    dispatch(fetchTopProducts(5));
    dispatch(fetchOrders());
  }, [dispatch]);

  const userColumns: TableColumn[] = [
    {
      label: "CustomerId",
      field: "Id",
      render: (Id: string) => {
        const formattedId = Id.slice(0, 4);
        return <div>{formattedId}</div>;
      },
    },
    {
      label: "Name",
      field: "UserName",
    },
    {
      label: "TotalOrders",
      field: "TotalOrders",
    },
    {
      label: "TotalAmountSpent",
      field: "TotalAmountSpent",
    },
    {
      label: "PhoneNumber",
      field: "PhoneNumber",
    },
    {
      label: "Address",
      field: "Address",
    },
  ];
  const productData = {
    labels: topProducts.map((p) => p.Name),
    datasets: [
      {
        label: "Highest Sold Item",
        data: topProducts.map((p) => p.TotalSales),
        backgroundColor: "rgba(75, 192, 192, 0.6)",
        borderColor: "rgba(75, 192, 192, 1)",
        borderWidth: 1,
      },
    ],
  };

  const productOptions: ChartOptions<"bar"> = {
    responsive: true,
    plugins: {
      legend: { display: true },
      tooltip: { enabled: true },
    },
    scales: {
      x: {
        ticks: {
          font: {
            size: 10,
          },
        },
      },
    },
  };
  const orderOptions: ChartOptions<"bar"> = {
    indexAxis: "y",
    responsive: true,
    plugins: {
      legend: { display: true },
      tooltip: { enabled: true },
    },
  };

  const orderData = {
    labels: orders.map((o) => o.Id),
    datasets: [
      {
        label: "Orders Total",
        data: orders.map((o) => o.OrderTotal),
        backgroundColor: "rgba(153, 102, 255, 0.6)",
        borderColor: "rgba(153, 102, 255, 1)",
        borderWidth: 1,
      },
    ],
  };

  if (loading || orderLoading) {
    return <Loader />;
  }

  return (
    <div className="flex min-h-screen bg-gray-100 dark:bg-gray-900 overflow-x-hidden">
      <div className="flex-1 flex flex-col">
        <header className="mx-4 p-4 rounded-lg bg-gray-200 dark:bg-gray-800/90 flex justify-between items-center">
          <h1 className="text-xl font-bold">Admin Dashboard</h1>
        </header>

        <main className="flex-1 p-4 overflow-y-auto">
          <div className="grid grid-cols-1 md:grid-cols-3 gap-4 mb-4">
            <div className="p-4 shadow rounded-lg flex items-center bg-white dark:bg-gray-800">
              <FiTrendingUp className="text-3xl text-blue-600 mr-4" />
              <div>
                <h2 className="text-sm font-semibold">Total Sale</h2>
                <p className="text-lg">
                  ${orders.reduce((sum, o) => sum + o.OrderTotal, 0)}
                </p>
              </div>
            </div>
            <div className="p-4 shadow rounded-lg flex items-center bg-white dark:bg-gray-800">
              <FaShoppingCart className="text-3xl text-green-600 mr-4" />
              <div>
                <h2 className="text-sm font-semibold">Total Orders</h2>
                <p className="text-lg">{orders.length}</p>
              </div>
            </div>
            <div className="p-4 shadow rounded-lg flex items-center bg-white dark:bg-gray-800">
              <FaUsers className="text-3xl text-purple-600 mr-4" />
              <div>
                <h2 className="text-sm font-semibold">Top Customer</h2>
                <p className="text-lg">{topCustomers[0]?.Name || "N/A"}</p>
              </div>
            </div>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="p-4 shadow rounded-lg bg-white dark:bg-gray-800">
              <h2 className="text-sm font-semibold mb-4">Orders Overview</h2>
              <div className="max-w-full overflow-x-auto">
                <Bar data={orderData} options={orderOptions} />
              </div>
            </div>
            <div className="p-4 shadow rounded-lg bg-white dark:bg-gray-800">
              <h2 className="text-sm font-semibold mb-4">Top Products</h2>
              <div className="max-w-full overflow-x-auto">
                <Bar data={productData} options={productOptions} />
              </div>
            </div>
          </div>

          <div className="mt-4 max-w-full overflow-x-auto">
            <TableWrapper
              title="Top Customers"
              columns={userColumns}
              data={topCustomers}
            />
          </div>
        </main>
      </div>
    </div>
  );
};

export default AdminDashboard;
