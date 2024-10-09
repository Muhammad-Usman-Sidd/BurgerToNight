import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchDeals } from "../../app/Stores/ProductSlice";
import { ProductGetDTO } from "../../models/ProductDtos";
import { AppDispatch, RootState } from "../../app/store";
import { fetchCategories } from "../../app/Stores/CategorySlice";
import Button from "../../components/Generics/Button";
import { addToCart } from "../../app/Stores/OrderSlice";
import { Link } from "react-router-dom";
import Loader from "../../components/Loading/Loader";

const Deals = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { deals, loading } = useSelector((state: RootState) => state.product);
  useEffect(() => {
    if (!deals.length) {
      dispatch(fetchDeals());
      dispatch(fetchCategories());
    }
  }, [dispatch]);

  const handleAddToCart = (deal: ProductGetDTO) => {
    dispatch(addToCart({ product: deal, quantity: 1 }));
  };
  if (loading) {
    return <Loader />;
  }
  return (
    <>
      <div data-aos="fade" className="container mt-14 mb-12">
        <h1 className="text-5xl font-bold text-center">On Going Deals</h1>
        {deals.length > 0 ? (
          <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6 mt-10">
            {deals?.map((deal: ProductGetDTO) => (
              <div
                key={deal.Id}
                className="p-5 bg-primary/40 rounded-lg shadow-lg"
              >
                <Link to={`${deal.Id}`}>
                  <img
                    src={deal.Image}
                    alt={deal.Name}
                    className="w-full h-[200px] object-cover rounded-md"
                  />
                  <h3 className="text-xl font-semibold mt-4">{deal.Name}</h3>
                  <p className="text-gray-500 mt-2">{deal.Description}</p>
                </Link>
                <Button
                  onClick={() => {
                    handleAddToCart(deal);
                  }}
                >
                  Grab Now
                </Button>
              </div>
            ))}
          </div>
        ) : (
          <div className="text-2xl translate-y-20 font-bold flex justify-center">
            No Deals At the moment
          </div>
        )}
      </div>
    </>
  );
};

export default Deals;
