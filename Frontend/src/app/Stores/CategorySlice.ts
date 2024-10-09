import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import CategoryService from "../../services/CategoryService";
import { APIResponse } from "../../models/APIResult";
import { toast } from "react-toastify";
import {
  CategoryCreateDTO,
  CategoryGetDTO,
  CategoryUpdateDTO,
} from "../../models/CategoryDtos";

interface CategoryState {
  categories: CategoryGetDTO[];
  currentCategory: any;
}

const initialState: CategoryState = {
  categories: [],
  currentCategory: {},
};

export const fetchCategories = createAsyncThunk("category/getAll", async () => {
  try {
    const response: APIResponse<CategoryGetDTO[]> =
      await CategoryService.getAllCategories();
    return response.Result || [];
  } catch (error) {
    toast.error(`Error fetching categories ${error}`);
    console.error(error);
    return [];
  }
});

export const createCategory = createAsyncThunk(
  "category/add",
  async (DTO: CategoryCreateDTO, { getState, dispatch, rejectWithValue }) => {
    const state = getState() as {
      auth: { isLoggedIn: boolean; role: string };
      categories: CategoryState;
    };
    if (state.auth.isLoggedIn && state.auth.role === "admin") {
      try {
        await CategoryService.createCategory(DTO);
        toast.success("Product added successfully");
        dispatch(fetchCategories());
      } catch (error: any) {
        toast.error("Error adding category");
        return rejectWithValue(error.message);
      }
    } else {
      toast.error("Please login to access this feature");
      return rejectWithValue("Not authorized");
    }
  }
);

export const deleteCategory = createAsyncThunk(
  "category/add",
  async (id: number, { getState }) => {
    const state = getState() as { auth: { isLoggedIn: boolean; role: string } };
    if (state.auth.isLoggedIn && state.auth.role === "admin") {
      try {
        await CategoryService.deleteCategory(id);
        toast.success("Category Deleted Succesfully!");
      } catch (error) {
        throw new Error(`Error fetching the ID ${error}`);
      }
    } else {
      throw new Error("Please login to axxess this feature");
    }
  }
);

export const updateCategory = createAsyncThunk(
  "categories/update",
  async (DTO: CategoryUpdateDTO, { getState, dispatch, rejectWithValue }) => {
    const state = getState() as {
      auth: { isLoggedIn: boolean; role: string };
      categories: CategoryState;
    };
    if (state.auth.isLoggedIn && state.auth.role === "admin") {
      try {
        await CategoryService.updateCategory(DTO);
        toast.success("Product updated successfully");
        dispatch(fetchCategories());
      } catch (error) {
        toast.error("Error updating product");
        return rejectWithValue(error.message);
      }
    } else {
      toast.error("You don't have access");
      return rejectWithValue("Not authorized");
    }
  }
);

const categorySlice = createSlice({
  name: "categories",
  initialState,
  reducers: {
    setCurrentCategory(state, action) {
      state.currentCategory = action.payload;
    },
    resetCurrentCategory(state) {
      state.currentCategory = {
        Name: "",
        Description: "",
        Icon: "",
        Id: null,
      };
    },
    handleIconUpload(state, action) {
      const { files } = action.payload;
      if (files && files.length) {
        const reader = new FileReader();
        reader.onloadend = () => {
          state.currentCategory.Icon = reader.result as string;
        };
        reader.readAsDataURL(files[0]);
      }
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchCategories.fulfilled, (state, action) => {
      state.categories = action.payload;
    });
  },
});

export const { setCurrentCategory, resetCurrentCategory, handleIconUpload } =
  categorySlice.actions;

export default categorySlice.reducer;
