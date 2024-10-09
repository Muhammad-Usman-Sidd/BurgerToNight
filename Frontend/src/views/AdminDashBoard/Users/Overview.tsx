import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../../app/store";
import { useEffect } from "react";
import { TableColumn } from "../../../components/Generics/MainTable";
import TableWrapper from "../../../components/Generics/TableWrapper";
import { fetchAllUsers } from "../../../app/Stores/AuthSlice";

const UserOverview: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { users } = useSelector((state: RootState) => state.auth);

  useEffect(() => {
    dispatch(fetchAllUsers());
  }, [dispatch]);

  const columns: TableColumn[] = [
    {
      label: "CustomerId",
      field: "Id",
      render: (Id: string) => {
        const formatedId = Id.slice(0, 4);
        return <div>{formatedId}</div>;
      },
    },
    {
      label: "Name",
      field: "UserName",
    },
    {
      label: "TotalOrders",
      field: "TotalOrders",
    },

    {
      label: "TotalAmountSpent",
      field: "TotalAmountSpent",
    },

    {
      label: "PhoneNumber",
      field: "PhoneNumber",
    },
    {
      label: "Address",
      field: "Address",
    },
  ];
  return (
    <div className="mt-10 mb-10">
      <TableWrapper title="Customers" columns={columns} data={users} />
    </div>
  );
};

export default UserOverview;
