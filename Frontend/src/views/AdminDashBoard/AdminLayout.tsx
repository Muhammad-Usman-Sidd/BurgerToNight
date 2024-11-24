import React from "react";
import { Outlet } from "react-router-dom";
import AdminNavSideBar from "./AdminNavSidebar";

const AdminLayout: React.FC = () => {
  return (
    <div className="flex min-h-screen bg-gray-100 dark:bg-gray-900 overflow-x-hidden">
      <div className="w-64 bg-gray-300 dark:bg-gray-800">
        <AdminNavSideBar />
      </div>

      <div className="flex-1 flex flex-col">
        <main className="p-4 flex-grow">
          <Outlet />
        </main>
      </div>
    </div>
  );
};

export default AdminLayout;
