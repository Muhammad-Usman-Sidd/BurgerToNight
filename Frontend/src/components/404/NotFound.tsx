import React from "react";
import { Link } from "react-router-dom";
import Logo from "../../assets/product/logo.png";

const NotFound: React.FC = () => {
  return (
    <div className="flex flex-col items-center justify-center h-screen bg-gray-100 dark:bg-gray-900">
      <img src={Logo} alt="Logo" className="w-32 mb-5" />
      <h1 className="text-5xl font-bold text-gray-800 dark:text-white">404</h1>
      <p className="mt-4 text-lg text-gray-600 dark:text-gray-300">
        Oops! The page you're looking for doesn't exist.
      </p>
      <Link
        to="/"
        className="mt-6 px-6 py-2 bg-primary text-white rounded-md hover:bg-primary/80 transition duration-300"
      >
        Go Back to Home
      </Link>
      <Link
        to="/deals"
        className="mt-2 px-4 py-2 text-gray-800 dark:text-white hover:underline"
      >
        Check Out Our Deals
      </Link>
    </div>
  );
};

export default NotFound;
