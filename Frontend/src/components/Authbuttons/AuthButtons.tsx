import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { logout } from "../../app/Stores/AuthSlice";
import { AppDispatch } from "../../app/store";
import { FiSettings } from "react-icons/fi";
import Button from "../Generics/Button";
import { Modal } from "../Generics/Modal";

const AuthButtons: React.FC = () => {
  const [showLogoutModal, setShowLogoutModal] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const token = localStorage.getItem("JWT token");

  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();

  const handleLogout = () => {
    setShowLogoutModal(true);
    setDropdownOpen(false);
  };

  const toggleDropdown = () => {
    setDropdownOpen((prev) => !prev);
  };

  const confirmLogout = () => {
    dispatch(logout());
    setShowLogoutModal(false);
    navigate("/");
  };

  return (
    <div className="relative inline-block text-left">
      <Button
        onClick={toggleDropdown}
        variant="light"
        aria-haspopup="true"
        aria-expanded={dropdownOpen}
      >
        <FiSettings />
      </Button>

      {dropdownOpen && (
        <div className="absolute right-0 mt-2 w-48 bg-white dark:bg-gray-800 border border-gray-200 dark:border-gray-700 rounded-md shadow-lg z-10">
          <div className="py-1">
            {token ? (
              <>
                <button
                  onClick={handleLogout}
                  className="block w-full text-left px-4 py-2 text-red-600 hover:bg-red-500 hover:text-white transition duration-200"
                >
                  Logout
                </button>
                <Link
                  to="/auth/reset-password"
                  onClick={() => setDropdownOpen(false)}
                  className="block w-full text-left px-4 py-2 text-primary hover:bg-primary hover:text-white transition duration-200"
                >
                  Reset Password
                </Link>
              </>
            ) : (
              <>
                <Link
                  to="/auth/sign-in"
                  onClick={() => setDropdownOpen(false)}
                  className="block w-full text-left px-4 py-2 text-primary hover:bg-primary  hover:text-white transition duration-200"
                >
                  Sign In
                </Link>
                <Link
                  to="/auth/sign-up"
                  onClick={() => setDropdownOpen(false)}
                  className="block w-full text-left px-4 py-2 text-primary hover:bg-primary hover:text-white transition duration-200"
                >
                  Sign Up
                </Link>
              </>
            )}
          </div>
        </div>
      )}

      {showLogoutModal && (
        <Modal
          title="Confirm Logout"
          onClose={() => setShowLogoutModal(false)}
          btnTitle1="Confirm"
          onConfirm={confirmLogout}
        >
          <p>Are you sure you want to log out?</p>
        </Modal>
      )}
    </div>
  );
};

export default AuthButtons;
