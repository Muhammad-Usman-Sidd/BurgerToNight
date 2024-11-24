import React from "react";
import ProductList from "../../components/Products/ProductListing";
import { Link } from "react-router-dom";

const Product: React.FC = () => {
  return (
    <>
      <div className="mt-14 mb-12">
        <ProductList />
        <div className="flex justify-center">
          <Link
            to="/products"
            className="text-center w-52 mt-10 cursor-pointer bg-primary text-white py-1 px-5 rounded-md"
          >
            View All
          </Link>
        </div>
      </div>
    </>
  );
};

export default Product;
