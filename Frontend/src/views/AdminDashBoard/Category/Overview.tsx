import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  fetchCategories,
  setCurrentCategory,
} from "../../../app/Stores/CategorySlice";
import { RootState, AppDispatch } from "../../../app/store";
import TableWrapper from "../../../components/Generics/TableWrapper";
import { TableColumn } from "../../../components/Generics/MainTable";
import Form from "./Form";

const CategoryList: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { categories, currentCategory } = useSelector(
    (state: RootState) => state.category
  );
  const [showForm, setShowForm] = useState<boolean>(false);

  useEffect(() => {
    dispatch(fetchCategories());
  }, [dispatch]);

  const columns: TableColumn[] = [
    { label: "Icon", field: "Icon" },
    { label: "Category Name", field: "Name" },
    { label: "Description", field: "Description" },
  ];

  const handleCreateNew = () => {
    dispatch(setCurrentCategory(undefined));
    setShowForm(true);
  };

  const handleEditAction = (category: Record<string, any>) => {
    dispatch(setCurrentCategory(category));
    setShowForm(true);
  };
  return (
    <div className="mt-10 mb-10">
      <TableWrapper
        title="Categories"
        columns={columns}
        data={categories}
        hasCreateAction
        onCreateNew={handleCreateNew}
        onEditAction={handleEditAction}
      />
      {showForm && (
        <Form item={currentCategory} onClose={() => setShowForm(false)} />
      )}
    </div>
  );
};

export default CategoryList;
