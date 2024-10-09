import React from "react";
import { useDispatch } from "react-redux";
import { toggleSidebar } from "../../app/Stores/OrderSlice";
import { BiCart } from "react-icons/bi";

const FloatingCartButton: React.FC = () => {
  const dispatch = useDispatch();

  const handleToggleSidebar = () => {
    dispatch(toggleSidebar());
  };

  return (
    <button
      onClick={handleToggleSidebar}
      className="fixed bottom-5 right-5 p-3 bg-blue-600 text-white rounded-full shadow-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50 z-30"
    >
      <BiCart className="h-6 w-6" aria-hidden="true" />
    </button>
  );
};

export default FloatingCartButton;
