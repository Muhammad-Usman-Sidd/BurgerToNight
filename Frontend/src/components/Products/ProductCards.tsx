import React from "react";
import { useDispatch } from "react-redux";
import { addToCart } from "../../app/Stores/OrderSlice";
import { AppDispatch } from "../../app/store";
import Button from "../Generics/Button";
import { ProductGetDTO } from "../../models/ProductDtos";
import { Link } from "react-router-dom";
import { setCurrentProduct } from "../../app/Stores/ProductSlice";

interface ProductCardProps {
  product: ProductGetDTO;
}

const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
  const dispatch = useDispatch<AppDispatch>();
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
      <Button
        onClick={handleAddToCart}
        variant="light"
        color="red"
        size="small"
      >
        Add To Cart
      </Button>
    </div>
  );
};

export default ProductCard;
