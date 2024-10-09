import { FaStar } from "react-icons/fa";
import React, { useEffect } from "react";
import { addToCart } from "../../app/Stores/OrderSlice";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch } from "../../app/store";
import { ProductGetDTO } from "../../models/ProductDtos";
import { fetchTopProducts } from "../../app/Stores/ProductSlice";
import { RootState } from "../../app/store";
import Button from "../Generics/Button";
import { Link } from "react-router-dom";
import Loader from "../Loading/Loader";

const TopProducts: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { topProducts, loading } = useSelector(
    (state: RootState) => state.product
  );

  const addToCartFunction = (product: ProductGetDTO) => {
    dispatch(addToCart({ product, quantity: 1 }));
  };

  useEffect(() => {
    const topCount = 3;
    if (!topProducts.length) {
      dispatch(fetchTopProducts(topCount));
    }
  }, [dispatch]);
  if (loading) {
    <Loader />;
  }
  return (
    <div className="m-14">
      <div className="container">
        <div className="text-center mb-32  max-w-[600px] mx-auto">
          <h1 className="text-center text-5xl font-bold m-5">Best Sellers</h1>
          <p data-aos="fade-up" className="text-xs text-gray-400">
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Sit
            asperiores modi Sit asperiores modi
          </p>
        </div>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-20 md:gap-5 place-items-center">
          {topProducts.slice(0, 3).map((data: ProductGetDTO) => (
            <div
              key={data.Id}
              data-aos="zoom-in"
              className="rounded-2xl bg-white dark:bg-gray-800 hover:bg-primary dark:hover:bg-primary hover:text-white relative shadow-xl duration-300 group max-w-[300px]"
            >
              <Link to={`/product/${data.Id}`}>
                <div className="h-[180px] w-[180px] overflow mx-auto">
                  <img
                    src={data.Image}
                    alt={data.Name}
                    className="w-full h-full object-cover transform -translate-y-20 group-hover:scale-105 duration-300 drop-shadow-md"
                  />
                </div>

                <div className="p-4 text-center">
                  <div className="w-full flex items-center justify-center gap-1">
                    {[...Array(4)].map((_, index) => (
                      <FaStar key={index} className="text-yellow-500" />
                    ))}
                  </div>
                  <h1 className="text-xl font-bold">{data.Name}</h1>
                  <p className="text-gray-500 group-hover:text-white duration-300 text-sm line-clamp-2">
                    {data.Description}
                  </p>
                  <Button onClick={() => addToCartFunction(data)}>
                    Order Now
                  </Button>
                </div>
              </Link>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default TopProducts;
