import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState, AppDispatch } from "../../../app/store";
import { fetchOrders, setCurrentOrder } from "../../../app/Stores/OrderSlice";
import TableWrapper from "../../../components/Generics/TableWrapper";
import { OrderDetailGetDTO } from "../../../models/OrderDetailDtos";
import { TableColumn } from "../../../components/Generics/MainTable";
import Form from "./Form";

const OrderOverview: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { orders, currentOrder } = useSelector(
    (state: RootState) => state.order
  );
  console.log(orders);
  const [showForm, setShowForm] = useState<boolean>(false);

  useEffect(() => {
    dispatch(fetchOrders());
  }, [dispatch]);
  const handleCreateNew = () => {
    dispatch(setCurrentOrder(undefined));
    setShowForm(true);
  };

  const handleEditAction = (order: Record<string, any>) => {
    dispatch(setCurrentOrder(order));
    setShowForm(true);
  };

  const columns: TableColumn[] = [
    { label: "Order No", field: "Id" },
    {
      label: "UserId",
      field: "UserId",
      render: (userId: string) => {
        const formatedId = userId.slice(0, 4);
        return <div>{formatedId}</div>;
      },
    },
    { label: "Customer Name", field: "Name" },
    { label: "Address", field: "Address" },
    { label: "PhoneNumber", field: "PhoneNumber" },
    { label: "Total Price", field: "OrderTotal" },
    {
      label: "Items",
      field: "Items",
      render: (items: OrderDetailGetDTO[]) => (
        <div>
          {items.map((item) => (
            <div key={item.Id}>
              {item.product.Name} - {item.Quantity}
            </div>
          ))}
        </div>
      ),
    },
    {
      label: "Order Date",
      field: "OrderDate",
      render: (orderDate: string) => {
        const date = new Date(orderDate).toLocaleDateString();
        const time = new Date(orderDate).toLocaleTimeString();
        return (
          <div>
            {date} - {time}
          </div>
        );
      },
    },
    { label: "Status", field: "OrderStatus" },
    { label: "Payment", field: "PaymentStatus" },
  ];

  return (
    <div className="mt-10 mb-10">
      <TableWrapper
        title="Orders"
        columns={columns}
        data={orders}
        hasCreateAction={false}
        onCreateNew={handleCreateNew}
        onEditAction={handleEditAction}
      />
      {showForm && (
        <Form item={currentOrder} onClose={() => setShowForm(false)} />
      )}
    </div>
  );
};

export default OrderOverview;
