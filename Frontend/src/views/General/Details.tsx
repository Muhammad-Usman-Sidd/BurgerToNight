import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useSelector, useDispatch } from "react-redux";
import { RootState, AppDispatch } from "../../app/store";
import { fetchProductById } from "../../app/Stores/ProductSlice";
import Button from "../../components/Generics/Button";
import { addToCart } from "../../app/Stores/OrderSlice";
import Loader from "../../components/Loading/Loader";
import { Link } from "react-router-dom";

const Details: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const dispatch = useDispatch<AppDispatch>();
  const { currentProduct, loading } = useSelector(
    (state: RootState) => state.product
  );
  const { role } = useSelector((state: RootState) => state.auth);
  const [quantity, setQuantity] = useState(1);

  useEffect(() => {
    if (id) {
      dispatch(fetchProductById(parseInt(id)));
    }
  }, [dispatch, id]);

  const handleAddToCart = () => {
    if (currentProduct) {
      dispatch(addToCart({ product: currentProduct, quantity }));
    }
  };

  if (!currentProduct || loading) {
    return <Loader />;
  }

  const increaseQuantity = () => setQuantity(quantity + 1);
  const decreaseQuantity = () => setQuantity(quantity > 1 ? quantity - 1 : 1);

  return (
    <div className="container mx-auto px-4 py-10">
      <div className="relative bg-gray-50 dark:bg-gray-900 shadow-xl rounded-xl overflow-hidden transition-all duration-500">
        <img
          src={currentProduct?.Image || ""}
          alt={currentProduct?.Name}
          className="w-full h-[400px] object-cover opacity-90 hover:opacity-100 transition-opacity duration-300"
        />
        <div className="absolute inset-0 bg-gradient-to-b from-transparent via-transparent to-black opacity-90 flex items-center justify-center">
          <h1 className="text-4xl font-bold text-white">
            {currentProduct?.Name}
          </h1>
        </div>
      </div>

      <div className="mt-10 bg-primary/5 dark:bg-gray-800 p-10 shadow-lg rounded-2xl space-y-8 transition-colors duration-300">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-10">
          <div className="relative">
            <img
              src={currentProduct?.Image || ""}
              alt={currentProduct?.Name}
              className="w-full h-[300px] md:h-[400px] object-cover rounded-lg shadow-lg"
            />
          </div>

          <div className="flex flex-col justify-between">
            <div>
              <h2 className="text-3xl font-bold mb-4">
                {currentProduct?.Name}
              </h2>
              <p className="text-gray-600 dark:text-gray-300 mb-3">
                {currentProduct?.Description}
              </p>
              <div className="text-gray-500 dark:text-gray-400 text-lg mb-1">
                <span className="font-bold">Category:</span>{" "}
                {currentProduct?.productCategory}
              </div>
              <div className="text-lg text-gray-500 dark:text-gray-400">
                Preparing Time: {currentProduct?.PreparingTime} mins
              </div>
              <div className="mt-5 flex items-center text-2xl font-semibold text-primary">
                <span className="text-black dark:text-white">Price: </span> $
                {currentProduct?.Price}
              </div>
            </div>

            <div className="mt-6">
              <h3 className="text-xl font-semibold mb-3">Quantity</h3>
              <div className="flex items-center gap-5">
                <button
                  onClick={decreaseQuantity}
                  className="bg-gray-300 dark:bg-gray-600 p-3 rounded-lg hover:bg-gray-400 dark:hover:bg-gray-700 transition-colors duration-300"
                >
                  -
                </button>
                <span className="text-xl font-medium">{quantity}</span>
                <button
                  onClick={increaseQuantity}
                  className="bg-gray-300 dark:bg-gray-600 p-3 rounded-lg hover:bg-gray-400 dark:hover:bg-gray-700 transition-colors duration-300"
                >
                  +
                </button>
              </div>
            </div>

            <div>
              {role === "admin" ? (
                <Link
                  to="/admin/products"
                  className="flex items-center bg-primary/60 justify-center w-full p-2 dark:bg-white/65 dark:text-black text-white font-semibold rounded-lg dark:hover:bg-white/35 transition-all duration-300"
                >
                  Manage
                </Link>
              ) : (
                <Button
                  variant="primary"
                  className="w-full rounded-none"
                  onClick={handleAddToCart}
                >
                  Add to Cart
                </Button>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Details;
