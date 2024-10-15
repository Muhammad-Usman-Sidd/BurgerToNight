import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import {
  checkout,
  readCurrentOrder,
  setCurrentOrder,
} from "../../app/Stores/OrderSlice";
import { OrderCreateDTO } from "../../models/OrderDtos";
import { useNavigate } from "react-router-dom";
import Input from "../Generics/Input";

const CheckoutPage: React.FC = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  const { currentOrder, cart } = useSelector((state: RootState) => state.order);
  const { user } = useSelector((state: RootState) => state.auth);

  const [orderDetails, setOrderDetails] = useState<OrderCreateDTO>({
    Name: currentOrder.Name,
    UserId: currentOrder.UserId,
    PhoneNumber: currentOrder.PhoneNumber || "",
    Address: currentOrder.Address || "",
    OrderTotal: currentOrder.OrderTotal,
    Items: currentOrder.Items,
  });

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setOrderDetails((prevDetails) => ({
      ...prevDetails,
      [name]: value,
    }));
  };

  dispatch(setCurrentOrder(currentOrder));

  const handleCheckout = async () => {
    try {
      dispatch(setCurrentOrder(orderDetails));
      console.log(currentOrder);
      await dispatch(checkout());
      dispatch(setCurrentOrder(undefined));
      navigate("/orders");
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    if (
      !currentOrder.Name ||
      !currentOrder.Address ||
      !currentOrder.PhoneNumber
    ) {
      setOrderDetails({
        Name: user.Name,
        PhoneNumber: user.PhoneNumber || "",
        Address: user.Address || "",
      });
    }
  }, [currentOrder, user]);

  useEffect(() => {
    if (cart.length !== currentOrder.Items.length) {
      dispatch(readCurrentOrder());
    }
  });
  return (
    <div className="container mx-auto p-6">
      <h2 className="text-2xl font-bold mb-6">Checkout</h2>
      <div className="bg-white shadow-md rounded-lg p-6 dark:bg-gray-800">
        <form>
          <div className="mb-4">
            <label className="block text-sm font-medium ">Full Name</label>
            <Input
              type="text"
              name="Name"
              placeholder="Enter Your Name..."
              value={orderDetails.Name}
              onChange={handleInputChange}
              className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm sm:text-sm"
            />
          </div>

          <div className="mb-4">
            <label className="block text-sm font-medium ">Phone Number</label>
            <Input
              type="text"
              name="PhoneNumber"
              placeholder="Enter Your Phone Number..."
              value={orderDetails.PhoneNumber}
              onChange={handleInputChange}
              className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm sm:text-sm"
            />
          </div>

          <div className="mb-4">
            <label className="block text-sm font-medium ">Address</label>
            <Input
              type="text"
              name="Address"
              placeholder="Enter Your Address..."
              value={orderDetails.Address}
              onChange={handleInputChange}
              className="mt-1 block w-full border border-gray-300 rounded-md shadow-sm sm:text-sm"
            />
          </div>

          <div className="mt-6 border-t border-gray-200 pt-4">
            <h3 className="text-lg font-medium mb-4">Order Summary</h3>
            <ul className="space-y-2">
              {currentOrder.Items.map((item, index) => (
                <li key={index} className="flex justify-between ">
                  <span>
                    {item.ProductName} (x{item.Quantity})
                  </span>
                  <span>${item.Price.toFixed(2)}</span>
                </li>
              ))}
            </ul>
            <div className="flex justify-between mt-4 font-bold">
              <span>Total:</span>
              <span>${currentOrder.OrderTotal.toFixed(2)}</span>
            </div>
          </div>

          <div className="mt-6">
            <button
              type="button"
              onClick={handleCheckout}
              className="w-full bg-green-600 text-white py-3 px-4 rounded-md shadow-sm hover:bg-green-700"
            >
              Place Order
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default CheckoutPage;
