import React, { useState, useEffect } from "react";
import { useDispatch } from "react-redux";
import { OrderUpdateDTO } from "../../../models/OrderDtos";
import { AppDispatch } from "../../../app/store";
import { useNavigate } from "react-router-dom";
import { deleteOrder, updateOrder } from "../../../app/Stores/OrderSlice";
import { Modal } from "../../../components/Generics/Modal";
import { OrderDetailGetDTO } from "../../../models/OrderDetailDtos";
import Input from "../../../components/Generics/Input";

interface FormProps {
  onClose: () => void;
  item: any;
}

const OrderForm: React.FC<FormProps> = ({ onClose, item }) => {
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const [deletDailog, setDeleteDailog] = useState<boolean>(false);
  const [order, setOrder] = useState<any>({
    Id: item?.Id || 0,
    UserId: item?.UserId || "",
    Name: item?.Name || "",
    OrderTotal: item?.OrderTotal || 0,
    PaymentStatus: item?.PaymentStatus || "",
    OrderStatus: item?.OrderStatus || "",
    PhoneNumber: item?.PhoneNumber || "",
    Address: item?.Address || "",
    Items: item?.Items || [],
  });

  useEffect(() => {
    if (item) {
      setOrder({
        Id: item.Id,
        UserId: item.UserId,
        Name: item.Name,
        OrderTotal: item.OrderTotal,
        PaymentStatus: item.PaymentStatus,
        OrderStatus: item.OrderStatus,
        PhoneNumber: item.PhoneNumber,
        Address: item.Address,
        Items: item.Items.map((orderItem: OrderDetailGetDTO) => ({
          ProductId: orderItem.product.Id,
          Quantity: orderItem.Quantity,
          Price: orderItem.product.Price,
        })),
      });
    }
  }, [item]);
  const handleDelete = () => {
    setDeleteDailog(true);
  };
  const deleteAsync = async () => {
    if (order.Id) {
      await dispatch(deleteOrder(order.Id));
      onClose();
      navigate("/admin/orders");
    }
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (item) {
      const updatedOrder: OrderUpdateDTO = {
        Id: order.Id,
        Name: order.Name,
        Address: order.Address,
        PhoneNumber: order.PhoneNumber,
        OrderStatus: order.OrderStatus,
        PaymentStatus: order.PaymentStatus,
      };
      await dispatch(updateOrder(updatedOrder));
    }
    onClose();
    navigate("/admin/orders");
  };

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
    >
  ) => {
    const { name, value } = e.target;
    setOrder({
      ...order,
      [name]: value,
    });
  };

  return (
    <Modal
      title="Edit Order"
      btnTitle1="Update"
      showDeleteButton={true}
      onDelete={handleDelete}
      onClose={onClose}
      onConfirm={handleSubmit}
    >
      <form className="bg-white dark:text-white  p-6 rounded-lg dark:bg-gray-900 ">
        <div className="mb-4">
          <label className="block ">Name</label>
          <Input
            type="text"
            name="Name"
            placeholder="Name"
            value={order.Name}
            onChange={handleChange}
            className="w-full p-2 border rounded"
          />
        </div>
        <div className="mb-4">
          <label className="block ">Address</label>
          <Input
            type="text"
            name="Address"
            placeholder="Address"
            value={order.Address}
            onChange={handleChange}
            className="w-full p-2 border rounded"
          />
        </div>
        <div className="mb-4">
          <label className="block ">Phone No</label>
          <Input
            type="text"
            name="PhoneNumber"
            placeholder="Phone number"
            value={order.PhoneNumber}
            onChange={handleChange}
            className="w-full p-2 border rounded"
          />
        </div>
        <div className="mb-4">
          <label className="block ">Payment Status</label>
          <select
            name="PaymentStatus"
            value={order.PaymentStatus}
            onChange={handleChange}
            className="w-full p-2 rounded dark:bg-gray-800"
          >
            <option value="" disabled>
              Select Payment Status
            </option>
            <option value="Pending">Pending</option>
            <option value="Verifying">Verifying Payment</option>
            <option value="Paid">Paid</option>
            <option value="Failed">Failed</option>
          </select>
        </div>

        <div className="mb-4">
          <label className="block ">Order Status</label>
          <select
            name="OrderStatus"
            value={order.OrderStatus}
            onChange={handleChange}
            className="w-full p-2 rounded dark:bg-gray-800"
          >
            <option value="" disabled>
              Select Order Status
            </option>
            <option value="Order Accepted">Order Accepted</option>
            <option value="Prepaing Order">Preparing Order</option>
            <option value="Out For Delivery">Out For Delivery</option>
            <option value="Delivered">Delivered</option>
          </select>
        </div>
      </form>
      {deletDailog && (
        <Modal
          title="Confirm Delete"
          onClose={() => setDeleteDailog(false)}
          btnTitle1="Confirm"
          onConfirm={deleteAsync}
        >
          <p>Are you sure you want to Delete this Item?</p>
        </Modal>
      )}
    </Modal>
  );
};

export default OrderForm;
