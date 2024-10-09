import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import {
  toggleSidebar,
  removeItem,
  readCurrentOrder,
} from "../../app/Stores/OrderSlice";
import { ProductGetDTO } from "../../models/ProductDtos";
import { FaX } from "react-icons/fa6";
import { BiTrash } from "react-icons/bi";
import { fetchUserById } from "../../app/Stores/AuthSlice";
import { useNavigate } from "react-router-dom";

const SidebarCart: React.FC = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  const state = useSelector((state: RootState) => state);
  const { cart, showSidebar } = state.order;

  const totalPrice = cart
    .reduce((total, item) => total + item.product.Price * item.quantity, 0)
    .toFixed(2);

  const handleToggleSidebar = () => {
    dispatch(toggleSidebar());
  };

  const handleRemoveFromCart = (product: ProductGetDTO) => {
    dispatch(removeItem(product));
  };

  const handleCheckout = async () => {
    await dispatch(readCurrentOrder());
    dispatch(toggleSidebar());
    navigate("/checkout");
  };

  useEffect(() => {
    if (state.auth.user.Id) {
      dispatch(fetchUserById(state.auth.user.Id));
    }
  }, [dispatch, state.auth.user]);
  return (
    <div
      className={`fixed inset-0 z-40 transition-transform duration-500 ease-in-out ${
        showSidebar ? "translate-x-0" : "translate-x-full"
      }`}
    >
      <div
        className="fixed inset-0 bg-black bg-opacity-50 transition-opacity"
        onClick={handleToggleSidebar}
      ></div>

      <div className="absolute right-0 top-0 h-full w-80 bg-white shadow-xl flex flex-col overflow-y-auto">
        <div className="p-4 flex justify-between items-center border-b border-gray-200">
          <h2 className="text-lg font-medium text-gray-900">Shopping Cart</h2>
          <button
            type="button"
            className="text-gray-400 hover:text-gray-600"
            onClick={handleToggleSidebar}
          >
            <FaX className="h-6 w-6" aria-hidden="true" />
          </button>
        </div>

        <div className="flex-1 p-4">
          {cart.length > 0 ? (
            <ul className="divide-y divide-gray-200">
              {cart.map((item, index) => (
                <li key={index} className="flex py-4">
                  <div className="w-24 h-24 flex-shrink-0 overflow-hidden rounded-md border border-gray-200">
                    <img
                      src={item.product.Image}
                      alt={item.product.Name}
                      className="h-full w-full object-cover object-center"
                    />
                  </div>
                  <div className="ml-4 flex-1">
                    <div className="flex justify-between text-base font-medium text-gray-900">
                      <h3>{item.product.Name}</h3>
                      <p>${(item.product.Price * item.quantity).toFixed(2)}</p>
                    </div>
                    <div className="flex justify-between items-end text-sm text-gray-500">
                      <p>Qty: {item.quantity}</p>
                      <button
                        type="button"
                        className="text-red-600 hover:text-red-800"
                        onClick={() => handleRemoveFromCart(item.product)}
                      >
                        <BiTrash className="h-5 w-5" aria-hidden="true" />
                        Remove
                      </button>
                    </div>
                  </div>
                </li>
              ))}
            </ul>
          ) : (
            <p className="text-gray-500 text-center">Your cart is empty.</p>
          )}
        </div>

        <div className="border-t border-gray-200 p-4">
          <div className="flex justify-between text-base font-medium text-gray-900">
            <p>Subtotal</p>
            <p>${totalPrice}</p>
          </div>
          <p className="mt-0.5 text-sm text-gray-500">
            Shipping and taxes calculated at checkout.
          </p>
          <div className="mt-6">
            <button
              className={`w-full flex items-center justify-center rounded-md border border-transparent bg-green-600 px-6 py-3 text-base font-medium text-white shadow-sm hover:bg-green-700 ${
                cart.length === 0 ? "opacity-50 cursor-not-allowed" : ""
              }`}
              disabled={cart.length === 0}
              onClick={handleCheckout}
            >
              Checkout
            </button>
          </div>
          <div className="mt-6 text-center">
            <button
              type="button"
              className="text-sm font-medium text-blue-600 hover:text-blue-800"
              onClick={handleToggleSidebar}
            >
              Continue Shopping &rarr;
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SidebarCart;
