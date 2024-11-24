import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { addToCart } from "../../app/Stores/OrderSlice";
import { AppDispatch, RootState } from "../../app/store";
import Button from "../Generics/Button";
import { ProductGetDTO } from "../../models/ProductDtos";
import { Link } from "react-router-dom";
import { setCurrentProduct } from "../../app/Stores/ProductSlice";

interface ProductCardProps {
  product: ProductGetDTO;
}

const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
  const dispatch = useDispatch<AppDispatch>();
  const { role } = useSelector((state: RootState) => state.auth);
  const handleAddToCart = () => {
    dispatch(addToCart({ product, quantity: 1 }));
  };
  const handleRedirect = () => {
    dispatch(setCurrentProduct(product));
  };
  return (
    <div data-aos="fade-out" className="flex flex-col space-y-3 items-center">
      <Link to={`/product/${product.Id}`} onClick={handleRedirect}>
        <img
          src={product.Image}
          alt={product.Name}
          className="h-[220px] w-[150px] object-cover rounded-md"
        />
        <div className="text-center">
          <h3 className="font-semibold">{product.Name}</h3>
          <p className="text-sm text-gray-500">${product.Price}</p>
        </div>
      </Link>
      {role === "admin" ? (
        <Link
          to="/admin/products"
          className="flex items-center justify-center w-[70%] p-1 mt-3 dark:bg-white/65 dark:text-black text-white font-semibold rounded-full bg-primary/90 dark:hover:bg-white/35 transition-all"
        >
          Manage
        </Link>
      ) : (
        <Button
          onClick={handleAddToCart}
          variant="light"
          color="red"
          size="small"
        >
          Add To Cart
        </Button>
      )}
    </div>
  );
};

export default ProductCard;
