import React, { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { Bar } from "react-chartjs-2";
import { FaUsers, FaShoppingCart, FaBars } from "react-icons/fa";
import { FiTrendingUp } from "react-icons/fi";
import { MdCategory, MdDashboard, MdInventory } from "react-icons/md";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend,
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

  const [isDrawerOpen, setDrawerOpen] = useState(false);

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
        const formatedId = Id.slice(0, 4);
        return <div>{formatedId}</div>;
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
    <Loader />;
  }

  return (
    <div className="flex h-screen bg-gray-100 dark:bg-gray-900">
      <div
        className={`fixed inset-0 bg-gray-300 dark:bg-gray-800 z-10 transform ${
          isDrawerOpen ? "translate-x-0" : "-translate-x-full"
        } transition-transform lg:relative lg:translate-x-0 lg:flex lg:flex-col w-64 p-4`}
      >
        <button
          className="absolute top-4 right-4 lg:hidden "
          onClick={() => setDrawerOpen(false)}
        >
          X
        </button>
        <div className="flex items-center mb-8 ">
          <MdDashboard className="text-4xl" />
          <h1 className="text-2xl ml-4">Admin Panel</h1>
        </div>
        <nav>
          <ul className="space-y-4">
            <li className=" flex items-center">
              <MdDashboard className="m-4" />
              <a href="/admin">Dashboard</a>
            </li>
            <li className=" flex items-center">
              <MdInventory className="m-4" />
              <a href="/admin/products">Products</a>
            </li>
            <li className=" flex items-center">
              <MdCategory className="m-4" />
              <a href="/admin/categories">Categories</a>
            </li>
            <li className=" flex items-center">
              <FaShoppingCart className="m-4" />
              <a href="/admin/orders">Orders</a>
            </li>
            <li className=" flex items-center">
              <FaUsers className="m-4" />
              <a href="/admin/users">Customers</a>
            </li>
          </ul>
        </nav>
      </div>

      <div className="flex-1 p-6">
        <div className="flex justify-between items-center mb-6">
          <h1 className="text-2xl font-bold">Admin Dashboard</h1>
          <button
            className="lg:hidden text-2xl"
            onClick={() => setDrawerOpen(!isDrawerOpen)}
          >
            <FaBars />
          </button>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-6">
          <div className="p-4 shadow rounded-lg flex items-center bg-white dark:bg-gray-800">
            <FiTrendingUp className="text-4xl text-blue-600 mr-4" />
            <div>
              <h2 className="text-xl font-bold">Total Sale</h2>
              <p>${orders.reduce((sum, o) => sum + o.OrderTotal, 0)}</p>
            </div>
          </div>
          <div className="p-4 shadow rounded-lg flex items-center bg-white dark:bg-gray-800">
            <FaShoppingCart className="text-4xl text-green-600 mr-4" />
            <div>
              <h2 className="text-xl font-bold">Total Orders</h2>
              <p>{orders.length}</p>
            </div>
          </div>
          <div className="p-4 shadow rounded-lg flex items-center bg-white dark:bg-gray-800">
            <FaUsers className="text-4xl text-purple-600 mr-4" />
            <div>
              <h2 className="text-xl font-bold">Top Customer</h2>
              <p>{topCustomers.length > 0 && topCustomers[0].Name}</p>
            </div>
          </div>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          <div className="p-6 shadow rounded-lg bg-white dark:bg-gray-800">
            <h2 className="text-xl font-semibold mb-4">Orders Overview</h2>
            <Bar data={orderData} />
          </div>
          <div className="p-6 shadow rounded-lg bg-white dark:bg-gray-800">
            <h2 className="text-xl font-semibold mb-4">Top Products</h2>
            <Bar data={productData} />
          </div>
        </div>
        <TableWrapper
          title="Top Customers"
          columns={userColumns}
          data={topCustomers}
        />
      </div>
    </div>
  );
};

export default AdminDashboard;
