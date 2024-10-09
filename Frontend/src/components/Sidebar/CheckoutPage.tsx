import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import { checkout, setCurrentOrder } from "../../app/Stores/OrderSlice";
import { OrderCreateDTO } from "../../models/OrderDtos";
import { useNavigate } from "react-router-dom";
import Input from "../Generics/Input";

const CheckoutPage: React.FC = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  const { currentOrder } = useSelector((state: RootState) => state.order);
  const { user, role } = useSelector((state: RootState) => state.auth);

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

  return <div className="container mx-auto p-6">{role === "customer"}</div>;
};

export default CheckoutPage;
