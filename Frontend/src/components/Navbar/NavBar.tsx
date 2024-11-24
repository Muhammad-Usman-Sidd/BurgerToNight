import Logo from "../../assets/SupportingImages/logo.png";
import { FaBars, FaTimes } from "react-icons/fa";
import DarkMode from "./DarkMode";
import React, { useState } from "react";
import { Link } from "react-router-dom";
import AuthButtons from "../Authbuttons/AuthButtons";

interface LinkProps {
  id: number;
  name: string;
  link: string;
}

const Menu: LinkProps[] = [
  { id: 1, name: "Home", link: "/#" },
  { id: 2, name: "About", link: "/about-us" },
  { id: 3, name: "Deals", link: "/deals" },
  { id: 4, name: "Menu", link: "/products" },
  { id: 5, name: "Categories", link: "/categories" },
  { id: 6, name: "Contact", link: "/contact-us" },
];

const NavBar: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <div className="shadow-md bg-white dark:bg-gray-900 dark:text-white duration-200 relative z-40">
      <div className="bg-primary/40 py-2">
        <div className="container mx-auto flex justify-between items-center px-4">
          <div className="flex items-center">
            <DarkMode />
          </div>

          <div className="flex items-center">
            <Link
              to="/about-us"
              className="font-bold text-2xl flex gap-2 items-center"
            >
              <img src={Logo} alt="Logo" className="w-10" />
              <span>BurgerToNight</span>
            </Link>
          </div>

          <div className="hidden sm:block">
            <AuthButtons />
          </div>

          <button
            className="sm:hidden text-xl focus:outline-none"
            onClick={() => setIsOpen(!isOpen)}
          >
            {isOpen ? <FaTimes /> : <FaBars />}
          </button>
        </div>
      </div>

      <div
        className={`fixed inset-0 bg-black bg-opacity-50 transition-transform duration-500 ease-in-out ${
          isOpen ? "-translate-y-0" : "-translate-y-full"
        } sm:hidden z-40`}
      >
        <div className="absolute top-0 h-full/2 w-full bg-white dark:bg-gray-800 p-6 shadow-lg transition-transform duration-500 ease-in-out">
          <ul className="flex flex-col gap-6">
            {Menu.map((data) => (
              <li key={data.id}>
                <Link
                  to={data.link}
                  className="text-lg flex justify-center font-medium hover:text-primary transition duration-200"
                  onClick={() => setIsOpen(false)}
                >
                  {data.name}
                </Link>
              </li>
            ))}
            {localStorage.getItem("Role") === "admin" ? (
              <li>
                <Link
                  to="/admin"
                  className="text-lg flex justify-center font-medium hover:text-primary transition duration-200"
                  onClick={() => setIsOpen(false)}
                >
                  Admin
                </Link>
              </li>
            ) : (
              <li>
                <Link
                  to="/orders"
                  className="text-lg flex justify-center font-medium hover:text-primary transition duration-200"
                  onClick={() => setIsOpen(false)}
                >
                  Orders
                </Link>
              </li>
            )}
            <li>
              <AuthButtons />
            </li>
          </ul>
        </div>
      </div>

      <div className="hidden sm:flex justify-center py-2">
        <ul className="flex items-center gap-4">
          {Menu.map((data) => (
            <li key={data.id}>
              <Link
                to={data.link}
                className="inline-block px-4 hover:text-primary duration-200"
                onClick={() => setIsOpen(false)}
              >
                {data.name}
              </Link>
            </li>
          ))}
          {localStorage.getItem("Role") === "admin" ? (
            <li>
              <Link
                to="/admin"
                className="inline-block px-4 hover:text-primary duration-200"
                onClick={() => setIsOpen(false)}
              >
                Admin
              </Link>
            </li>
          ) : (
            <li>
              <Link
                to="/orders"
                className="inline-block px-4 hover:text-primary duration-200"
                onClick={() => setIsOpen(false)}
              >
                Orders
              </Link>
            </li>
          )}
        </ul>
      </div>
    </div>
  );
};

export default NavBar;
