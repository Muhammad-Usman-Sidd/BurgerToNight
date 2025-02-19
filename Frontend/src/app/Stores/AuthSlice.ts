import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import AuthService from "../../services/AuthService";
import {
  LoginDTO,
  ResetPasswordDTO,
  LoginResponseDTO,
  RegistrationRequestDTO,
  UserDTO,
} from "../../models/AuthDtos";
import { APIResponse } from "../../models/APIResult";
import { toast } from "react-toastify";

interface User {
  Id: string;
  Name?: string;
  PhoneNumber?: string;
  Address?: string;
}

interface AuthState {
  user: User;
  token: string;
  role: string;
  isLoggedIn: boolean;
  showDropdownButtons: boolean;
  topCustomers: UserDTO[];
  users: UserDTO[];
}

const initialState: AuthState = {
  user: { Id: localStorage.getItem("UserId") || "" },
  token: localStorage.getItem("JWT token") || "",
  role: localStorage.getItem("Role") || "",
  isLoggedIn: !!localStorage.getItem("JWT token"),
  showDropdownButtons: false,
  topCustomers: [],
  users: [],
};

export const login = createAsyncThunk(
  "auth/login",
  async (dto: LoginDTO, { rejectWithValue }) => {
    try {
      const response: APIResponse<LoginResponseDTO> = await AuthService.login(
        dto
      );
      if (response.IsSuccess) {
        localStorage.setItem("JWT token", response.Result.Token);
        localStorage.setItem("Role", response.Result.Role);
        localStorage.setItem("UserId", response.Result.User.Id);
        return response.Result;
      } else {
        throw new Error(response.ErrorMessages.join(", "));
      }
    } catch (error: any) {
      toast.error(`Login Error: ${error.message}`);
      return rejectWithValue(error.message);
    }
  }
);

export const logout = createAsyncThunk("auth/logout", async () => {
  try {
    localStorage.removeItem("JWT token");
    localStorage.removeItem("Role");
    localStorage.removeItem("UserId");
  } catch (error: any) {
    toast.error(`Logout Error: ${error.message}`);
    console.error(error);
  }
});

export const register = createAsyncThunk(
  "auth/register",
  async (dto: RegistrationRequestDTO, { rejectWithValue }) => {
    try {
      const response: APIResponse<UserDTO> = await AuthService.register(dto);
      if (response.IsSuccess) {
        toast.success("Registration successful!");
        return response.Result;
      } else {
        throw new Error(response.ErrorMessages.join(", "));
      }
    } catch (error: any) {
      toast.error(`Registration Error: ${error.message}`);
      return rejectWithValue(error.message);
    }
  }
);

export const resetPassword = createAsyncThunk(
  "auth/resetPassword",
  async (dto: ResetPasswordDTO, { rejectWithValue }) => {
    try {
      const response: APIResponse<ResetPasswordDTO> =
        await AuthService.resetPassword(dto);
      if (response.IsSuccess) {
        toast.success("Password reset successful!");
        return response.Result;
      } else {
        throw new Error(response.ErrorMessages.join(", "));
      }
    } catch (error: any) {
      toast.error(`Reset Password Error: ${error.message}`);
      return rejectWithValue(error.message);
    }
  }
);

export const fetchUserById = createAsyncThunk(
  "auth/fetchUserById",
  async (userId: string) => {
    if (userId !== "") {
      const response: APIResponse<UserDTO> = await AuthService.getUserById(
        userId
      );
      if (!response.IsSuccess) {
        throw new Error("Error fetching user details");
      }
      return response.Result;
    }
  }
);

export const fetchTopCustomers = createAsyncThunk(
  "auth/top-customers",
  async () => {
    try {
      const response: APIResponse<UserDTO[]> =
        await AuthService.getTopCustomers();
      console.log(response);
      if (!response.IsSuccess) {
        throw new Error("Error fetching Top Users");
      }
      return response.Result;
    } catch (error) {
      console.error(error);
    }
  }
);

export const fetchAllUsers = createAsyncThunk("auth/customers", async () => {
  try {
    const response: APIResponse<UserDTO[]> = await AuthService.getAllUsers();
    console.log(response);
    if (!response.IsSuccess) {
      throw new Error("Error fetching Users");
    }
    return response.Result;
  } catch (error) {
    toast.error(`Error:${error}`);
  }
});

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    toggleDropdownButtons: (state) => {
      state.showDropdownButtons = !state.showDropdownButtons;
    },
    initializeStore: (state) => {
      const token = localStorage.getItem("JWT token");
      const role = localStorage.getItem("Role");
      const userId = localStorage.getItem("UserId");
      if (token) {
        state.token = token;
        state.isLoggedIn = true;
        state.role = role || "";
        state.user.Id = userId || "";
      }
    },
  },
  extraReducers: (builder) => {
    builder.addCase(
      login.fulfilled,
      (state, action: PayloadAction<LoginResponseDTO>) => {
        const { Token, Role, User } = action.payload;
        state.isLoggedIn = true;
        state.token = Token;
        state.role = Role;
        state.user = User;
      }
    );
    builder.addCase(
      fetchUserById.fulfilled,
      (state, action: PayloadAction<any>) => {
        const { Id, Name, Address, PhoneNumber } = action.payload;
        state.user.Id = Id;
        state.user.Name = Name;
        state.user.Address = Address;
        state.user.PhoneNumber = PhoneNumber;
      }
    );
    builder.addCase(logout.fulfilled, (state) => {
      state.isLoggedIn = false;
      state.token = "";
      state.role = "";
      state.user = { Id: "" };
    });
    builder.addCase(fetchTopCustomers.fulfilled, (state, action) => {
      state.topCustomers = action.payload as any;
    });
    builder.addCase(fetchAllUsers.fulfilled, (state, action) => {
      state.users = action.payload as any;
    });
  },
});

export const { toggleDropdownButtons, initializeStore } = authSlice.actions;
export default authSlice.reducer;
