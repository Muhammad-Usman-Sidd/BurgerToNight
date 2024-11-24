import React from "react";
import { FaShoppingCart, FaUsers } from "react-icons/fa";
import { MdCategory, MdDashboard, MdInventory } from "react-icons/md";
import { Link } from "react-router-dom";

const AdminNavSideBar: React.FC = () => {
  return (
    <div>
      <div className="flex items-center mb-8 p-4">
        <MdDashboard className="text-4xl" />
        <h1 className="text-2xl ml-4">Admin Panel</h1>
      </div>
      <nav className="space-y-4 p-4">
        <ul>
          <li className="flex items-center">
            <MdDashboard className="m-4" />
            <Link to="/admin">Dashboard</Link>
          </li>
          <li className="flex items-center">
            <MdInventory className="m-4" />
            <Link to="/admin/products">Products</Link>
          </li>
          <li className="flex items-center">
            <MdCategory className="m-4" />
            <Link to="/admin/categories">Categories</Link>
          </li>
          <li className="flex items-center">
            <FaShoppingCart className="m-4" />
            <Link to="/admin/orders">Orders</Link>
          </li>
          <li className="flex items-center">
            <FaUsers className="m-4" />
            <Link to="/admin/users">Customers</Link>
          </li>
        </ul>
      </nav>
    </div>
  );
};
export default AdminNavSideBar;
