import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchProducts, setSearchQuery } from "../../app/Stores/ProductSlice";
import { RootState, AppDispatch } from "../../app/store";
import ProductCard from "./ProductCards";
import { useLocation } from "react-router-dom";
import { IoMdSearch } from "react-icons/io";
import { ProductGetDTO } from "../../models/ProductDtos";

const ProductListing: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { products, totalItems, pageSize, searchQuery } = useSelector(
    (state: RootState) => state.product
  );
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [filter, setFilter] = useState<string>(searchQuery);
  const location = useLocation();
  const [searchTimeout, setSearchTimeout] = useState<any | null>(null);

  const totalPages = Math.ceil(totalItems / pageSize);

  const nextPage = () => {
    if (currentPage < totalPages) {
      setCurrentPage((prevPage) => prevPage + 1);
    }
  };

  const prevPage = () => {
    if (currentPage > 1) {
      setCurrentPage((prevPage) => prevPage - 1);
    }
  };

  useEffect(() => {
    if (searchTimeout) {
      clearTimeout(searchTimeout);
    }
    if (location.pathname === "/") {
      setFilter("");
      dispatch(setSearchQuery(""));
    }

    const timeoutId = setTimeout(() => {
      dispatch(
        fetchProducts({
          pageIndex: currentPage,
          pageSize,
          searchQuery: filter,
        })
      );
    }, 300);

    setSearchTimeout(timeoutId);

    return () => {
      clearTimeout(timeoutId);
    };
  }, [filter, currentPage, dispatch, location.pathname]);

  return (
    <div className="mt-14 mb-12">
      <div className="container">
        <div className="text-center mb-10 max-w-[600px] mx-auto">
          <h1 className="text-center text-5xl font-bold m-5">Menu</h1>
          {location.pathname === "/products" && (
            <div className="sticky top-0 py-6 my-5">
              <div className="flex justify-center">
                <div className="relative group w-full sm:w-[400px] md:w-[500px]">
                  <input
                    type="text"
                    value={filter}
                    placeholder="Search ..."
                    onChange={(e) => setFilter(e.target.value)}
                    className="w-full transition-all duration-300 rounded-full border border-gray-300 px-5 py-3 focus:outline-none focus:border-primary focus:ring-2 focus:ring-primary text-gray-800 dark:border-gray-500 dark:bg-gray-800 dark:text-white"
                  />
                  <IoMdSearch className="text-gray-500 group-hover:text-primary absolute top-1/2 -translate-y-1/2 right-4 text-xl" />
                </div>
              </div>
            </div>
          )}
          <p className="text-xs text-gray-400">
            Lorem ipsum dolor sit amet consectetur, adipisicing elit. Sit
            asperiores modi.
          </p>
        </div>
        {products && products.length > 0 ? (
          <div>
            <div className="grid grid-cols-1 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 place-items-center gap-5">
              {products.map((product: ProductGetDTO) => (
                <ProductCard key={product.Id} product={product} />
              ))}
            </div>

            {location.pathname === "/products" && products.length > 0 && (
              <div className="flex justify-center mt-20 space-x-4">
                <button
                  onClick={prevPage}
                  disabled={currentPage <= 1}
                  className="px-4 py-2 bg-blue-300 text-primary rounded disabled:opacity-50"
                >
                  Previous
                </button>

                <span className="flex items-center">
                  Page {currentPage} of {totalPages}
                </span>

                <button
                  onClick={nextPage}
                  disabled={currentPage >= totalPages}
                  className="px-4 py-2 bg-primary text-primry rounded disabled:opacity-50"
                >
                  Next
                </button>
              </div>
            )}
          </div>
        ) : (
          <div className="text-center text-blue-500 text-2xl">
            No Items Found With Specified Key word {filter}
          </div>
        )}
      </div>
    </div>
  );
};

export default ProductListing;
