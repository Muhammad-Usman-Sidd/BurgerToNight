import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import { fetchUserPastOrders } from "../../app/Stores/OrderSlice";
import Loader from "../../components/Loading/Loader";

const Order: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { auth, order } = useSelector((state: RootState) => state);

  useEffect(() => {
    if (auth.user.Id) {
      dispatch(fetchUserPastOrders());
    }
  }, [auth.user.Id, dispatch]);

  if (order.orderLoading) {
    return <Loader />;
  }
  return (
    <div className="container mt-14">
      <h1 className="text-5xl font-bold text-center">Your Orders</h1>

      {order.pastOrders.length === 0 ? (
        <p className="text-center text-xl mt-10">You have no past orders.</p>
      ) : (
        <div className="m-10 grid grid-cols-1 gap-6">
          {order.pastOrders.map((order) => (
            <div
              key={order.Id}
              className="flex flex-col sm:flex-row justify-between bg-primary/30 items-center p-4 rounded-lg shadow-lg"
            >
              <div className="flex flex-col items-start">
                <h3 className="text-xl font-semibold">
                  Order ID #{order.Id} ({order.Items.length}{" "}
                  {order.Items.length > 1 ? "items" : "item"})
                </h3>
                <ul className="list-disc text-primary ml-5 mt-2">
                  {order.Items.map((p, index) => (
                    <li key={index} className="dark:text-gray-400">
                      {p.product.Name} - Quantity: {p.Quantity}
                    </li>
                  ))}
                </ul>
                <p className="mt-2 text-black dark:text-primary text-xl">
                  Status: {order.OrderStatus}
                </p>
                <p className="text-black dark:text-gray-500">
                  Payment Status: {order.PaymentStatus}
                </p>
              </div>
              <div className="mt-4 sm:mt-0">
                <p className="text-lg font-bold text-right sm:text-left">
                  Total: ${order.OrderTotal.toFixed(2)}
                </p>
                <p className="text-sm dark:text-gray-400">
                  Order Date: {new Date(order.OrderDate).toLocaleDateString()}
                </p>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default Order;
