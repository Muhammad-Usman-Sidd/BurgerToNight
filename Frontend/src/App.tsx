import React, { Children } from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import NavBar from "./components/Navbar/NavBar";
import AOS from "aos";
import "aos/dist/aos.css";
import Footer from "./components/Footer/Footer";
import Home from "./views/General/Home";
import Deals from "./views/General/Deals";
import AboutUs from "./views/General/AboutUs";
import Order from "./views/General/Order";
import ProductOverview from "./views/AdminDashBoard/Product/Overview";
import CategoryOverview from "./views/AdminDashBoard/Category/Overview";
import SignIn from "./views/General/Sign-In";
import SignUp from "./views/General/Sign-Up";
import { RootState } from "./app/store";
import { useSelector } from "react-redux";
import ProductListing from "./components/Products/ProductListing";
import NotFound from "./components/404/NotFound";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import CartSidebar from "./components/Sidebar/Sidebar";
import FloatingCartButton from "./components/Sidebar/CartButton";
import OrderOverview from "./views/AdminDashBoard/Order/Overview";
import ResetPassword from "./views/General/Reset-Password";
import Details from "./views/General/Details";
import CategoriesListing from "./views/General/Categories";
import CheckoutPage from "./components/Sidebar/CheckoutPage";
import ContactUs from "./views/General/ContactUs";
import AdminDashboard from "./views/AdminDashBoard/AdminDashBoard";
import UserOverview from "./views/AdminDashBoard/Users/Overview";

const App: React.FC = () => {
  const { token, role } = useSelector((state: RootState) => state.auth);

  React.useEffect(() => {
    AOS.init({
      offset: 100,
      duration: 800,
      easing: "ease-in-sine",
      delay: 100,
    });
    AOS.refresh();
  }, []);

  return (
    <Router>
      <div className="flex flex-col min-h-screen bg-white dark:bg-gray-900 dark:text-white duration-200">
        <NavBar />
        <main className="flex-grow">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/deals" element={<Deals />} />
            <Route path="/products" element={<ProductListing />} />
            <Route path="/categories" element={<CategoriesListing />} />
            <Route path="/about-us" element={<AboutUs />} />
            <Route path="/contact-us" element={<ContactUs />} />
            <Route path="/orders" element={token ? <Order /> : <SignIn />} />
            <Route
              path="/checkout"
              element={token ? <CheckoutPage /> : <SignIn />}
            />
            <Route
              path="/:item/:id"
              element={token ? <Details /> : <SignIn />}
            />
            <Route
              path="/auth/sign-in"
              element={token ? <Navigate to="/" replace /> : <SignIn />}
            />
            <Route
              path="/auth/sign-up"
              element={token ? <Navigate to="/" replace /> : <SignUp />}
            />
            <Route
              path="/auth/reset-password"
              element={token ? <ResetPassword /> : <SignUp />}
            />
            <Route
              path="/admin"
              element={
                token && role === "admin" ? <AdminDashboard /> : <SignIn />
              }
            />
            <Route
              path="/admin/products"
              element={
                token && role === "admin" ? <ProductOverview /> : <SignIn />
              }
            />
            <Route
              path="/admin/categories"
              element={
                token && role === "admin" ? <CategoryOverview /> : <SignIn />
              }
            />
            <Route
              path="/admin/orders"
              element={
                token && role === "admin" ? <OrderOverview /> : <SignIn />
              }
            />
            <Route
              path="/admin/users"
              element={
                token && role === "admin" ? <UserOverview /> : <SignIn />
              }
            />
            <Route path="*" element={<NotFound />} />
          </Routes>
        </main>
        <CartSidebar />
        <FloatingCartButton />
        <Footer />
        <ToastContainer
          position="top-right"
          autoClose={3000}
          hideProgressBar={false}
          newestOnTop={true}
          closeOnClick
          rtl={false}
          pauseOnFocusLoss
          draggable
          pauseOnHover
        />
      </div>
    </Router>
  );
};

export default App;
