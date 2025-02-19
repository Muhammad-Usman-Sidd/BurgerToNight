import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  fetchProducts,
  setCurrentProduct,
} from "../../../app/Stores/ProductSlice";
import { RootState, AppDispatch } from "../../../app/store";
import TableWrapper from "../../../components/Generics/TableWrapper";
import { TableColumn } from "../../../components/Generics/MainTable";
import Form from "./Form";

const ProductOverview: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { products, currentProduct, totalItems } = useSelector(
    (state: RootState) => state.product
  );
  const [showForm, setShowForm] = useState<boolean>(false);

  useEffect(() => {
    if (products.length < 12) {
      dispatch(
        fetchProducts({ pageIndex: 1, pageSize: totalItems, searchQuery: "" })
      );
    }
  }, [dispatch, totalItems, products.length]);

  const columns: TableColumn[] = [
    { label: "Image", field: "Image" },
    { label: "Product Name", field: "Name" },
    { label: "Description", field: "Description" },
    { label: "Category", field: "productCategory" },
    { label: "Preparing Time", field: "PreparingTime" },
    { label: "Price", field: "Price" },
  ];

  const handleCreateNew = () => {
    dispatch(setCurrentProduct(null));
    setShowForm(true);
  };

  const handleEditAction = (product: Record<string, any>) => {
    dispatch(setCurrentProduct(product as any));
    setShowForm(true);
  };

  return (
    <div className="mt-10 mb-10">
      <TableWrapper
        title="Products"
        columns={columns}
        data={products}
        hasCreateAction
        onCreateNew={handleCreateNew}
        onEditAction={handleEditAction}
      />

      {showForm && (
        <Form item={currentProduct} onClose={() => setShowForm(false)} />
      )}
    </div>
  );
};

export default ProductOverview;
