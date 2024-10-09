import { configureStore } from "@reduxjs/toolkit";
import ProductSlice from "./Stores/ProductSlice";
import CategorySlice from "./Stores/CategorySlice";
import AuthSlice from "./Stores/AuthSlice";
import OrderSlice from "./Stores/OrderSlice";
export const store = configureStore({
  reducer: {
    product: ProductSlice,
    category: CategorySlice,
    auth: AuthSlice,
    order: OrderSlice,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
