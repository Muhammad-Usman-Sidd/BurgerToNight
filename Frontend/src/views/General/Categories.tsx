import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../app/store";
import { useEffect } from "react";
import { fetchCategories } from "../../app/Stores/CategorySlice";
import { fetchProducts, setSearchQuery } from "../../app/Stores/ProductSlice";
import { CategoryGetDTO } from "../../models/CategoryDtos";
import Button from "../../components/Generics/Button";
import { useNavigate } from "react-router-dom";

const CategoriesListing = () => {
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const { product, category } = useSelector((state: RootState) => state);
  const { pageIndex, pageSize, searchQuery } = product;
  useEffect(() => {
    dispatch(fetchCategories());
  }, [dispatch]);

  const redirectToProducts = (filterCategory: string) => {
    dispatch(setSearchQuery(filterCategory));
    dispatch(fetchProducts({ pageIndex, pageSize, searchQuery }));
    navigate("/products");
  };

  return (
    <>
      <div data-aos="fade" className="container mt-14 mb-12">
        <h1 className="text-5xl font-bold text-center">Categories</h1>
        {category.categories.length ? (
          <div className="grid grid-cols-1 sm:grid-cols-3 lg:grid-cols-4 gap-6 mt-10">
            {category.categories?.map((category: CategoryGetDTO) => (
              <div
                key={category.Id}
                className="p-5 bg-primary/40 rounded-lg shadow-lg"
              >
                <img
                  src={category.Icon}
                  alt={category.Name}
                  className="w-full h- object-cover rounded-md"
                />
                <h3 className="text-xl font-semibold mt-4">{category.Name}</h3>
                <p className="text-gray-500 mt-2">{category.Description}</p>
                <Button
                  onClick={() => {
                    redirectToProducts(category.Name);
                  }}
                >
                  View
                </Button>
              </div>
            ))}
          </div>
        ) : (
          <div
            className="flex justify-center
          p-10 translate-y-2/3 text-xl"
          >
            Backend Is Not Working
          </div>
        )}
      </div>
    </>
  );
};

export default CategoriesListing;
