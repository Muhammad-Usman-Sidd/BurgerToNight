import React, { useState, useEffect } from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import {
  addProduct,
  deleteProduct,
  updateProduct,
} from "../../../app/Stores/ProductSlice";
import { AppDispatch } from "../../../app/store";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";
import Input from "../../../components/Generics/Input";
import { fetchCategories } from "../../../app/Stores/CategorySlice";
import { Modal } from "../../../components/Generics/Modal";
import {
  ProductCreateUpdateDTO,
  ProductGetDTO,
} from "../../../models/ProductDtos";

interface FormProps {
  onClose: () => void;
  item: ProductGetDTO;
}

const Form: React.FC<FormProps> = ({ onClose, item }) => {
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const [deletDailog, setDeleteDailog] = useState<boolean>(false);
  const [product, setProduct] = useState<ProductCreateUpdateDTO>({
    Id: 0,
    Name: "",
    Description: "",
    Price: 0,
    PreparingTime: "",
    CategoryId: 0,
    Image: "",
  });

  const categories = useSelector(
    (state: RootState) => state.category.categories
  );

  useEffect(() => {
    dispatch(fetchCategories());
  }, [dispatch]);

  useEffect(() => {
    if (item) {
      setProduct({
        Id: item.Id,
        Name: item.Name || "",
        Description: item.Description || "",
        Price: item.Price || 0,
        PreparingTime: item.PreparingTime || "",
        CategoryId: item.CategoryId || 0,
        Image: item.Image || "",
      });
    }
  }, [item]);
  const handleDelete = () => {
    setDeleteDailog(true);
  };
  const deleteAsync = async () => {
    if (product.Id) {
      await dispatch(deleteProduct(product.Id));
      onClose();
      navigate("/admin/products");
    }
  };
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (item) {
      await dispatch(updateProduct(product));
    } else {
      await dispatch(addProduct(product));
    }
    onClose();
    navigate("/admin/products");
  };

  const handleChange = (
    e: React.ChangeEvent<
      HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement
    >
  ) => {
    const { name, value } = e.target;
    setProduct({
      ...product,
      [name]: value,
    });
  };

  const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setProduct({ ...product, Image: reader.result as string });
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
          <label className="block ">Name</label>
          <Input
            type="text"
            name="Name"
            placeholder="Product Name"
            value={product.Name}
            onChange={handleChange}
          />
        </div>
        <div className="mb-4">
          <label className="block ">Description</label>
          <Input
            type="text"
            name="Description"
            placeholder="Product Description"
            value={product.Description}
            onChange={handleChange}
          />
        </div>
        <div className="mb-4">
          <label className="block ">Price</label>
          <Input
            type="number"
            name="Price"
            placeholder="Price"
            value={product.Price}
            onChange={handleChange}
          />
        </div>
        <div className="mb-4">
          <label className="block ">Preparing Time</label>
          <Input
            type="text"
            name="PreparingTime"
            placeholder="Preparing Time"
            value={product.PreparingTime}
            onChange={handleChange}
          />
        </div>
        <div className="mb-4">
          <label className="block ">Category</label>
          <select
            name="CategoryId"
            value={product.CategoryId}
            onChange={handleChange}
            className="w-full p-2 rounded dark:bg-gray-800"
          >
            <option value="" disabled>
              Select Category
            </option>
            {categories.map((category) => (
              <option key={category.Id} value={category.Id}>
                {category.Name}
              </option>
            ))}
          </select>
        </div>
        <div className="mb-4">
          <label className="block ">Image</label>
          {product.Image && (
            <div className="mb-2 flex justify-center">
              <img
                className="h-40 w-52 object-cover rounded border"
                src={product.Image}
                alt="Current Product"
              />
            </div>
          )}
          <input
            type="file"
            onChange={handleImageChange}
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

export default Form;
