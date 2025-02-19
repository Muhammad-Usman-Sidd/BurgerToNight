import { useDispatch } from "react-redux";
import { AppDispatch } from "../../../app/store";
import { CategoryGetDTO } from "../../../models/CategoryDtos";
import { useNavigate } from "react-router-dom";
import React, { useEffect, useState } from "react";
import {
  createCategory,
  deleteCategory,
  fetchCategories,
  updateCategory,
} from "../../../app/Stores/CategorySlice";
import { Modal } from "../../../components/Generics/Modal";
import Input from "../../../components/Generics/Input";

interface FormProps {
  onClose: () => void;
  item: CategoryGetDTO;
}

const CategoryForm: React.FC<FormProps> = ({ onClose, item }) => {
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const [deletDailog, setDeleteDailog] = useState<boolean>(false);
  const [category, setCategory] = useState<CategoryGetDTO>({
    Id: 0,
    Name: "",
    Description: "",
    Icon: "",
  });

  useEffect(() => {
    dispatch(fetchCategories());
  }, [dispatch]);

  useEffect(() => {
    if (item) {
      setCategory({
        Id: item.Id,
        Name: item.Name || "",
        Description: item.Description || "",
        Icon: item.Icon || "",
      });
    }
  }, [item]);
  const handleDelete = () => {
    setDeleteDailog(true);
  };

  const deleteAsync = async () => {
    await dispatch(deleteCategory(category.Id));
    onClose();
    navigate("/admin/categories");
  };

  const handleSubmit = async (e?: React.FormEvent) => {
    e!.preventDefault();
    if (item) {
      await dispatch(updateCategory(category));
    } else {
      await dispatch(createCategory(category));
    }
    onClose();
    navigate("/admin/categories");
  };

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
    >
  ) => {
    const { name, value } = e.target;
    setCategory({
      ...category,
      [name]: value,
    });
  };

  const handleIconChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setCategory({ ...category, Icon: reader.result as string });
      };
      reader.readAsDataURL(file);
    }
  };

  return (
    <Modal
      title={item ? "Edit" : "Create"}
      btnTitle1={item ? "Update" : "Create"}
      onClose={onClose}
      showDeleteButton={item ? true : false}
      onDelete={handleDelete}
      onConfirm={handleSubmit}
    >
      <form className="bg-white dark:text-white  p-6 rounded-lg dark:bg-gray-900 ">
        <div className="mb-4">
          <label className="block">Name</label>
          <Input
            type="text"
            name="Name"
            placeholder="Category Name"
            value={category.Name}
            onChange={handleChange}
          />
        </div>
        <div className="mb-4">
          <label className="block">Description</label>
          <Input
            name="Description"
            placeholder="Product Description"
            value={category.Description}
            onChange={handleChange}
          />
        </div>
        <div className="mb-4">
          <label className="block">Icon</label>
          {category.Icon && (
            <div className="mb-2">
              <img
                className="h-32 object-cover rounded border"
                src={category.Icon}
                alt="Current Category"
              />
            </div>
          )}
          <input
            type="file"
            onChange={handleIconChange}
            className="w-full p-2 border rounded"
          />
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

export default CategoryForm;
